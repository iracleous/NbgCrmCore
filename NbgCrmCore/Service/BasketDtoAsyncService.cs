using Microsoft.EntityFrameworkCore;
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
    public class BasketDtoAsyncService : IBasketDtoAsyncService
    {
        private CrmDbContext db;
        private ILogger<BasketDtoAsyncService> logger;

        public BasketDtoAsyncService(CrmDbContext db,ILogger<BasketDtoAsyncService> logger )
        {
            this.db = db;
            this.logger = logger;
        }

        public async Task<List<BasketDto>> GetBasketDtoByUserId(int userId)
        {
            /*
            List<Basket> baskets = await
                db.Baskets.Where(basket => basket.User.UserId == userId)
               .ToListAsync();

            var basketDtos = new List<BasketDto>();
            baskets.ForEach(basket => basketDtos.Add(new BasketDto(basket)));
            return basketDtos;
            */

            return await
                db.Baskets
                .Where(basket => basket.User.UserId == userId)
                .Select(basket => new BasketDto(basket))
                .ToListAsync();
        }

        public Task<BasketDto> GetBasketDtoWithProducts(int basketId)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> AddProductToBasket(int basketId, int productId)
        {
            logger.LogInformation("AddProductToBasket");
            Basket basket = await db.Baskets.FindAsync(basketId);
            if (basket == null)
            {
                logger.LogInformation("AddProductToBasket Basket not found");
                return false;
            }
            Product product = await db.Products.FindAsync(productId);
            if (product == null)
            {
                logger.LogInformation("AddProductToBasket Product not found");
                return false;
            }
            var basketItem = new BasketItem { 
                Basket = basket, 
                Product = product, 
                Discount = 0, 
                Quantity = 1 };

            db.BasketItems.Add(basketItem);
            await db.SaveChangesAsync();
            logger.LogInformation("AddProductToBasket basketItem added");
            return true;
        }

        public async Task<bool> CreateBasket(int userId)
        {
            Basket basket = new ();
            User user = db.Users.Find(userId);
            basket.User = user;
            db.Baskets.Add(basket);
            int result = await db.SaveChangesAsync();
            return result==1;
        }



    }
}
