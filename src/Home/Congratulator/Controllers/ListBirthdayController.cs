using AppServices.Services;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

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


        [HttpGet("nearestBirthday")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoPersonResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNearest()
        {
            try
            {
                var result = await _birthdayService.GetNearestBirthday();
                return Ok(result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoPersonResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _birthdayService.GetAllPerson();
                return Ok(result);
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoPersonResponse>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAsync(string name, DateTime dateBrth, IFormFile file)
        {
            byte[] photo;
            try
            {
                await using (var ms = new MemoryStream())
                await using (var fs = file.OpenReadStream())
                {
                    await fs.CopyToAsync(ms);
                    photo = ms.ToArray();
                }
                var result = await _birthdayService.AddPerson(name, dateBrth, photo);
                return Created("", result);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }


    [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoPersonResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditPerson(int id, string name, DateTime dateBrth, IFormFile file)
        {
            byte[] photo;
            try
            {
                await using (var ms = new MemoryStream())
                await using (var fs = file.OpenReadStream())
                {
                    await fs.CopyToAsync(ms);
                    photo = ms.ToArray();
                }
                var res = await _birthdayService.EditPerson(id, name, dateBrth, photo);
                return Ok(res);
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoPersonResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletePerson(int id)
        {
            try
            {
                await _birthdayService.DeletePerson(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}