using NbgCrmCore.Model;
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

        public BasketDto() { }

        public BasketDto(Basket basket)
        {

            if (basket != null)
            {

                BasketId = basket.BasketId;
                TotalAmount = basket.TotalAmount;
                StatusDescription = basket.Status.ToString();
                DateTime = basket.DateTime;
                UserId = basket.User.UserId;
                UserName = basket.User.Username;
                Products = new List<ProductDto>();

                basket.BasketItems.ForEach(item => Products.Add(new ProductDto
                {
                    ProductId = item.Product.ProductId,
                    Price = item.Product.Price,
                    Name = item.Product.Name,
                    ColorDescription = item.Product.Color.ToString(),
                    ImageFilename = item.Product.ImageFilename
                }));
            }
        }

    }
}
