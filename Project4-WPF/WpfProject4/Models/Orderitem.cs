using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject4.Models
{
    public class Orderitem
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        public ulong? Id { get; set; }
        public string PizzaName { get; set; }
        public string SizeName { get; set; }
        public float PriceFactor { get; set; }

        public double Price
        {
            get {
                double calculatedprice = 0;
                ObservableCollection<IngredientOrderitem> ingredientOrderitems =_stonkspizzaDatabase.GetOrderitemIngredientsByOrderitem(this);
                foreach (IngredientOrderitem ingredientOrderitem in ingredientOrderitems)
                {
                    calculatedprice += ingredientOrderitem.Price * ingredientOrderitem.Quantity * this.PriceFactor;
                }
                
                return calculatedprice; 
            }
        }


    }
}
