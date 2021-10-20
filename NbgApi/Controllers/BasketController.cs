using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NbgCrmCore.Model;
using NbgCrmCore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NbgApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        private readonly ILogger<BasketController> logger;

        public BasketController(IBasketService _basketService, ILogger<BasketController> _logger)
        {
            basketService = _basketService;
            logger = _logger;
        }


        // GET: api/<BasketController>/user/{userId}
        [HttpGet("user/{userId}")]
        public IEnumerable<Basket> GetBasketByUserId(int userId)
        {
            logger.LogInformation("GetBasketByUserId");
            return basketService.GetBasketByUserId(userId);
        }

        // POST api/<BasketController>{userId}
        [HttpPost("user/{userId}")]
        public int CreateBasket([FromRoute] int userId)
        {
            logger.LogInformation("CreateBasket");
            //to check
            return basketService.CreateBasket(userId);
        }


        // POST api/<BasketController>/{basketId}/product/{productId}
        [HttpPost("{basketId}/product/{productId}")]
        public bool AddProductToBasket([FromRoute] int basketId, [FromRoute] int productId)
        {
            logger.LogInformation("AddProductToBasket");
            return basketService.AddProductToBasket(basketId, productId);
        }

        // GET api/<BasketController>/5
        [HttpGet("{basketId}")]
        public Basket GetBasketWithProducts(int basketId)
        {
            logger.LogInformation("GetBasketWithProducts");
            return basketService.GetBasketWithProducts(basketId);
        }

        
 
    }
}
