
// ========== Reservation ==========
using System;

namespace PhumlaniKamnandi.Business
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int BookingID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; }   // unconfirmed, cancelled, confirmed
        public DateTime DateBooked { get; set; }
        

        public Reservation() { }

        public Reservation(int bookingId, DateTime checkIn, DateTime checkOut, string status, DateTime dateBooked)
        {
            BookingID = bookingId;
            CheckInDate = checkIn;
            CheckOutDate = checkOut;
            Status = status;
            DateBooked = dateBooked;
        }


        
    }
}