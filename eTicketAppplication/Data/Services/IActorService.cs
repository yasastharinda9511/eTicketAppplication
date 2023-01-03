using eTicketAppplication.Models;

namespace eTicketAppplication.Data.Services
{
    public interface IActorService
    {
        public Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);
        Task<Actor> UpdateAsync(int id, Actor newActor);
        Task DeleteAsync(int id);
    }
}
