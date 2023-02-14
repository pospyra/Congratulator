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
        IQueryable<Person> GetAll();

        Task<Person> GetByIdAsync(int Id);

        Task AddAsync(Person model);

        Task UpdateAsync(Person model);

        Task DeleteAsync(Person model);
    }
}
