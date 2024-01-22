-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 22, 2024 at 11:24 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_worklog`
--
CREATE DATABASE IF NOT EXISTS `db_worklog` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `db_worklog`;

-- --------------------------------------------------------

--
-- Table structure for table `tb_projects`
--

DROP TABLE IF EXISTS `tb_projects`;
CREATE TABLE IF NOT EXISTS `tb_projects` (
  `projectID` int(11) NOT NULL AUTO_INCREMENT,
  `projectName` varchar(50) NOT NULL,
  PRIMARY KEY (`projectID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tb_users`
--

DROP TABLE IF EXISTS `tb_users`;
CREATE TABLE IF NOT EXISTS `tb_users` (
  `userID` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(15) NOT NULL,
  `fullName` varchar(50) NOT NULL,
  `password` varchar(15) NOT NULL,
  PRIMARY KEY (`userID`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tb_users_projects`
--

DROP TABLE IF EXISTS `tb_users_projects`;
CREATE TABLE IF NOT EXISTS `tb_users_projects` (
  `userID` int(11) NOT NULL,
  `projectID` int(11) NOT NULL,
  KEY `FK_projectID` (`projectID`),
  KEY `FK_userID` (`userID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tb_worklog`
--

DROP TABLE IF EXISTS `tb_worklog`;
CREATE TABLE IF NOT EXISTS `tb_worklog` (
  `logID` int(11) NOT NULL AUTO_INCREMENT,
  `logStart` time NOT NULL,
  `logEnd` time NOT NULL,
  `logDate` date NOT NULL,
  `logDetails` varchar(255) NOT NULL,
  `userID` int(11) NOT NULL,
  `projectID` int(11) NOT NULL,
  PRIMARY KEY (`logID`),
  KEY `FK_log_projectID` (`projectID`),
  KEY `FK_log_userID` (`userID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tb_users_projects`
--
ALTER TABLE `tb_users_projects`
  ADD CONSTRAINT `FK_projectID` FOREIGN KEY (`projectID`) REFERENCES `tb_projects` (`projectID`),
  ADD CONSTRAINT `FK_userID` FOREIGN KEY (`userID`) REFERENCES `tb_users` (`userID`);

--
-- Constraints for table `tb_worklog`
--
ALTER TABLE `tb_worklog`
  ADD CONSTRAINT `FK_log_projectID` FOREIGN KEY (`projectID`) REFERENCES `tb_projects` (`projectID`),
  ADD CONSTRAINT `FK_log_userID` FOREIGN KEY (`userID`) REFERENCES `tb_users` (`userID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
