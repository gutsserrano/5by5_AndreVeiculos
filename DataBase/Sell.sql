USE DBAndreVeiculos
GO

CREATE TABLE Sell
(
    Id INT IDENTITY(1,1) NOT NULL,
    CarPlate VARCHAR(10) NOT NULL,
    EmployeeId VARCHAR(14) NOT NULL,
    ClientId VARCHAR(14) NOT NULL,
    SellDate DATE NOT NULL,
    SellPrice REAL NOT NULL,
    PaymentId INT NOT NULL,
    CONSTRAINT PK_Sell PRIMARY KEY (Id),
    CONSTRAINT FK_Sell_Car FOREIGN KEY (CarPlate) REFERENCES Car(Plate),
    CONSTRAINT FK_Sell_Employee FOREIGN KEY (EmployeeId) REFERENCES Employee(IdDocument),
    CONSTRAINT FK_Sell_Client FOREIGN KEY (ClientId) REFERENCES Client(IdDocument),
    CONSTRAINT FK_Sell_Payment FOREIGN KEY (PaymentId) REFERENCES Payment(Id)
);
GO