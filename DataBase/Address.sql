USE DBAndreVeiculos
GO

CREATE TABLE Address
(
    Id INT IDENTITY(1,1) NOT NULL,
    PostalCode VARCHAR(10) NOT NULL,
    State CHAR(2) NOT NULL,
    City VARCHAR(50) NOT NULL,
    PublicPlace VARCHAR(50) NOT NULL,
    PublicPlaceType VARCHAR(50) NOT NULL,
    Number INT NOT NULL,
    Neighborhood VARCHAR(50) NOT NULL,
    Complement VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Address PRIMARY KEY (Id)
)
GO  