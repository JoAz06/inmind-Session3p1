create table Enrollments(student_id SERIAL references Student(id), course_id SERIAL references Courses(id));

create table Courses(id SERIAL primary key, name varchar(100), teacher_id SERIAL references Teacher(id));

create table Teacher(id SERIAL primary key, name varchar(100));

create table Student(id SERIAL PRIMARY KEY,name varchar(100), dob DATE, country varchar(100));