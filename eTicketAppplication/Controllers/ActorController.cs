using eTicketAppplication.Data.Services;
using eTicketAppplication.Models;
using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eTicketAppplication.Controllers
{
    public class ActorController : Controller
    {

        private readonly IActorService service;

        public ActorController(IActorService service) 
        { 
            
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var actors = await service.GetAllAsync();
            return View(actors);
        }

        //Get: Actor/Create
        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor) 
        {

            if (!ModelState.IsValid) 
            { 
                return View(actor);
            }
            await service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get : Actor/Details/1
        public async Task<IActionResult> Details(int id) 
        {

            var actorDetails = await service.GetByIdAsync(id);

            if(actorDetails == null) return View("Empty");
            return View(actorDetails);
        
        }
        
        public async Task<IActionResult> Edit(int id) 
        {
            var actorDetails = await service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor) 
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await service.UpdateAsync(id , actor); 
            return RedirectToAction(nameof(Index));


        }


        public async Task<ActionResult> Delete(int id) 
        { 
            
            var ActionDetails = await service.GetByIdAsync(id);
            if (ActionDetails == null) return View("Not Found");

            return View(ActionDetails);
        
        }
        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) 
        {
             var actorDetails = await service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");

            await service.DeleteAsync(id);  
            return RedirectToAction(nameof(Index));

        }

    }
}
