using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using GoogleAdmin.Models;

namespace GoogleAdmin.Logic
{
    public class GmailSupport
    {
        private string ApplicationName;

        public GmailSupport(string applicationName) => (ApplicationName) = (applicationName);

        private GmailService CreateGmailClient(ICredential googleCreds)
        {
            return new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = googleCreds,
                ApplicationName = ApplicationName,
            });
        }

        public async Task SetSignature(IEnumerable<GoogleUser> users, (string signature, string adminSignature) signatureInfo)
        {
            foreach (GoogleUser user in users.Where(u => u.PrimaryEmail.Contains("admin")))
            {
                var gmailService = this.CreateGmailClient(GoogleCredentialAuth.GetImpersonationServiceCredentials(user.PrimaryEmail));
                var signatureQuery = gmailService.Users.Settings.SendAs.List(user!.User!.Id);
                signatureQuery.Fields = "sendAs(isPrimary,sendAsEmail,signature)";

                var signatureResponse = await signatureQuery.ExecuteAsync();
                SendAs currentSendAs = signatureResponse.SendAs.SingleOrDefault(sa => sa!.IsPrimary ?? false)!;

                currentSendAs.Signature = user.UseAlternateSignature ?
                    string.Format(signatureInfo.adminSignature, user.User.Name.FullName, (user.User?.Organizations != null ? user.User?.Organizations[0]?.Title : null) ?? string.Empty)
                    : string.Format(signatureInfo.signature, user.User.Name.FullName, (user.User?.Organizations != null ? user.User?.Organizations[0]?.Title : null) ?? string.Empty);

                currentSendAs = await gmailService.Users.Settings.SendAs.Patch(currentSendAs, user.User!.Id, currentSendAs.SendAsEmail).ExecuteAsync();

                Console.WriteLine($"Updated {user.User.Name.FullName} -- {(user.User?.Organizations != null ? user.User.Organizations[0]?.Title : null) ?? string.Empty}");
            }
        }

    }
}
