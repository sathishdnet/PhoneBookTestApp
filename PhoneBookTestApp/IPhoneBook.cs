using System.Data;

namespace PhoneBookTestApp
{
    public interface IPhoneBook
    {
        Person findPerson(string firstName, string lastName);
        void AddPerson(Person newPerson);

        DataTable GetPhoneBook();
    }
}