using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OnlineShoppingStore.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter the name of the product")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter the description of the product")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter the price of the product")]
        [Range(0.01, double.MaxValue, ErrorMessage ="Please enter a positive price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please enter the category of the product")]
        public string Category { get; set; }
    }
}
