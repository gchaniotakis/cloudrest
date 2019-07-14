create table Teachers(
id int identity (1,1) not null,
firstname nvarchar(50) not null,
lastname nvarchar(50) not null,
primary key (id)
);

create table Students(
id int identity (1,1) not null,
firstname nvarchar(50) not null,
lastname nvarchar(50) not null,
primary key (id)
);

create table Lessons(
id int identity (1,1) not null,
title nvarchar(50) not null,
primary key(id)
);

create table TeacherLessons(
teacherid int not null,
lessonid int not null,
constraint fk_teacherlessons1 foreign key (teacherid) references Teachers(id),
constraint fk_teacherlessons2 foreign key (lessonid) references Lessons(id)
);

create table StudentLessons(
studentid int not null,
lessonid int not null,
constraint fk_studentlessons1 foreign key (studentid) references Students(id),
constraint fk_studentlessons2 foreign key (lessonid) references Lessons(id)
);