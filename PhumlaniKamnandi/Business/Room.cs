using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaniKamnandi.Business
{



    // ========== Rooms ==========
    public class Room
    {
        public int RoomID { get; set; }
        public int AccountID { get; set; }
        public bool IsOccupied { get; set; }
        public string SuiteType { get; set; }   // standard, deluxe


        public Room() { }

        public Room(int accountId, bool isOccupied, string suiteType)
        {
            AccountID = accountId;
            IsOccupied = isOccupied;
            SuiteType = suiteType;
        }
        


    }
}

