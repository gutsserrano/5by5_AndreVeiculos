USE DBAndreVeiculos
GO

CREATE TABLE Operation
(
    Id INT IDENTITY(1,1) NOT NULL,
    Description VARCHAR(100) NOT NULL,
    CONSTRAINT PK_Operation PRIMARY KEY (Id),
)