-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 24, 2024 at 09:57 AM
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

-- --------------------------------------------------------

--
-- Table structure for table `tb_projects`
--

CREATE TABLE `tb_projects` (
  `projectID` int(11) NOT NULL,
  `projectName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tb_projects`
--

INSERT INTO `tb_projects` (`projectID`, `projectName`) VALUES
(1, 'MADAM'),
(2, 'EDP'),
(3, 'ARJUNA'),
(4, 'OKE OCE'),
(5, 'STUNTING'),
(6, 'DP 0%'),
(7, 'BASMAL'),
(8, '1CC'),
(9, 'FORMULA E'),
(10, 'FOOD ESTATE'),
(11, 'HAMBALANG'),
(12, 'MOBAM'),
(13, 'PROJECT D');

-- --------------------------------------------------------

--
-- Table structure for table `tb_users`
--

CREATE TABLE `tb_users` (
  `userID` int(11) NOT NULL,
  `username` varchar(15) NOT NULL,
  `fullName` varchar(50) NOT NULL,
  `password` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tb_users`
--

INSERT INTO `tb_users` (`userID`, `username`, `fullName`, `password`) VALUES
(1, 'martin27', 'Martin Christian', 'martin123'),
(2, 'andhikarky', 'Andhika Rizky Fariz', 'andhika123'),
(3, 'dion69', 'Dionisius ayu widianto', 'diondion2'),
(4, 'vendorAC', 'Dimas Pradip', 'dimasdarah'),
(26, 'ACVendor', 'Dimas Pradip', 'dimasdarah'),
(27, 'PasuluGalak99', 'Dinda Pasulu', 'dindateo28'),
(28, 'devitasedih', 'Devita Helga', 'devitauiux'),
(29, 'pradiptamotogp', 'Pradipta Putera', 'googledrive'),
(30, 'greenflag', 'Darrel Wicaksono', 'ayucyber99'),
(31, 'kurosuke', 'Chris Martin', 'malaysia45'),
(32, 'banivuca77', 'Bani Vuca', 'kucinghitamputi');

-- --------------------------------------------------------

--
-- Table structure for table `tb_users_projects`
--

CREATE TABLE `tb_users_projects` (
  `userID` int(11) NOT NULL,
  `projectID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tb_users_projects`
--

INSERT INTO `tb_users_projects` (`userID`, `projectID`) VALUES
(1, 2),
(1, 1),
(2, 1),
(2, 3),
(26, 5),
(26, 5),
(26, 9),
(26, 6),
(26, 11),
(27, 10),
(27, 13),
(27, 5),
(27, 11),
(27, 12),
(28, 13),
(28, 7),
(28, 10),
(29, 13),
(29, 5),
(29, 3),
(30, 9),
(30, 12),
(31, 1),
(31, 2),
(32, 13),
(32, 12),
(32, 11),
(31, 12),
(32, 4),
(1, 7),
(2, 10),
(3, 13),
(4, 4);

-- --------------------------------------------------------

--
-- Table structure for table `tb_worklog`
--

CREATE TABLE `tb_worklog` (
  `logID` int(11) NOT NULL,
  `logStart` time NOT NULL,
  `logEnd` time NOT NULL,
  `logDate` date NOT NULL,
  `logDetails` varchar(255) NOT NULL,
  `userID` int(11) NOT NULL,
  `projectID` int(11) NOT NULL,
  `logTitle` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tb_worklog`
--

INSERT INTO `tb_worklog` (`logID`, `logStart`, `logEnd`, `logDate`, `logDetails`, `userID`, `projectID`, `logTitle`) VALUES
(18, '13:00:00', '15:00:00', '2024-01-23', 'Fixing Ticket WK-21', 2, 1, 'Fixing Bug'),
(19, '09:00:00', '11:30:00', '2024-01-24', 'Developing new feature for module A', 1, 2, 'Feature Implementation'),
(20, '14:45:00', '17:15:00', '2024-01-24', 'Reviewing code for PR #56', 1, 3, 'Code Review'),
(21, '10:30:00', '12:00:00', '2024-01-25', 'Attending project meeting', 2, 1, 'Project Meeting'),
(22, '16:00:00', '18:30:00', '2024-01-25', 'Researching new API integration methods', 1, 2, 'API Research'),
(23, '14:00:00', '14:45:00', '2024-01-24', 'Resolving bug reported in ticket WK-32', 2, 1, 'Bug Fix'),
(24, '08:45:00', '10:15:00', '2024-01-26', 'Writing unit tests for new code', 1, 3, 'Unit Testing'),
(25, '11:00:00', '12:30:00', '2024-01-26', 'Preparing presentation for client meeting', 1, 2, 'Client Meeting Preparation'),
(26, '15:00:00', '17:00:00', '2024-01-27', 'Deploying new code to staging environment', 2, 2, 'Code Deployment'),
(27, '09:45:00', '11:15:00', '2024-01-27', 'Reviewing user feedback on new feature', 1, 1, 'User Feedback Review'),
(28, '13:30:00', '15:00:00', '2024-01-24', 'Refactoring code for better performance', 1, 3, 'Code Refactoring'),
(29, '10:00:00', '12:00:00', '2024-01-24', 'Developing new feature for module A', 1, 2, 'Feature Implementation'),
(30, '15:30:00', '17:45:00', '2024-01-24', 'Reviewing code for PR #56', 1, 3, 'Code Review'),
(31, '09:45:00', '11:15:00', '2024-01-25', 'Attending project meeting', 1, 1, 'Project Meeting'),
(32, '14:00:00', '16:00:00', '2024-01-25', 'Researching new API integration methods', 2, 1, 'API Research'),
(33, '15:30:00', '16:15:00', '2024-01-24', 'Resolving bug reported in ticket WK-32', 2, 2, 'Bug Fix'),
(34, '08:30:00', '09:45:00', '2024-01-26', 'Writing unit tests for new code', 1, 1, 'Unit Testing'),
(35, '10:45:00', '12:15:00', '2024-01-26', 'Preparing presentation for client meeting', 1, 2, 'Client Meeting Preparation'),
(36, '13:30:00', '15:00:00', '2024-01-27', 'Deploying new code to staging environment', 2, 3, 'Code Deployment'),
(37, '16:45:00', '18:15:00', '2024-01-27', 'Troubleshooting performance issue', 1, 2, 'Performance Troubleshooting'),
(38, '09:15:00', '10:45:00', '2024-01-28', 'Reviewing design mockups for new feature', 2, 3, 'Design Review'),
(39, '16:00:01', '19:00:28', '2024-10-24', 'Meeting dengan vendor galon depok galak', 2, 3, 'Daily Meeting (Vendor Depok)'),
(40, '09:00:00', '12:30:00', '2024-01-25', 'Meeting bareng vendor knalpot di Pondok Indah', 31, 9, 'Meeting Vendor Knalpot');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_projects`
--
ALTER TABLE `tb_projects`
  ADD PRIMARY KEY (`projectID`);

--
-- Indexes for table `tb_users`
--
ALTER TABLE `tb_users`
  ADD PRIMARY KEY (`userID`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Indexes for table `tb_users_projects`
--
ALTER TABLE `tb_users_projects`
  ADD KEY `FK_projectID` (`projectID`),
  ADD KEY `FK_userID` (`userID`);

--
-- Indexes for table `tb_worklog`
--
ALTER TABLE `tb_worklog`
  ADD PRIMARY KEY (`logID`),
  ADD KEY `FK_log_projectID` (`projectID`),
  ADD KEY `FK_log_userID` (`userID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tb_projects`
--
ALTER TABLE `tb_projects`
  MODIFY `projectID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `tb_users`
--
ALTER TABLE `tb_users`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `tb_worklog`
--
ALTER TABLE `tb_worklog`
  MODIFY `logID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

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
