using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class MovieUserOrders
    {
        [Key]
        [Column(Order = 1)]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string UserId { get; set; }

        public DateTime OrderCompleted { get;set; }




    }
}
