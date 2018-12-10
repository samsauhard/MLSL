create database soccer_management;
use soccer_management;
create table Clubs(name varchar(100), city varchar(100), registration_number varchar(100) primary key, address varchar(20));
create table players(club_registration_number varchar(50), name varchar(50), date_of_birth varchar(50), jersey_number varchar(50));
create table matches(home varchar(50), away varchar(50), matchdate varchar(50), homeid varchar(50), awayid varchar(50));