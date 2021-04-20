using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manger
{
    class InOut
    {

        /// <summary>
        /// Reads all the date from file and puts it into list
        /// </summary>
        /// <returns>List of contact's</returns>
        public static List<Person> ReadContacts()
        {
            string FileName = "Data.csv";
            List<Person> peopleList = new List<Person>();
            string[] lines = File.ReadAllLines(FileName);

            if (lines.Length > 1)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(';');
                    string name = values[0];
                    string surname = values[1];
                    string phone = values[2];
                    string address = values[3];

                    peopleList.Add(new Person(name, surname, phone, address));
                }
            }

            return peopleList;
        }


        /// <summary>
        /// Prints data to csv file
        /// </summary>
        /// <param name="peopleList">Contact's list</param>
        public static void PrintToCsv(List<Person> peopleList)
        {
            var csv = new StringBuilder();
            csv.AppendLine(string.Format("{0};{1};{2};{3};", "Name", "Surname", "Phone number", "Address"));

            for (int i = 0; i < peopleList.Count; i++)
            {
                csv.AppendLine(peopleList[i].ToCsv());
            }

            File.WriteAllText("Data.csv", csv.ToString());
        }


        /// <summary>
        /// Prints contact's list into console 
        /// </summary>
        /// <param name="peopleList">Contact's list</param>
        public static void PrintToScreen(List<Person> peopleList)
        {
            if (peopleList.Count > 0)
            {
                Console.WriteLine(new string('-', 74));
                Console.WriteLine(string.Format("|{0,-15} |{1, -15} |{2,-15} |{3, -20} |", "Name", "Surname", "Phone number", "Address"));
                Console.WriteLine(new string('-', 74));
                for (int i = 0; i < peopleList.Count; i++)
                {
                    Console.WriteLine(peopleList[i].ToString());
                }
                Console.WriteLine(new string('-', 74), "\n");
            }
            else
            {
                throw new Exception("No contact's found");
            }
        }
    }
}
