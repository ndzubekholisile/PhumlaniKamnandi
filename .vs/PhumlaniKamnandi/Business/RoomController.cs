// ========== Room Controller ==========
using System;
using PhumlaniKamnandi.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PhumlaniKamnandi.Business;
using System.Linq;

namespace PhumlaniKamnandi.Business
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

        #region Availability Methods
        public List<Room> GetAvailableRooms()
        {
            return rooms.Where(r => !r.IsOccupied).ToList();
        }

        public List<Room> GetOccupiedRooms()
        {
            return rooms.Where(r => r.IsOccupied).ToList();
        }

        public int GetAvailableRoomCount()
        {
            return rooms.Count(r => !r.IsOccupied);
        }

        public double GetOccupancyPercentage()
        {
            var totalRooms = rooms.Count;
            if (totalRooms == 0) return 0;
            
            var occupiedRooms = rooms.Count(r => r.IsOccupied);
            return (occupiedRooms * 100.0) / totalRooms;
        }

        public List<Room> GetRoomsBySuiteType(string suiteType)
        {
            return rooms.Where(r => r.SuiteType.Equals(suiteType, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        #endregion
    }
}