using ContactsApi.Data;
using ContactsApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactsApi.Repositories
{
    public class ContactRepository
    {
        private readonly ContactContext _context;

        public ContactRepository(ContactContext context)
        {
            _context = context;
        }

        public IEnumerable<Contact> GetAll() => _context.Contacts.ToList();
        public Contact GetById(int id) => _context.Contacts.Find(id);
        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }
    }
}
