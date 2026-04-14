create database Company
use Company
create table Employees 
(
EmployeeID int,
FirstName nvarchar(max),
LastName nvarchar(max),
Email nvarchar(max),
PhoneNumber nvarchar(max),
HireDate date,
JobTitle nvarchar(max),
Salary money,
Department nvarchar(max),
)

insert into Employees
values
(1, 'John', 'Doe', 'john.doe@company.az', '1234567890', '2020-01-15', 'Software Engineer', 60000, 'IT'),
(2, 'Jane', 'Smith', 'jane.smith@example.com', '9876543210', '2019-03-22', 'IT Manager', 75000, 'IT'),
(3, 'Michael', 'Johnson', 'michael.johnson@example.com', '5551234567', '2021-07-10', 'Accountant', 55000, 'Finance'),
(4, 'Emily', 'Davis', 'emily.davis@company.az', '4449871234', '2018-11-05', 'Marketing Specialist', 50000, 'Marketing'),
(5, 'David', 'Brown', 'david.brown@example.com', '3332221111', '2022-06-18', 'Sales Executive', 52000, 'Sales')
delete Employees

--1
select * from Employees

--2
select * from Employees where Salary>2000

--3
select * from Employees where Department='IT'

--4
select * from Employees order by Salary desc

--5
select Firstname,Salary from Employees  

--6
select * from Employees where HireDate>'2020'

--7
select * from Employees where Email like '%company.az';
--select FirstName,YEAR(HireDate) as HireDate from Employees where YEAR(HireDate)='2020'

--8
select Max(Salary) from Employees
SELECT FirstName, Salary FROM Employees WHERE Salary = (SELECT MAX(Salary) FROM Employees)

--9
SELECT FirstName, Salary FROM Employees WHERE Salary = (SELECT MIN(Salary) FROM Employees)

--10
SELECT FirstName, Salary FROM Employees WHERE Salary = (SELECT AVG(Salary) FROM Employees)

--11
select COUNT(*) from Employees 

--12
select Sum(Salary) as TotalSalary from Employees  

--13
select Department,Count(*) as Department_Isciler from Employees  Group by Department

--14
select Department, AVG(Salary) as Ortalama_Department_Maas from Employees Group by Department

--15
select Department, MAX(Salary) as Max_Department_Maas from Employees Group by Department

--16
update Employees set Salary=2800 where EmployeeID=1 
--select * from Employees

--17
update Employees set Salary=Salary*1.1 where Department='IT'
--select * from Employees

--18
--update Employees set FirstName='Leyla', LastName='Hesenova' where EmployeeID=2
--select * from Employees
update Employees set JobTitle='HR Meneceri' where FirstName='Leyla' AND LastName='Hesenova'
--select * from Employees

--19
delete from Employees where EmployeeID=5

--20
insert into Employees
values
(6, 'Sarah', 'Wilson', 'sarah.wilson@company.az', '2223334444', '2023-01-10', 'HR Specialist', 1400, 'HR')
select * from Employees
delete from Employees where Salary<1500

--21
select FirstName from Employees where FirstName like '%a%'
--select * from Employees

--22
insert into Employees
values
(7, 'Alex', 'Taylor', 'alex.taylor@gmail.com', '1112223333', '2024-05-01', 'Data Analyst', 2300, 'IT')
select FirstName,Salary from Employees where Salary between 2000 and 2500
--select * from Employees

--23
select * from Employees where Department in ('IT', 'Finance')
--select * from Employees