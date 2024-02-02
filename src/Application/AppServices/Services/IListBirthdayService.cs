using Contracts;

namespace AppServices.Services
{
    public interface IListBirthdayService 
    {
        Task<ICollection<InfoPersonResponse>> GetNearestBirthday();

        Task<InfoPersonResponse> AddPerson(string name, DateTime dateBrth, byte[] photo);

        Task DeletePerson(int id);

        Task<IReadOnlyCollection<InfoPersonResponse>> GetAllPerson();

        Task<InfoPersonResponse> EditPerson(int id, string name, DateTime dateBrth, byte[] photo);
    }
}
