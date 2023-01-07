using eTickets.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace eTicketAppplication.Data.Base
{
    public class EntityBaseRespository<T> : IEntityBaseRepository<T> where T : class,IEntityBase, new()
    {
        protected readonly AppDbContext context;

        public EntityBaseRespository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State= EntityState.Deleted;
            context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            query = includeProperties.Aggregate(query, (current,includeProperty)=> current.Include(includeProperty));
            return await query.ToListAsync();
        }

        public async Task<T> GetIdAsync(int id) => await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
