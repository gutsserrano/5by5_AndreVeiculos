USE DBAndreVeiculos
GO

CREATE TABLE Card
(
    CardNumber VARCHAR(30) NOT NULL,
    SecurityNumber CHAR(3) NOT NULL,
    ExpirationDate DATE NOT NULL,
    NameInCard VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Card PRIMARY KEY (CardNumber)
)
GO