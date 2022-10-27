using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Entities
{
    public class Photo : HollywoodEntity
    {
        public int PhotoId { get; set; }
        [Display(Name = "Photo URL")]
        public string Url { get; set; }

        //Navigation Properties
        public virtual Actor Actor { get; set; }
    }
}
