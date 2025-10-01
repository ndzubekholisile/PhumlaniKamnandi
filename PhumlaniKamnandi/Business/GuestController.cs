// ========== Guest Controller ==========
using System;

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
            hotelDB.DataSetChange(aGuest, operation);

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
            return hotelDB.UpdateDataSource(guest);
        }
        #endregion

        #region Find Methods

        public Guest Find(string ID)
        {
            int index = 0;
            bool found = (guests[index].bookingID == ID);
            int count = AllGuests.Count;

            while (!(found) && (index < guests.Count - 1))
            {
                index++;
                found = (guests[index].bookingID == ID);
            }


            return AllGuests[index];
        }

        private int FindIndex(Guest aGuest)
        {
            int counter = 0;
            bool found = false;
            found = (aGuest.bookingID == guests[counter].bookingID);
            while (!found && counter <= guests.Count)
            {
                counter++;
                found = (aGuest.bookingID == guests[counter].bookingID);
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