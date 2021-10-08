using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NbgCrmCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Service
{
    public class BasketService : IBasketService
    {
        //basketRepository implementation

        private readonly CrmDbContext db;
        private readonly ILogger<BasketService> logger;


        public BasketService(CrmDbContext db, ILogger<BasketService> logger)
        {
            this.db = db;
            this.logger = logger;
        }
        public bool AddProductToBasket(int basketId, int productId)
        {
            logger.LogInformation("AddProductToBasket");

            Basket basket = db.Baskets.Find(basketId);
            if (basket == null)
            {
                logger.LogInformation("AddProductToBasket Basket not found");
                return false;
            }
            Product product = db.Products.Find(productId);
            if (product == null)
            {
                logger.LogInformation("AddProductToBasket Product not found");
                return false;
            }
            var basketItem = new BasketItem { Basket=basket, Product=product, Discount=0, Quantity=1 };


            db.BasketItems.Add(basketItem);
            db.SaveChanges();
            logger.LogInformation("AddProductToBasket basketItem added");
            return true;
        }

        public bool CreateBasket(int userId)
        {
            logger.LogInformation("CreateBasket");
            User user = db.Users.Find(userId);
            if (user == null)
            {
                logger.LogInformation("CreateBasket user not found");
                return false;
            }

            var basket = new Basket { DateTime=DateTime.Now,  Status= Status.OPEN, User= user};

            db.Baskets.Add(basket);
            db.SaveChanges();

            logger.LogInformation("CreateBasket basket created");
            return true;
        }

        public List<Basket> GetBasketByUserId(int userId)
        {
            logger.LogInformation("GetBasketByUserId");
            return db.Baskets
                .Where(basket => basket.User.UserId == userId)
                .Include(basket => basket.User)
                .Include(basket => basket.BasketItems)
                .ThenInclude(basketItem => basketItem.Product)
                .ToList();
        }

        public Basket GetBasketWithProducts(int basketId)
        {
            logger.LogInformation("GetBasketWithProducts");
            return db.Baskets
                .Where(basket => basket.BasketId==basketId)
                .Include(basket => basket.User)
                .Include(basket => basket.BasketItems)
                .ThenInclude(basketItem => basketItem.Product)
                .FirstOrDefault();
        }
    }
}
