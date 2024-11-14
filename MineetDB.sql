CREATE DATABASE MineetDB
USE MineetDB

CREATE TABLE Meetings(

    meeting_Id INT IDENTITY(1,1) PRIMARY KEY,
    meeting_Name VARCHAR(100) NOT NULL,
    meeting_Type VARCHAR(20) NOT NULL,
    meeting_Date DATE NOT NULL
)

CREATE TABLE MeetingItem(
    item_Id INT IDENTITY(1,1) PRIMARY KEY,
    item_Name VARCHAR(100) NOT NULL,
    item_Description VARCHAR(MAX) NOT NULL,
    item_Status VARCHAR(20) NOT NULL,
    item_PersonResponsible VARCHAR(30) NOT NULL,
    meeting_Id INT,
    FOREIGN KEY (meeting_Id) REFERENCES Meetings (meeting_Id),
    itemMeeting_Date DATE NOT NULL
)

CREATE TABLE MeetingItemHistory(
    item_HistoryId INT IDENTITY(1,1) PRIMARY KEY,
    item_Name VARCHAR(100) NOT NULL,
    item_Description VARCHAR(MAX) NOT NULL,
    item_Status VARCHAR(20) NOT NULL,
    item_PersonResponsible VARCHAR(30) NOT NULL,
    meeting_Id INT,
    FOREIGN KEY (meeting_Id) REFERENCES Meetings (meeting_Id),
	item_Id INT, 
    FOREIGN KEY (item_Id) REFERENCES MeetingItem (item_Id),
    itemMeeting_Date DATE NOT NULL
)




INSERT INTO Meetings (meeting_Name, meeting_Type, meeting_Date)
VALUES 
('Project Kickoff', 'Internal', '2024-11-15'),
('Client Presentation', 'External', '2024-11-20'),
('Team Retrospective', 'Internal', '2024-11-22'),
('Budget Review', 'Internal', '2024-11-25'),
('Sales Meeting', 'External', '2024-11-28'),
('Strategy Planning', 'Internal', '2024-12-01'),
('Product Launch', 'External', '2024-12-05'),
('Quarterly Review', 'Internal', '2024-12-10');

INSERT INTO MeetingItem (item_Name, item_Description, item_Status, item_PersonResponsible, meeting_Id, itemMeeting_Date)
VALUES 
    ('Budget Approval', 'Review and approve the budget for Q1.', 'Pending', 'Alice Johnson', 1, '2024-11-15');
	


INSERT INTO MeetingItemHistory (item_Name, item_Description, item_Status, item_PersonResponsible, meeting_Id, item_Id, itemMeeting_Date)
VALUES 
    ('Budget Approval', 'Review and approve the budget for Q1.', 'Pending', 'Alice Johnson', 1, 1, '2024-11-15');




	
DROP TABLE Meetings
DROP TABLE MeetingItem
DROP TABLE MeetingItemHistory

Select * From Meetings
Select * From MeetingItem
Select * From MeetingItemHistory

DELETE FROM MeetingItemHistory WHERE item_Name ='Finalise SomeCompany contract'