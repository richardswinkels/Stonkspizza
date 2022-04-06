using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject4.Models
{
    public class UserRole : Role
    {
        #region properties
        public ulong UserId { get; set; }
        public ulong RoleId { get; set; }
        #endregion
    }
}
