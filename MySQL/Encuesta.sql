drop database if exists encuesta;
create database Encuesta;
use Encuesta;

/*TEMPLATES*/

create table answerGroup
(
answerGroupId INT primary key auto_increment,
answerGroupName VARCHAR(50)
);

create table answer
(
answerId int primary key auto_increment,
answerGroupId int,
answer VARCHAR(50),
foreign key (answerGroupId) references answerGroup(answerGroupId)
);

create table question
(
questionId INT primary key auto_increment,
answerGroupId INT,
question VARCHAR(70),
foreign key (answerGroupId) references answerGroup(answerGroupId)
);

create table quiz
(
quizId INT primary key auto_increment,
quizName VARCHAR(50)
);


create table quiz_has_question
(
questionId INT,
quizId INT,
primary key (questionId,quizId),
foreign key (questionId) references question(questionId),
foreign key (quizId) references quiz(quizId)
);


/*QUIZZES*/

create table quizDevice
(
quizDeviceId INT primary key auto_increment,
quizToApply INT,
quizDeviceName VARCHAR(30),
quizDeviceLocation varchar(45),
dateCreated datetime default now(),
foreign key (quizToApply) references quiz(quizId)
);

create table answeredQuiz
(
answeredQuizId INT primary key auto_increment,
quizDeviceId INT,
creationDate DATE,
foreign key (quizDeviceId) references quizDevice(quizDeviceId)
);

create table answeredQuizDetail
(
answerId  INT,
questionId INT,
answeredQuizId INT,
elapsedTime time,
PRIMARY KEY (answeredQuizId, questionId),
foreign key (answerId) references answer(answerId),
foreign KEY (questionId) references question(questionId),
foreign KEY (answeredQuizId) references answeredQuiz(answeredQuizId)
);


/*USER PERMITS*/
create table userRole
(
userRoleId INT primary key auto_increment,
roleName VARCHAR(60)
);

create table user
(
userId INT primary key auto_increment,
roleId INT,
userName VARCHAR (60),
password VARCHAR(15),
foreign key (roleId) references userRole(userRoleId)
);

create table  permit
(
permitId INT primary key auto_increment,
permitName VARCHAR(20)
);

create table userRole_has_permit
(
userRoleId INT,
permitId INT,
permitAllowed TINYINT(1),
foreign key (userRoleId) references userRole(userRoleId),
foreign key (permitId) references permit(permitId),
check (permitAllowed = 0 or permitAllowed = 1)
);

/** 
Datos por defecto
**/
insert into answergroup 
values 
(1,'Face icons'),
(2,'Star icons');

insert into answer 
values 
(1,1,'[icon:face1]'),
(2,1,'[icon:face2]'),
(3,1,'[icon:face3]'),
(4,1,'[icon:face4]'),
(5,1,'[icon:face5]'),
(6,2,'[icon:star1]'),
(7,2,'[icon:star2]'),
(8,2,'[icon:star3]'),
(9,2,'[icon:star4]'),
(10,2,'[icon:star5]');

insert into quiz 
values 
(1,'Encuesta de satisfacción'),
(2,'Encuesta de limpieza');

insert into question 
values
(1,2,'Como califica nuestros servicios'),
(2,2,'Como valora la calidad de nuestros productos'),
(3,2,'Como califica la limpieza de los baÃ±os'),
(4,2,'Como califica la limpieza de la recepciÃ³n');

insert into quiz_has_question 
values 
(1,1),
(2,1),
(3,2),
(4,2);

insert into quizdevice 
values
(1,1,'Dipositivo 1','Recepción',CURRENT_TIMESTAMP),
(2,2,'Dipositivo 2','Tienda',CURRENT_TIMESTAMP);

-- Consultar preguntas a realizar en el dispotivio cliente
select q.questionId, q.question, q.answerGroupId from question q
inner join quiz_has_question qhq on q.questionId = qhq.questionId 
inner join quiz on quiz.quizId = qhq.quizId 
inner join quizdevice device on device.quizToApply = quiz.quizId 
where device.quizDeviceId = 2;

-- Consultar las respuestas por cada pregunta
select a.answerId, a.answer from answer a 
inner join answergroup ag on a.answerGroupId = ag.answerGroupId 
where ag.answerGroupId = 2;
