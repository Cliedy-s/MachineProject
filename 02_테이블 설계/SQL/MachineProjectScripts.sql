CREATE DATABASE  IF NOT EXISTS `machineprojectdb` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `machineprojectdb`;
-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: machineprojectdb
-- ------------------------------------------------------
-- Server version	8.0.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employees` (
  `EmployeeID` char(5) NOT NULL,
  `Name` varchar(30) NOT NULL,
  `Phone` varchar(14) DEFAULT NULL,
  `Email` varchar(30) DEFAULT NULL,
  `Addr` varchar(50) DEFAULT NULL,
  `Authority` varchar(10) NOT NULL,
  `ID` varchar(20) NOT NULL,
  `Password` varchar(20) NOT NULL,
  PRIMARY KEY (`EmployeeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `machine`
--

DROP TABLE IF EXISTS `machine`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `machine` (
  `MachineID` char(5) NOT NULL,
  `isRunning` bit(1) DEFAULT b'0',
  PRIMARY KEY (`MachineID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `machine`
--

LOCK TABLES `machine` WRITE;
/*!40000 ALTER TABLE `machine` DISABLE KEYS */;
/*!40000 ALTER TABLE `machine` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plistbymachine`
--

DROP TABLE IF EXISTS `plistbymachine`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `plistbymachine` (
  `MachineID` char(5) NOT NULL,
  `ProductionID` char(5) NOT NULL,
  `AmountPerDay` int(11) NOT NULL,
  PRIMARY KEY (`MachineID`,`ProductionID`),
  KEY `fk_production_plistbymachine_productionid` (`ProductionID`),
  CONSTRAINT `fk_machine_plistbymachine_machineid` FOREIGN KEY (`MachineID`) REFERENCES `machine` (`MachineID`),
  CONSTRAINT `fk_production_plistbymachine_productionid` FOREIGN KEY (`ProductionID`) REFERENCES `production` (`ProductionID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plistbymachine`
--

LOCK TABLES `plistbymachine` WRITE;
/*!40000 ALTER TABLE `plistbymachine` DISABLE KEYS */;
/*!40000 ALTER TABLE `plistbymachine` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `production`
--

DROP TABLE IF EXISTS `production`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `production` (
  `ProductionID` char(5) NOT NULL,
  `ProductionName` varchar(20) NOT NULL,
  PRIMARY KEY (`ProductionID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `production`
--

LOCK TABLES `production` WRITE;
/*!40000 ALTER TABLE `production` DISABLE KEYS */;
/*!40000 ALTER TABLE `production` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productionlist`
--

DROP TABLE IF EXISTS `productionlist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productionlist` (
  `ProductionCode` int(11) NOT NULL,
  `MachineID` char(5) NOT NULL,
  `ProductionID` char(5) NOT NULL,
  `TodoCode` int(11) NOT NULL,
  `EmployeeID` char(5) NOT NULL,
  `NormalAmount` int(11) NOT NULL,
  `DefectAmount` int(11) NOT NULL,
  `ProductionDate` datetime NOT NULL,
  PRIMARY KEY (`ProductionCode`),
  KEY `fk_plistbymachine_productionlist_machineid_productionid` (`MachineID`,`ProductionID`),
  KEY `fk_todo_productionlist_todocode` (`TodoCode`),
  KEY `fk_employees_productionlist_employeeid` (`EmployeeID`),
  CONSTRAINT `fk_employees_productionlist_employeeid` FOREIGN KEY (`EmployeeID`) REFERENCES `employees` (`EmployeeID`),
  CONSTRAINT `fk_plistbymachine_productionlist_machineid_productionid` FOREIGN KEY (`MachineID`, `ProductionID`) REFERENCES `plistbymachine` (`MachineID`, `ProductionID`),
  CONSTRAINT `fk_todo_productionlist_todocode` FOREIGN KEY (`TodoCode`) REFERENCES `todo` (`TodoCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productionlist`
--

LOCK TABLES `productionlist` WRITE;
/*!40000 ALTER TABLE `productionlist` DISABLE KEYS */;
/*!40000 ALTER TABLE `productionlist` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productionplan`
--

DROP TABLE IF EXISTS `productionplan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productionplan` (
  `ProductionPlanCode` int(11) NOT NULL,
  `ProductionID` char(5) NOT NULL,
  `TotalAmount` int(11) NOT NULL,
  PRIMARY KEY (`ProductionPlanCode`),
  KEY `fk_production_productionplan_productionid` (`ProductionID`),
  CONSTRAINT `fk_production_productionplan_productionid` FOREIGN KEY (`ProductionID`) REFERENCES `production` (`ProductionID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productionplan`
--

LOCK TABLES `productionplan` WRITE;
/*!40000 ALTER TABLE `productionplan` DISABLE KEYS */;
/*!40000 ALTER TABLE `productionplan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `todo`
--

DROP TABLE IF EXISTS `todo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `todo` (
  `TodoCode` int(11) NOT NULL,
  `MachineID` char(5) NOT NULL,
  `ProductionID` char(5) NOT NULL,
  `EmployeeID` char(5) NOT NULL,
  `TotalAmount` int(11) NOT NULL,
  `EndExpected` datetime NOT NULL,
  PRIMARY KEY (`TodoCode`),
  KEY `fk_plistbymachine_todo_machineid_productionid` (`MachineID`,`ProductionID`),
  KEY `fk_employees_todo_employeeid` (`EmployeeID`),
  CONSTRAINT `fk_employees_todo_employeeid` FOREIGN KEY (`EmployeeID`) REFERENCES `employees` (`EmployeeID`),
  CONSTRAINT `fk_plistbymachine_todo_machineid_productionid` FOREIGN KEY (`MachineID`, `ProductionID`) REFERENCES `plistbymachine` (`MachineID`, `ProductionID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `todo`
--

LOCK TABLES `todo` WRITE;
/*!40000 ALTER TABLE `todo` DISABLE KEYS */;
/*!40000 ALTER TABLE `todo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-28 16:02:17
