using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Agenda_con_ArchivosTests1;

namespace Agenda_con_Archivos.Models.Tests
{
    [TestClass()]
    public class ContactManagerTests
    {
        [TestMethod()]
        public void RegisterTest()
        {
            var id = 0;
            var name = "name";
            var surname = "surname";
            var phoneNumber = 666666666;
            var location = "location";
            var expected = new Contact()
            {
                id = id,
                name = name,
                surname = surname,
                phoneNumber = phoneNumber,
                location = location,
            };
            ContactManager manager = new ContactManager();
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                {"id", manager.setId().ToString() },
                {"name", name },
                {"surname", surname },
                {"phoneNumber", phoneNumber.ToString() },
                {"location", location }
            };
            var response = manager.Register(data);
            AssertHelper.HasEqualFieldValues(expected, response);
        }
    }
}