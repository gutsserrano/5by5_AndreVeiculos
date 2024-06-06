USE DBAndreVeiculos
GO

CREATE TABLE Pix
(
    Id INT IDENTITY(1,1) NOT NULL,
    PixTypeId INT NOT NULL,
    PixKey VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Pix PRIMARY KEY (Id),
    CONSTRAINT FK_Pix_PixType FOREIGN KEY (PixTypeId) REFERENCES PixType(Id)
);
GO