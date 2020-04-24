using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Agenda_con_ArchivosTests1;
using System.IO;

namespace Agenda_con_Archivos.Models.Tests
{
    [TestClass()]
    public class ContactManagerTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            File.Delete("Contactos.txt");
        }
        [TestMethod()]
        public void RegisterTest_returns_the_same_contact_if_is_correctly_registered()
        {
            var id = 0;
            var name = "name";
            var surname = "surname";
            var phoneNumber = 666666666;
            var location = "location";
            var expected = new Contact()
            {
                Id = id,
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber,
                Location = location,
            };
            ContactManager manager = new ContactManager();
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                {"id", manager.SetId().ToString() },
                {"name", name },
                {"surname", surname },
                {"phoneNumber", phoneNumber.ToString() },
                {"location", location }
            };
            var response = manager.Register(data);
            AssertHelper.HasEqualFieldValues(expected, response);
        }
        [TestMethod()]
        public void RegisterTest_set_id_correctly_when_contact_is_registered()
        {
            var id = 1;
            var name = "name";
            var surname = "surname";
            var phoneNumber = 666666666;
            var location = "location";
            var expected = new Contact()
            {
                Id = id,
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber,
                Location = location,
            };
            ContactManager manager = new ContactManager();
            Dictionary<string, string> dataFirst = new Dictionary<string, string>
            {
                {"id", manager.SetId().ToString() },
                {"name", name },
                {"surname", surname },
                {"phoneNumber", phoneNumber.ToString() },
                {"location", location }
            };
            manager.Register(dataFirst); 
            Dictionary<string, string> dataSecond = new Dictionary<string, string>
            {
                {"id", manager.SetId().ToString() },
                {"name", name },
                {"surname", surname },
                {"phoneNumber", phoneNumber.ToString() },
                {"location", location }
            };
            var response = manager.Register(dataSecond);
            AssertHelper.HasEqualFieldValues(expected, response);
        }
    }
}