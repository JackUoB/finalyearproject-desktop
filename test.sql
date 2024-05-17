-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: May 17, 2024 at 09:35 AM
-- Server version: 8.3.0
-- PHP Version: 8.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `test`
--

-- --------------------------------------------------------

--
-- Table structure for table `fixtures`
--

DROP TABLE IF EXISTS `fixtures`;
CREATE TABLE IF NOT EXISTS `fixtures` (
  `week` int DEFAULT NULL,
  `date_and_time` datetime DEFAULT NULL,
  `home_team` text,
  `home_score` text,
  `away_score` text,
  `away_team` text,
  `venue` text
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `fixtures`
--

INSERT INTO `fixtures` (`week`, `date_and_time`, `home_team`, `home_score`, `away_score`, `away_team`, `venue`) VALUES
(1, '2024-02-11 10:00:00', 'Tellborough Athletic', '3', '3', 'Spellmouth Thunder', 'Hilltop Park'),
(1, '2024-02-11 10:00:00', 'Kennan Grove Hawks', '2', '1', 'Riverhampton Phoenix', 'Kennan Grove Place'),
(1, '2024-02-11 10:00:00', 'Barnshaw Bulls', '0', '5', 'Bridgely Wood Wanderers', 'Barnshaw Palace Park'),
(1, '2024-02-11 10:00:00', 'River Park Rovers', '3', '3', 'Hankridge Town', 'Birchwood Park'),
(1, '2024-02-11 10:00:00', 'SE Tigers', '4', '2', 'Siddean United', 'Briggs Park'),
(2, '2024-02-18 10:00:00', 'Riverhampton Phoenix', '2', '0', 'Tellborough Athletic', 'Wren Park'),
(2, '2024-02-18 10:00:00', 'Bridgely Wood Wanderers', '4', '0', 'Spellmouth Thunder', 'Bridgely Wood Common'),
(2, '2024-02-18 10:00:00', 'Hankridge Town', '1', '1', 'Kennan Grove Hawks', 'West Hankridge Playing Fields'),
(2, '2024-02-18 10:00:00', 'Siddean United', '1', '1', 'Barnshaw Bulls', 'Benfield Place'),
(2, '2024-02-18 10:00:00', 'SE Tigers', '1', '2', 'River Park Rovers', 'Briggs Park'),
(3, '2024-02-25 10:00:00', 'Tellborough Athletic', '6', '3', 'Bridgely Wood Wanderers', 'Hilltop Park'),
(3, '2024-02-25 10:00:00', 'Riverhampton Phoenix', '4', '1', 'Hankridge Town', 'Wren Park'),
(3, '2024-02-25 10:00:00', 'Spellmouth Thunder', '4', '0', 'Siddean United', 'Elizabeth Tower Park'),
(3, '2024-02-25 10:00:00', 'Kennan Grove Hawks', '2', '2', 'SE Tigers', 'Kennan Grove Place'),
(3, '2024-02-25 10:00:00', 'Barnshaw Bulls', '5', '1', 'River Park Rovers', 'Barnshaw Palace Park'),
(4, '2024-03-03 10:00:00', 'Hankridge Town', '1', '0', 'Tellborough Athletic', 'West Hankridge Playing Fields'),
(4, '2024-03-03 10:00:00', 'Siddean United', '2', '3', 'Bridgely Wood Wanderers', 'Benfield Place'),
(4, '2024-03-03 10:00:00', 'SE Tigers', '4', '2', 'Riverhampton Phoenix', 'Briggs Park'),
(4, '2024-03-03 10:00:00', 'River Park Rovers', '2', '7', 'Spellmouth Thunder', 'Birchwood Park'),
(4, '2024-03-03 10:00:00', 'Barnshaw Bulls', '3', '3', 'Kennan Grove Hawks', 'Barnshaw Palace Park'),
(5, '2024-03-10 10:00:00', 'Tellborough Athletic', '2', '1', 'Siddean United', 'Hilltop Park'),
(5, '2024-03-10 10:00:00', 'Hankridge Town', '2', '1', 'SE Tigers', 'West Hankridge Playing Fields'),
(5, '2024-03-10 10:00:00', 'Bridgely Wood Wanderers', '0', '4', 'River Park Rovers', 'Bridgely Wood Common'),
(5, '2024-03-10 10:00:00', 'Riverhampton Phoenix', '2', '3', 'Barnshaw Bulls', 'Wren Park'),
(5, '2024-03-10 10:00:00', 'Spellmouth Thunder', '2', '2', 'Kennan Grove Hawks', 'Elizabeth Tower Park'),
(6, '2024-03-17 10:00:00', 'SE Tigers', '4', '4', 'Tellborough Athletic', 'Briggs Park'),
(6, '2024-03-17 10:00:00', 'River Park Rovers', '2', '2', 'Siddean United', 'Birchwood Park'),
(6, '2024-03-17 10:00:00', 'Barnshaw Bulls', '1', '1', 'Hankridge Town', 'Barnshaw Palace Park'),
(6, '2024-03-17 10:00:00', 'Kennan Grove Hawks', '2', '0', 'Bridgely Wood Wanderers', 'Kennan Grove Place'),
(6, '2024-03-17 10:00:00', 'Spellmouth Thunder', '2', '0', 'Riverhampton Phoenix', 'Elizabeth Tower Park'),
(7, '2024-03-24 10:00:00', 'Tellborough Athletic', '1', '0', 'River Park Rovers', 'Hilltop Park'),
(7, '2024-03-24 10:00:00', 'SE Tigers', '3', '0', 'Barnshaw Bulls', 'Briggs Park'),
(7, '2024-03-24 10:00:00', 'Siddean United', '1', '2', 'Kennan Grove Hawks', 'Benfield Place'),
(7, '2024-03-24 10:00:00', 'Hankridge Town', '0', '2', 'Spellmouth Thunder', 'West Hankridge Playing Fields'),
(7, '2024-03-24 10:00:00', 'Bridgely Wood Wanderers', '4', '3', 'Riverhampton Phoenix', 'Bridgely Wood Common'),
(8, '2024-04-07 10:00:00', 'Barnshaw Bulls', '0', '5', 'Tellborough Athletic', 'Barnshaw Palace Park'),
(8, '2024-04-07 10:00:00', 'Kennan Grove Hawks', '0', '2', 'River Park Rovers', 'Kennan Grove Place'),
(8, '2024-04-07 10:00:00', 'Spellmouth Thunder', '3', '4', 'SE Tigers', 'Elizabeth Tower Park'),
(8, '2024-04-07 10:00:00', 'Riverhampton Phoenix', '5', '3', 'Siddean United', 'Wren Park'),
(8, '2024-04-07 10:00:00', 'Bridgely Wood Wanderers', '2', '1', 'Hankridge Town', 'Bridgely Wood Common'),
(9, '2024-04-14 10:00:00', 'Tellborough Athletic', '2', '1', 'Kennan Grove Hawks', 'Hilltop Park'),
(9, '2024-04-14 10:00:00', 'Barnshaw Bulls', '3', '3', 'Spellmouth Thunder', 'Barnshaw Palace Park'),
(9, '2024-04-14 10:00:00', 'River Park Rovers', '4', '1', 'Riverhampton Phoenix', 'Birchwood Park'),
(9, '2024-04-14 10:00:00', 'SE Tigers', '7', '2', 'Bridgely Wood Wanderers', 'Briggs Park'),
(9, '2024-04-14 10:00:00', 'Siddean United', '1', '4', 'Hankridge Town', 'Benfield Place'),
(10, '2024-04-21 10:00:00', 'Spellmouth Thunder', '0', '6', 'Tellborough Athletic', 'Elizabeth Tower Park'),
(10, '2024-04-21 10:00:00', 'Riverhampton Phoenix', '3', '2', 'Kennan Grove Hawks', 'Wren Park'),
(10, '2024-04-21 10:00:00', 'Bridgely Wood Wanderers', '3', '2', 'Barnshaw Bulls', 'Bridgely Wood Common'),
(10, '2024-04-21 10:00:00', 'Hankridge Town', '0', '2', 'River Park Rovers', 'West Hankridge Playing Fields'),
(10, '2024-04-21 10:00:00', 'Siddean United', '8', '4', 'SE Tigers', 'Benfield Place'),
(11, '2024-04-28 10:00:00', 'Tellborough Athletic', '3', '1', 'Riverhampton Phoenix', 'Hilltop Park'),
(11, '2024-04-28 10:00:00', 'Spellmouth Thunder', '2', '1', 'Bridgely Wood Wanderers', 'Elizabeth Tower Park'),
(11, '2024-04-28 10:00:00', 'Kennan Grove Hawks', '1', '3', 'Hankridge Town', 'Kennan Grove Place'),
(11, '2024-04-28 10:00:00', 'Barnshaw Bulls', '4', '5', 'Siddean United', 'Barnshaw Palace Park'),
(11, '2024-04-28 10:00:00', 'River Park Rovers', '0', '0', 'SE Tigers', 'Birchwood Park'),
(12, '2024-05-05 10:00:00', 'Bridgely Wood Wanderers', '2', '2', 'Tellborough Athletic', 'Bridgely Wood Common'),
(12, '2024-05-05 10:00:00', 'Hankridge Town', '4', '3', 'Riverhampton Phoenix', 'West Hankridge Playing Fields'),
(12, '2024-05-05 10:00:00', 'Siddean United', '2', '5', 'Spellmouth Thunder', 'Benfield Place'),
(12, '2024-05-05 10:00:00', 'SE Tigers', '3', '0', 'Kennan Grove Hawks', 'Briggs Park'),
(12, '2024-05-05 10:00:00', 'River Park Rovers', '0', '1', 'Barnshaw Bulls', 'Birchwood Park'),
(13, '2024-05-12 10:00:00', 'Tellborough Athletic', '0', '2', 'Hankridge Town', 'Hilltop Park'),
(13, '2024-05-12 10:00:00', 'Bridgely Wood Wanderers', '3', '2', 'Siddean United', 'Bridgely Wood Common'),
(13, '2024-05-12 10:00:00', 'Riverhampton Phoenix', '1', '2', 'SE Tigers', 'Wren Park'),
(13, '2024-05-12 10:00:00', 'Spellmouth Thunder', '5', '1', 'River Park Rovers', 'Elizabeth Tower Park'),
(13, '2024-05-12 10:00:00', 'Kennan Grove Hawks', '1', '1', 'Barnshaw Bulls', 'Kennan Grove Place'),
(14, '2024-05-19 10:00:00', 'Siddean United', '', '', 'Tellborough Athletic', 'Benfield Place'),
(14, '2024-05-19 10:00:00', 'SE Tigers', '', '', 'Hankridge Town', 'Briggs Park'),
(14, '2024-05-19 10:00:00', 'River Park Rovers', '', '', 'Bridgely Wood Wanderers', 'Birchwood Park'),
(14, '2024-05-19 10:00:00', 'Barnshaw Bulls', '', '', 'Riverhampton Phoenix', 'Barnshaw Palace Park'),
(14, '2024-05-19 10:00:00', 'Kennan Grove Hawks', '', '', 'Spellmouth Thunder', 'Kennan Grove Place'),
(15, '2024-05-26 10:00:00', 'Tellborough Athletic', '', '', 'SE Tigers', 'Hilltop Park'),
(15, '2024-05-26 10:00:00', 'Siddean United', '', '', 'River Park Rovers', 'Benfield Place'),
(15, '2024-05-26 10:00:00', 'Hankridge Town', '', '', 'Barnshaw Bulls', 'West Hankridge Playing Fields'),
(15, '2024-05-26 10:00:00', 'Bridgely Wood Wanderers', '', '', 'Kennan Grove Hawks', 'Bridgely Wood Common'),
(15, '2024-05-26 10:00:00', 'Riverhampton Phoenix', '', '', 'Spellmouth Thunder', 'Wren Park'),
(16, '2024-06-02 10:00:00', 'River Park Rovers', '', '', 'Tellborough Athletic', 'Birchwood Park'),
(16, '2024-06-02 10:00:00', 'Barnshaw Bulls', '', '', 'SE Tigers', 'Barnshaw Palace Park'),
(16, '2024-06-02 10:00:00', 'Kennan Grove Hawks', '', '', 'Siddean United', 'Kennan Grove Place'),
(16, '2024-06-02 10:00:00', 'Spellmouth Thunder', '', '', 'Hankridge Town', 'Elizabeth Tower Park'),
(16, '2024-06-02 10:00:00', 'Riverhampton Phoenix', '', '', 'Bridgely Wood Wanderers', 'Wren Park'),
(17, '2024-06-09 10:00:00', 'Tellborough Athletic', '', '', 'Barnshaw Bulls', 'Hilltop Park'),
(17, '2024-06-09 10:00:00', 'River Park Rovers', '', '', 'Kennan Grove Hawks', 'Birchwood Park'),
(17, '2024-06-09 10:00:00', 'SE Tigers', '', '', 'Spellmouth Thunder', 'Briggs Park'),
(17, '2024-06-09 10:00:00', 'Siddean United', '', '', 'Riverhampton Phoenix', 'Benfield Place'),
(17, '2024-06-09 10:00:00', 'Hankridge Town', '', '', 'Bridgely Wood Wanderers', 'West Hankridge Playing Fields'),
(18, '2024-06-16 10:00:00', 'Kennan Grove Hawks', '', '', 'Tellborough Athletic', 'Kennan Grove Place'),
(18, '2024-06-16 10:00:00', 'Spellmouth Thunder', '', '', 'Barnshaw Bulls', 'Elizabeth Tower Park'),
(18, '2024-06-16 10:00:00', 'Riverhampton Phoenix', '', '', 'River Park Rovers', 'Wren Park'),
(18, '2024-06-16 10:00:00', 'Bridgely Wood Wanderers', '', '', 'SE Tigers', 'Bridgely Wood Common'),
(18, '2024-06-16 10:00:00', 'Hankridge Town', '', '', 'Siddean United', 'West Hankridge Playing Fields');

-- --------------------------------------------------------

--
-- Table structure for table `league_table`
--

DROP TABLE IF EXISTS `league_table`;
CREATE TABLE IF NOT EXISTS `league_table` (
  `name` text,
  `played` int DEFAULT NULL,
  `wins` int DEFAULT NULL,
  `draws` int DEFAULT NULL,
  `losses` int DEFAULT NULL,
  `goals_for` int DEFAULT NULL,
  `goals_against` int DEFAULT NULL,
  `goal_difference` int DEFAULT NULL,
  `points` int DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `league_table`
--

INSERT INTO `league_table` (`name`, `played`, `wins`, `draws`, `losses`, `goals_for`, `goals_against`, `goal_difference`, `points`) VALUES
('Tellborough Athletic', 13, 7, 3, 3, 34, 20, 14, 24),
('Spellmouth Thunder', 13, 7, 3, 3, 38, 28, 10, 24),
('Kennan Grove Hawks', 13, 3, 5, 5, 19, 24, -5, 14),
('Riverhampton Phoenix', 13, 4, 0, 9, 28, 34, -6, 12),
('Barnshaw Bulls', 13, 3, 5, 5, 24, 33, -9, 14),
('Bridgely Wood Wanderers', 13, 7, 1, 5, 32, 33, -1, 22),
('River Park Rovers', 13, 5, 3, 5, 23, 26, -3, 18),
('Hankridge Town', 13, 6, 3, 4, 23, 21, 2, 21),
('SE Tigers', 13, 7, 3, 3, 39, 28, 11, 24),
('Siddean United', 13, 2, 2, 9, 30, 43, -13, 8);

-- --------------------------------------------------------

--
-- Table structure for table `squad`
--

DROP TABLE IF EXISTS `squad`;
CREATE TABLE IF NOT EXISTS `squad` (
  `squad_number` int DEFAULT NULL,
  `first_name` text,
  `last_name` text,
  `position` text,
  `username` text,
  `password` text
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `squad`
--

INSERT INTO `squad` (`squad_number`, `first_name`, `last_name`, `position`, `username`, `password`) VALUES
(1, 'Craig', 'Thompson', 'Goalkeeper', 'cthompson', '123'),
(2, 'Nick', 'Case', 'Defender', 'ncase', '123'),
(3, 'Jamal', 'Azim', 'Defender', 'jazim', '123'),
(5, 'Jed', 'Defty', 'Defender', 'jdefty', '123'),
(7, 'Declan', 'Healy', 'Midfielder', 'dhealy', '123'),
(8, 'Dennis', 'Hemple', 'Midfielder', 'dhemple', '123'),
(9, 'Luka', 'Karna', 'Forward', 'lkarna', '123'),
(10, 'Abu', 'Obi', 'Forward', 'aobi', '123'),
(11, 'Lawrence', 'Kerr', 'Forward', 'lkerr', '123'),
(13, 'Matthew', 'Ketchell', 'Goalkeeper', 'mketchell', '123'),
(15, 'Kevin', 'Goddard', 'Midfielder', 'kgoddard', '123'),
(17, 'Jack', 'Mahon', 'Midfielder', 'jmahon', '123'),
(21, 'David', 'Helme', 'Defender', 'dhelme', '123'),
(28, 'Dave', 'Gallagher', 'Defender', 'dgallagher', '123'),
(31, 'Ismail', 'Cetin', 'Midfielder', 'icetin', '123'),
(4, 'Jack', 'O\'Neill', 'Midfielder', 'joneill', '123');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
