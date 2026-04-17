create database Company2
use Company2

create table Employees
(
	EmployeeID int primary key identity,
	Name nvarchar(max) not null,
	SurName nvarchar(max) default('xxx'),
	Age int,
	Salary decimal,
	Postion nvarchar(max),
	isDeleted bit,

	CityId int foreign key (CityID) references Cities(CityID),
)
create table Cities
(
	CityID int primary key identity,
	CityName nvarchar(200) not null unique,
	CountryID int foreign key (CountryID) references Countries(CountryID),
)
create table Countries
(
	CountryID int primary key identity,
	CountryName nvarchar(200) unique not null,
)

insert into Countries 
values 
('Azerbaijan'),
('Spain'),
('Turkey'),
('Russia')

insert into Cities
values
('Baku', 1),
('Madrid', 2),
('Barcelona', 2),
('Istanbul', 3),
('Ankara', 3),
('Moscow', 4)

insert into Employees
values
('Elvin', 'Aliyev', 30, 5000, 'Developer', 0, 1),
('Leyla', 'Huseynova', 28, 4500, 'Designer', 1, 1),
('Murad', 'Mammadov', 35, 6000, 'Manager', 0, 2),
('Aysel', 'Guliyeva', 32, 5500, 'Developer', 0, 2),
('Izzet','Qurbanov',25,980,'Salesman',1,3),
('Nigar','Aliyeva',29,1200,'Reseption',0,6)

--truncate table Employees

delete Employees

select * from Employees
select * from Cities

select e.Name,e.SurName, c.CityName as City, co.CountryName as Country from Employees e
join Cities c on e.CityId = c.CityID
join Countries co on c.CountryID = co.CountryID

select e.Name,e.Salary, c.CityName as City, co.CountryName as Country from Employees e
join Cities c on e.CityId = c.CityID
join Countries co on c.CountryID = co.CountryID
where e.Salary>2000

select CityName as City,co.CountryName from Cities e
join Countries co on e.CountryID = co.CountryID

select e.Name,e.SurName,e.Age,e.Salary,e.Postion, e.isDeleted from Employees e
where Postion='Reseption'

select e.Name,e.SurName, c.CityName City,co.CountryName from Employees e
join Cities c on e.CityId=c.CityID
join Countries co on co.CountryID=c.CountryID
where e.isDeleted=1

