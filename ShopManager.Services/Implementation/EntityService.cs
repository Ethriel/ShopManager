using ShopManager.Services.Utility;
using Microsoft.EntityFrameworkCore;

namespace ShopManager.Services
{
    public class EntityService<T> : IEntityService<T> where T : class
    {
        protected readonly DbContext context;
        protected readonly DbSet<T> set;
        //protected readonly IQueryable<T> query;

        public EntityService(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
            //this.query = this.set;
            //var navigations = context.Model.FindEntityType(typeof(T))
            //                               .GetNavigations();
            //foreach (var navigation in navigations)
            //{
            //    query = query.Include(navigation.Name);
            //}
        }
        public bool Create(T entity)
        {
            if (entity == null) return false;

            set.Add(entity);

            return Save() > 0;
        }

        public async Task<bool> CreateAsync(T entity)
        {
            return await Task.FromResult(Create(entity));
        }

        public bool Delete(object id)
        {
            var entity = set.Find(id);

            if (entity == null) return false;

            set.Remove(entity);

            return Save() > 0;
        }

        public async Task<bool> DeleteAsync(object id)
        {
            return await Task.FromResult(Delete(id));
        }

        public IQueryable<T> Read()
        {
            return set.AsQueryable();
        }

        public async Task<IQueryable<T>> ReadAsync()
        {
            return await Task.FromResult(Read());
        }

        public T Update(T oldEntity, T newEntity)
        {
            var updatedEntity = UpdateUtility<T>.Update(context.Model, oldEntity, newEntity);

            return Save() > 0 ? updatedEntity : null;
        }

        public async Task<T> UpdateAsync(T oldEntity, T newEntity)
        {
            return await Task.FromResult(Update(oldEntity, newEntity));
        }

        private int Save()
        {
            return context.SaveChanges();
        }

        private async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
