// ========== Guest Controller ==========
using System;
using PhumlaniKamnandi.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhumlaniKamnandi.Business;
using System.Linq;

namespace PhumlaniKamnandi.Business
{
    public class GuestController
    {
        #region Constructor
        public GuestController(HotelDB hDB)
        {
            hotelDB = hDB;
            guests = hotelDB.AllGuests ?? new Collection<Guest>();
        }
        #endregion

        #region Data Members
        HotelDB hotelDB;
        Collection<Guest> guests;
        #endregion

        #region Properties
        public Collection<Guest> AllGuests
        {
            get
            {
                return guests;
            }
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Guest aGuest, DB.DBOperation operation)
        {
            int index = 0;
            hotelDB.DataSetChange(new HotelDB.HotelObject(aGuest), operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    guests.Add(aGuest);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aGuest);
                    guests[index] = aGuest;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aGuest);
                    guests.RemoveAt(index);
                    break;
            }

        }

        public bool FinalizeChanges(Guest guest)
        {
            return hotelDB.UpdateDataSource(new HotelDB.HotelObject(guest));
        }
        #endregion

        #region Find Methods

        public Guest Find(int ID)
        {
            if (guests == null || guests.Count == 0)
                return null;

            int index = 0;
            bool found = (guests[index] != null && guests[index].BookingID == ID);
            int count = AllGuests.Count;

            while (!(found) && (index < guests.Count - 1))
            {
                index++;
                found = (guests[index] != null && guests[index].BookingID == ID);
            }

            return found ? AllGuests[index] : null;
        }

        private int FindIndex(Guest aGst)
        {
            if (guests == null || guests.Count == 0 || aGst == null)
                return -1;

            HotelDB.HotelObject aGuest = new HotelDB.HotelObject(aGst);
            int counter = 0;
            bool found = false;
            found = (guests[counter] != null && aGuest.AsGuest.BookingID == guests[counter].BookingID);
            while (!found && counter < guests.Count - 1)
            {
                counter++;
                found = (guests[counter] != null && aGuest.AsGuest.BookingID == guests[counter].BookingID);
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

        #region Search Methods
        public List<Guest> SearchGuests(string searchTerm)
        {
            if (guests == null) return new List<Guest>();
            
            if (string.IsNullOrWhiteSpace(searchTerm))
                return guests.Where(g => g != null).ToList();

            searchTerm = searchTerm.ToLower().Trim();
            return guests.Where(g => g != null &&
                (g.Name != null && g.Name.ToLower().Contains(searchTerm)) ||
                (g.Telephone != null && g.Telephone.Contains(searchTerm)) ||
                (g.AddressLine1 != null && g.AddressLine1.ToLower().Contains(searchTerm)))
                .ToList();
        }

        public Guest FindByGuestId(int guestId)
        {
            if (guests == null) return null;
            return guests.FirstOrDefault(g => g != null && g.GuestID == guestId);
        }

        public List<Guest> GetGuestsByBookingIds(List<int> bookingIds)
        {
            if (guests == null || bookingIds == null) return new List<Guest>();
            return guests.Where(g => g != null && bookingIds.Contains(g.BookingID)).ToList();
        }
        #endregion
    }
}