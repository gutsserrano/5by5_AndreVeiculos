USE DBAndreVeiculos
GO

CREATE TABLE Employee
(
    IdDocument VARCHAR(14) NOT NULL,
    IdPosition INT NOT NULL,
    ComissionValue REAL NOT NULL,
    Comission REAL NOT NULL,
    CONSTRAINT PK_Employee PRIMARY KEY (IdDocument),
    CONSTRAINT FK_Employee_Person FOREIGN KEY (IdDocument) REFERENCES Person(Document),
    CONSTRAINT FK_Employee_Position FOREIGN KEY (IdPosition) REFERENCES Position(Id)
)
GO