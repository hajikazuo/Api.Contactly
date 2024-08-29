using Api.Contactly.Data;
using Api.Contactly.Models;
using Api.Contactly.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RT.Comb;

namespace Api.Contactly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactlyDbContext _context;   
        private readonly ICombProvider _comb;

        public ContactsController(ContactlyDbContext context, ICombProvider comb)
        {
            _context = context;
            _comb = comb;
        }

        [HttpGet]
        public async Task <IActionResult> GetAllContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult AddContact(AddContactRequestDTO request)
        {
            var contact = new Contact
            {
                ContactId = _comb.Create(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Favorite = request.Favorite
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return Ok(contact);
        }
    }
}
