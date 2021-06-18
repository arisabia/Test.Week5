--create database scuola

create table Studente(
	ID int identity(1,1) primary key not null,
	Nome varchar(50) not null,
	Cognome varchar(50) not null,
	AnnoNascita int not null,
	unique(Nome,Cognome,AnnoNascita)
)

insert into Studente values
('Mario','Simoni',1999),
('Anna','Rossi',1989),
('Maria','Mauro',2000),
('Sarah','Bianchi',2001)

create table Esame(
	ID int identity(1,1) primary key not null,
	Nome varchar(50) not null,
	CFU int not null,
	Data date not null,
	Votazione int,
	Passato char(1),
	
	check(Passato in ('Y', 'N'))

)
insert into Esame values
('Matematica', 2,'2021-02-01', 100,'Y'),
('Scienze', 5,'2021-03-11',99 ,'Y'),
('Storia',3 ,'2021-04-05', 30,'N')

create table EsameStudente(
	StudenteID int,
	EsameID int,
	foreign key(StudenteID) references Studente(ID),
	foreign key(EsameID) references Esame(ID)
)

insert into EsameStudente values 
(1,1),
(2,2),
(3,3),
(1,2),
(1,3)
