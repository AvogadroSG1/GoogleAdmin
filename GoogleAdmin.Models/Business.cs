using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAdmin.Models
{
    public enum BusinessType
    {
        HP,
        AE
    }

    public record Business(string ApplicationName, string jsonFileName, string adminUserName, string signature);
}
