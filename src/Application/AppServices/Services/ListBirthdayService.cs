using Contracts;
using DataAccess.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public class ListBirthdayService : IListBirthdayService
    {
        public IListBirthdayRepository _listBirthdayRepository;

        public ListBirthdayService(IListBirthdayRepository listBirthdayRepository)
        {
            _listBirthdayRepository= listBirthdayRepository;
        }
        public async Task<InfoPersonResponse> AddPerson(string name, DateTime dateBrth)
        {
            var newPerson = new Person
            {
                Name = name,
                DateBirthDay = dateBrth.ToUniversalTime()
            };
            await _listBirthdayRepository.AddAsync(newPerson);

            return new InfoPersonResponse()
            {
                Id = newPerson.Id,
                Name = newPerson.Name,
                DateBirthday = newPerson.DateBirthDay
            };
        }

        public async Task DeletePerson(int id)
        {
          var delPerson = await _listBirthdayRepository.GetByIdAsync(id);
          await _listBirthdayRepository.DeleteAsync(delPerson);   
        }

        public async Task<InfoPersonResponse> EditPerson(int id, string name, DateTime dateBrth)
        {
            var existingUser = await _listBirthdayRepository.GetByIdAsync(id);
           existingUser.Name = name;
           existingUser.DateBirthDay = dateBrth.ToUniversalTime();

            await _listBirthdayRepository.UpdateAsync(existingUser);

            return new InfoPersonResponse()
            {
                Id = id,
                Name = name,
                DateBirthday = dateBrth
            };
        }

        public async Task<IReadOnlyCollection<InfoPersonResponse>> GetAllPerson()
        {
            return await _listBirthdayRepository.GetAll()
                .Select(x => new InfoPersonResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                   DateBirthday = x.DateBirthDay
                }).ToListAsync();
        }

        public async Task<ICollection<InfoPersonResponse>> GetNearestBirthday()
        {
            var birtdays = _listBirthdayRepository.GetAll().Where(x=>x.DateBirthDay.Month == DateTime.UtcNow.Month
            || x.DateBirthDay.Month == DateTime.UtcNow.Month+1);
            return await birtdays.Select(x=> new InfoPersonResponse()
            {
                Id = x.Id,
                Name = x.Name,
                DateBirthday = x.DateBirthDay
            }).OrderBy(x=>x.DateBirthday).ToListAsync();
        }
    }
}
