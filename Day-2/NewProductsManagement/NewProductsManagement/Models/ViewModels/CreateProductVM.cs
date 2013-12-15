using NewProductsManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewProductsManagement.Models.ViewModels
{
    public class CreateProductVM
    {
       
        public List<Product> Products { get; set; }
        
        public Product Product { get; set; }
    }
}