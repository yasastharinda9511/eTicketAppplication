using eTicketAppplication.Models;
using eTickets.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace eTicketAppplication.Data.Services
{
    public class ActorsService : IActorService
    {

        private readonly AppDbContext context;

        public ActorsService(AppDbContext context)
        {
              
              this.context = context;
        }


        public async Task AddAsync(Actor actor)
        {
            await context.Actors.AddAsync(actor);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await context.Actors.FirstOrDefaultAsync(x => x.Id == id); 
            context.Actors.Remove(result);
            await context.SaveChangesAsync();
        }
        public async Task<Actor> GetByIdAsync(int id)
        {
           var result = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);
           return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            context.Update(newActor);
            await context.SaveChangesAsync();
            return newActor;
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await context.Actors.ToListAsync();
            return result;
        }

    }
}
