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
        public IEnumerable<BasketDto> GetBasketDtoByUserId(int userId)
        {
            logger.LogInformation("GetBasketDtoByUserId");
            return basketService.GetBasketDtoByUserId(userId);
        }

        // GET: api/<BasketDtoController>
        [HttpGet("{basketId}")]
        public BasketDto GetBasketDtoWithProducts(int basketId)
        {
            logger.LogInformation("GetBasketDtoWithProducts");
            BasketDto basketDto = basketService.GetBasketDtoWithProducts(basketId);
            if (basketDto == null) return new BasketDto();
            return basketDto;
        }

        // POST api/<BasketDtoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BasketDtoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BasketDtoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
