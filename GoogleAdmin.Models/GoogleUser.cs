using System;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace GoogleAdmin.Models;
public record GoogleUser(User User, string PrimaryEmail, bool UseAlternateSignature);

