using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using PhumlaniKamnandi.Business;

namespace PhumlaniKamnandi.Data
{
    internal class HotelDB : DB
    {
        #region String literals and Constants
        // Booker
        private const string table1 = "Booker";
        private const string sqlLocal1 = "SELECT * FROM Booker";

        // RoomAccount
        private const string table2 = "RoomAccount";
        private const string sqlLocal2 = "SELECT * FROM RoomAccount";

        // Rooms
        private const string table3 = "Room";
        private const string sqlLocal3 = "SELECT * FROM Room";

        // Reservation
        private const string table4 = "Reservation";
        private const string sqlLocal4 = "SELECT * FROM Reservation";

        // Guest
        private const string table5 = "Guest";
        private const string sqlLocal5 = "SELECT * FROM Guest";

        // Employee
        private const string table6 = "Employee";
        private const string sqlLocal6 = "SELECT * FROM Employee";
        
     
        String[] sql_local_select =
        {
        "SELECT * FROM Booker",
        "SELECT * FROM RoomAccount",
        "SELECT * FROM Room",
        "SELECT * FROM Reservation",
        "SELECT * FROM Guest",
        "SELECT * FROM Employee"
        };

        #endregion

        #region Properties and Fields
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


        #endregion

        #region Enumeration Objects AND structs

        public struct HotelObject
        {
            private readonly object value;

            public enum HotelObjectType
            {
                Booker,
                Reservation,
                RoomAccount,
                Room,
                Employee,
                Guest,
                None,
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
            public Reservation AsReservation =>
                Type == HotelObjectType.Reservation ? (Reservation)value : null;
            public RoomAccount AsRoomAccount =>
                Type == HotelObjectType.RoomAccount ? (RoomAccount)value : null;
            public Room AsRoom => Type == HotelObjectType.Room ? (Room)value : null;
            public Employee AsEmployee => Type == HotelObjectType.Employee ? (Employee)value : null;
            public Guest AsGuest => Type == HotelObjectType.Guest ? (Guest)value : null;

            public override string ToString()
            {
                return $"{Type}: {value}";
            }
        }
        #endregion

        #region Constructors
        public HotelDB()
            : base()
        {
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
        #endregion

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
                                NumOfPeopleExpected = Convert.ToInt32(
                                    myRow["num_of_people_expected"]
                                ),
                            };
                            AllBookers.Add(aBooker);
                            break;

                        case table2: // RoomAccount
                            aRoomAccount = new RoomAccount
                            {
                                AccountID = Convert.ToInt32(myRow["accountID"]),
                                Balance = Convert.ToDecimal(myRow["balance"]),
                                Status = Convert.ToString(myRow["status"]).TrimEnd(),
                            };
                            AllRoomAccounts.Add(aRoomAccount);
                            break;

                        case table3: // Rooms
                            aRoom = new Room
                            {
                                RoomID = Convert.ToInt32(myRow["roomID"]),
                                AccountID = Convert.ToInt32(myRow["accountID"]),
                                IsOccupied = Convert.ToBoolean(myRow["isOccupied"]),
                                SuiteType = Convert.ToString(myRow["suiteType"]).TrimEnd(),
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
                                DateBooked = Convert.ToDateTime(myRow["date_booked"]),
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
                                DateBooked = Convert.ToDateTime(myRow["date_booked"]),
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
                                Password = Convert.ToString(myRow["password"]).TrimEnd(),
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

        private int FindRow(HotelObject hotel_obj, String table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (myRow.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                else
                {
                    switch (hotel_obj.Type)
                    {
                        case HotelObject.HotelObjectType.Booker:
                            // TODO: Add parameters for Booker
                            if (hotel_obj.AsBooker.BookingID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["bookerID"]))
                            {
                                returnValue = rowIndex;
                                break;
                            }
                            break;

                        case HotelObject.HotelObjectType.RoomAccount:
                            // TODO: Add parameters for RoomAccount
                            if (hotel_obj.AsRoomAccount.AccountID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["accountID"]))
                            {
                                returnValue = rowIndex;
                                break;
                            }
                            break;

                        case HotelObject.HotelObjectType.Room:
                            // TODO: Add parameters for Room
                            if (hotel_obj.AsRoom.RoomID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["roomID"]))
                            {
                                returnValue = rowIndex;
                                break;
                            }
                            break;

                        case HotelObject.HotelObjectType.Reservation:
                            // TODO: Add parameters for Reservation
                            if (hotel_obj.AsReservation.ReservationID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["reservationID"]))
                            {
                                returnValue = rowIndex;
                                break;
                            }
                            break;

                        case HotelObject.HotelObjectType.Guest:
                            // TODO: Add parameters for Guest
                            if (hotel_obj.AsGuest.GuestID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["guestID"]))
                            {
                                returnValue = rowIndex;
                                break;
                            }
                            break;

