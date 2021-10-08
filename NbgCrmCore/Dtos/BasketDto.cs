using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Dtos
{
    public class BasketDto
    {

        public int? BasketId { get; set; }
        public decimal? TotalAmount { get; set; }
        public string StatusDescription { get; set; }
        public DateTime DateTime { get; set; }

        public int? UserId { get; set; }
        public string UserName { get; set; }
        public List<ProductDto> Products { get; set; }

    }
}
