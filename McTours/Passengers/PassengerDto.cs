using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Passengers
{
    public class PassengerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string DateOf
        {
            get
            {
                return $"{DateOfBirth.Day}/{DateOfBirth.Month}/{DateOfBirth.Year}";
            }
        }

        public Gender Gender { get; set; }

        //public string GenderName
        //{
        //    get
        //    {
        //        return EnumHelper.GenderName.ContainsKey(Gender) ? EnumHelper.GenderName[Gender] : string.Empty;


        //    }
        //}
    }
}
