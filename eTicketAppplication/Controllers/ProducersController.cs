using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicketAppplication.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext context;

        public ProducersController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await context.Producers.ToListAsync();
            return View(allProducers);
        }
    }
}
