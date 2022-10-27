using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalApp.Areas.Admin.DTos
{
    public class ProductDto
    {
        public int Id { get; set; }
       // [required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public object Shop { get; set; }
    }
}