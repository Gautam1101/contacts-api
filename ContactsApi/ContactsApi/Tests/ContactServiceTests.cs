using Xunit;
using ContactsApi.Services;
using ContactsApi.Models;
using ContactsApi.Repositories;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ContactsApi.Tests
{
    public class ContactServiceTests
    {
        [Fact]
        public void GetAllContacts_ReturnsAllContacts()
        {
            var mockRepo = new Mock<ContactRepository>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(GetSampleContacts());
            var service = new ContactService(mockRepo.Object);

            var result = service.GetAllContacts();

            Assert.Equal(3, result.Count());
        }

        private IEnumerable<Contact> GetSampleContacts()
        {
            return new List<Contact>
            {
                new Contact { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new Contact { Id = 2, FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com" },
                new Contact { Id = 3, FirstName = "Sam", LastName = "Smith", Email = "sam.smith@example.com" },
            };
        }
    }
}
