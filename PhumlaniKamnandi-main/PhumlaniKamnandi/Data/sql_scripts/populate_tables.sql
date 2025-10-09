-- Sample Booker data
INSERT INTO Booker (num_of_people_expected)
VALUES (3);

-- Sample Employee data for testing login
INSERT INTO Employee (name, role, username, password)
VALUES 
    ('John Smith', 'Manager', 'admin', 'admin123'),
    ('Jane Doe', 'Receptionist', 'jane.doe', 'password'),
    ('Mike Johnson', 'Supervisor', 'mike.j', 'mike123');

-- Sample Room Account data
INSERT INTO RoomAccount (balance, status)
VALUES 
    (0.00, 'settled'),
    (150.00, 'outstanding'),
    (0.00, 'settled');

-- Sample Room data
INSERT INTO Room (accountID, isOccupied, suiteType)
VALUES 
    (1, 0, 'standard'),
    (2, 1, 'deluxe'),
    (3, 0, 'executive');
