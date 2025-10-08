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
            rooms = hotelDB.AllRooms ?? new Collection<Room>();
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
            if (rooms == null || rooms.Count == 0)
                return null;

            int index = 0;
            bool found = (rooms[index] != null && rooms[index].RoomID == ID);
            int count = AllRooms.Count;

            while (!(found) && (index < rooms.Count - 1))
            {
                index++;
                found = (rooms[index] != null && rooms[index].RoomID == ID);
            }

            return found ? AllRooms[index] : null;
        }

        private int FindIndex(Room aRoom)
        {
            if (rooms == null || rooms.Count == 0 || aRoom == null)
                return -1;

            int counter = 0;
            bool found = false;
            found = (rooms[counter] != null && aRoom.RoomID == rooms[counter].RoomID);
            while (!found && counter < rooms.Count - 1)
            {
                counter++;
                found = (rooms[counter] != null && aRoom.RoomID == rooms[counter].RoomID);
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
            if (rooms == null) return new List<Room>();
            return rooms.Where(r => r != null && !r.IsOccupied).ToList();
        }

        public List<Room> GetOccupiedRooms()
        {
            if (rooms == null) return new List<Room>();
            return rooms.Where(r => r != null && r.IsOccupied).ToList();
        }

        public int GetAvailableRoomCount()
        {
            if (rooms == null) return 0;
            return rooms.Count(r => r != null && !r.IsOccupied);
        }

        public double GetOccupancyPercentage()
        {
            if (rooms == null) return 0;
            var totalRooms = rooms.Count;
            if (totalRooms == 0) return 0;
            
            var occupiedRooms = rooms.Count(r => r != null && r.IsOccupied);
            return (occupiedRooms * 100.0) / totalRooms;
        }

        public List<Room> GetRoomsBySuiteType(string suiteType)
        {
            if (rooms == null || string.IsNullOrWhiteSpace(suiteType)) return new List<Room>();
            return rooms.Where(r => r != null && r.SuiteType != null && 
                              r.SuiteType.Equals(suiteType, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        #endregion
    }
}