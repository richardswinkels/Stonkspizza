using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject4.Models
{
    public class IngredientOrderitem
    {
        public ulong Id { get; set; }
        public ulong IngredientId { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public ulong Quantity { get; set; }
        public ulong QuantityIngredient { get; set; }

        public string Unit { get; set; }
    }
}
