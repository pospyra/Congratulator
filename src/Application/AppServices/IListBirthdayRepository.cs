using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IListBirthdayRepository
    {
        public IQueryable<Person> GetAll();

        public Task<Person> GetByIdAsync(int Id);

        public Task AddAsync(Person model);

        public Task UpdateAsync(Person model);

        public Task DeleteAsync(Person model);
    }
}
