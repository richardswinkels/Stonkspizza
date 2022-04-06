using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject4.Models
{
    public class Bike
    {
        public ulong? Id { get; set; }
        public ulong BrandId { get; set; }
        public ulong ModelId { get; set; }
        public ulong EmployeeId { get; set; }
    }
}
