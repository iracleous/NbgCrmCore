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
            return true;
        }

        public bool CreateBasket(int userId)
        {
            return false;
        }

        public List<Basket> GetBasketByUserId(int userId)
        {
            return new List<Basket>();
        }

        public Basket GetBasketWithProducts(int basketId)
        {
            return new Basket();
        }
    }
}
