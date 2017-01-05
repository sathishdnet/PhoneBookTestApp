using System;
using System.Data;
using System.Data.SQLite;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        SQLiteConnection _dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
        
        //To Add new contach into Phone book
        public void AddPerson(Person person)
        {
            //throw new System.NotImplementedException();
          
            try
            {
                _dbConnection.Open();

                SQLiteCommand command = 
                    new SQLiteCommand(
                        "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('"+person.name+ "','" + person.phoneNumber + "', '" + person.address + "')",
                        _dbConnection);
                command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.Close();
            }

        }

        //To retrive all contacts from Phone book
        public DataTable GetPhoneBook()
        {
            //throw new System.NotImplementedException();
            _dbConnection.Open();

            try
            {
                SQLiteCommand cmd;
                SQLiteDataReader reader;
                DataTable dt = new DataTable();
                using (cmd = new SQLiteCommand("Select * from PHONEBOOK", _dbConnection))
                {
                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {   
                            dt.Load(reader);
                        }
                    }
                }

         
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.Close();
            }

        }

        //To find a contact from phone book by Name
        public Person findPerson(string firstName, string lastName)
        {
            //throw new System.NotImplementedException();
            _dbConnection.Open();

            try
            {
                SQLiteCommand cmd;
                SQLiteDataReader reader;
                DataTable dt = new DataTable();
                Person person = new Person();
                using (cmd = new SQLiteCommand("Select * from PHONEBOOK Where NAME='"+ firstName+" "+lastName+"'", _dbConnection))
                {
                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {   
                                person.name = reader["NAME"].ToString();
                                person.phoneNumber = reader["PHONENUMBER"].ToString();
                                person.address = reader["ADDRESS"].ToString();
                                break;
                            }
                            
                        }
                    }
                }


                return person;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dbConnection.Close();
            }

        }
    }
}