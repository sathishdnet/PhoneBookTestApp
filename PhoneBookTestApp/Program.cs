using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        private static PhoneBook phonebook = new PhoneBook();
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\nHello, Welcome to Phone Book App! \n");

                DatabaseUtil.initializeDatabase();

                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */
                Person objPerson = new Person()
                {
                    name= "John Smith",
                    phoneNumber= "(248) 123-4567",
                    address= "1234 Sand Hill Dr, Royal Oak, MI"
                };
                phonebook.AddPerson(objPerson);

                objPerson = new Person()
                {
                    name = "Cynthia Smith",
                    phoneNumber = "(824) 128-8758",
                    address = "875 Main St, Ann Arbor, MI"
                };
                phonebook.AddPerson(objPerson);
                

                // TODO: print the phone book out to System.out
                var phoneBookData = phonebook.GetPhoneBook();
                if(phoneBookData != null)
                {
                    Console.WriteLine("List of Contacts from Phone Book:");
                    for(var i=0; i< phoneBookData.Rows.Count;i++)
                    {
                        var contactNum = i + 1;
                        Console.WriteLine("\n Contact "+ contactNum + " : \n Name: "+ phoneBookData.Rows[i][0] +"\n Phone: " + phoneBookData.Rows[i][1] + "\n Address: " + phoneBookData.Rows[i][2]);
                    }
                    
                }

                // TODO: find Cynthia Smith and print out just her entry
                var person = phonebook.findPerson("Cynthia", "Smith");
                if(person.name != null)
                {
                    Console.WriteLine("\n Cynthia Smith is available in Phone book and below are the details.");
                    Console.WriteLine(" Name: " + person.name + "\n Phone: " + person.phoneNumber + "\n Address: " + person.address);
                }
                else
                {
                    Console.WriteLine("\n Oops!, Cynthia Smith is not available in Phone book.");
                }

                // TODO: insert the new person objects into the database
                Console.WriteLine("\nEnter 1 to add new contact Or any other key to Proceed.");
                var input = Console.ReadKey();
                if(input.KeyChar.ToString() == "1")
                {
                    AddNewContact();
                }

                
                Console.WriteLine("\n ***Thank you, Have a nice day.***");
                Console.Read();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Encountered as exception while running the process with below message.\n"+ex.Message);
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }

        //To Add new contacts into DB recursively
        public static void AddNewContact()
        {
            Console.WriteLine("\nType Name and Enter: ");
            var inputName = Console.ReadLine();
            Console.WriteLine("Type Phone Number and Enter: ");
            var inputPhone = Console.ReadLine();

            Console.WriteLine("Type Address and Enter: ");
            var inputAddress = Console.ReadLine();

           Person objPerson = new Person()
            {
                name = inputName,
                phoneNumber = inputPhone,
                address = inputAddress
            };
            phonebook.AddPerson(objPerson);

            Console.WriteLine("Your Contact has been saved. Enter 1 to add new contact Or any other key to Proceed");
            var input = Console.ReadKey();
            if (input.KeyChar.ToString() == "1")
            {
                AddNewContact();
            }

        }
    }
}
