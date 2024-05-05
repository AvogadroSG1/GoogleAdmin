using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using GoogleAdmin.Models;
using static GoogleAdmin.Models.GoogleAdminConstants;

namespace GoogleAdmin.Logic
{
    public class GmailSupport
    {
        private string ApplicationName;
        private bool DryRun;

        public GmailSupport(string applicationName, bool dryRun = false) => (ApplicationName, DryRun) = (applicationName, dryRun);

        private GmailService CreateGmailClient(ICredential googleCreds)
        {
            return new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = googleCreds,
                ApplicationName = ApplicationName,
            });
        }

        public async Task SetSignature(IEnumerable<GoogleUser> users, string Signature)
        {
            foreach (GoogleUser user in users)
            {
                var gmailService = this.CreateGmailClient(GoogleCredentialAuth.GetImpersonationServiceCredentials(user.PrimaryEmail));
                var signatureQuery = gmailService.Users.Settings.SendAs.List(user!.User!.Id);
                signatureQuery.Fields = "sendAs(isPrimary,sendAsEmail,signature)";

                var signatureResponse = await signatureQuery.ExecuteAsync();
                SendAs currentSendAs = signatureResponse.SendAs.SingleOrDefault(sa => sa!.IsPrimary ?? false)!;


                var newSignature = string.Format(
                    Signature,
                    user.User.Name.FullName,
                    (user.User?.Organizations != null ? user.User?.Organizations[0]?.Title : null) ?? string.Empty);

                currentSendAs.Signature = newSignature;

                if (!DryRun)
                {
                    currentSendAs = await gmailService.Users.Settings.SendAs.Patch(currentSendAs, user.User!.Id, currentSendAs.SendAsEmail).ExecuteAsync();
                }

                Console.WriteLine($"Updated {user.User?.Name.FullName} -- {(user?.User?.Organizations != null ? user.User.Organizations[0]?.Title : null) ?? string.Empty} -- Signature {user?.CostCenter} with  -- \r\n{newSignature}\r\n");
            }
        }

    }
}
