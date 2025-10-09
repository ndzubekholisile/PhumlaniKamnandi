-- Table: RoomAccount
CREATE TABLE [dbo].RoomAccount (
    accountID INT PRIMARY KEY IDENTITY(1,1),
    balance DECIMAL(10,2) DEFAULT 0.00,
    status VARCHAR(20) NOT NULL CHECK (status IN ('settled','outstanding'))
);

-- Table: Room
CREATE TABLE [dbo].Room (
    roomID INT PRIMARY KEY IDENTITY(1,1),
    accountID INT,
    isOccupied BIT DEFAULT 0,
    suiteType VARCHAR(20) NOT NULL CHECK (suiteType IN ('standard','deluxe','executive','family','presidential')),
    FOREIGN KEY (accountID) REFERENCES RoomAccount(accountID)
);

-- Table: Booker
CREATE TABLE [dbo].Booker (
    bookingID INT PRIMARY KEY IDENTITY(1,1),
    num_of_people_expected INT NOT NULL
);

-- Table: Reservation
CREATE TABLE [dbo].Reservation (
    reservationID INT PRIMARY KEY IDENTITY(1,1),
    bookingID INT,
    check_in_date DATE NOT NULL,
    check_out_date DATE NOT NULL,
    status VARCHAR(20) DEFAULT 'unconfirmed' CHECK (status IN ('unconfirmed','cancelled','confirmed')),
    date_booked DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (bookingID) REFERENCES Booker(bookingID)
);

-- Table: Guest
CREATE TABLE [dbo].Guest (
    guestID INT PRIMARY KEY IDENTITY(1,1),
    bookingID INT,
    name VARCHAR(100) NOT NULL,
    telephone VARCHAR(20),
    addressLine1 VARCHAR(255),
    addressLine2 VARCHAR(255),
    postalCode VARCHAR(20),
    date_booked DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (bookingID) REFERENCES Booker(bookingID)
);

-- Table: Employee
CREATE TABLE [dbo].Employee (
    empID INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(100) NOT NULL,
    role VARCHAR(50) NOT NULL,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL
);
