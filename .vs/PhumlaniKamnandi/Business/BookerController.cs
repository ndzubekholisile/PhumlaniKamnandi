// ========== Booker Controller ==========
using System;
using PhumlaniKamnandi.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhumlaniKamnandi.Business;

namespace PhumlaKamnandi.Business
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
    }
}