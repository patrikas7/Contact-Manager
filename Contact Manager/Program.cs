using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manger
{
    class Program
    {
        /// <summary>
        /// Main method which interacts with user and fulfill users selected options
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool Exit = false;
            List<Person> PeopleList = InOut.ReadContacts();
            while (!Exit)
            {
                int choice = 0;
                Console.WriteLine("Contact manager \n");
                Console.WriteLine("Choose what you want to do: (enter number of selected option)");
                Console.WriteLine("1. Add contact");
                Console.WriteLine("2. Update contact information");
                Console.WriteLine("3. Delete contact");
                Console.WriteLine("4. View all contacts");
                Console.WriteLine("5. Exit and save");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice < 1 || choice > 5)
                        throw new Exception();
                }

                catch
                {
                    Console.Clear();
                    Console.WriteLine("Selected choice does not exist \n ");
                }

                switch (choice)
                {
                    case 1:
                        {
                            try
                            {
                                var person = TaskUtils.CreatePerson();
                                if (TaskUtils.CheckEligibility(person, PeopleList))
                                {
                                    PeopleList.Add(person);
                                    Console.Clear();
                                    Console.WriteLine("Contact was created successfuly! \n");
                                }

                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Contact was not created because person with declared phone number already exists \n");
                                }
                            }
                            catch(Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                string text = string.Empty;
                                TaskUtils.UpdateInfo(PeopleList, out text);
                                Console.Clear();
                                if (text == string.Empty)
                                    Console.WriteLine("Contact was updated successfuly! \n");

                                else
                                    Console.WriteLine(text);
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case 3:
                        {
                            try
                            {
                                TaskUtils.DeleteInfo(PeopleList);
                                Console.Clear();
                                Console.WriteLine("Contact was deleted successfuly! \n");
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case 4:
                        {
                            try
                            {
                                Console.Clear();
                                InOut.PrintToScreen(PeopleList);
                            }
                            catch (Exception ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex.Message);
                            }

                            break;
                        }

                    case 5:
                        {
                            InOut.PrintToCsv(PeopleList);
                            Exit = true;
                            break;
                        }
                }
            }
        }
    }
}
