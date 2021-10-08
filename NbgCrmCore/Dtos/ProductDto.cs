using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InventoryQuantity { get; set; }

        public string ColorDescription { get; set; }

        public DateTime BuyDate { get; set; }

        public string ImageFilename { get; set; }
    }
}
