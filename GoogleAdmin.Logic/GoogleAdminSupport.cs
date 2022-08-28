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
using System.Linq;

namespace GoogleAdmin.Logic;

public class GoogleAdminSupport
{
    private readonly DirectoryService service;

    public GoogleAdminSupport(ICredential googleCreds, string applicationName) =>
        service =
            new DirectoryService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = googleCreds,
                ApplicationName = applicationName,
            });

    public async Task<IEnumerable<GoogleUser>> GetUsers()
    {
        // Define parameters of request.
        UsersResource.ListRequest request = service.Users.List();
        request.Customer = "my_customer";
        request.MaxResults = 50;
        request.OrderBy = UsersResource.ListRequest.OrderByEnum.Email;

        // List users.
        IList<User> users = (await request.ExecuteAsync()).UsersValue;

        return users?.Select(userItem =>
            new GoogleUser(userItem, userItem.PrimaryEmail, userItem.Organizations?.Any(o => o.CostCenter == "1") ?? false))
            ?? new List<GoogleUser>();
    }


}

