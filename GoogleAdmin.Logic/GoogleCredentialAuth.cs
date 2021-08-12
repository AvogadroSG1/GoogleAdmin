using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Util.Store;

namespace GoogleAdmin.Logic
{
    public class GoogleCredentialAuth
    {
        public GoogleCredentialAuth()
        {
        }

        string[] Scopes = { DirectoryService.Scope.AdminDirectoryUserReadonly, GmailService.Scope.GmailSettingsBasic, GmailService.Scope.GmailCompose, GmailService.Scope.MailGoogleCom };

        public async Task<UserCredential> GetCredentials()
        {
            UserCredential credentials;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credentials = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    (await GoogleClientSecrets.FromStreamAsync(stream)).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            return credentials;
        }
    }
}
