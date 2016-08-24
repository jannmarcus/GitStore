using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Entities
{
    public class Cartline
    {
        public Product Products { get; set; }
        public int Quantity { get; set; }
    }
}
