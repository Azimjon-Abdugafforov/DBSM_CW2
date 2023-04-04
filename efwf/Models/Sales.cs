using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBSD_CW2.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public Array Products { get; set; }
        public string PaymentType { get; set; }
        public decimal Cost { get; set; }
    }
}
