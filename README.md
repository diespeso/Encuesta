## Instituto Tecnologico de Tijuana

### Integrantes:
- Rojas Ceballos Oscar Alonso
- Garcia Chacon Daniel
- Dominguez Cruz Carolina
- Regalado Lopez Edgar Eduardo
- Meza Guerrero Alberto Hazael


### Proyecto
- Encuesta
Permite aplicar y editar encuestas de satisfacción del cliente.

## Indice
### Avance 1
- [Diagrama](/imagenes/DiagramaV1.png)


## DDL
```SQL
create database Encuesta;
use Encuesta;

/*TEMPLATES*/
create table answers
(
answerId INT primary key,
answer VARCHAR(50)
);

create table answersGroup
(
answerGroupId INT primary key,
answerId INT,
answerGroupName VARCHAR(50),
foreign key (answerId) references answers(answerId)
);

create table questions
(
questionId INT primary key,
answerGroup INT,
questionName VARCHAR(40),
question VARCHAR(70),
foreign key (answerGroup) references answersGroup(answerGroupId)
);

create table questionsGroup_has_questions
(
questionId INT,
answerGroupId INT,
primary key (questionId,answerGroupId),
foreign key (questionId) references questions(questionId),
foreign key (answerGroupId) references answersGroup(answerGroupId)
);

create table questionsGroup
(
questionGroupId INT primary key,
questionGroupName VARCHAR(50)
);

/*QUIZZES*/

create table quizDevices
(
quizDeviceId INT primary key,
questionGroupToApply INT,
quizDeviceName VARCHAR(30),
dateCreated DATE,
foreign key (questionGroupToApply) references questionsGroup (questionGroupId)
);

create table answeredQuiz
(
answeredQuizId INT primary key,
quizDeviceId INT,
creationDate DATE,
elasedTime TIME,
foreign key (quizDeviceId) references quizDevices(quizDeviceId)
);

create table answeredQuizDetails
(
answerId  INT,
questionId INT,
answeredQuizId INT,
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
```
