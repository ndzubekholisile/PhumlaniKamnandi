// ========== Room Account Controller ==========
using System;
using PhumlaniKamnandi.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhumlaniKamnandi.Business;
using System.Linq;

namespace PhumlaniKamnandi.Business
{
    public class RoomAccountController
    {
        #region Constructor
        public RoomAccountController()
        {
            hotelDB = new HotelDB();
            roomaccounts = hotelDB.AllRoomAccounts ?? new Collection<RoomAccount>();
        }
        #endregion

        #region Data Members
        HotelDB hotelDB;
        Collection<RoomAccount> roomaccounts;
        #endregion

        #region Properties
        public Collection<RoomAccount> AllRoomAccounts
        {
            get
            {
                return roomaccounts;
            }
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(RoomAccount aRoomAccount, DB.DBOperation operation)
        {
            int index = 0;
            hotelDB.DataSetChange(new HotelDB.HotelObject(aRoomAccount), operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    roomaccounts.Add(aRoomAccount);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aRoomAccount);
                    roomaccounts[index] = aRoomAccount;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aRoomAccount);
                    roomaccounts.RemoveAt(index);
                    break;
            }

        }

        public bool FinalizeChanges(RoomAccount roomaccount)
        {
            return hotelDB.UpdateDataSource(new HotelDB.HotelObject(roomaccount));
        }
        #endregion

        #region Find Methods
        public RoomAccount Find(int ID)
        {
            if (roomaccounts == null || roomaccounts.Count == 0)
                return null;

            int index = 0;
            bool found = (roomaccounts[index] != null && roomaccounts[index].AccountID == ID);
            int count = AllRoomAccounts.Count;

            while (!(found) && (index < roomaccounts.Count - 1))
            {
                index++;
                found = (roomaccounts[index] != null && roomaccounts[index].AccountID == ID);
            }

            return found ? AllRoomAccounts[index] : null;
        }

        private int FindIndex(RoomAccount aRoomAccount)
        {
            if (roomaccounts == null || roomaccounts.Count == 0 || aRoomAccount == null)
                return -1;

            int counter = 0;
            bool found = false;
            found = (roomaccounts[counter] != null && aRoomAccount.AccountID == roomaccounts[counter].AccountID);
            while (!found && counter < roomaccounts.Count - 1)
            {
                counter++;
                found = (roomaccounts[counter] != null && aRoomAccount.AccountID == roomaccounts[counter].AccountID);
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