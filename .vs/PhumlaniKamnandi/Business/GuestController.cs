// ========== Guest Controller ==========
using System;
using PhumlaniKamnandi.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhumlaniKamnandi.Business;


namespace PhumlaKamnandi.Business
{
    public class GuestController
    {
        #region Constructor
        public GuestController()
        {
            hotelDB = new HotelDB();
            guests = hotelDB.AllGuests;
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
            int index = 0;
            bool found = (guests[index].BookingID == ID);
            int count = AllGuests.Count;

            while (!(found) && (index < guests.Count - 1))
            {
                index++;
                found = (guests[index].BookingID == ID);
            }


            return AllGuests[index];
        }

        private int FindIndex(Guest aGst)
        {
            HotelDB.HotelObject aGuest = new HotelDB.HotelObject(aGst);
            int counter = 0;
            bool found = false;
            found = (aGuest.AsGuest.BookingID == guests[counter].BookingID);
            while (!found && counter <= guests.Count)
            {
                counter++;
                found = (aGuest.AsGuest.BookingID == guests[counter].BookingID);
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
    }
}