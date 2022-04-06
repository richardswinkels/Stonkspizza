using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject4.Models
{
    public abstract class Person
    {
        #region properties
        public ulong? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        #endregion
    }
}
