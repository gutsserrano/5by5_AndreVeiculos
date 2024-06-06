USE DBAndreVeiculos
GO

CREATE TABLE Client
(
    IdDocument VARCHAR(14) NOT NULL,
    Income REAL NOT NULL,
    DocumentPdf VARCHAR NOT NULL,
    CONSTRAINT PK_Client PRIMARY KEY (IdDocument),
    CONSTRAINT FK_Client_Person FOREIGN KEY (IdDocument) REFERENCES Person(Document)
)
GO