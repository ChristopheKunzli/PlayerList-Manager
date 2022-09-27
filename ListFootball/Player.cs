using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFootball
{
    public class Player
    {
        #region Private Fields

        private string firstName;
        private string lastName;
        private string phoneNumber;

        #endregion

        public Player(string firstName, string lastName, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
        }


        #region Getters Setters

        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

        #endregion

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
