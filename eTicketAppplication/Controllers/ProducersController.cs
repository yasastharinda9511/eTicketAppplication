using eTicketAppplication.Data.Services;
using eTicketAppplication.Models;
using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace eTicketAppplication.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService service;
        public ProducersController(IProducerService service)
        {
            this.service = service;     
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await service.GetAllAsync();
            return View(allProducers);
        }

        
        public async Task<IActionResult> Details(int id) 
        {
            var producerDetails = await service.GetIdAsync(id);

            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);

        }
        //Get: producers/Create
        public IActionResult Create() 
        {
            
            return View();
        
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName ,Bio")] Producer producer) 
        {
            if (!ModelState.IsValid) return View(producer);

            await service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        
        }


        //Get: producers/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var producerDetail = await service.GetIdAsync(id);
            if (producerDetail == null) return View("NotFound");
            return View(producerDetail);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id ,[Bind("Id,ProfilePictureURL, FullName ,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if (id == producer.Id) 
            {
                await service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));

            }
            
            return View(producer);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var producerDetail = await service.GetIdAsync(id);
            if (producerDetail == null) return View("NotFound");
            return View(producerDetail);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id,ProfilePictureURL, FullName ,Bio")] Producer producer)
        {
            var producerDetail = await service.GetIdAsync(id);
            if (producerDetail == null) return View("NotFound");

            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));


        }


    }
}
