using System;
using Google.Apis.Admin.Directory.directory_v1.Data;
using static GoogleAdmin.Models.GoogleAdminConstants;

namespace GoogleAdmin.Models;
public record GoogleUser(User User, string PrimaryEmail, CostCenter CostCenter);

