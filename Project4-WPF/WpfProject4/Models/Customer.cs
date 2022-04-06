using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject4.Models
{
    public class Customer : Person
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        #region properties
        public int PizzaPoints { get; set; }
        #endregion

        public void RevokePizzaPoints()
        {
            if (this.PizzaPoints != 0)
            {
                this.PizzaPoints -= 10;
                _stonkspizzaDatabase.UpdateCustomer(this);
            }
        }
    }
}
