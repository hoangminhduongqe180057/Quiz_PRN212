create database Quiz
use Quiz

-- Table for User
CREATE TABLE [User] (
    Id INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(100) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL -- E.g., "Admin", "Teacher", "Student"
);

-- Table for Student, with foreign key to User
CREATE TABLE Student (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    UserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES [User](Id)
);

-- Table for Category
CREATE TABLE Category (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL -- E.g., "Math", "Science", "History"
);

-- Table for Quiz, with foreign key to Category
CREATE TABLE Quiz (
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(200) NOT NULL,
    CategoryId INT NOT NULL,
    Duration TIME, -- Optional, for timed quizzes
    FOREIGN KEY (CategoryId) REFERENCES Category(Id)
);

-- Table for Question, with foreign key to Quiz
CREATE TABLE Question (
    Id INT PRIMARY KEY IDENTITY,
    Text NVARCHAR(500) NOT NULL,
    CorrectAnswerId INT NULL, -- Reference to Answer.Id for correct answer
    QuizId INT NOT NULL,
    FOREIGN KEY (QuizId) REFERENCES Quiz(Id)
);

-- Table for Answer, with foreign key to Question
CREATE TABLE Answer (
    Id INT PRIMARY KEY IDENTITY,
    Text NVARCHAR(200) NOT NULL,
    IsCorrect BIT NOT NULL,
    QuestionId INT NOT NULL,
    FOREIGN KEY (QuestionId) REFERENCES Question(Id)
);

-- Table for Mark, with foreign keys to Student and Quiz
CREATE TABLE Mark (
    Id INT PRIMARY KEY IDENTITY,
    StudentId INT NOT NULL,
    QuizId INT NOT NULL,
    Score INT NOT NULL,
    DateTaken DATETIME NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES Student(Id),
    FOREIGN KEY (QuizId) REFERENCES Quiz(Id)
);
