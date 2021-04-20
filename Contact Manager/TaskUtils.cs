using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manger
{
    /// <summary>
    /// Class to implement all the tasks that are given
    /// </summary>
    class TaskUtils
    {
        /// <summary>
        /// Creats person object from given data
        /// </summary>
        /// <returns>Persons object</returns>
         public static Person CreatePerson()
        {
            Console.Clear();
            Console.WriteLine("Add contact: \n");

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Last name: ");
            string surname = Console.ReadLine();
            Console.Write("Phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Address: (optional) ");
            string address = Console.ReadLine();

            if (name == string.Empty || surname == string.Empty || phoneNumber == string.Empty)
            {
                throw new Exception("Contact was not added, name, surname and phone number has to be declared \n");
            }

            return new Person(name, surname, phoneNumber, address);
        }
        
        /// <summary>
        /// Updates selected contact's data with new data
        /// </summary>
        /// <param name="peopleList">Contact's list</param>
        /// <returns>Updated contact's list</returns>
        public static List<Person> UpdateInfo(List<Person> peopleList, out string text)
        {
            List<Person> tempList = new List<Person>();
            Console.Clear();

            Person tempPerson = GetInfo();

            var temp = peopleList.Where(x => x.Name == tempPerson.Name && x.Surname == tempPerson.Surname).ToList<Person>();

            if (temp.Count > 0)
            {

                Console.WriteLine("Your information: \n");
                InOut.PrintToScreen(temp);

                Console.WriteLine("What do you want to update? (enter number of selected option)");
                Console.WriteLine("1. Update name");
                Console.WriteLine("2. Update last name");
                Console.WriteLine("3. Update phone number");
                Console.WriteLine("4. Update address");
                int choice = int.Parse(Console.ReadLine());

                if (choice < 1 || choice > 4)
                {
                    text = "Selected choice does not exist \n ";
                }

                else
                {
                    string updatedInfo = string.Empty;
                    text = string.Empty;
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter new name: ");
                                updatedInfo = Console.ReadLine();
                                peopleList = peopleList.Where(x => x.Name == tempPerson.Name).Select(x => { x.Name = updatedInfo; return x; }).ToList<Person>();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Enter new last name: ");
                                updatedInfo = Console.ReadLine();
                                peopleList = peopleList.Where(x => x.Surname == tempPerson.Surname).Select(x => { x.Surname = updatedInfo; return x; }).ToList<Person>();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Enter new phone number: ");
                                updatedInfo = Console.ReadLine();
                                var tempContact = new Person(tempPerson.Name, tempPerson.Surname, updatedInfo, tempPerson.Address);

                                if (CheckEligibility(tempContact, peopleList))
                                    peopleList = peopleList.Where(x => x.PhoneNumber == tempPerson.PhoneNumber).Select(x => { x.PhoneNumber = updatedInfo; return x; }).ToList<Person>();

                                else
                                    text = "Phone number was not updated because its already exists \n";

                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Enter new address: ");
                                peopleList = peopleList.Where(x => x.Address == tempPerson.Address).Select(x => { x.Address = updatedInfo; return x; }).ToList<Person>();
                                break;
                            }
                    }
                }
            }

            else
            {
                throw new Exception("Contact was not found");
            }
            return peopleList;
        }

        /// <summary>
        /// Deletes selected contact from list
        /// </summary>
        /// <param name="peopleList">Contact's list</param>
        /// <returns>Updated contact's list</returns>
        public static List<Person> DeleteInfo(List<Person> peopleList)
        {
            Console.Clear();
            Person tempPerson = GetInfo();

            if (peopleList.Where(x => x.Name == tempPerson.Name && x.Surname == tempPerson.Surname && x.PhoneNumber == tempPerson.PhoneNumber && x.Address == tempPerson.Address).Any())
            {
                peopleList.RemoveAll(x => x.Name == tempPerson.Name && x.Surname == tempPerson.Surname && x.PhoneNumber == tempPerson.PhoneNumber && x.Address == tempPerson.Address);
            }

           else
            {
                throw new Exception("Contact was not found");
            }

            return peopleList;
        }

        /// <summary>
        /// Creates persons object from given data
        /// </summary>
        /// <returns>Persons object</returns>
        private static Person GetInfo()
        {
            Console.Write("Enter your name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your surname : ");
            string surname = Console.ReadLine();
            Console.Write("Enter your phone number : ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter your address : ");
            string address = Console.ReadLine();

            return new Person(name, surname, phoneNumber, address);
        }

        /// <summary>
        /// Method checks if there are no same contact's phone numbers in list
        /// </summary>
        /// <param name="person">New contact</param>
        /// <param name="peopleList">Contact's list</param>
        /// <returns>True if new contact's phone number was not found in list, otherwise false</returns>
        public static bool CheckEligibility(Person person, List<Person> peopleList)
        {
            if(peopleList.Where(x => x.Name != person.Name && x.Surname != person.Surname && x.PhoneNumber == person.PhoneNumber).Any())
            {
                return false;
            }

            return true;
        }

    }
}
