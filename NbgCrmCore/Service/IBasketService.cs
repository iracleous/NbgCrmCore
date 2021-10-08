using NbgCrmCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgCrmCore.Service
{
    public interface IBasketService
    {

        public bool CreateBasket(int userId);
        public List<Basket> GetBasketByUserId(int userId);

        public bool AddProductToBasket(int basketId, int productId);

        public Basket GetBasketWithProducts(int basketId);

    }
}
