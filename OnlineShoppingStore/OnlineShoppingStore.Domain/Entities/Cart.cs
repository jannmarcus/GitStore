using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Entities
{
    public class Cart
    {
        private List<Cartline> lineCollection = new List<Cartline>();

        public void AddItem(Product product, int quantity)
        {
            Cartline line = lineCollection.Where(p => p.Products.ProductID == product.ProductID)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new Cartline { Products = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(p => p.Products.ProductID == product.ProductID);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(p => p.Products.Price * p.Quantity);
        }
        public IEnumerable<Cartline> Lines
        {
            get { return lineCollection; }
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }
}
