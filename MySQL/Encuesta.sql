create database Encuesta;
use Encuesta;

/*TEMPLATES*/

create table answersGroup
(
answerGroupId INT primary key,
answerGroupName VARCHAR(50)
);

create table answers
(
answerId INT primary key,
answerGroupId int,
answer VARCHAR(50),
foreign key (answerGroupId) references answersGroup(answerGroupId)
);

create table questions
(
questionId INT primary key,
answerGroupId INT,
question VARCHAR(70),
foreign key (answerGroupId) references answersGroup(answerGroupId)
);

create table quiz
(
quizId INT primary key,
quizName VARCHAR(50)
);


create table quiz_has_questions
(
questionId INT,
quizId INT,
primary key (questionId,quizId),
foreign key (questionId) references questions(questionId),
foreign key (quizId) references quiz(quizId)
);


/*QUIZZES*/

create table quizDevices
(
quizDeviceId INT primary key,
quizToApply INT,
quizDeviceName VARCHAR(30),
quizDeviceLocation varchar(45),
dateCreated DATE,
foreign key (quizToApply) references quiz (quizId)
);

create table answeredQuiz
(
answeredQuizId INT primary key,
quizDeviceId INT,
creationDate DATE,
foreign key (quizDeviceId) references quizDevices(quizDeviceId)
);

create table answeredQuizDetails
(
answerId  INT,
questionId INT,
answeredQuizId INT,
elasedTime time,
PRIMARY KEY (answeredQuizId, questionId),
foreign key (answerId) references answers(answerId),
foreign KEY (questionId) references questions(questionId),
foreign KEY (answeredQuizId) references answeredQuiz(answeredQuizId)
);


/*USER PERMITS*/
create table userRoles
(
userRoleId INT primary key,
roleName VARCHAR(60)
);

create table users
(
userId INT ,
roleId INT,
userName VARCHAR (60),
contrasena VARCHAR(15),
foreign key (roleId) references userRoles(userRoleId)
);

create table  permits
(
permitId INT primary key,
permitName VARCHAR(20)
);

create table userRoles_has_permits
(
userRoleId INT,
permitId INT,
permitAllowed TINYINT(1),
foreign key (userRoleId) references userRoles(userRoleId),
foreign key (permitId) references permits(permitId),
check (permitAllowed = 0 or permitAllowed = 1)
);

/** 
Datos por defecto
**/
insert into answersgroup 
values 
(1,'Face icons'),
(2,'Star icons');

insert into answers 
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

insert into questions 
values
(1,2,'Como califica nuestros servicios'),
(2,2,'Como valora la calidad de nuestros productos'),
(3,2,'Como califica la limpieza de los baños'),
(4,2,'Como califica la limpieza de la recepción');

insert into quiz_has_questions 
values 
(1,1),
(2,1),
(3,2),
(4,2);

insert into quizdevices 
values
(1,1,'Dipositivo 1','Recepción',now()),
(2,2,'Dipositivo 2','Tienda',now());

-- Consultar preguntas a realizar en el dispotivio cliente
select q.questionId, q.question, q.answerGroupId from questions q
inner join quiz_has_questions qhq on q.questionId = qhq.questionId 
inner join quiz on quiz.quizId = qhq.quizId 
inner join quizdevices device on device.quizToApply = quiz.quizId 
where device.quizDeviceId = 2;

-- Consultar las respuestas por cada pregunta
select a.answerId, a.answer from answers a 
inner join answersgroup ag on a.answerGroupId = ag.answerGroupId 
where ag.answerGroupId = 2;
