USE DBAndreVeiculos
GO

CREATE TABLE Person
(
    Document VARCHAR(14) NOT NULL,
    Name VARCHAR(50) NOT NULL,
    BirthDate DATE NOT NULL,
    AddressId INT NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Person PRIMARY KEY (Document),
    CONSTRAINT FK_Person_Address FOREIGN KEY (AddressId) REFERENCES Address(Id)
)
GO  