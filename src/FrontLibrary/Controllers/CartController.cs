using Common.Models;
using FrontLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private CartService service{ get; set; }

        public CartController()
        {
            service = new CartService();
        }

        // POST api/<Cart>
        [HttpPost]
        public IActionResult Post([FromBody] Cart cart)
        {
            try
            {
                return Ok(service.PostCart(cart).Result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
