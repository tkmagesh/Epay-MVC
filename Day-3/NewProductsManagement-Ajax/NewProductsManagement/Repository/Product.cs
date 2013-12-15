using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewProductsManagement.Repository
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public int Units { get; set; }

        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }

    public class Category {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

    }

    public class ProductsManagementContext : DbContext {
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Category> Categories { get; set; }
    }




}