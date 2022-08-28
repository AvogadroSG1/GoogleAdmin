using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using GoogleAdmin.Models;
using static GoogleAdmin.Models.GoogleAdminConstants;

namespace GoogleAdmin.Logic
{
    public static class GoogleCredentialAuth
    {
        static readonly string[] Scopes =
        {
            DirectoryService.Scope.AdminDirectoryUserReadonly,
            GmailService.Scope.GmailModify,
            GmailService.Scope.GmailSettingsBasic,
            GmailService.Scope.GmailCompose,
            GmailService.Scope.MailGoogleCom
        };

        private static GoogleCredential? CurrentCredentials = null;

        public async static Task<GoogleCredential?> ReadClientJson(string fileName, CancellationToken cancellationToken = default)
        {
            var decodedCreds = await GoogleCredential.FromFileAsync(fileName, CancellationToken.None);
            return CurrentCredentials = decodedCreds.CreateScoped(Scopes);
        }
        public static GoogleCredential GetAdminServiceCredentials(string adminName) => GetImpersonationServiceCredentials(adminName);

        public static GoogleCredential GetImpersonationServiceCredentials(string user) => CurrentCredentials!.CreateWithUser(user);
    }
}
