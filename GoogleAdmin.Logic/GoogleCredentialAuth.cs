using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using static GoogleAdmin.Models.GoogleAdminConstants;
using System.Collections.Immutable;
using System.Collections.Generic;

namespace GoogleAdmin.Logic
{
    public class GoogleCredentialAuth
    {
        static readonly string[] Scopes = { DirectoryService.Scope.AdminDirectoryUserReadonly, GmailService.Scope.GmailModify, GmailService.Scope.GmailSettingsBasic, GmailService.Scope.GmailCompose, GmailService.Scope.MailGoogleCom };

        private static readonly ImmutableDictionary<Business, (string fileName, string adminUserName)> googleSecurityInfo
            = new Dictionary<Business, (string fileName, string adminUserName)>
            {
                { Business.HP, ("hirepoliceSA.json", "admin@hirepolice.com") },
                { Business.AE,  ("armedEnforcementSA.json", "admin@armedenforcement.com") }
            }.ToImmutableDictionary();

        private static GoogleCredential? CurrentCredentials = null;
        private static string AdminName = string.Empty;
        private static string FileName = string.Empty;

        public async static void SetDefaults(Business business)
        {
            (AdminName, FileName) = googleSecurityInfo[business];
            
            var decodedCreds = await GoogleCredential.FromFileAsync(FileName, CancellationToken.None);
            CurrentCredentials = decodedCreds.CreateScoped(Scopes);
        }
        public static GoogleCredential GetAdminServiceCredentials() => GetImpersonationServiceCredentials(AdminName);

        public static GoogleCredential GetImpersonationServiceCredentials(string user) => CurrentCredentials!.CreateWithUser(user);
    }
}
