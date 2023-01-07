using eTicketAppplication.Data.Base;
using eTicketAppplication.Models;
using eTickets.Data;
using Microsoft.EntityFrameworkCore;

namespace eTicketAppplication.Data.Services
{
    public class MovieService : EntityBaseRespository<Movie> , IMoviesService
    {

        public MovieService(AppDbContext context) : base(context)
        {
        
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movieDetails =  await context.Movies.
                               Include(c => c.Cinema).
                               Include(c => c.Producer).
                               Include(am => am.Actors_Movies).
                               ThenInclude(a => a.Actor).
                               FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;

        }
    }
}
