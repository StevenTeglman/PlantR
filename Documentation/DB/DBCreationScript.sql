use PlantR

create table Plant(
id int identity(1,1) primary key,
cname varchar(255) not null,
lname varchar(255) not null,
imgurl varchar(255) not null,
description varchar(255) not null,
sdays int not null
);

create table Account(
id int identity(1,1) primary key,
username varchar(255) not null unique,
email varchar(255) not null unique,
password varchar(255) not null,
);

create table PersonalPlant(
id int identity(1,1) primary key,
pid int not null,
aid int not null,
nname varchar(255) not null,
lastwatered date not null,
nextwatered date not null,
wduration int not null,
Foreign key (pid) references Plant(id),
Foreign key (aid) references Account(id)
);