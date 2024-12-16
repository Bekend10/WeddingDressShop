using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_WeddingDressShop.Models
{
    public class PRODUCT
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public PRODUCT()
        {
            
        }

        public PRODUCT(string name, string description, float price, int stockQuantity, string imageUrl, DateTime createdDate, int categoryID, string categoryName)
        {
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
            ImageUrl = imageUrl;
            CreatedDate = createdDate;
            CategoryID = categoryID;
            CategoryName = categoryName;
        }
    }
}