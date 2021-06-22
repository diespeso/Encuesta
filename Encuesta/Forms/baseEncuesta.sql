-- MySqlBackup.NET 2.3.4
-- Dump Time: 2021-06-21 21:26:55
-- --------------------------------------
-- Server version 8.0.23 MySQL Community Server - GPL


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

CREATE DATABASE IF NOT EXISTS encuesta;
USE encuesta;

-- 
-- Definition of answergroup
-- 
DROP TABLE IF EXISTS `answergroup`;
CREATE TABLE IF NOT EXISTS `answergroup` (
  `answerGroupId` int NOT NULL AUTO_INCREMENT,
  `answerGroupName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`answerGroupId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table answergroup
-- 

/*!40000 ALTER TABLE `answergroup` DISABLE KEYS */;
INSERT INTO `answergroup`(`answerGroupId`,`answerGroupName`) VALUES
(1,'Face icons'),
(2,'Star icons');
/*!40000 ALTER TABLE `answergroup` ENABLE KEYS */;

-- 
-- Definition of answer
-- 

DROP TABLE IF EXISTS `answer`;
CREATE TABLE IF NOT EXISTS `answer` (
  `answerId` int NOT NULL AUTO_INCREMENT,
  `answerGroupId` int DEFAULT NULL,
  `answer` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`answerId`),
  KEY `answerGroupId` (`answerGroupId`),
  CONSTRAINT `answer_ibfk_1` FOREIGN KEY (`answerGroupId`) REFERENCES `answergroup` (`answerGroupId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table answer
-- 

/*!40000 ALTER TABLE `answer` DISABLE KEYS */;
INSERT INTO `answer`(`answerId`,`answerGroupId`,`answer`) VALUES
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
/*!40000 ALTER TABLE `answer` ENABLE KEYS */;

-- 
-- Definition of permit
-- 

DROP TABLE IF EXISTS `permit`;
CREATE TABLE IF NOT EXISTS `permit` (
  `permitId` int NOT NULL AUTO_INCREMENT,
  `permitName` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`permitId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table permit
-- 

/*!40000 ALTER TABLE `permit` DISABLE KEYS */;
INSERT INTO `permit`(`permitId`,`permitName`) VALUES
(1,'VerDispositivos'),
(2,'AgregarDispositivos'),
(3,'VerUsuarios'),
(4,'AgregarUsuarios'),
(5,'VerEncuestas'),
(6,'AgregarEncuestas'),
(7,'VerReportes'),
(8,'Respaldos');
/*!40000 ALTER TABLE `permit` ENABLE KEYS */;

-- 
-- Definition of question
-- 

DROP TABLE IF EXISTS `question`;
CREATE TABLE IF NOT EXISTS `question` (
  `questionId` int NOT NULL AUTO_INCREMENT,
  `answerGroupId` int DEFAULT NULL,
  `question` varchar(70) DEFAULT NULL,
  PRIMARY KEY (`questionId`),
  KEY `answerGroupId` (`answerGroupId`),
  CONSTRAINT `question_ibfk_1` FOREIGN KEY (`answerGroupId`) REFERENCES `answergroup` (`answerGroupId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table question
-- 

/*!40000 ALTER TABLE `question` DISABLE KEYS */;

/*!40000 ALTER TABLE `question` ENABLE KEYS */;

-- 
-- Definition of quiz
-- 

DROP TABLE IF EXISTS `quiz`;
CREATE TABLE IF NOT EXISTS `quiz` (
  `quizId` int NOT NULL AUTO_INCREMENT,
  `quizName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`quizId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table quiz
-- 

/*!40000 ALTER TABLE `quiz` DISABLE KEYS */;

/*!40000 ALTER TABLE `quiz` ENABLE KEYS */;

-- 
-- Definition of quiz_has_question
-- 

DROP TABLE IF EXISTS `quiz_has_question`;
CREATE TABLE IF NOT EXISTS `quiz_has_question` (
  `questionId` int NOT NULL,
  `quizId` int NOT NULL,
  PRIMARY KEY (`questionId`,`quizId`),
  KEY `quizId` (`quizId`),
  CONSTRAINT `quiz_has_question_ibfk_1` FOREIGN KEY (`questionId`) REFERENCES `question` (`questionId`),
  CONSTRAINT `quiz_has_question_ibfk_2` FOREIGN KEY (`quizId`) REFERENCES `quiz` (`quizId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table quiz_has_question
-- 

/*!40000 ALTER TABLE `quiz_has_question` DISABLE KEYS */;

/*!40000 ALTER TABLE `quiz_has_question` ENABLE KEYS */;

-- 
-- Definition of quizdevice
-- 

DROP TABLE IF EXISTS `quizdevice`;
CREATE TABLE IF NOT EXISTS `quizdevice` (
  `quizDeviceId` int NOT NULL AUTO_INCREMENT,
  `quizToApplyId` int DEFAULT NULL,
  `quizDeviceName` varchar(30) DEFAULT NULL,
  `quizDeviceLocation` varchar(45) DEFAULT NULL,
  `dateCreated` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`quizDeviceId`),
  KEY `quizToApplyId` (`quizToApplyId`),
  CONSTRAINT `quizdevice_ibfk_1` FOREIGN KEY (`quizToApplyId`) REFERENCES `quiz` (`quizId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table quizdevice
-- 

/*!40000 ALTER TABLE `quizdevice` DISABLE KEYS */;

/*!40000 ALTER TABLE `quizdevice` ENABLE KEYS */;

-- 
-- Definition of answeredquiz
-- 

DROP TABLE IF EXISTS `answeredquiz`;
CREATE TABLE IF NOT EXISTS `answeredquiz` (
  `answeredQuizId` int NOT NULL AUTO_INCREMENT,
  `quizDeviceId` int DEFAULT NULL,
  `creationDate` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`answeredQuizId`),
  KEY `quizDeviceId` (`quizDeviceId`),
  CONSTRAINT `answeredquiz_ibfk_1` FOREIGN KEY (`quizDeviceId`) REFERENCES `quizdevice` (`quizDeviceId`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table answeredquiz
-- 

/*!40000 ALTER TABLE `answeredquiz` DISABLE KEYS */;

/*!40000 ALTER TABLE `answeredquiz` ENABLE KEYS */;

-- 
-- Definition of answeredquizdetail
-- 

DROP TABLE IF EXISTS `answeredquizdetail`;
CREATE TABLE IF NOT EXISTS `answeredquizdetail` (
  `answerId` int DEFAULT NULL,
  `questionId` int NOT NULL,
  `answeredQuizId` int NOT NULL,
  `elapsedTime` time DEFAULT NULL,
  PRIMARY KEY (`answeredQuizId`,`questionId`),
  KEY `answerId` (`answerId`),
  KEY `questionId` (`questionId`),
  CONSTRAINT `answeredquizdetail_ibfk_1` FOREIGN KEY (`answerId`) REFERENCES `answer` (`answerId`),
  CONSTRAINT `answeredquizdetail_ibfk_2` FOREIGN KEY (`questionId`) REFERENCES `question` (`questionId`),
  CONSTRAINT `answeredquizdetail_ibfk_3` FOREIGN KEY (`answeredQuizId`) REFERENCES `answeredquiz` (`answeredQuizId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table answeredquizdetail
-- 

/*!40000 ALTER TABLE `answeredquizdetail` DISABLE KEYS */;

/*!40000 ALTER TABLE `answeredquizdetail` ENABLE KEYS */;

-- 
-- Definition of userrole
-- 

DROP TABLE IF EXISTS `userrole`;
CREATE TABLE IF NOT EXISTS `userrole` (
  `userRoleId` int NOT NULL AUTO_INCREMENT,
  `roleName` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`userRoleId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table userrole
-- 

/*!40000 ALTER TABLE `userrole` DISABLE KEYS */;
INSERT INTO `userrole`(`userRoleId`,`roleName`) VALUES
(1,'Admin'),
(2,'Reportes'),
(3,'Encuestas');
/*!40000 ALTER TABLE `userrole` ENABLE KEYS */;

-- 
-- Definition of user
-- 

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `userId` int NOT NULL AUTO_INCREMENT,
  `roleId` int DEFAULT NULL,
  `userName` varchar(60) DEFAULT NULL,
  `password` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`userId`),
  KEY `roleId` (`roleId`),
  CONSTRAINT `user_ibfk_1` FOREIGN KEY (`roleId`) REFERENCES `userrole` (`userRoleId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table user
-- 

/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user`(`userId`,`roleId`,`userName`,`password`) VALUES
(1,1,'admin','$MYHASH$V1$10000$JlYHf7XUteA2E+e4aF1ufie8Zo8eB0OqUZyVOvYOUauAIwgl'),
(2,2,'reportes','reportes');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

-- 
-- Definition of userrole_has_permit
-- 

DROP TABLE IF EXISTS `userrole_has_permit`;
CREATE TABLE IF NOT EXISTS `userrole_has_permit` (
  `userRoleId` int DEFAULT NULL,
  `permitId` int DEFAULT NULL,
  `permitAllowed` tinyint(1) DEFAULT NULL,
  KEY `userRoleId` (`userRoleId`),
  KEY `permitId` (`permitId`),
  CONSTRAINT `userrole_has_permit_ibfk_1` FOREIGN KEY (`userRoleId`) REFERENCES `userrole` (`userRoleId`),
  CONSTRAINT `userrole_has_permit_ibfk_2` FOREIGN KEY (`permitId`) REFERENCES `permit` (`permitId`),
  CONSTRAINT `userrole_has_permit_chk_1` CHECK (((`permitAllowed` = 0) or (`permitAllowed` = 1)))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- 
-- Dumping data for table userrole_has_permit
-- 

/*!40000 ALTER TABLE `userrole_has_permit` DISABLE KEYS */;
INSERT INTO `userrole_has_permit`(`userRoleId`,`permitId`,`permitAllowed`) VALUES
(1,1,1),
(1,2,1),
(1,3,1),
(1,4,1),
(1,5,1),
(1,6,1),
(1,7,1),
(1,8,1),
(2,1,0),
(2,2,0),
(2,3,0),
(2,4,0),
(2,5,0),
(2,6,0),
(2,7,1),
(2,8,0),
(3,1,0),
(3,2,0),
(3,3,0),
(3,4,0),
(3,5,1),
(3,6,1),
(3,7,0),
(3,8,0);
/*!40000 ALTER TABLE `userrole_has_permit` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2021-06-21 21:26:55
-- Total time: 0:0:0:0:96 (d:h:m:s:ms)
