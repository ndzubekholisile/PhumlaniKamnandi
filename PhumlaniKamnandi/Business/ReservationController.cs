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
        public ReservationController(HotelDB hDB)
        {
            hotelDB = hDB;
            reservations = hotelDB.AllReservations ?? new Collection<Reservation>();
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
            if (reservations == null || reservations.Count == 0)
                return null;

            int index = 0;
            bool found = (reservations[index] != null && reservations[index].ReservationID == ID);
            int count = AllReservations.Count;

            while (!(found) && (index < reservations.Count - 1))
            {
                index++;
                found = (reservations[index] != null && reservations[index].ReservationID == ID);
            }

            return found ? AllReservations[index] : null;
        }

        private int FindIndex(Reservation aReservation)
        {
            if (reservations == null || reservations.Count == 0 || aReservation == null)
                return -1;

            int counter = 0;
            bool found = false;
            found = (reservations[counter] != null && aReservation.ReservationID == reservations[counter].ReservationID);
            while (!found && counter < reservations.Count - 1)
            {
                counter++;
                found = (reservations[counter] != null && aReservation.ReservationID == reservations[counter].ReservationID);
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
            if (reservations == null) return new List<Reservation>();
            return reservations.Where(r => r != null && r.Status != null && 
                                     (r.Status == "confirmed" || r.Status == "checked_in")).ToList();
        }

        public List<Reservation> GetReservationsByDateRange(DateTime startDate, DateTime endDate)
        {
            if (reservations == null) return new List<Reservation>();
            return reservations.Where(r => r != null && r.Status != null &&
                r.CheckInDate <= endDate && r.CheckOutDate >= startDate &&
                (r.Status == "confirmed" || r.Status == "checked_in"))
                .ToList();
        }

        public List<Reservation> GetReservationsByBookingIds(List<int> bookingIds)
        {
            if (reservations == null || bookingIds == null) return new List<Reservation>();
            return reservations.Where(r => r != null && bookingIds.Contains(r.BookingID)).ToList();
        }

        public List<Reservation> SearchReservations(string guestName = null, string bookingId = null)
        {
            if (reservations == null) return new List<Reservation>();
            var query = reservations.Where(r => r != null).AsEnumerable();

            if (!string.IsNullOrWhiteSpace(bookingId))
            {
                query = query.Where(r => r.BookingID.ToString().Contains(bookingId));
            }

            return query.ToList();
        }

        public decimal CalculateReservationCost(Reservation reservation, decimal nightlyRate = 150.00m)
        {
            if (reservation == null) return 0;
            var nights = (reservation.CheckOutDate - reservation.CheckInDate).Days;
            return nights * nightlyRate;
        }

        public decimal CalculateDeposit(Reservation reservation, decimal depositPercentage = 0.20m)
        {
            if (reservation == null) return 0;
            var totalCost = CalculateReservationCost(reservation);
            return totalCost * depositPercentage;
        }
        #endregion
    }
}