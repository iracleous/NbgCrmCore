using NbgCrmCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Service
{
    public interface IBasketDtoService
    {
        public int CreateBasket(int userId);
        public bool AddProductToBasket(int basketId, int productId);
        public BasketDto GetBasketDtoWithProducts(int basketId);
        public List<BasketDto> GetBasketDtoByUserId(int userId);

    }
}
