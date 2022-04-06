using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject4.Models
{
    public class Employee : Person
    {
        #region properties
        public string PersonalEmail { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bsn { get; set; }
        #endregion
    }
}
