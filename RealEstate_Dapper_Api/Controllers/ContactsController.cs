using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("GetLast4Contact")]
        public async Task<IActionResult> GetLast4Contact()
        {
            var values = await _contactRepository.GetLast4Contact();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            _contactRepository.CreateContact(createContactDto);
            return Ok("Personel başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            _contactRepository.DeleteContact(id);
            return Ok("Personel Başarıyla silindi");
        }/*
        [HttpGet("GetLast4Contact")]
        public async Task<IActionResult> GetLast4Contact(Last4ContactResultDto last4ContactResultDto)
        {
            _contactRepository.GetLast4Contact(last4ContactResultDto);
            return Ok("Personel Başarıyla güncellendi");
        }
        */
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDContact(int id)
        {
            var value = await _contactRepository.GetByIDContactDto(id);
            return Ok(value);
        }
    }
}



