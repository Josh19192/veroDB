-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 05, 2023 at 12:10 AM
-- Server version: 10.1.19-MariaDB
-- PHP Version: 5.6.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hotelreservationsystem`
--

-- --------------------------------------------------------

--
-- Table structure for table `guest`
--

CREATE TABLE `guest` (
  `guest_id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `ContactNo.` varchar(50) NOT NULL,
  `room_id` int(11) NOT NULL,
  `no._of_occupants` int(30) NOT NULL,
  `Overall_payment` double(10,2) NOT NULL,
  `date_registered` date NOT NULL,
  `status` varchar(100) NOT NULL DEFAULT 'Pre-Registered',
  `Payment_Status` varchar(100) NOT NULL DEFAULT 'Pending'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `guest`
--

INSERT INTO `guest` (`guest_id`, `Name`, `ContactNo.`, `room_id`, `no._of_occupants`, `Overall_payment`, `date_registered`, `status`, `Payment_Status`) VALUES
(3, 'Cj Acayen', '09647846563', 2, 7, 1190.00, '2023-08-02', 'Checked-out', 'Paid'),
(4, 'Johannes', '09786536622', 1, 6, 1250.00, '2023-08-02', 'Checked-out', 'Paid'),
(5, 'Jeffrey Emetrio', '09768576835', 2, 5, 2600.00, '2023-08-02', 'Checked-out', 'Paid'),
(6, 'Marimar Santiago', '09874343533', 3, 4, 1450.00, '2023-08-02', 'Checked-out', 'Paid'),
(7, 'Corazon A. Wang', '097564746355', 1, 4, 1230.00, '2023-08-02', 'Checked-out', 'Paid'),
(8, 'Cardio Dalisay', '0978657544', 2, 4, 1190.00, '2023-08-02', 'Checked-out', 'Paid'),
(9, 'Don Santiago', '097653435363', 2, 4, 1010.00, '2023-08-02', 'Checked-out', 'Paid'),
(10, 'Surandoy Quezon', '09853443666', 4, 3, 560.00, '2023-08-02', 'Cancelled Registration', 'Unregistered'),
(11, 'Jaworsky', '0987654333', 5, 2, 1040.00, '2023-07-03', 'Checked-out', 'Paid'),
(12, 'Jena Cena', '09768664545', 4, 3, 560.00, '2023-07-28', 'Checked-out', 'Paid'),
(13, 'Mark Pingris', '09675745544', 4, 4, 630.00, '2023-06-14', 'Cancelled Registration', 'Unregistered'),
(14, 'Michael Dajong', '09785565443', 2, 2, 990.00, '2023-08-02', 'Checked-in', 'Paid'),
(15, 'jared', '098888', 4, 4, 2000.00, '2023-12-04', 'Cancelled Registration', 'Unregistered'),
(16, 'brian', '097765', 5, 3, 3000.00, '2023-12-04', 'Checked-in', 'Paid'),
(17, 'james', '093743', 1, 3, 1500.00, '2023-12-05', 'Checked-in', 'Paid');

-- --------------------------------------------------------

--
-- Table structure for table `payment_transaction`
--

CREATE TABLE `payment_transaction` (
  `transaction_id` int(11) NOT NULL,
  `guest_id` int(11) NOT NULL,
  `total_payment` double(10,2) NOT NULL,
  `Cash` double(10,2) NOT NULL,
  `Change` double(10,2) NOT NULL,
  `transaction_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `payment_transaction`
--

INSERT INTO `payment_transaction` (`transaction_id`, `guest_id`, `total_payment`, `Cash`, `Change`, `transaction_date`) VALUES
(1, 2, 690.00, 700.00, 10.00, '2023-08-02'),
(2, 3, 1190.00, 2000.00, 810.00, '2023-08-02'),
(3, 4, 1250.00, 1500.00, 250.00, '2023-08-02'),
(4, 5, 2600.00, 3000.00, 400.00, '2023-08-02'),
(5, 6, 1450.00, 2000.00, 550.00, '2023-08-02'),
(6, 7, 1230.00, 2000.00, 770.00, '2023-08-02'),
(7, 8, 1190.00, 1500.00, 310.00, '2023-08-02'),
(8, 9, 1010.00, 1500.00, 490.00, '2023-08-02'),
(9, 11, 1040.00, 1500.00, 460.00, '2023-08-02'),
(10, 12, 560.00, 700.00, 140.00, '2023-08-02'),
(11, 14, 990.00, 20.00, 970.00, '2023-12-04'),
(12, 16, 3000.00, 4000.00, 1000.00, '2023-12-04'),
(13, 17, 1500.00, 2000.00, 500.00, '2023-12-05');

-- --------------------------------------------------------

--
-- Table structure for table `room`
--

CREATE TABLE `room` (
  `room_id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Capacity` int(20) NOT NULL,
  `Availability` varchar(50) NOT NULL DEFAULT 'Available',
  `price` double(10,2) NOT NULL,
  `date_created` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `room`
--

INSERT INTO `room` (`room_id`, `Name`, `Capacity`, `Availability`, `price`, `date_created`) VALUES
(1, 'room1', 3, 'Unavailable', 500.00, '2023-07-24'),
(2, 'room3', 15, 'Available', 900.00, '2023-07-24'),
(3, 'room 2', 3, 'Unavailable', 200.00, '2023-07-24'),
(4, 'room 4', 12, 'Unavailable', 500.00, '2023-07-24'),
(5, 'room 5', 25, 'Unavailable', 1000.00, '2023-08-02'),
(6, 'room6', 7, 'Available', 700.00, '2023-12-05');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `user_id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `address` varchar(100) NOT NULL,
  `Username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`user_id`, `Name`, `Email`, `address`, `Username`, `password`) VALUES
(1, 'qwer', 'qwer', 'ewqefwsdgsd', 'qwe', 'qwe'),
(2, 'Jetrdytfuyg', 'efsef', 'ewfewf', 'ewfewf', 'qwe1'),
(3, 'james', 'jameskharl.vero@gmail.com', 'minoyho', 'kharl', 'haha');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `guest`
--
ALTER TABLE `guest`
  ADD PRIMARY KEY (`guest_id`);

--
-- Indexes for table `payment_transaction`
--
ALTER TABLE `payment_transaction`
  ADD PRIMARY KEY (`transaction_id`);

--
-- Indexes for table `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`room_id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `guest`
--
ALTER TABLE `guest`
  MODIFY `guest_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
--
-- AUTO_INCREMENT for table `payment_transaction`
--
ALTER TABLE `payment_transaction`
  MODIFY `transaction_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
--
-- AUTO_INCREMENT for table `room`
--
ALTER TABLE `room`
  MODIFY `room_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
