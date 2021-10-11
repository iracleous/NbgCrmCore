using Microsoft.Extensions.Logging;
using NbgCrmCore.Dtos;
using NbgCrmCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Service
{
    public class BasketDtoService : IBasketDtoService
    {
        private readonly CrmDbContext db;
        private readonly ILogger<BasketDtoService> logger;

        private readonly BasketService basketService;

        public BasketDtoService(CrmDbContext _db, ILogger<BasketDtoService> _logger ,
            BasketService _basketService  )
        {
            db = _db;
            logger = _logger;
            basketService = _basketService;
        }

        public bool AddProductToBasket(int basketId, int productId)
        {
            return basketService.AddProductToBasket(basketId, productId);
        }

        public bool CreateBasket(int userId)
        {
            return basketService.CreateBasket(userId);
        }

        public List<BasketDto> GetBasketDtoByUserId(int userId)
        {
            List<Basket> baskets = basketService.GetBasketByUserId(userId);
            var basketDtos = new List<BasketDto>();
            baskets.ForEach(basket => basketDtos.Add(new BasketDto(basket)));
            return basketDtos;
        }

        public BasketDto GetBasketDtoWithProducts(int basketId)
        {
            Basket basket = basketService.GetBasketWithProducts(basketId);
            return new BasketDto(basket);
        }
    }
}