                        case HotelObject.HotelObjectType.Employee:
                            // TODO: Add parameters for Employee
                            if (hotel_obj.AsEmployee.EmpID == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["empID"]))
                            {
                                returnValue = rowIndex;
                                break;
                            }
                            break;
                    }

                }
                rowIndex++;
            }
            return returnValue;
        }
        public void FillRow(DataRow aRow, HotelObject hotel_obj)
        {
            if (hotel_obj.Type == HotelObject.HotelObjectType.None)
                throw new ArgumentException("Unsupported type", nameof(hotel_obj.Type));
            switch (hotel_obj.Type)
            {
                case HotelObject.HotelObjectType.Booker:
                    Booker b = hotel_obj.AsBooker;
                    aRow["bookingID"] = b.BookingID;
                    aRow["num_of_people_expected"] = b.NumOfPeopleExpected;
                    break;

                case HotelObject.HotelObjectType.RoomAccount:
                    RoomAccount ra = hotel_obj.AsRoomAccount;
                    aRow["accountID"] = ra.AccountID;
                    aRow["balance"] = ra.Balance;
                    aRow["status"] = ra.Status;
                    break;

                case HotelObject.HotelObjectType.Room:
                    Room r = hotel_obj.AsRoom;
                    aRow["roomID"] = r.RoomID;
                    aRow["accountID"] = r.AccountID;
                    aRow["isOccupied"] = r.IsOccupied;
                    aRow["suiteType"] = r.SuiteType;
                    break;

                case HotelObject.HotelObjectType.Reservation:
                    Reservation res = hotel_obj.AsReservation;
                    aRow["reservationID"] = res.ReservationID;
                    aRow["bookingID"] = res.BookingID;
                    aRow["check_in_date"] = res.CheckInDate;
                    aRow["check_in_date"] = res.CheckOutDate;
                    aRow["status"] = res.Status;
                    aRow["date_booked"] = res.DateBooked;
                    break;

                case HotelObject.HotelObjectType.Guest:
                    Guest g = hotel_obj.AsGuest;
                    aRow["guestID"] = g.GuestID;
                    aRow["bookingID"] = g.BookingID;
                    aRow["name"] = g.Name;
                    aRow["telephone"] = g.Telephone;
                    aRow["addressLine1"] = g.AddressLine1;
                    aRow["addressLine2"] = g.AddressLine2;
                    aRow["postalCode"] = g.PostalCode;
                    aRow["date_booked"] = g.DateBooked;
                    break;

                case HotelObject.HotelObjectType.Employee:
                    Employee e = hotel_obj.AsEmployee;
                    aRow["empID"] = e.EmpID;
                    aRow["name"] = e.Name;
                    aRow["role"] = e.Role;
                    aRow["username"] = e.Username;
                    aRow["password"] = e.Password;
                    break;
            }
        }

        #endregion

        #region Building Parameters for CRUD Operations
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
                   

                    param = new SqlParameter("@BookingID", SqlDbType.Int, 4, "BookingID");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter(
                        "@NumOfPeopleExpected",
                        SqlDbType.Int,
                        4,
                        "num_of_people_expected"
                    );

                    daMain.InsertCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.RoomAccount:
                    RoomAccount ra = hotel_obj.AsRoomAccount;

                    param = new SqlParameter("@AccountID", SqlDbType.Int, 4, "accountID");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Balance", SqlDbType.Money, 8, "balance");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Status", SqlDbType.NVarChar, 20, "status");

                    daMain.InsertCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Room:
                    Room r = hotel_obj.AsRoom;

                    param = new SqlParameter("@RoomID", SqlDbType.Int, 4, "roomID");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@AccountID", SqlDbType.Int, 4, "accountID");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@IsOccupied", SqlDbType.Bit, 1, "isOccupied");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@SuiteType", SqlDbType.NVarChar, 50, "suiteType");

                    daMain.InsertCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Reservation:
                    Reservation res = hotel_obj.AsReservation;

                    param = new SqlParameter("@ReservationID", SqlDbType.Int, 4, "reservationID");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@BookingID", SqlDbType.Int, 4, "bookingID");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@CheckInDate", SqlDbType.DateTime, 8, "check_in_date");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter(
                        "@CheckOutDate",
                        SqlDbType.DateTime,
                        8,
                        "check_out_date"
                    );

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Status", SqlDbType.NVarChar, 20, "status");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@DateBooked", SqlDbType.DateTime, 8, "date_booked");

                    daMain.InsertCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Guest:
                    Guest g = hotel_obj.AsGuest;

                    param = new SqlParameter("@GuestID", SqlDbType.Int, 4, "guestID");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@BookingID", SqlDbType.Int, 4, "bookingID");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "name");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Telephone", SqlDbType.NVarChar, 15, "telephone");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter(
                        "@AddressLine1",
                        SqlDbType.NVarChar,
                        100,
                        "addressLine1"
                    );

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter(
                        "@AddressLine2",
                        SqlDbType.NVarChar,
                        100,
                        "addressLine2"
                    );

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 10, "postalCode");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@DateBooked", SqlDbType.DateTime, 8, "date_booked");

                    daMain.InsertCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Employee:
                    Employee e = hotel_obj.AsEmployee;

                    param = new SqlParameter("@EmpID", SqlDbType.Int, 4, "empID");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "name");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Role", SqlDbType.NVarChar, 50, "role");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Username", SqlDbType.NVarChar, 50, "username");

                    daMain.InsertCommand.Parameters.Add(param);

                    param = new SqlParameter("@Password", SqlDbType.NVarChar, 50, "password");

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

                    daMain.DeleteCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.RoomAccount:
                    param = new SqlParameter("@AccountID", SqlDbType.Int);

                    daMain.DeleteCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Room:
                    param = new SqlParameter("@RoomID", SqlDbType.Int);

                    daMain.DeleteCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Reservation:
                    param = new SqlParameter("@ReservationID", SqlDbType.Int);

                    daMain.DeleteCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Guest:
                    param = new SqlParameter("@GuestID", SqlDbType.Int);

                    daMain.DeleteCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Employee:
                    param = new SqlParameter("@EmpID", SqlDbType.Int);

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

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter(
                        "@NumOfPeopleExpected",
                        SqlDbType.Int,
                        4,
                        "num_Of_people_expected"
                    );
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.RoomAccount:
                    RoomAccount ra = hotel_obj.AsRoomAccount;

                    param = new SqlParameter("@AccountID", SqlDbType.Int, 4, "accountID");
                    param.SourceVersion = DataRowVersion.Original;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Balance", SqlDbType.Money, 8, "balance");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Status", SqlDbType.NVarChar, 20, "status");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Room:
                    Room r = hotel_obj.AsRoom;

                    param = new SqlParameter("@RoomID", SqlDbType.Int, 4, "roomID");
                    param.SourceVersion = DataRowVersion.Original;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@AccountID", SqlDbType.Int, 4, "accountID");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@IsOccupied", SqlDbType.Bit, 1, "isOccupied");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@SuiteType", SqlDbType.NVarChar, 50, "suiteType");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Reservation:
                    Reservation res = hotel_obj.AsReservation;

                    param = new SqlParameter("@ReservationID", SqlDbType.Int, 4, "reservationID");
                    param.SourceVersion = DataRowVersion.Original;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@BookingID", SqlDbType.Int, 4, "bookingID");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@CheckInDate", SqlDbType.DateTime, 8, "check_in_date");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter(
                        "@CheckOutDate",
                        SqlDbType.DateTime,
                        8,
                        "check_out_date"
                    );
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Status", SqlDbType.NVarChar, 20, "status");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@DateBooked", SqlDbType.DateTime, 8, "date_booked");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Guest:
                    Guest g = hotel_obj.AsGuest;

                    param = new SqlParameter("@GuestID", SqlDbType.Int, 4, "guestID");
                    param.SourceVersion = DataRowVersion.Original;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@BookingID", SqlDbType.Int, 4, "bookingID");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "name");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Telephone", SqlDbType.NVarChar, 15, "telephone");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter(
                        "@AddressLine1",
                        SqlDbType.NVarChar,
                        100,
                        "addressLine1"
                    );
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter(
                        "@AddressLine2",
                        SqlDbType.NVarChar,
                        100,
                        "addressLine2"
                    );
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 10, "postalCode");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@DateBooked", SqlDbType.DateTime, 8, "date_booked");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);
                    break;

                case HotelObject.HotelObjectType.Employee:
                    Employee e = hotel_obj.AsEmployee;

                    param = new SqlParameter("@EmpID", SqlDbType.Int, 4, "empID");
                    param.SourceVersion = DataRowVersion.Original;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Name", SqlDbType.NVarChar, 100, "name");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Role", SqlDbType.NVarChar, 50, "role");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Username", SqlDbType.NVarChar, 50, "username");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);

                    param = new SqlParameter("@Password", SqlDbType.NVarChar, 50, "password");
                    param.SourceVersion = DataRowVersion.Current;

                    daMain.UpdateCommand.Parameters.Add(param);
                    break;
            }
        }

        #endregion

        #region Creating CRUD SQL Commands
        
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
                        "INSERT INTO RoomAccount (accountID, balance, status) VALUES (@AccountID,@Balance, @Status)",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Room:
                    daMain.InsertCommand = new SqlCommand(
                        "INSERT INTO Room (roomID, accountID, isOccupied, suiteType) VALUES (@RoomID,@AccountID, @IsOccupied, @SuiteType)",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Reservation:
                    daMain.InsertCommand = new SqlCommand(
                        "INSERT INTO Reservation (bookingID, check_in_date, check_out_date, status, date_booked) "
                            + "VALUES (@BookingID, @CheckInDate, @CheckOutDate, @Status, @DateBooked)",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Guest:
                    daMain.InsertCommand = new SqlCommand(
                        "INSERT INTO Guest (bookingID, name, telephone, addressLine1, addressLine2, postalCode, date_booked) "
                            + "VALUES (@BookingID, @Name, @Telephone, @AddressLine1, @AddressLine2, @PostalCode, @DateBooked)",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Employee:
                    daMain.InsertCommand = new SqlCommand(
                        "INSERT INTO Employee (name, role, username, password) "
                            + "VALUES (@Name, @Role, @Username, @Password)",
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
                        "UPDATE Booker SET num_of_people_expected = @NumOfPeopleExpected "
                            + "WHERE bookingID = @BookingID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.RoomAccount:
                    daMain.UpdateCommand = new SqlCommand(
                        "UPDATE RoomAccount SET balance = @Balance, status = @Status "
                            + "WHERE accountID = @AccountID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Room:
                    daMain.UpdateCommand = new SqlCommand(
                        "UPDATE Room SET accountID = @AccountID, isOccupied = @IsOccupied, suiteType = @SuiteType "
                            + "WHERE roomID = @RoomID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Reservation:
                    daMain.UpdateCommand = new SqlCommand(
                        "UPDATE Reservation SET bookingID = @BookingID, check_in_date = @CheckInDate, "
                            + "check_out_date = @CheckOutDate, status = @Status, date_booked = @DateBooked "
                            + "WHERE reservationID = @ReservationID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Guest:
                    daMain.UpdateCommand = new SqlCommand(
                        "UPDATE Guest SET bookingID = @BookingID, name = @Name, telephone = @Telephone, "
                            + "addressLine1 = @AddressLine1, addressLine2 = @AddressLine2, postalCode = @PostalCode, "
                            + "date_booked = @DateBooked WHERE guestID = @GuestID",
                        cnMain
                    );
                    break;

                case HotelObject.HotelObjectType.Employee:
                    daMain.UpdateCommand = new SqlCommand(
                        "UPDATE Employee SET name = @Name, role = @Role, username = @Username, password = @Password "
                            + "WHERE empID = @EmpID",
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
        #endregion

      
        #region Database Operations CRUD
        public void DataSetChange(HotelObject hotel_obj, DBOperation operation)
        {
            DataRow aRow = null;
            string dataTable = hotel_obj.Type.ToString();
           
            switch (operation)
            {
                case DB.DBOperation.Add:
                   

                    aRow = dsMain.Tables[dataTable].NewRow();
                    FillRow(aRow, hotel_obj);
                    //Add to the dataset
                    dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                   aRow = dsMain.Tables[dataTable].Rows[FindRow(hotel_obj, dataTable)];
                    FillRow(aRow, hotel_obj);

                    break;
            }
        }

        public bool UpdateDataSource(HotelObject hotel_obj)
        {
            bool success = true;
            Create_INSERT_Command(hotel_obj);
            Create_UPDATE_Command(hotel_obj);
            //Create_DELETE_Command(hotel_obj);

            switch (hotel_obj.Type)
            {
                case HotelObject.HotelObjectType.Booker:
                    // TODO: Add parameters for Booker
                    success = UpdateDataSource(sqlLocal1, table1);
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

        #endregion
    }
}
