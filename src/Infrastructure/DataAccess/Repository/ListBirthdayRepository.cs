
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ListBirthdayRepository : IListBirthdayRepository
    {
        protected DbContext DbContext { get; }
        protected DbSet<Person> DbSet { get; }

        public ListBirthdayRepository(DbContext dbContext)
        {
            DbContext= dbContext;
            DbSet = DbContext.Set<Person>();
        }

        public async Task AddAsync(Person model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            await DbSet.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Person model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            DbSet.Remove(model);
            await DbContext.SaveChangesAsync();
        }

        public IQueryable<Person> GetAll()
        {
            return DbSet;
        }

        public async Task<Person> GetByIdAsync(int Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public async Task UpdateAsync(Person model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            DbSet.Update(model);
            await DbContext.SaveChangesAsync();
        }
    }
}
