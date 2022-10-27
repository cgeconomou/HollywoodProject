using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product : HollywoodEntity
    {
        public int Id { get; set; }

        // [required]
        public string Onoma { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        //Foreing Key
        public int? ShopId { get; set; }

        //Navigation Properties
        public virtual Shop Shop { get; set; }
    }
}
