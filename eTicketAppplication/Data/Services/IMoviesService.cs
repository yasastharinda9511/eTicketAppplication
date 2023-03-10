using eTicketAppplication.Data.Base;
using eTicketAppplication.Models;

namespace eTicketAppplication.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieById(int id);
    }
}
