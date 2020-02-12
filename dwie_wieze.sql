-- phpMyAdmin SQL Dump
-- version 3.5.5
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Czas wygenerowania: 12 Lut 2020, 16:35
-- Wersja serwera: 5.5.21-log
-- Wersja PHP: 5.3.20

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Baza danych: `dwie_wieze`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `miejsca_parkingowe`
--

CREATE TABLE IF NOT EXISTS `miejsca_parkingowe` (
  `ID_miejsca` int(11) NOT NULL AUTO_INCREMENT,
  `Właściciel` text COLLATE utf8_polish_ci NOT NULL,
  PRIMARY KEY (`ID_miejsca`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci AUTO_INCREMENT=7 ;

--
-- Zrzut danych tabeli `miejsca_parkingowe`
--

INSERT INTO `miejsca_parkingowe` (`ID_miejsca`, `Właściciel`) VALUES
(1, 'W-123'),
(2, 'W-456'),
(3, 'at'),
(4, 'br'),
(5, 'ff'),
(6, 'tt');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `mieszkancy`
--

CREATE TABLE IF NOT EXISTS `mieszkancy` (
  `ID_mieszkanca` int(11) NOT NULL AUTO_INCREMENT,
  `Imie` text COLLATE utf8_polish_ci NOT NULL,
  `Nazwisko` text COLLATE utf8_polish_ci NOT NULL,
  `Informacje` text COLLATE utf8_polish_ci NOT NULL,
  `Sciezka` text COLLATE utf8_polish_ci NOT NULL,
  PRIMARY KEY (`ID_mieszkanca`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci ROW_FORMAT=COMPACT AUTO_INCREMENT=5 ;

--
-- Zrzut danych tabeli `mieszkancy`
--

INSERT INTO `mieszkancy` (`ID_mieszkanca`, `Imie`, `Nazwisko`, `Informacje`, `Sciezka`) VALUES
(1, 'Jakub', 'Koltunowicz', 'Wiek: 22\r\nZawód: bezrobotny student \r\nPesel: 123456789 \r\nLubi placki z truskawkami.', '1.png'),
(2, 'Piotr', 'Bledowski', 'Wiek: 22\r\nZawód: Pro-gamer\r\nPesel: 987654321\r\nLubi grać w gry.', '2.png'),
(3, 'Kuba', 'Tymoszuk', 'Wiek: 22\r\nZawód: inż. Robotyk\r\nPesel:135798642\r\nLubi budować roboty.', '3.png'),
(4, 'Wladyslaw', 'Jagielonczyk', 'Wiek: 650\r\nZawód: Król Polski\r\nPesel: 00000000001\r\nNie lubi zakonu krzyżackiego.', '');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `rezerwacje`
--

CREATE TABLE IF NOT EXISTS `rezerwacje` (
  `ID_rezerwacji` int(11) NOT NULL AUTO_INCREMENT,
  `ID_miejsca` int(11) NOT NULL,
  `Poczatek` date NOT NULL,
  `Koniec` date NOT NULL,
  `Rezerwujacy` text COLLATE utf8_polish_ci NOT NULL,
  UNIQUE KEY `ID_rezerwacji` (`ID_rezerwacji`),
  KEY `ID_rezerwacji_2` (`ID_rezerwacji`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci AUTO_INCREMENT=5 ;

--
-- Zrzut danych tabeli `rezerwacje`
--

INSERT INTO `rezerwacje` (`ID_rezerwacji`, `ID_miejsca`, `Poczatek`, `Koniec`, `Rezerwujacy`) VALUES
(1, 1, '2020-02-01', '2020-02-08', 'W12'),
(2, 2, '2020-02-17', '2020-02-21', 'ttt'),
(3, 3, '2020-02-06', '2020-02-21', 'gf'),
(4, 4, '2020-02-15', '2020-02-16', 'mn');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
