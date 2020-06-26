using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartPromotionEngine.Service.Read.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CartPromotionEngine.Read.Controllers
{
    [Route("api/promotionengine")]
    [ApiController]
    public class CartPromtionEngineController : ControllerBase
    {
        private ICartPromotionEngineService _cartPromotionEngineService;
        
        public CartPromtionEngineController(ICartPromotionEngineService cartPromotionEngineService)
        {

            _cartPromotionEngineService = cartPromotionEngineService;
        }

        [HttpGet("{cartItems}/{promotionCode}/gettotalvalue")]
        public double GetTotalValueOFCart(string cartItems, string promotionCode)
        {
            var result = _cartPromotionEngineService.TotalValueOfCart(cartItems, promotionCode);
            return result;
        }
    }
}
