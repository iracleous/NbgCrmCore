using Microsoft.AspNetCore.Http;
using NbgCrmCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbgMvc.Models
{
    public class ProductWithImage
    {
        public Product Product { get; set; }
        public IFormFile ProductImage { set; get; }

    }
}
