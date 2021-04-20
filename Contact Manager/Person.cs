using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manger
{
    /// <summary>
    /// Persons constructor class
    /// </summary>
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        /// <summary>
        /// Generates object
        /// </summary>
        /// <param name="name">Contact's name</param>
        /// <param name="surname">Contact's surname</param>
        /// <param name="phoneNumber">Contact's phone nuber</param>
        /// <param name="address">Contact's address</param>
        public Person(string name, string surname, string phoneNumber, string address)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Address = address;
        }
        public override string ToString()
        {
            return string.Format($"|{Name,-15} |{Surname,-15} |{PhoneNumber,-15} |{Address,-20} |");
        }

        public string ToCsv()
        {
            return string.Format("{0};{1};{2};{3};",Name,Surname,PhoneNumber,Address);
        }
    }
}
