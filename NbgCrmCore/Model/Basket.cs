using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Model
{
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }
        public   decimal TotalAmount { get; set; }
        public   Status Status { get; set; }
        public    DateTime DateTime  { get; set; }

        public virtual User User { get; set; }
       
         public virtual List<BasketItem> BasketItems{ get; set; }
    }
}
