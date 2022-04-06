using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject4.Models
{
    public class PizzaIngredient : Ingredient
    {
        public ulong? PizzaId { get; set; }
        public ulong? IngredientId { get; set; }
        public new int Quantity { get; set; }
    }
}
