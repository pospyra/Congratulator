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
        public async Task<InfoPersonResponse> AddPerson(AddPersonRequest addPersonRequest)
        {
            var newPerson = new Person
            {
                Name = addPersonRequest.Name,
                DateBirthDay = addPersonRequest.DateBirthday
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

        public async Task<InfoPersonResponse> EditPerson(int id,EditPersonRequest editPersonRequest)
        {
            var existingUser = await _listBirthdayRepository.GetByIdAsync(id);

            existingUser.Name = editPersonRequest.Name;
            existingUser.DateBirthDay = editPersonRequest.DateBirthday;

            await _listBirthdayRepository.UpdateAsync(existingUser);

            return new InfoPersonResponse()
            {
                Id = id,
                Name = editPersonRequest.Name,
                DateBirthday = editPersonRequest.DateBirthday
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
    }
}
