using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int qunatity)
        {
            CartLine cartLine = lineCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            
            if (cartLine == null)
            {
                lineCollection.Add(new CartLine { Product = product, Qunatity = qunatity });
            }
            else
            {
                cartLine.Qunatity += qunatity;
            }
            
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(l => l.Product.Price * l.Qunatity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines { get { return lineCollection; } }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Qunatity { get; set; }
    }
}
