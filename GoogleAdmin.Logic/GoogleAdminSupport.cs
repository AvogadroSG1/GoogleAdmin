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
        string ApplicationName = "Directory API .NET Quickstart";

        private UserCredential credential { get; set; }
        private DirectoryService service { get; set; }
        
        public GoogleAdminSupport(UserCredential credential)
        {
            this.credential = credential;
            this.service = this.CreateDirectoryService();
        }

        private DirectoryService CreateDirectoryService()
        {
            return new DirectoryService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
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
