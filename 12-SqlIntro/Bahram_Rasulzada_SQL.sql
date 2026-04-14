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

select * from Employees

select * from Employees where Salary>2000
select * from Employees where Department='IT'
select * from Employees order by Salary desc
select Firstname,Salary from Employees  
select * from Employees where HireDate>'2020'
select * from Employees where Email like '%company.az';
--select FirstName,YEAR(HireDate) as HireDate from Employees where YEAR(HireDate)='2020'


select Max(Salary) from Employees
SELECT FirstName, Salary FROM Employees WHERE Salary = (SELECT MAX(Salary) FROM Employees)
SELECT FirstName, Salary FROM Employees WHERE Salary = (SELECT MIN(Salary) FROM Employees)
SELECT FirstName, Salary FROM Employees WHERE Salary = (SELECT AVG(Salary) FROM Employees)
select COUNT(*) from Employees 
select Sum(Salary) as TotalSalary from Employees  


select Department,Count(*) as Department_Isciler from Employees  Group by Department
select Department,Salary from Employees where Salary=(Select AVG(Salary) from Employees)
select Department, AVG(Salary) as Ortalama_Department_Maas from Employees Group by Department
select Department, MAX(Salary) as Max_Department_Maas from Employees Group by Department


delete from Employees where EmployeeID=5