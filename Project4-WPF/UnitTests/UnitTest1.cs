using System;
using WpfProject4.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Collections.ObjectModel;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();
       
        [TestMethod]
        public void Ingredient_Add5_Sum()
        {
            //Arrange
            
            Ingredient ingredient = _stonkspizzaDatabase.GetIngredientById(1);
            int oldamount = ingredient.Quantity;

            //Act
            ingredient.Add5();

            //Assert
            Assert.AreEqual(oldamount + 5, ingredient.Quantity, 0.001, "Gefaald, jammer");
        }
        [TestMethod]
        public void Orderitems_Sum()
        {
            //Arrange
            Order order = _stonkspizzaDatabase.GetOrderById(1);

            //Act
            double price = order.Price;

            //Assert
            Assert.AreEqual(6.5, price, 0.001, "Gefaald, jammer");
        }

        [TestMethod]
        public void Revokepizzapoints_Substract()
        {
            //Arrange
            Customer customer = _stonkspizzaDatabase.GetCustomerById(9);
            double pizzapoints = customer.PizzaPoints;

            //Act
            customer.RevokePizzaPoints();

            //Assert
            if (pizzapoints != 0)
            {
                Assert.AreEqual(pizzapoints - 10, customer.PizzaPoints, 0.001, "Gefaald, jammer");
            }
            else
            {
                Assert.AreEqual(0, customer.PizzaPoints, 0.001, "Gefaald, jammer");
            }
        }
        [TestMethod]
        public void CreateUnit()
        {
            //Arrange
            Unit addunit = new Unit() { Name = "Testunit" };
            ObservableCollection<Unit> ocUnitsBefore = _stonkspizzaDatabase.GetAllUnits();
            int ocUnitsCount = ocUnitsBefore.Count;

            //Act
            _stonkspizzaDatabase.AddUnit(addunit);

            //Assert
            ObservableCollection<Unit> ocUnitsAfter = _stonkspizzaDatabase.GetAllUnits();
            int ocUnitsCountAfter = ocUnitsAfter.Count;
            Assert.AreEqual(ocUnitsCount + 1, ocUnitsCountAfter, 0.001, "Gefaald, jammer");
        }

        [TestMethod]
        public void VerifyLoginUserRightPassword()
        {
            //Arrange
            User user = new User()
            {
                Password = "$2y$10$QiTtPeI/lzc0Ug/jbPfp3u8Q/R3EeqRzMKXS9qjqi5nVBdOjOUCFy",
            };


            //Act
            bool succes = user.VerifyLogin("password");

            //Act
            Assert.IsTrue(succes, "Verify login test gefaald!");

        }

        [TestMethod]
        public void VerifyLoginUserWrongPassword()
        {
            //Arrange
            User user = new User()
            {
                Password = "$2y$10$QiTtPeI/lzc0Ug/jbPfp3u8Q/R3EeqRzMKXS9qjqi5nVBdOjOUCFy",
            };


            //Act
            bool succes = user.VerifyLogin("verkeerdewachtwoord");

            //Act
            Assert.IsFalse(succes, "Verify login test gefaald!");

        }
    }
}
