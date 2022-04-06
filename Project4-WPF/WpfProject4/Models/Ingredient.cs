using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfProject4.Models
{
    public class Ingredient
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        public ulong? Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public ulong? UnitId { get; set; }

        public void Add1()
        {
            Quantity = Quantity + 1;
            _stonkspizzaDatabase.UpdateIngredient(this);
        }
        public void Add2()
        {
            Quantity = Quantity + 2;
            _stonkspizzaDatabase.UpdateIngredient(this);
        }
        public void Add5()
        {
            Quantity = Quantity + 5;
            _stonkspizzaDatabase.UpdateIngredient(this);
        }
        public void Add10()
        {
            Quantity = Quantity + 10;
            _stonkspizzaDatabase.UpdateIngredient(this);
        }
    }
}
