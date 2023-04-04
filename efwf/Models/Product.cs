using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBSD_CW2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool OnSale { get; set; }
        public DateTime? ExpirationDate{ get; set; }
        public int CategoryId { get; set; }
        public IFormFile ImageData { get; set; }
    }
}
