using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject4.Models
{
    public class Ordertransaction
    {
        public ulong Id { get; set; }
        public ulong OrderId { get; set; }
        public ulong UserId { get; set; }
        public ulong StatusId { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
