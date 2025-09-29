using PhumlaniKamnandi.Business;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhumlaniKamnandi.Data
{
    internal class HotelDB:DB
    {
        // Booker
        private const string table1 = "Booker";
        private const string sqlLocal1 = "SELECT * FROM Booker";

        // RoomAccount
        private const string table2 = "RoomAccount";
        private const string sqlLocal2 = "SELECT * FROM RoomAccount";

        // Rooms
        private const string table3 = "Rooms";
        private const string sqlLocal3 = "SELECT * FROM Rooms";

        // Reservation
        private const string table4 = "Reservation";
        private const string sqlLocal4 = "SELECT * FROM Reservation";

        // Guest
        private const string table5 = "Guest";
        private const string sqlLocal5 = "SELECT * FROM Guest";

        // Employee
        private const string table6 = "Employee";
        private const string sqlLocal6 = "SELECT * FROM Employee";



        private Collection<Booker> bookers;
        private Collection<Reservation> reservations;
        private Collection<RoomAccount> roomAccounts;
        private Collection<Room> rooms;
        private Collection<Employee> employees;
        private Collection<Guest> guests;

        public Collection<Booker> AllBookers => bookers;
        public Collection<Reservation> AllReservations => reservations;
        public Collection<RoomAccount> AllRoomAccounts => roomAccounts;
        public Collection<Room> AllRooms => rooms;
        public Collection<Employee> AllEmployees => employees;
        public Collection<Guest> AllGuests => guests;



        public struct HotelObject
        {
            private readonly object value;

            public enum HotelObjectType
            {
                None,
                Booker,
                Reservation,
                RoomAccount,
                Room,
                Employee,
                Guest
            }

            public HotelObjectType Type { get; }

            // Constructors
            public HotelObject(Booker b)
            {
                value = b;
                Type = HotelObjectType.Booker;
            }

            public HotelObject(Reservation r)
            {
                value = r;
                Type = HotelObjectType.Reservation;
            }

            public HotelObject(RoomAccount ra)
            {
                value = ra;
                Type = HotelObjectType.RoomAccount;
            }

            public HotelObject(Room room)
            {
                value = room;
                Type = HotelObjectType.Room;
            }

            public HotelObject(Employee e)
            {
                value = e;
                Type = HotelObjectType.Employee;
            }

            public HotelObject(Guest g)
            {
                value = g;
                Type = HotelObjectType.Guest;
            }

            // Accessors (safe casts)
            public Booker AsBooker => Type == HotelObjectType.Booker ? (Booker)value : null;
            public Reservation AsReservation => Type == HotelObjectType.Reservation ? (Reservation)value : null;
            public RoomAccount AsRoomAccount => Type == HotelObjectType.RoomAccount ? (RoomAccount)value : null;
            public Room AsRoom => Type == HotelObjectType.Room ? (Room)value : null;
            public Employee AsEmployee => Type == HotelObjectType.Employee ? (Employee)value : null;
            public Guest AsGuest => Type == HotelObjectType.Guest ? (Guest)value : null;

            public override string ToString()
            {
                return $"{Type}: {value}";
            }
        }


        public HotelDB():base() {
            bookers = new Collection<Booker>();
            reservations = new Collection<Reservation>();
            roomAccounts = new Collection<RoomAccount>();
            rooms = new Collection<Room>();
            employees = new Collection<Employee>();
            guests = new Collection<Guest>();

            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);
            FillDataSet(sqlLocal2, table2);
            Add2Collection(table2);
            FillDataSet(sqlLocal3, table3);
            Add2Collection(table3);
            FillDataSet(sqlLocal4, table4);
            Add2Collection(table4);
            FillDataSet(sqlLocal5, table5);
            Add2Collection(table5);
            FillDataSet(sqlLocal6, table6);
            Add2Collection(table6);
        }


        #region Utility Methods

        public void Add2Collection(string atable)
        {
            DataRow myRow;

            Booker aBooker;
            RoomAccount aRoomAccount;
            Room aRoom;
            Reservation aReservation;
            Guest aGuest;
            Employee anEmp;
            
            //implementation coming!
            foreach (DataRow myRow_loopVariable in dsMain.Tables[atable].Rows)
            {
                myRow = myRow_loopVariable;

                //If the employee entry has not been deleted from the database then Add it to collection
                if (myRow.RowState != DataRowState.Deleted)
                {
                    switch (atable)
                    {
                        case table1: // Booker
                            aBooker = new Booker
                            {
                                BookingID = Convert.ToInt32(myRow["bookingID"]),
                                NumOfPeopleExpected = Convert.ToInt32(myRow["num_of_people_expected"])
                            };
                            AllBookers.Add(aBooker);
                            break;

                        case table2: // RoomAccount
                            aRoomAccount = new RoomAccount
                            {
                                AccountID = Convert.ToInt32(myRow["accountID"]),
                                Balance = Convert.ToDecimal(myRow["balance"]),
                                Status = Convert.ToString(myRow["status"]).TrimEnd()
                            };
                            AllRoomAccounts.Add(aRoomAccount);
                            break;

                        case table3: // Rooms
                            aRoom = new Room
                            {
                                RoomID = Convert.ToInt32(myRow["roomID"]),
                                AccountID = Convert.ToInt32(myRow["accountID"]),
                                IsOccupied = Convert.ToBoolean(myRow["isOccupied"]),
                                SuiteType = Convert.ToString(myRow["suiteType"]).TrimEnd()
                            };
                            AllRooms.Add(aRoom);
                            break;

                        case table4: // Reservation
                            aReservation = new Reservation
                            {
                                ReservationID = Convert.ToInt32(myRow["reservationID"]),
                                BookingID = Convert.ToInt32(myRow["bookingID"]),
                                CheckInDate = Convert.ToDateTime(myRow["check_in_date"]),
                                CheckOutDate = Convert.ToDateTime(myRow["check_out_date"]),
                                Status = Convert.ToString(myRow["status"]).TrimEnd(),
                                DateBooked = Convert.ToDateTime(myRow["date_booked"])
                            };
                            AllReservations.Add(aReservation);
                            break;

                        case table5: // Guest
                            aGuest = new Guest
                            {
                                GuestID = Convert.ToInt32(myRow["guestID"]),
                                BookingID = Convert.ToInt32(myRow["bookingID"]),
                                Name = Convert.ToString(myRow["name"]).TrimEnd(),
                                Telephone = Convert.ToString(myRow["telephone"]).TrimEnd(),
                                AddressLine1 = Convert.ToString(myRow["addressLine1"]).TrimEnd(),
                                AddressLine2 = Convert.ToString(myRow["addressLine2"]).TrimEnd(),
                                PostalCode = Convert.ToString(myRow["postalCode"]).TrimEnd(),
                                DateBooked = Convert.ToDateTime(myRow["date_booked"])
                            };
                            AllGuests.Add(aGuest);
                            break;

                        case table6: // Employee
                            anEmp = new Employee
                            {
                                EmpID = Convert.ToInt32(myRow["empID"]),
                                Name = Convert.ToString(myRow["name"]).TrimEnd(),
                                Role = Convert.ToString(myRow["role"]).TrimEnd(),
                                Username = Convert.ToString(myRow["username"]).TrimEnd(),
                                Password = Convert.ToString(myRow["password"]).TrimEnd()
                            };
                            AllEmployees.Add(anEmp);
                            break;
                    }

                }
            }
            }

        /// <summary>
        /// Populates a <see cref="DataRow"/> with values from a given <see cref="HotelObject"/>.  
        /// The method inspects the <see cref="HotelObject.Type"/> to determine which underlying  
        /// entity (Booker, Reservation, RoomAccount, Room, Employee, Guest) is wrapped, and  
        /// maps its properties into the corresponding columns of the <paramref name="aRow"/>.  
        /// If the <see cref="HotelObject"/> type does not match the expected table schema,  
        /// the row remains unchanged.
        /// </summary>
        public void FillRow(DataRow aRow, HotelObject hotel_obj)
        {
            if (hotel_obj.Type == HotelObject.HotelObjectType.None) throw new ArgumentException("Unsupported type", nameof(hotel_obj.Type));
            switch (hotel_obj.Type)
            {
                case HotelObject.HotelObjectType.Booker:
                    Booker b= hotel_obj.AsBooker;
                    aRow["BookingID"] = b.BookingID;
                    aRow["num_of_people_expected"] = b.NumOfPeopleExpected;
                    break;

                case HotelObject.HotelObjectType.RoomAccount:
                    RoomAccount ra= hotel_obj.AsRoomAccount;
                    aRow["AccountID"] = ra.AccountID;
                    aRow["Balance"] = ra.Balance;
                    aRow["Status"] = ra.Status;
                    break;

                case HotelObject.HotelObjectType.Room:
                    Room r = hotel_obj.AsRoom;
                    aRow["RoomID"] = r.RoomID;
                    aRow["AccountID"] = r.AccountID;
                    aRow["IsOccupied"] = r.IsOccupied;
                    aRow["SuiteType"] = r.SuiteType;
                    break;

                case HotelObject.HotelObjectType.Reservation:
                    Reservation res=hotel_obj.AsReservation;
                    aRow["ReservationID"] = res.ReservationID;
                    aRow["BookingID"] = res.BookingID;
                    aRow["CheckInDate"] = res.CheckInDate;
                    aRow["CheckOutDate"] = res.CheckOutDate;
                    aRow["Status"] = res.Status;
                    aRow["DateBooked"] = res.DateBooked;
                    break;

                case HotelObject.HotelObjectType.Guest:
                    Guest g = hotel_obj.AsGuest;
                    aRow["GuestID"] = g.GuestID;
                    aRow["BookingID"] = g.BookingID;
                    aRow["Name"] = g.Name;
                    aRow["Telephone"] = g.Telephone;
                    aRow["AddressLine1"] = g.AddressLine1;
                    aRow["AddressLine2"] = g.AddressLine2;
                    aRow["PostalCode"] = g.PostalCode;
                    aRow["DateBooked"] = g.DateBooked;
                    break;

                case HotelObject.HotelObjectType.Employee:
                    Employee e = hotel_obj.AsEmployee;
                    aRow["EmpID"] = e.EmpID;
                    aRow["Name"] = e.Name;
                    aRow["Role"] = e.Role;
                    aRow["Username"] = e.Username;
                    aRow["Password"] = e.Password;
                    break;
                    
            }
        }


        #endregion


        /// <summary>
        /// Populates the <see cref="SqlParameter"/> collection for the <see cref="daMain.InsertCommand"/> 
        /// based on the provided <see cref="HotelObject"/>. 
        /// The method inspects the <see cref="HotelObject.Type"/> to determine which underlying 
        /// entity (Booker, Reservation, RoomAccount, Room, Employee, Guest) is wrapped, 
        /// and adds parameters corresponding to its properties. 
        /// If the <see cref="HotelObject"/> type does not match, no parameters are added.
        /// </summary>
        /// <param name="hotel_obj">The <see cref="HotelObject"/> containing the entity data.</param>
        private void Build_INSERT_Parameters(HotelObject hotel_obj)
        {
            SqlParameter param;

            switch (hotel_obj.Type)
            {
                case HotelObject.HotelObjectType.Booker:
                    Booker aBooker = hotel_obj.AsBooker;

                    param = new SqlParameter("@BookingID", SqlDbType.Int, 4, "BookingID");
                    param.SourceVersion = DataRowVersion.Original;
                    param.Value = aBooker.BookingID;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@NumOfPeopleExpected", SqlDbType.Int, 4, "NumOfPeopleExpected");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = aBooker.NumOfPeopleExpected;
                    daMain.InsertCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.RoomAccount:
                    RoomAccount ra = hotel_obj.AsRoomAccount;

                    param = new SqlParameter("@AccountID", SqlDbType.Int, 4, "AccountID");
                    param.SourceVersion = DataRowVersion.Original;
                    param.Value = ra.AccountID;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Balance", SqlDbType.Money, 8, "Balance");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = ra.Balance;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Status", SqlDbType.NVarChar, 20, "Status");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = ra.Status;
                    daMain.InsertCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Room:
                    Room r = hotel_obj.AsRoom;

                    param = new SqlParameter("@RoomID", SqlDbType.Int, 4, "RoomID");
                    param.SourceVersion = DataRowVersion.Original;
                    param.Value = r.RoomID;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@AccountID", SqlDbType.Int, 4, "AccountID");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = r.AccountID;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@IsOccupied", SqlDbType.Bit, 1, "IsOccupied");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = r.IsOccupied;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@SuiteType", SqlDbType.NVarChar, 50, "SuiteType");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = r.SuiteType;
                    daMain.InsertCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Reservation:
                    Reservation res = hotel_obj.AsReservation;

                    param = new SqlParameter("@ReservationID", SqlDbType.Int, 4, "ReservationID");
                    param.SourceVersion = DataRowVersion.Original;
                    param.Value = res.ReservationID;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@BookingID", SqlDbType.Int, 4, "BookingID");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = res.BookingID;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@CheckInDate", SqlDbType.DateTime, 8, "CheckInDate");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = res.CheckInDate;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@CheckOutDate", SqlDbType.DateTime, 8, "CheckOutDate");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = res.CheckOutDate;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Status", SqlDbType.NVarChar, 20, "Status");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = res.Status;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@DateBooked", SqlDbType.DateTime, 8, "DateBooked");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = res.DateBooked;
                    daMain.InsertCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Guest:
                    Guest g = hotel_obj.AsGuest;

                    param = new SqlParameter("@GuestID", SqlDbType.Int, 4, "GuestID");
                    param.SourceVersion = DataRowVersion.Original;
                    param.Value = g.GuestID;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@BookingID", SqlDbType.Int, 4, "BookingID");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = g.BookingID;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = g.Name;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Telephone", SqlDbType.NVarChar, 15, "Telephone");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = g.Telephone;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@AddressLine1", SqlDbType.NVarChar, 100, "AddressLine1");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = g.AddressLine1;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100, "AddressLine2");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = g.AddressLine2;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 10, "PostalCode");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = g.PostalCode;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@DateBooked", SqlDbType.DateTime, 8, "DateBooked");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = g.DateBooked;
                    daMain.InsertCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Employee:
                    Employee e = hotel_obj.AsEmployee;

                    param = new SqlParameter("@EmpID", SqlDbType.Int, 4, "EmpID");
                    param.SourceVersion = DataRowVersion.Original;
                    param.Value = e.EmpID;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = e.Name;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Role", SqlDbType.NVarChar, 50, "Role");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = e.Role;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Username", SqlDbType.NVarChar, 50, "Username");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = e.Username;
                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Password", SqlDbType.NVarChar, 50, "Password");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = e.Password;
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
            }
        }

        private void Build_DELETE_Parameters(HotelObject hotel_obj)
        {
     
            SqlParameter param;

            switch (hotel_obj.Type)
            {
                case HotelObject.HotelObjectType.Booker:
                    param = new SqlParameter("@BookingID", SqlDbType.Int);
                    param.Value = hotel_obj.AsBooker.BookingID;
                    daMain.DeleteCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.RoomAccount:
                    param = new SqlParameter("@AccountID", SqlDbType.Int);
                    param.Value = hotel_obj.AsRoomAccount.AccountID;
                    daMain.DeleteCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Room:
                    param = new SqlParameter("@RoomID", SqlDbType.Int);
                    param.Value = hotel_obj.AsRoom.RoomID;
                    daMain.DeleteCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Reservation:
                    param = new SqlParameter("@ReservationID", SqlDbType.Int);
                    param.Value = hotel_obj.AsReservation.ReservationID;
                    daMain.DeleteCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Guest:
                    param = new SqlParameter("@GuestID", SqlDbType.Int);
                    param.Value = hotel_obj.AsGuest.GuestID;
                    daMain.DeleteCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Employee:
                    param = new SqlParameter("@EmpID", SqlDbType.Int);
                    param.Value = hotel_obj.AsEmployee.EmpID;
                    daMain.DeleteCommand.Parameters.Add(param);
                    break;

            }
        

        }
        private void Build_UPDATE_Parameters(HotelObject hotel_obj)
        {
            SqlParameter param;

            switch (hotel_obj.Type)
            {
                case HotelObject.HotelObjectType.Booker:
                    Booker aBooker = hotel_obj.AsBooker;

                    param = new SqlParameter("@BookingID", SqlDbType.Int, 4, "BookingID");
                    param.SourceVersion = DataRowVersion.Original;
                    param.Value = aBooker.BookingID;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@NumOfPeopleExpected", SqlDbType.Int, 4, "NumOfPeopleExpected");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = aBooker.NumOfPeopleExpected;
                    daMain.UpdateCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.RoomAccount:
                    RoomAccount ra = hotel_obj.AsRoomAccount;

                    param = new SqlParameter("@AccountID", SqlDbType.Int, 4, "AccountID");
                    param.SourceVersion = DataRowVersion.Original;
                    param.Value = ra.AccountID;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Balance", SqlDbType.Money, 8, "Balance");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = ra.Balance;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Status", SqlDbType.NVarChar, 20, "Status");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = ra.Status;
                    daMain.UpdateCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Room:
                    Room r = hotel_obj.AsRoom;

                    param = new SqlParameter("@RoomID", SqlDbType.Int, 4, "RoomID");
                    param.SourceVersion = DataRowVersion.Original;
                    param.Value = r.RoomID;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@AccountID", SqlDbType.Int, 4, "AccountID");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = r.AccountID;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@IsOccupied", SqlDbType.Bit, 1, "IsOccupied");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = r.IsOccupied;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@SuiteType", SqlDbType.NVarChar, 50, "SuiteType");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = r.SuiteType;
                    daMain.UpdateCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Reservation:
                    Reservation res = hotel_obj.AsReservation;

                    param = new SqlParameter("@ReservationID", SqlDbType.Int, 4, "ReservationID");
                    param.SourceVersion = DataRowVersion.Original;
                    param.Value = res.ReservationID;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@BookingID", SqlDbType.Int, 4, "BookingID");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = res.BookingID;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@CheckInDate", SqlDbType.DateTime, 8, "CheckInDate");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = res.CheckInDate;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@CheckOutDate", SqlDbType.DateTime, 8, "CheckOutDate");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = res.CheckOutDate;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Status", SqlDbType.NVarChar, 20, "Status");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = res.Status;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@DateBooked", SqlDbType.DateTime, 8, "DateBooked");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = res.DateBooked;
                    daMain.UpdateCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Guest:
                    Guest g = hotel_obj.AsGuest;

                    param = new SqlParameter("@GuestID", SqlDbType.Int, 4, "GuestID");
                    param.SourceVersion = DataRowVersion.Original;
                    param.Value = g.GuestID;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@BookingID", SqlDbType.Int, 4, "BookingID");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = g.BookingID;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = g.Name;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Telephone", SqlDbType.NVarChar, 15, "Telephone");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = g.Telephone;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@AddressLine1", SqlDbType.NVarChar, 100, "AddressLine1");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = g.AddressLine1;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@AddressLine2", SqlDbType.NVarChar, 100, "AddressLine2");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = g.AddressLine2;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 10, "PostalCode");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = g.PostalCode;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@DateBooked", SqlDbType.DateTime, 8, "DateBooked");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = g.DateBooked;
                    daMain.UpdateCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Employee:
                    Employee e = hotel_obj.AsEmployee;

                    param = new SqlParameter("@EmpID", SqlDbType.Int, 4, "EmpID");
                    param.SourceVersion = DataRowVersion.Original;
                    param.Value = e.EmpID;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "Name");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = e.Name;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Role", SqlDbType.NVarChar, 50, "Role");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = e.Role;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Username", SqlDbType.NVarChar, 50, "Username");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = e.Username;
                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Password", SqlDbType.NVarChar, 50, "Password");
                    param.SourceVersion = DataRowVersion.Current;
                    param.Value = e.Password;
                    daMain.UpdateCommand.Parameters.Add(param);
                    break;
            }
        }


        /// <summary>
        /// Creates the <see cref="SqlCommand"/> for inserting a new record into the database 
        /// for the specified <see cref="HotelObject"/> type. 
        /// The command text is dynamically selected based on <see cref="HotelObject.Type"/>, 
        /// targeting the correct table and columns for insertion. 
        /// After the command is created, it calls <see cref="Build_INSERT_Parameters"/> 
        /// to add all required SQL parameters.
        private void Create_INSERT_Command(HotelObject hotel_obj)
        {
            switch (hotel_obj.Type)
            {
                case HotelObject.HotelObjectType.Booker:
                    daMain.InsertCommand = new SqlCommand(
                        "INSERT INTO Booker (num_of_people_expected) VALUES (@NumOfPeopleExpected)",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.RoomAccount:
                    daMain.InsertCommand = new SqlCommand(
                        "INSERT INTO RoomAccount (balance, status) VALUES (@Balance, @Status)",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Room:
                    daMain.InsertCommand = new SqlCommand(
                        "INSERT INTO Rooms (accountID, isOccupied, suiteType) VALUES (@AccountID, @IsOccupied, @SuiteType)",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Reservation:
                    daMain.InsertCommand = new SqlCommand(
                        "INSERT INTO Reservation (bookingID, check_in_date, check_out_date, status, date_booked) " +
                        "VALUES (@BookingID, @CheckInDate, @CheckOutDate, @Status, @DateBooked)",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Guest:
                    daMain.InsertCommand = new SqlCommand(
                        "INSERT INTO Guest (bookingID, name, telephone, addressLine1, addressLine2, postalCode, date_booked) " +
                        "VALUES (@BookingID, @Name, @Telephone, @AddressLine1, @AddressLine2, @PostalCode, @DateBooked)",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Employee:
                    daMain.InsertCommand = new SqlCommand(
                        "INSERT INTO Employee (name, role, username, password) " +
                        "VALUES (@Name, @Role, @Username, @Password)",
                        cnMain
                    );
                    break;
            }


            // Add parameters for the chosen type
            Build_INSERT_Parameters(hotel_obj);
        }

        private void Create_UPDATE_Command(HotelObject hotel_obj)
        {
            switch (hotel_obj.Type)
            {
                case HotelObject.HotelObjectType.Booker:
                    daMain.UpdateCommand = new SqlCommand(
                        "UPDATE Booker SET num_of_people_expected = @NumOfPeopleExpected " +
                        "WHERE bookingID = @BookingID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.RoomAccount:
                    daMain.UpdateCommand = new SqlCommand(
                        "UPDATE RoomAccount SET balance = @Balance, status = @Status " +
                        "WHERE accountID = @AccountID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Room:
                    daMain.UpdateCommand = new SqlCommand(
                        "UPDATE Rooms SET accountID = @AccountID, isOccupied = @IsOccupied, suiteType = @SuiteType " +
                        "WHERE roomID = @RoomID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Reservation:
                    daMain.UpdateCommand = new SqlCommand(
                        "UPDATE Reservation SET bookingID = @BookingID, check_in_date = @CheckInDate, " +
                        "check_out_date = @CheckOutDate, status = @Status, date_booked = @DateBooked " +
                        "WHERE reservationID = @ReservationID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Guest:
                    daMain.UpdateCommand = new SqlCommand(
                        "UPDATE Guest SET bookingID = @BookingID, name = @Name, telephone = @Telephone, " +
                        "addressLine1 = @AddressLine1, addressLine2 = @AddressLine2, postalCode = @PostalCode, " +
                        "date_booked = @DateBooked WHERE guestID = @GuestID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Employee:
                    daMain.UpdateCommand = new SqlCommand(
                        "UPDATE Employee SET name = @Name, role = @Role, username = @Username, password = @Password " +
                        "WHERE empID = @EmpID",
                        cnMain
                    );
                    break;
            }



            // Add parameters for the chosen type
            Build_UPDATE_Parameters(hotel_obj);
        }

        private void Create_DELETE_Command(HotelObject hotel_obj)
        {

            switch (hotel_obj.Type)
            {
                case HotelObject.HotelObjectType.Booker:
                    daMain.DeleteCommand = new SqlCommand(
                        "DELETE FROM Booker WHERE bookingID = @BookingID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.RoomAccount:
                    daMain.DeleteCommand = new SqlCommand(
                        "DELETE FROM RoomAccount WHERE accountID = @AccountID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Room:
                    daMain.DeleteCommand = new SqlCommand(
                        "DELETE FROM Rooms WHERE roomID = @RoomID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Reservation:
                    daMain.DeleteCommand = new SqlCommand(
                        "DELETE FROM Reservation WHERE reservationID = @ReservationID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Guest:
                    daMain.DeleteCommand = new SqlCommand(
                        "DELETE FROM Guest WHERE guestID = @GuestID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Employee:
                    daMain.DeleteCommand = new SqlCommand(
                        "DELETE FROM Employee WHERE empID = @EmpID",
                        cnMain
                    );
                    break;
            }


        }


        public bool UpdateDataSource(HotelObject hotel_obj)
        {
            bool success = true;
            Create_INSERT_Command(hotel_obj);
            Create_UPDATE_Command(hotel_obj);
            Create_DELETE_Command(hotel_obj);

            switch (hotel_obj.Type)
            {
                case HotelObject.HotelObjectType.Booker:
                    // TODO: Add parameters for Booker
                    success=UpdateDataSource(sqlLocal1, table1);
                    break;

                case HotelObject.HotelObjectType.RoomAccount:
                    // TODO: Add parameters for RoomAccount
                    success = UpdateDataSource(sqlLocal2, table2);
                    break;

                case HotelObject.HotelObjectType.Room:
                    // TODO: Add parameters for Room
                    success = UpdateDataSource(sqlLocal3, table3);
                    break;

                case HotelObject.HotelObjectType.Reservation:
                    // TODO: Add parameters for Reservation
                    success = UpdateDataSource(sqlLocal4, table4);
                    break;

                case HotelObject.HotelObjectType.Guest:
                    // TODO: Add parameters for Guest
                    success = UpdateDataSource(sqlLocal5, table5);
                    break;

                case HotelObject.HotelObjectType.Employee:
                    // TODO: Add parameters for Employee
                    success = UpdateDataSource(sqlLocal6, table6);
                    break;
            }

            return success;

        }



    }
}
