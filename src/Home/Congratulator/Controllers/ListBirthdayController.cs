using AppServices.Services;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Congratulator.Controllers
{
    [ApiController]
    public class ListBirthdayController : ControllerBase
    {
       private readonly IListBirthdayService _birthdayService;
        public ListBirthdayController(IListBirthdayService birthdayService)
        {
            _birthdayService = birthdayService;
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoPersonResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _birthdayService.GetAllPerson();
            return Ok(result);
        }

        [HttpPost("createAd")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoPersonResponse>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAdAsync(AddPersonRequest createPerson)
        {
            var result = await _birthdayService.AddPerson(createPerson);
            return Created("", result);
        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoPersonResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditAddAsync(int id, EditPersonRequest edit)
        {
            var res = await _birthdayService.EditPerson(id, edit);
            return Ok(res);
        }


        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoPersonResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await _birthdayService.DeletePerson(id);
            return NoContent();
        }
    }
}