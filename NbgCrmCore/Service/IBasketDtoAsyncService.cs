using NbgCrmCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Service
{
   public interface IBasketDtoAsyncService
    {
        public Task<bool> CreateBasket(int userId);
        public Task<bool> AddProductToBasket(int basketId, int productId);
        public Task<BasketDto> GetBasketDtoWithProducts(int basketId);
        public Task<List<BasketDto>> GetBasketDtoByUserId(int userId);

    }
}
