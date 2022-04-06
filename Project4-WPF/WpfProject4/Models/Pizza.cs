using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject4.Models
{
    public class Pizza
    {
        public ulong? Id { get; set; }
        public string Name { get; set; }
        public bool IsCustom { get; set; }
        public ulong? UserId { get; set; }
    }
}
