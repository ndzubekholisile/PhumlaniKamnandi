CREATE TABLE [dbo].Room (
    roomID INT PRIMARY KEY IDENTITY(1,1),
    accountID INT,
    isOccupied BIT DEFAULT 0,
    suiteType VARCHAR(20) NOT NULL CHECK (suiteType IN ('standard','deluxe','executive','family','presidential')),
    FOREIGN KEY (accountID) REFERENCES RoomAccount(accountID)
);
