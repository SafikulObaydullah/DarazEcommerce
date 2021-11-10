using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystem.ViewModel
{
    public class ProductVM
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        public string VideoPath { get; set; }
        public string Feature { get; set; }
        public string Description { get; set; }
        public string Warranty { get; set; }
        public decimal Price { get; set; }
        public string FeaturedPic { get; set; }
     
        public string CategoryName { get; set; }
      
        public string BrandName { get; set; }
       
        public string ModelName { get; set; }
        
        public string OriginName { get; set; }
    }
}