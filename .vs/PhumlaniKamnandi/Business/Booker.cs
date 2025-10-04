using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaniKamnandi.Business
{
    public class Booker
    {
        public int BookingID { get; set; }   // Primary Key (IDENTITY)
        public int NumOfPeopleExpected { get; set; }

        public Booker() { }

        public Booker(int numOfPeopleExpected)
        {
            NumOfPeopleExpected = numOfPeopleExpected;
        }

        public override string ToString()
        {
            return $"BookingID: {BookingID}, NumOfPeopleExpected: {NumOfPeopleExpected}";
        }
    }
}
