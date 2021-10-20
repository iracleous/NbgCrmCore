using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NbgCrmCore.Dtos;
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
    public class BasketDtoController : ControllerBase
    {

        private readonly IBasketDtoService basketService;
        private ILogger<BasketDtoController> logger;

        public BasketDtoController(IBasketDtoService basketService, ILogger<BasketDtoController> logger)
        {
            this.basketService = basketService;
            this.logger = logger;
        }


        // GET: api/<BasketDtoController>
        [HttpGet("user/{userId}")]
        public IActionResult GetBasketDtoByUserId(int userId)
        {
            logger.LogInformation("GetBasketDtoByUserId");
            return Ok(basketService.GetBasketDtoByUserId(userId));
        }

        // GET: api/<BasketDtoController>
        [HttpGet("{basketId}")]
        public IActionResult GetBasketDtoWithProducts(int basketId)
        {
            logger.LogInformation("GetBasketDtoWithProducts");
            BasketDto basketDto = basketService.GetBasketDtoWithProducts(basketId);
            if (basketDto == null) return NotFound();
            return Ok(basketDto); 
        }




        // POST api/<BasketController>{userId}
        [HttpPost("user/{userId}")]
        public int CreateBasket([FromRoute] int userId)
        {
            logger.LogInformation("CreateBasket");
            return basketService.CreateBasket(userId);
        }


        // POST api/<BasketController>/{basketId}/product/{productId}
        [HttpPost("{basketId}/product/{productId}")]
        public bool AddProductToBasket([FromRoute] int basketId, [FromRoute] int productId)
        {
            logger.LogInformation("AddProductToBasket");
            return basketService.AddProductToBasket(basketId, productId);
        }





    }
}
