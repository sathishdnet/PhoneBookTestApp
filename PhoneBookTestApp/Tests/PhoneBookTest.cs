using PhoneBookTestApp;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhoneBookTestAppTests
{
    // ReSharper disable InconsistentNaming
    
    [TestClass]
    public class PhoneBookTest
    {
        private static PhoneBook phonebook = new PhoneBook();
        
        [TestMethod]
        public void addPerson()
        {
            try
            {
               
                DatabaseUtil.initializeDatabase();

                Person objPerson = new Person()
                {
                    name = "Test Name",
                    phoneNumber = "(248) 123-4567",
                    address = "1234 Sand Hill Dr, Royal Oak, MI"
                };
                phonebook.AddPerson(objPerson);
                
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
            
        }

        [TestMethod]
        public void findPerson()
        {
            try
            {
                
                DatabaseUtil.initializeDatabase();
                
                Person objPerson = new Person()
                {
                    name = "Cynthia Smith",
                    phoneNumber = "(824) 128-8758",
                    address = "875 Main St, Ann Arbor, MI"
                };
                phonebook.AddPerson(objPerson);

                var person = phonebook.findPerson("Cynthia", "Smith");

                Assert.IsNotNull(person);
                Assert.IsNotNull(person.name);
                
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }

    // ReSharper restore InconsistentNaming 
}