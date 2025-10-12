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

        // Multi-guest support properties
        private List<Guest> _guests;
        public List<Guest> Guests 
        { 
            get { return _guests ?? (_guests = new List<Guest>()); }
            set { _guests = value; }
        }

        public Booker() 
        {
            _guests = new List<Guest>();
        }

        public Booker(int numOfPeopleExpected)
        {
            NumOfPeopleExpected = numOfPeopleExpected;
            _guests = new List<Guest>();
        }

        // Multi-guest helper methods
        public void AddGuest(Guest guest)
        {
            if (guest != null)
            {
                guest.BookingID = this.BookingID;
                Guests.Add(guest);
            }
        }

        public void RemoveGuest(Guest guest)
        {
            if (guest != null)
            {
                Guests.Remove(guest);
            }
        }

        public void RemoveGuestAt(int index)
        {
            if (index >= 0 && index < Guests.Count)
            {
                Guests.RemoveAt(index);
            }
        }

        public Guest GetPrimaryGuest()
        {
            return Guests.FirstOrDefault();
        }

        public int GetGuestCount()
        {
            return Guests.Count;
        }

        public bool HasGuests()
        {
            return Guests.Count > 0;
        }

        public void UpdateNumOfPeopleExpected()
        {
            NumOfPeopleExpected = Guests.Count;
        }

        public override string ToString()
        {
            return $"BookingID: {BookingID}, NumOfPeopleExpected: {NumOfPeopleExpected}, Guests: {Guests.Count}";
        }
    }
}
