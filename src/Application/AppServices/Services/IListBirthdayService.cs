using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public interface IListBirthdayService 
    {
        Task<InfoPersonResponse> AddPerson(AddPersonRequest addPersonRequest);
        Task DeletePerson(int id);
        Task<IReadOnlyCollection<InfoPersonResponse>> GetAllPerson();

        Task<InfoPersonResponse> EditPerson(int id, EditPersonRequest editPersonRequest);
    }
}
