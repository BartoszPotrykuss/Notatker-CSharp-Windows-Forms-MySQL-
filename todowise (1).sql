-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 07 Paź 2023, 14:53
-- Wersja serwera: 10.4.25-MariaDB
-- Wersja PHP: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `todowise`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `note`
--

CREATE TABLE `note` (
  `Id` int(11) NOT NULL,
  `Subject` varchar(50) CHARACTER SET utf16 COLLATE utf16_polish_ci NOT NULL,
  `Content` text CHARACTER SET utf16 COLLATE utf16_polish_ci NOT NULL,
  `CreationDate` date NOT NULL,
  `ExpiryDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `note`
--

INSERT INTO `note` (`Id`, `Subject`, `Content`, `CreationDate`, `ExpiryDate`) VALUES
(3, 'Subject', 'Content', '2023-10-27', '2023-10-27');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `todo`
--

CREATE TABLE `todo` (
  `Id` int(11) NOT NULL,
  `Subject` int(11) NOT NULL,
  `Content` int(11) NOT NULL,
  `DueDate` int(11) NOT NULL,
  `Status` int(11) NOT NULL,
  `Priority` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `tolearn`
--

CREATE TABLE `tolearn` (
  `Id` int(11) NOT NULL,
  `Subject` varchar(50) NOT NULL,
  `Content` text NOT NULL,
  `DueDate` date NOT NULL,
  `PercentageOfMaterialLearned` int(11) NOT NULL,
  `Priority` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
