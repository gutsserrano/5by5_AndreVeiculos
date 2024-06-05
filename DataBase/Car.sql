USE DBAndreVeiculos
GO

CREATE TABLE Car
(
    Plate VARCHAR(10) NOT NULL,
    Name VARCHAR(50) NOT NULL,
    ModelYear INT NOT NULL,
    ManufactureYear INT NOT NULL,
    Color VARCHAR(20) NOT NULL,
    Sold BIT NOT NULL,
    CONSTRAINT PK_Car PRIMARY KEY (Plate)
)
GO