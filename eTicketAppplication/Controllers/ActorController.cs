using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTicketAppplication.Controllers
{
    public class ActorController : Controller
    {

        private readonly AppDbContext context;

        public ActorController(AppDbContext appDbContext) 
        { 
            
            context = appDbContext;
        }
        public IActionResult Index()
        {
            var actors = context.Actors.ToList();
            return View(actors);
        }
    }
}
