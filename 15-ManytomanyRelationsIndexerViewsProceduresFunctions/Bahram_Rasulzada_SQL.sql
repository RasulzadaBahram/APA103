create database CompanyMM
use CompanyMM

create table Employees
(
	EmployeeID int primary key identity,
	FirstName nvarchar(max) not null,
	LastName nvarchar(max) not null,
	BirthDate date not null,
	Email nvarchar(50) not null unique
)
create table Projects
(
ProjectID int primary key identity,
ProjectName nvarchar(max) not null,
StartDate date not null,
EndDate date not null
)

create table EmployeeProjects
(
EmployeeID int foreign key(EmployeeID) references Employees(EmployeeID),
ProjectID int foreign key(ProjectID) references Projects(ProjectID),
AssignedDate date not null
Primary key(EmployeeID, ProjectID)
)

INSERT INTO Employees (FirstName, LastName, BirthDate, Email)
VALUES 
('Alice', 'Johnson', '1985-03-12', 'alice.j@example.com'),
('Bob', 'Smith', '1990-07-22', 'b.smith@example.com'),
('Charlie', 'Davis', '1982-11-05', 'charlie.d@example.com'),
('Diana', 'Prince', '1995-01-30', 'diana.p@example.com');

INSERT INTO Projects (ProjectName, StartDate, EndDate)
VALUES 
('Cloud Migration', '2023-01-01', '2023-06-30'),
('Mobile App Redesign', '2023-03-15', '2023-12-20'),
('Security Audit', '2023-05-01', '2023-08-15');

INSERT INTO EmployeeProjects (EmployeeID, ProjectID, AssignedDate)
VALUES 
(1, 1, '2023-01-01'), -- Alice on Cloud Migration
(1, 2, '2023-03-15'), -- Alice on Mobile App
(2, 2, '2023-03-15'), -- Bob on Mobile App
(3, 3, '2023-05-01'), -- Charlie on Security Audit
(4, 1, '2023-02-10'); -- Diana on Cloud Migration

SELECT e.EmployeeID, e.FirstName, e.LastName, p.ProjectName, ep.AssignedDate from Employees e
join EmployeeProjects ep on e.EmployeeID = ep.EmployeeID
join Projects p on ep.ProjectID = p.ProjectID

SELECT p.ProjectName, COUNT(ep.EmployeeID) as EmployeeCount from Projects p
join EmployeeProjects ep on p.ProjectID = ep.ProjectID
group by p.ProjectName

SELECT e.EmployeeID, e.FirstName, e.LastName, COUNT(ep.ProjectID) as ProjectCount from Employees e
join EmployeeProjects ep on e.EmployeeID = ep.EmployeeID
group by  e.EmployeeID, e.FirstName, e.LastName
HAVING COUNT(ep.ProjectID) >= 2


CREATE VIEW EmployeeProjectView AS

SELECT e.EmployeeID, CONCAT(e.FirstName, ' ', e.LastName) as FullName, p.ProjectID, p.ProjectName, ep.AssignedDate
FROM Employees e
JOIN EmployeeProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID

SELECT * from EmployeeProjectView where EmployeeID = 2

CREATE procedure sp_AssignEmployeeToProject @eId  int, @proId int
as
begin
    if not exists (
        select 1 from EmployeeProjects
        where EmployeeID = @eId and ProjectID = @proId
    )
    begin
        insert into EmployeeProjects (EmployeeID, ProjectID, AssignedDate)
        values (@eId, @proId, GETDATE())
    end
end


EXEC sp_AssignEmployeeToProject 2,1

SELECT * FROM EmployeeProjectView WHERE EmployeeID = 2

create function fn_GetProjectCount(@empId int)
returns int
as
begin
    declare @count int
    select @count = COUNT(*) from EmployeeProjects
    where EmployeeID = @empId
    return @count
end

SELECT e.EmployeeID, e.FirstName, e.LastName, dbo.fn_GetProjectCount(e.EmployeeID) AS ProjectCount
from Employees e

EXEC sp_AssignEmployeeToProject 5, 1

SELECT * FROM EmployeeProjectView
WHERE EmployeeID = 5

DELETE FROM EmployeeProjects
WHERE EmployeeID = 4

