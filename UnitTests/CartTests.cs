using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            Cart target = new Cart();
            
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);

            CartLine[] results = target.Lines.ToArray();

            Assert.AreEqual(2, results.Length);
            Assert.AreEqual(p1, results[0].Product);
            Assert.AreEqual(p2, results[1].Product);
        }
        [TestMethod]
        public void Can_Add_Quntity_For_Existing_Product()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p1, 10);

            CartLine[] results = target.Lines.OrderBy(l => l.Product.ProductID).ToArray();

            Assert.AreEqual(2, results.Length);
            Assert.AreEqual(11, results[0].Qunatity);
            Assert.AreEqual(3, results[1].Qunatity);
        }
        [TestMethod]
        public void Can_Remove_Line()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };

            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);

            target.RemoveLine(p2);

            Assert.AreEqual(0, target.Lines.Where(l => l.Product == p2).Count());
            Assert.AreEqual(2, target.Lines.Count());
        }
        [TestMethod]
        public void Calculate_Cart_Total()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);

            decimal result = target.ComputeTotalValue();

            Assert.AreEqual(450M, result);
        }
        [TestMethod]
        public void Can_Clear_Cart()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);

            target.Clear();

            Assert.AreEqual(0, target.Lines.Count());
        }
    }

    
}
