USE DBAndreVeiculos
GO

CREATE TABLE CarOperation
(
    Id INT IDENTITY(1,1) NOT NULL,
    CarPlate VARCHAR(10) NOT NULL,
    OperationId INT NOT NULL,
    IsDone BIT NOT NULL,
    CONSTRAINT PK_CarOperation PRIMARY KEY (Id),
    CONSTRAINT FK_CarOperation_Car FOREIGN KEY (CarPlate) REFERENCES Car(Plate),
    CONSTRAINT FK_CarOperation_Operation FOREIGN KEY (OperationId) REFERENCES Operation(Id)
)