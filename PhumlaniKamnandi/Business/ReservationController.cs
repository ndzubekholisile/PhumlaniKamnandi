// ========== Reservation Controller ==========
using System;

namespace PhumlaKamnandi.Business
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
            hotelDB.DataSetChange(aReservation, operation);

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
            return hotelDB.UpdateDataSource(reservation);
        }
        #endregion

        #region Find Methods
        public Reservation Find(string ID)
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
    }
}