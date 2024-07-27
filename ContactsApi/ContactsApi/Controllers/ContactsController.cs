using Microsoft.AspNetCore.Mvc;
using ContactsApi.Models;
using ContactsApi.Services;
using System.Collections.Generic;

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactService _service;

        public ContactsController(ContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetContacts()
        {
            return Ok(_service.GetAllContacts());
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetContact(int id)
        {
            var contact = _service.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public ActionResult<Contact> PostContact(Contact contact)
        {
            _service.AddContact(contact);
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult PutContact(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            _service.UpdateContact(contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _service.DeleteContact(id);
            return NoContent();
        }
    }
}
