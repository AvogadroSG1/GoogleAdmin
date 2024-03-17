using System.Collections.Immutable;
using static GoogleAdmin.Models.GoogleAdminConstants;

namespace GoogleAdmin.Models
{
    public enum BusinessType
    {
        HP,
        AE
    }

    public record Business(string ApplicationName, string JsonFileName, string AdminUserName, string Signature = default);
}
