using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pizza_mama.Models;

namespace pizza_mama.Pages
{
    public class MenuPizzasModel : PageModel
    {
        private readonly pizza_mama.Data.DataContext _context;

        public MenuPizzasModel (pizza_mama.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Pizza> Pizza { get; set; }
        public async Task OnGetAsync()
        {
            Pizza = await _context.Pizzas.ToListAsync();
        }
    }
}
