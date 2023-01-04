using eTicketAppplication.Data.Services;
using eTicketAppplication.Models;
using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace eTicketAppplication.Controllers
{
    public class CinemaController : Controller
    {
        public readonly ICinemaService service;
        public CinemaController(ICinemaService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {

            var allCinemas = await service.GetAllAsync();
            return View(allCinemas);
        }

        // Get Cinemas/Create

        public IActionResult Create() 
        {
            return View();
        
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema) 
        {
            if (!ModelState.IsValid) return View(cinema);

            await service.AddAsync(cinema);

            return RedirectToAction(nameof(Index));
        
        }

        public async Task<IActionResult> Details(int id) 
        {
            var cinemaResult = await service.GetIdAsync(id);

            if (cinemaResult == null) return View("NotFound");

            return View(cinemaResult);
        }

        // Get:Edit/id

        public async Task<IActionResult> Edit(int id) 
        { 
            
            var cinemaResult = await service.GetIdAsync(id);
            if (cinemaResult == null) return View("NotFound");

            return View(cinemaResult);
        
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema) 
        {

            if (!ModelState.IsValid) return View(cinema);
            await service.UpdateAsync(id ,cinema);
            return RedirectToAction(nameof(Index));
        
        }

        public async Task<IActionResult> Delete(int id)
        {

            var cinemaResult = await service.GetIdAsync(id);
            if (cinemaResult == null) return View("NotFound");

            return View(cinemaResult);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {

            var cinemaDetail = await service.GetIdAsync(id);
            if (cinemaDetail == null) return View("NotFound");

            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
