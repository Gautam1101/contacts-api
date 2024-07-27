using ContactsApi.Models;
using ContactsApi.Repositories;
using System.Collections.Generic;

namespace ContactsApi.Services
{
    public class ContactService
    {
        private readonly ContactRepository _repository;

        public ContactService(ContactRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Contact> GetAllContacts() => _repository.GetAll();
        public Contact GetContactById(int id) => _repository.GetById(id);
        public void AddContact(Contact contact) => _repository.Add(contact);
        public void UpdateContact(Contact contact) => _repository.Update(contact);
        public void DeleteContact(int id) => _repository.Delete(id);
    }
}
