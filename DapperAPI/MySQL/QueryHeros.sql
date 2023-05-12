CREATE DATABASE HerosDB;

USE HerosDB;

CREATE TABLE Heros(
Id INT AUTO_INCREMENT,
Name VARCHAR(30) NOT NULL,
Attribute VARCHAR(25) NOT NULL,
Complexity VARCHAR(18) NOT NULL,
Biography VARCHAR(1000) NOT NULL,
Image VARCHAR(2000) NOT NULL,
PRIMARY KEY(Id)
);

SELECT * FROM Heros;

SELECT * FROM Heros WHERE Id = @Id;

SELECT * FROM Heros WHERE Name = @Name;

INSERT INTO Heros(Name, Attribute, Complexity, Biography, Image)
VALUES (@Name, @Attribute, @Comlexity, @Biography, @Image);

UPDATE Heros SET Name = @Name, Attribute = @Attribute, Complexity = @Complexity, Biography = @Biography, Image = @Image 
WHERE Id = @Id;

DELETE FROM Heros WHERE Id = @Id;
