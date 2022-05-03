create database project; -- create database
use project; -- using newly created database

/* creating the 2 tables: Theatre and Movie */
CREATE TABLE Theatres (
    TheatreId INT PRIMARY KEY auto_increment,
    Name VARCHAR(1000) NOT NULL,
    Address VARCHAR(1000) NOT NULL,
    Phone_no VARCHAR(1000) NOT NULL
);

CREATE TABLE Movies (
    MovieId INT PRIMARY KEY auto_increment,
    Name VARCHAR(1000) NOT NULL,
    Genre VARCHAR(1000),
    Director VARCHAR(1000),
    TheatreId INT,
    FOREIGN KEY (TheatreId) REFERENCES Theatres(TheatreId)
);

/* Dummy values for 2 tables*/
INSERT INTO theatres 
(TheatreId, Name, Address, Phone_no) 
VALUES(1, 'REGAL E-WALK 4DX & RPX','247 W. 42nd St., New York, NY 10036','(844)462-7342'),
(2, 'AMC EMPIRE 25','234 West 42nd St., New York, NY 10036', '(212) 398-2597'),
(3, 'AMC 34TH STREET 14','312 W. 34th St., New York, NY 10001','(212) 244-4556'),
(4,'PARIS THEATER','4 W. 58th St., New York, NY 10019','(212) 823-8945'),
(5,'AMC LINCOLN SQUARE 13','1998 Broadway, New York, NY 10023','(212) 336-5020'),
(6,'AMC KIPS BAY 15','570 Second Ave., New York, NY 10016','212) 447-0638'),
(7,'AMC 19TH ST. EAST 6','890 Broadway, New York, NY 10003','(212) 260-8173'),
(8,'REGAL ATLAS PARK','80-28 Cooper Avenue, Glendale, NY 11385','(844) 462-7342'),
(9,'REGAL UA MIDWAY','108-22 Queens Blvd., Forest Hills, NY 11375','(844) 462-7342');

INSERT INTO Movies (MovieId,Name,Genre,Director,TheatreId) 
VALUES(1, 'The NorthMan','Action/Adventure','Robert Eggers',8),
(2, 'Father Stu','Drama', 'Rosalind Ross',9),
(3, 'The Batman','Action/Adventure','Matt Reeves',8);

-- get all the theatre list in database
select * from theatres;
-- get all movie list in database
select * from movies;
-- get all movies playing in a particular theatre (for eg: 8)
SELECT 
    A.*, B.*
FROM
    Theatres AS A
        INNER JOIN
    Movies AS B ON A.TheatreId = B.TheatreId
WHERE A.TheatreId = 8;


