// ========== Guest ==========
using System;

namespace PhumlaniKamnandi.Business
{
    public class Guest
    {
        public int GuestID { get; set; }
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public DateTime DateBooked { get; set; }

        public Guest() { BookingID = -1; }

        public Guest(int bookingId, string name, string telephone, string addressLine1, string addressLine2, string postalCode, DateTime dateBooked)
        {
            BookingID = bookingId;
            Name = name;
            Telephone = telephone;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            PostalCode = postalCode;
            DateBooked = dateBooked;
        }
    }
}