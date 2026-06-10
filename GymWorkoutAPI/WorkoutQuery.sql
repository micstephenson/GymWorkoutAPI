CREATE TABLE Workouts(
	WorkoutID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	WorkoutName VARCHAR(100),
	WorkoutSets INT,
	Reps INT,
	Duration FLOAT,
);

CREATE TABLE Trainers(
	TrainerID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Email VARCHAR(100)
);

CREATE TABLE GymSessions(
	SessionID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	SessionDate DATE NOT NULL,
	OverallDuration FLOAT NOT NULL,
	TrainerID INT NOT NULL,
	FOREIGN KEY (TrainerID) REFERENCES Trainers(TrainerID)
);

CREATE TABLE SessionWorkout(
	SessionID INT NOT NULL,
	WorkoutID INT NOT NULL,
	PRIMARY KEY (SessionID, WorkoutID),
	FOREIGN KEY (SessionID) REFERENCES GymSessions(SessionID),
	FOREIGN KEY (WorkoutID) REFERENCES Workouts(WorkoutID)
);

ALTER TABLE SessionWorkout
DROP COLUMN Duration;

INSERT INTO Workouts (WorkoutName, WorkoutSets, Reps, Duration)
VALUES ('RDLS', '3', '3', '30');

INSERT INTO Trainers (FirstName, LastName, Email)
VALUES ('Miah', 'Bovey', 'MiahBovey@gymplace.com');

INSERT INTO GymSessions (SessionDate, OverallDuration, TrainerID)
VALUES ('Jane', 'Doe', 2);

INSERT INTO Trainers (FirstName, LastName, Email)
VALUES
('Alice', 'Johnson', 'alice.johnson@example.com'),
('Bob', 'Smith', 'bob.smith@example.com');

INSERT INTO Workouts (WorkoutName, WorkoutSets, Reps, Duration)
VALUES
('Bench Press', 4, 10, 20),
('Deadlift', 3, 8, 25),
('Squats', 5, 12, 30),
('Plank', 1, 1, 5); -- Reps 1 means a single timed hold

INSERT INTO GymSessions (SessionDate, OverallDuration, TrainerID)
VALUES
('2025-09-15', 60, 1),
('2025-09-16', 45, 2);

-- Session 1 has Bench Press and Squats
INSERT INTO SessionWorkout (SessionID, WorkoutID)
VALUES
(1, 1),  -- Bench Press
(1, 3);  -- Squats

-- Session 2 has Deadlift and Plank
INSERT INTO SessionWorkout (SessionID, WorkoutID)
VALUES
(2, 2),  -- Deadlift
(2, 4);   -- Plank

UPDATE Workouts
SET Reps = NULL
WHERE WorkoutID IN(4,5,6);

DELETE FROM Workouts
WHERE WorkoutID = '1019';

ALTER TABLE Workouts
ALTER COLUMN Difficulty VARCHAR(30) NOT NULL;

SELECT * FROM Workouts;

DROP TABLE Trainers;

SELECT
    gs.SessionID,
    gs.SessionDate,
    t.FirstName + ' ' + t.LastName AS TrainerName,
	w.WorkoutID,
    w.WorkoutName,
    w.WorkoutSets,
    w.Reps,
    gs.OverallDuration AS SessionDuration
FROM GymSessions gs
INNER JOIN Trainers t
    ON gs.TrainerID = t.TrainerID
INNER JOIN SessionWorkout sw
    ON gs.SessionID = sw.SessionID
INNER JOIN Workouts w
    ON sw.WorkoutID = w.WorkoutID
WHERE gs.SessionID = 1;

SELECT
    gs.SessionID,
    w.WorkoutName,
    w.WorkoutSets,
    w.Reps,
    gs.OverallDuration AS SessionDuration
FROM GymSessions gs
INNER JOIN SessionWorkout sw
    ON gs.SessionID = sw.SessionID
INNER JOIN Workouts w
    ON sw.WorkoutID = w.WorkoutID
WHERE gs.SessionID = 1;