using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kalyani1.Models
{
    public class ProductIndexModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsOrdered { get; set; }
    }
}