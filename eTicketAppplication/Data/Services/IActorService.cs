using eTicketAppplication.Models;

namespace eTicketAppplication.Data.Services
{
    public interface IActorService
    {
        IEnumerable<Actor> GetAll();
        Actor GetById();
        void Add(Actor actor);
        Actor Update(int id, Actor newActor);
        void Delete(int id);
    }
}
