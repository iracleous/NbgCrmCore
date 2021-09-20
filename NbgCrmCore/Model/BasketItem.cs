using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Model
{
    public class BasketItem
    {
        public int BasketItemId { get; set; }
        public  int  Quantity { get; set; }
        public   decimal  Discount { get; set; }
        public virtual Basket  Basket { get; set; }
        public virtual Product  Product { get; set; }
        
    }
}
