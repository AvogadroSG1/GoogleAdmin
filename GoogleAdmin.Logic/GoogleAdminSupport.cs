using Google.Apis.Auth.OAuth2;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using GoogleAdmin.Models;

namespace GoogleAdmin.Logic
{
    public class GoogleAdminSupport
    {
        string ApplicationName = "Hire Police Signatures";

        private DirectoryService service { get; set; }
        
        public GoogleAdminSupport(GoogleCredential googleCreds)
        {
            this.service = this.CreateDirectoryService(googleCreds);
        }

        public GoogleAdminSupport(UserCredential credential)
        {
            this.service = this.CreateDirectoryService(credential);
        }

        private DirectoryService CreateDirectoryService(GoogleCredential googleCreds)
        {
            return new DirectoryService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = googleCreds,
                ApplicationName = ApplicationName,
            });
        }

        private DirectoryService CreateDirectoryService(UserCredential uc)
        {
            return new DirectoryService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = uc,
                ApplicationName = ApplicationName,
            });
        }
        public async Task<List<GoogleUser>> GetUsers()
        { 
            // Define parameters of request.
            UsersResource.ListRequest request = service.Users.List();
            request.Customer = "my_customer";
            request.MaxResults = 50;
            request.OrderBy = UsersResource.ListRequest.OrderByEnum.Email;

            // List users.
            IList<User> users = (await request.ExecuteAsync()).UsersValue;

            List<GoogleUser> orgUsers = new List<GoogleUser>(10);

            if (users != null && users.Count > 0)
            {
                foreach (var userItem in users)
                {
                    orgUsers.Add(
                        new GoogleUser()
                        {
                            User = userItem,
                            PrimaryEmail = userItem.PrimaryEmail
                        });
                }
            }

            return orgUsers;

        }


    }
}
