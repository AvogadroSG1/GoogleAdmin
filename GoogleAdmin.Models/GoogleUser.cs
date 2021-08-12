using System;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace GoogleAdmin.Models
{
    public class GoogleUser
    {
        public User User { get; set; }
        public string PrimaryEmail { get; set; }
    }
}
