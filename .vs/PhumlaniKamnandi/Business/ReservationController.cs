// ========== Reservation Controller ==========
using System;
using PhumlaniKamnandi.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhumlaniKamnandi.Business;
using System.Linq;

namespace PhumlaniKamnandi.Business
{
    public class ReservationController
    {
        #region Constructor
        public ReservationController()
        {
            hotelDB = new HotelDB();
            reservations = hotelDB.AllReservations;
        }
        #endregion

        #region Data Members
        HotelDB hotelDB;
        Collection<Reservation> reservations;
        #endregion

        #region Properties
        public Collection<Reservation> AllReservations
        {
            get
            {
                return reservations;
            }
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Reservation aReservation, DB.DBOperation operation)
        {
            int index = 0;
            hotelDB.DataSetChange(new HotelDB.HotelObject(aReservation), operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    reservations.Add(aReservation);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aReservation);
                    reservations[index] = aReservation;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aReservation);
                    reservations.RemoveAt(index);
                    break;
            }

        }

        public bool FinalizeChanges(Reservation reservation)
        {
            return hotelDB.UpdateDataSource(new HotelDB.HotelObject(reservation));
        }
        #endregion

        #region Find Methods
        public Reservation Find(int ID)
        {
            int index = 0;
            bool found = (reservations[index].ReservationID == ID);
            int count = AllReservations.Count;

            while (!(found) && (index < reservations.Count - 1))
            {
                index++;
                found = (reservations[index].ReservationID == ID);
            }


            return AllReservations[index];
        }

        private int FindIndex(Reservation aReservation)
        {
            int counter = 0;
            bool found = false;
            found = (aReservation.ReservationID == reservations[counter].ReservationID);
            while (!found && counter <= reservations.Count)
            {
                counter++;
                found = (aReservation.ReservationID == reservations[counter].ReservationID);
            }
            if (found)
            {
                return counter;
            }
            else
            {
                return -1;
            }
        }
        #endregion

        #region Business Logic Methods
        public List<Reservation> GetActiveReservations()
        {
            return reservations.Where(r => r.Status == "confirmed" || r.Status == "checked_in").ToList();
        }

        public List<Reservation> GetReservationsByDateRange(DateTime startDate, DateTime endDate)
        {
            return reservations.Where(r => 
                r.CheckInDate <= endDate && r.CheckOutDate >= startDate &&
                (r.Status == "confirmed" || r.Status == "checked_in"))
                .ToList();
        }

        public List<Reservation> GetReservationsByBookingIds(List<int> bookingIds)
        {
            return reservations.Where(r => bookingIds.Contains(r.BookingID)).ToList();
        }

        public List<Reservation> SearchReservations(string guestName = null, string bookingId = null)
        {
            var query = reservations.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(bookingId))
            {
                query = query.Where(r => r.BookingID.ToString().Contains(bookingId));
            }

            return query.ToList();
        }

        public decimal CalculateReservationCost(Reservation reservation, decimal nightlyRate = 150.00m)
        {
            var nights = (reservation.CheckOutDate - reservation.CheckInDate).Days;
            return nights * nightlyRate;
        }

        public decimal CalculateDeposit(Reservation reservation, decimal depositPercentage = 0.20m)
        {
            var totalCost = CalculateReservationCost(reservation);
            return totalCost * depositPercentage;
        }
        #endregion
    }
}