using NbgCrmCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbgMvc.Models
{
    public class ProductsPage
    {


        public List<Product> Products { get; set; }
        public int PageCount { get; set; }
        public int PageNext { get; set; }
        public int PagePrevious { get; set; }
    }
}
