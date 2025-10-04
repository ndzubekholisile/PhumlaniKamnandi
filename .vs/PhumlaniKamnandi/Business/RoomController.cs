// ========== Room Controller ==========
using System;
using PhumlaniKamnandi.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhumlaniKamnandi.Business;


namespace PhumlaKamnandi.Business
{
    public class RoomController
    {
        #region Constructor
        public RoomController()
        {
            hotelDB = new HotelDB();
            rooms = hotelDB.AllRooms;
        }
        #endregion

        #region Data Members
        HotelDB hotelDB;
        Collection<Room> rooms;
        #endregion

        #region Properties
        public Collection<Room> AllRooms
        {
            get
            {
                return rooms;
            }
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Room aRoom, DB.DBOperation operation)
        {
            int index = 0;
            hotelDB.DataSetChange(new HotelDB.HotelObject(aRoom), operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    rooms.Add(aRoom);
                    break;
                case DB.DBOperation.Edit:
                    index = FindIndex(aRoom);
                    rooms[index] = aRoom;
                    break;
                case DB.DBOperation.Delete:
                    index = FindIndex(aRoom);
                    rooms.RemoveAt(index);
                    break;
            }

        }

        public bool FinalizeChanges(Room room)
        {
            return hotelDB.UpdateDataSource(new HotelDB.HotelObject(room));
        }
        #endregion

        #region Find Methods

        public Room Find(int ID)
        {
            int index = 0;
            bool found = (rooms[index].RoomID == ID);
            int count = AllRooms.Count;

            while (!(found) && (index < rooms.Count - 1))
            {
                index++;
                found = (rooms[index].RoomID == ID);
            }


            return AllRooms[index];
        }

        private int FindIndex(Room aRoom)
        {
            int counter = 0;
            bool found = false;
            found = (aRoom.RoomID == rooms[counter].RoomID);
            while (!found && counter <= rooms.Count)
            {
                counter++;
                found = (aRoom.RoomID == rooms[counter].RoomID);
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