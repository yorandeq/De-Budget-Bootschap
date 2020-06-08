-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 08, 2020 at 02:07 PM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `boodschapwijzer`
--

-- --------------------------------------------------------

--
-- Table structure for table `discount_offers`
--

CREATE TABLE `discount_offers` (
  `offer_id` int(11) NOT NULL,
  `supermarket` int(11) NOT NULL,
  `brand` varchar(255) NOT NULL,
  `category` varchar(225) NOT NULL,
  `icon` longblob,
  `expiration_date` date NOT NULL,
  `min_amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `discount_products`
--

CREATE TABLE `discount_products` (
  `product_id` int(11) NOT NULL,
  `discount_offer` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `icon` longblob,
  `state` int(1) NOT NULL,
  `bought_by` int(11) DEFAULT NULL,
  `total_price` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `notifications`
--

CREATE TABLE `notifications` (
  `notification_id` int(11) NOT NULL,
  `user` int(11) NOT NULL,
  `message` varchar(255) NOT NULL,
  `state` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `notifications`
--

INSERT INTO `notifications` (`notification_id`, `user`, `message`, `state`) VALUES
(1, 1, 'test notificatie 1', 1),
(2, 1, 'test notificatie 2', 1);

-- --------------------------------------------------------

--
-- Table structure for table `registration`
--

CREATE TABLE `registration` (
  `registration_id` int(11) NOT NULL,
  `user` int(11) NOT NULL,
  `product` int(11) NOT NULL,
  `product_amount` int(255) NOT NULL,
  `paid` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `supermarkets`
--

CREATE TABLE `supermarkets` (
  `supermarket_id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `icon` longblob,
  `description` text,
  `link` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` text NOT NULL,
  `password_salt` text NOT NULL,
  `admin` int(1) NOT NULL,
  `admin_supermarket` int(11) DEFAULT NULL,
  `amount_shopped` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `username`, `password`, `password_salt`, `admin`, `admin_supermarket`, `amount_shopped`) VALUES
(1, 'user1', 'tcITXx4BpfwzK8ndFVPPAHWCgco3YHZCJJUau6V2pAw=', 'a/U5GbHautUG9OH2k1nDLcYUbEEJifrYTnt2QdATRac=', 0, NULL, 0),
(2, 'user2', 'Ks4az6unlQJAoxXvGvfANK8gpoxyTDQ15F8SSP44b38=', 'GBxFOIYj12q++W7e/jZL5PummvYUtuy0KIjk3bleBRY=', 0, NULL, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `discount_offers`
--
ALTER TABLE `discount_offers`
  ADD PRIMARY KEY (`offer_id`),
  ADD KEY `supermarket` (`supermarket`);

--
-- Indexes for table `discount_products`
--
ALTER TABLE `discount_products`
  ADD PRIMARY KEY (`product_id`),
  ADD KEY `discount_offer` (`discount_offer`,`bought_by`),
  ADD KEY `bought_by` (`bought_by`);

--
-- Indexes for table `notifications`
--
ALTER TABLE `notifications`
  ADD PRIMARY KEY (`notification_id`),
  ADD KEY `user` (`user`);

--
-- Indexes for table `registration`
--
ALTER TABLE `registration`
  ADD PRIMARY KEY (`registration_id`),
  ADD KEY `user` (`user`),
  ADD KEY `product` (`product`);

--
-- Indexes for table `supermarkets`
--
ALTER TABLE `supermarkets`
  ADD PRIMARY KEY (`supermarket_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD KEY `admin_supermarket` (`admin_supermarket`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `discount_offers`
--
ALTER TABLE `discount_offers`
  MODIFY `offer_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `discount_products`
--
ALTER TABLE `discount_products`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `notifications`
--
ALTER TABLE `notifications`
  MODIFY `notification_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `registration`
--
ALTER TABLE `registration`
  MODIFY `registration_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supermarkets`
--
ALTER TABLE `supermarkets`
  MODIFY `supermarket_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `discount_offers`
--
ALTER TABLE `discount_offers`
  ADD CONSTRAINT `discount_offers_ibfk_1` FOREIGN KEY (`supermarket`) REFERENCES `supermarkets` (`supermarket_id`);

--
-- Constraints for table `discount_products`
--
ALTER TABLE `discount_products`
  ADD CONSTRAINT `discount_products_ibfk_1` FOREIGN KEY (`discount_offer`) REFERENCES `discount_offers` (`offer_id`),
  ADD CONSTRAINT `discount_products_ibfk_2` FOREIGN KEY (`bought_by`) REFERENCES `users` (`user_id`);

--
-- Constraints for table `notifications`
--
ALTER TABLE `notifications`
  ADD CONSTRAINT `notifications_ibfk_1` FOREIGN KEY (`user`) REFERENCES `users` (`user_id`);

--
-- Constraints for table `registration`
--
ALTER TABLE `registration`
  ADD CONSTRAINT `registration_ibfk_1` FOREIGN KEY (`user`) REFERENCES `users` (`user_id`),
  ADD CONSTRAINT `registration_ibfk_2` FOREIGN KEY (`product`) REFERENCES `discount_products` (`product_id`);

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`admin_supermarket`) REFERENCES `supermarkets` (`supermarket_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
