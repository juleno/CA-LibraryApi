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
    public class LibraryController : ControllerBase
    {
        private BookService bookService { get; set; }

        public LibraryController()
        {
            bookService = new BookService();
        }

        // GET: api/<LibraryController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(bookService.GetAllBook().Result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<LibraryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LibraryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LibraryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibraryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
