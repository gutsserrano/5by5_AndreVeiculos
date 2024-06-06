USE DBAndreVeiculos
GO

CREATE TABLE Payment
(
    Id INT IDENTITY(1,1) NOT NULL,
    CardId VARCHAR(30),
    BankSlipId INT,
    PixId INT,
    PaymentDate DATE NOT NULL,
    CONSTRAINT PK_Payment PRIMARY KEY (Id),
    CONSTRAINT FK_Payment_Card FOREIGN KEY (CardId) REFERENCES Card(CardNumber),
    CONSTRAINT FK_Payment_BankSlip FOREIGN KEY (BankSlipId) REFERENCES BankSlip(Id),
    CONSTRAINT FK_Payment_Pix FOREIGN KEY (PixId) REFERENCES Pix(Id)
);
GO