CREATE TABLE Tilaukset
(
    Id int,
    AsiakasId int,
    TuoteId int,
    Määrä float,
    Maksutapa varchar(20)
);

CREATE TABLE Asiakkaat
(
    Id int,
    Nimi varchar(100),
    Osoite varchar(100),
    Sähköposti varchar(50)
);

CREATE TABLE Tuotteet
(
    Id int,
    Nimi varchar(50),
    Hinta float
);
