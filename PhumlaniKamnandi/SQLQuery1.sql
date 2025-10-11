CREATE TABLE [dbo].Room (
    roomID INT PRIMARY KEY IDENTITY(1,1),
    accountID INT,
    isOccupied BIT DEFAULT 0,
    suiteType VARCHAR(20) NOT NULL CHECK (suiteType IN ('standard','deluxe')),
    FOREIGN KEY (accountID) REFERENCES RoomAccount(accountID)
);
