using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Model
{
    public class Basket
    {
        public int BasketId { get; set; }
        public    User User { get; set; }
        public    DateTime DateTime  { get; set; }
         public   Status Status { get; set; }
         public   decimal TotalAmount { get; set; }
          public virtual List<BasketItem> BasketItems{ get; set; }
    }
}
