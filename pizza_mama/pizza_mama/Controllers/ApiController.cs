using Microsoft.AspNetCore.Mvc;
using pizza_mama.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizza_mama.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        
        // GET: api/GetPizzas
        [HttpGet]
        [Route("GetPizzas")]

        public IActionResult GetPizzas()
        {
            var pizza = new Pizza() { name = "pizza test", price = 12, vegetarian = false, ingredient = "Sauce Tomate, Mozzarella, Jambon"};
            return new string[] { "Pizza", "value2" };
        }
    }
}
