CREATE DATABASE Library
GO
USE Library
CREATE TABLE Authors(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(30) NOT NULL,
Surname NVARCHAR(50) NOT NULL,
Age DATETIME2
)
GO

INSERT INTO Authors([Name],[Surname],Age)
VALUES('Linus','Torvalds',GETDATE()),
('Leyla','Mammadova',GETDATE()),
('Akif','Mammadli',GETDATE())

GO

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(30) NOT NULL
)

GO
INSERT INTO Categories([Name])
VALUES('Dram'),('Adventure'),('Sci-Fi'),('Programming')

GO

CREATE TABLE Books(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(30) NOT NULL,
[Pages] INT NOT NULL,
[AuthorId] INT FOREIGN KEY REFERENCES Authors(Id) ON DELETE CASCADE NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id) ON DELETE CASCADE NOT NULL
)

GO

INSERT INTO Books([Name],[Pages],[AuthorId],[CategoryId])
VALUES('Linus Essential',350,1,3),
('C#',1200,2,4),
('Tom Sawyer Adventure',70,3,2),
('C++',350,1,3),
('Design Patterns',350,2,4)



--SP

CREATE PROCEDURE sp_GetBookById
@book_id INT
AS
BEGIN
SELECT * FROM Books AS B
WHERE B.Id=@book_id

END