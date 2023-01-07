using eTicketAppplication.Data.Services;
using eTicketAppplication.Models;
using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicketAppplication.Controllers
{
    public class MovieController : Controller
    {

        private readonly IMoviesService service;

        public MovieController(IMoviesService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await service.GetAllAsync(n=>n.Cinema);
            return View(allMovies);
        }

        //Get : Movie/Details/1

        public async Task<IActionResult> Details(int id) 
        {
            var movieDetail = await service.GetMovieById(id);
            return View(movieDetail);
        
        }
    }
}
