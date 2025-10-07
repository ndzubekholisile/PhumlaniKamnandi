// ========== Booker Controller ==========
using System;
using PhumlaniKamnandi.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhumlaniKamnandi.Business;
using System.Linq;

namespace PhumlaniKamnandi.Business
{
    public class BookerController
    {
        #region Constructor
        public BookerController()
        {
            hotelDB = new HotelDB();
            bookers = hotelDB.AllBookers;
        }
        #endregion

        #region Data Members
        HotelDB hotelDB;
        Collection<Booker> bookers;
        #endregion

        #region Properties
        public Collection<Booker> AllBookers
        {
            get
            {
                return bookers;
            }
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Booker aBooker, DB.DBOperation operation)
        {
            int index = 0;
            hotelDB.DataSetChange(new HotelDB.HotelObject(aBooker), operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    bookers.Add(aBooker);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aBooker);
                    bookers[index] = aBooker;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aBooker);
                    bookers.RemoveAt(index);
                    break;
            }

        }

        public bool FinalizeChanges(Booker booker)
        {
            return hotelDB.UpdateDataSource(new HotelDB.HotelObject(booker));
        }
        #endregion

        #region Find Methods
        public Booker Find(int ID)
        {
            int index = 0;
            bool found = (bookers[index].BookingID == ID);
            int count = AllBookers.Count;

            while (!(found) && (index < bookers.Count - 1))
            {
                index++;
                found = (bookers[index].BookingID == ID);
            }


            return AllBookers[index];
        }

        private int FindIndex(Booker aBooker)
        {
            int counter = 0;
            bool found = false;
            found = (aBooker.BookingID == bookers[counter].BookingID);
            while (!found && counter <= bookers.Count)
            {
                counter++;
                found = (aBooker.BookingID == bookers[counter].BookingID);
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

        #region Enhanced Booking Operations
        private GuestController guestController;
        private ReservationController reservationController;

        private void InitializeControllers()
        {
            if (guestController == null)
                guestController = new GuestController();
            if (reservationController == null)
                reservationController = new ReservationController();
        }

        public class BookingViewModel
        {
            public int ReservationID { get; set; }
            public int BookingID { get; set; }
            public string GuestName { get; set; }
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public string Status { get; set; }
            public DateTime DateBooked { get; set; }
            public string CheckIn => CheckInDate.ToShortDateString();
            public string CheckOut => CheckOutDate.ToShortDateString();
            public string DateBookedString => DateBooked.ToShortDateString();
        }

        public List<BookingViewModel> GetAllBookingsWithGuestInfo()
        {
            InitializeControllers();
            var reservations = reservationController.AllReservations;
            var guests = guestController.AllGuests;

            return reservations.Join(
                guests,
                r => r.BookingID,
                g => g.BookingID,
                (r, g) => new BookingViewModel
                {
                    ReservationID = r.ReservationID,
                    BookingID = r.BookingID,
                    GuestName = g.Name,
                    CheckInDate = r.CheckInDate,
                    CheckOutDate = r.CheckOutDate,
                    Status = r.Status,
                    DateBooked = r.DateBooked
                }).ToList();
        }

        public List<BookingViewModel> SearchBookings(string guestName = null, string bookingId = null)
        {
            var allBookings = GetAllBookingsWithGuestInfo();

            if (!string.IsNullOrWhiteSpace(guestName))
            {
                allBookings = allBookings.Where(b => 
                    b.GuestName.ToLower().Contains(guestName.ToLower())).ToList();
            }

            if (!string.IsNullOrWhiteSpace(bookingId))
            {
                allBookings = allBookings.Where(b => 
                    b.BookingID.ToString().Contains(bookingId)).ToList();
            }

            return allBookings;
        }

        public bool CreateBooking(Guest guest, Reservation reservation)
        {
            InitializeControllers();
            try
            {
                // Add guest first
                guestController.DataMaintenance(guest, DB.DBOperation.Add);
                if (!guestController.FinalizeChanges(guest))
                    return false;

                // Add reservation
                reservationController.DataMaintenance(reservation, DB.DBOperation.Add);
                return reservationController.FinalizeChanges(reservation);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateBooking(Guest guest, Reservation reservation)
        {
            InitializeControllers();
            try
            {
                // Update guest
                guestController.DataMaintenance(guest, DB.DBOperation.Edit);
                if (!guestController.FinalizeChanges(guest))
                    return false;

                // Update reservation
                reservationController.DataMaintenance(reservation, DB.DBOperation.Edit);
                return reservationController.FinalizeChanges(reservation);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CancelBooking(int reservationId)
        {
            InitializeControllers();
            try
            {
                var reservation = reservationController.Find(reservationId);
                if (reservation == null) return false;

                reservation.Status = "cancelled";
                reservationController.DataMaintenance(reservation, DB.DBOperation.Edit);
                return reservationController.FinalizeChanges(reservation);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Report Generation
        public System.Data.DataTable GenerateOccupancyReport(DateTime startDate, DateTime endDate)
        {
            InitializeControllers();
            var roomController = new RoomController();
            var dt = new System.Data.DataTable();
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Occupied Rooms", typeof(int));
            dt.Columns.Add("Total Rooms", typeof(int));
            dt.Columns.Add("Occupancy %", typeof(string));

            var totalRooms = roomController.AllRooms.Count;
            var allReservations = reservationController.AllReservations;

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                var occupiedRooms = allReservations
                    .Count(r => r.CheckInDate <= date && r.CheckOutDate > date &&
                               (r.Status == "confirmed" || r.Status == "checked_in"));

                var occupancyPercent = totalRooms > 0 ? (occupiedRooms * 100.0) / totalRooms : 0;

                dt.Rows.Add(
                    date.ToShortDateString(),
                    occupiedRooms,
                    totalRooms,
                    $"{occupancyPercent:F1}%"
                );
            }

            return dt;
        }

        public System.Data.DataTable GenerateRevenueReport(int year, int month)
        {
            InitializeControllers();
            var dt = new System.Data.DataTable();
            dt.Columns.Add("Week", typeof(string));
            dt.Columns.Add("Bookings", typeof(int));
            dt.Columns.Add("Revenue", typeof(decimal));
            dt.Columns.Add("Average per Booking", typeof(decimal));

            var startOfMonth = new DateTime(year, month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            var allReservations = reservationController.AllReservations;

            for (int week = 1; week <= 5; week++)
            {
                var weekStart = startOfMonth.AddDays((week - 1) * 7);
                var weekEnd = weekStart.AddDays(6);

                if (weekEnd > endOfMonth) weekEnd = endOfMonth;

                var weekBookings = allReservations
                    .Where(r => r.DateBooked >= weekStart && r.DateBooked <= weekEnd &&
                               r.Status != "cancelled")
                    .ToList();

                var totalRevenue = weekBookings.Sum(r => reservationController.CalculateReservationCost(r));
                var avgPerBooking = weekBookings.Count > 0 ? totalRevenue / weekBookings.Count : 0;

                dt.Rows.Add(
                    $"Week {week}",
                    weekBookings.Count,
                    totalRevenue,
                    avgPerBooking
                );
            }

            return dt;
        }
        #endregion
    }
}