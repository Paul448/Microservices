-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Erstellungszeit: 18. Mrz 2021 um 12:05
-- Server-Version: 10.1.37-MariaDB
-- PHP-Version: 7.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `microservicespro`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `mannschaft`
--

CREATE TABLE `mannschaft` (
  `MID` int(11) NOT NULL,
  `NAME` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `mannschaft`
--

INSERT INTO `mannschaft` (`MID`, `NAME`) VALUES
(2, 'FC Bonn'),
(6, '44'),
(7, 'FC TESTENDINGS'),
(8, 'FC TESTENDINGS'),
(9, 'FC TESTENDINGS'),
(10, 'Test');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `person`
--

CREATE TABLE `person` (
  `PID` int(11) NOT NULL,
  `Name` varchar(30) NOT NULL,
  `Typ` varchar(30) NOT NULL,
  `Siege` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `person`
--

INSERT INTO `person` (`PID`, `Name`, `Typ`, `Siege`) VALUES
(1, 'Peter', 'Fussballspieler', NULL),
(2, 'Jürgem', 'Fussballspieler', NULL),
(3, 'Neuer', 'Trainer', NULL),
(4, 'Lesch', 'Trainer', NULL),
(5, 'Moritz', 'Fusballspieler', NULL);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `ps_ms`
--

CREATE TABLE `ps_ms` (
  `PSMS_ID` int(11) NOT NULL,
  `MID` int(11) DEFAULT NULL,
  `PID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `ps_ms`
--

INSERT INTO `ps_ms` (`PSMS_ID`, `MID`, `PID`) VALUES
(1, 2, 1),
(2, 2, 3),
(8, 2, 3);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `spiele`
--

CREATE TABLE `spiele` (
  `SPID` int(11) NOT NULL,
  `TID` int(11) DEFAULT NULL,
  `MS1ID` int(11) DEFAULT NULL,
  `MS2ID` int(11) DEFAULT NULL,
  `Ergebnis1` int(11) DEFAULT NULL,
  `Ergebnis2` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `spiele`
--

INSERT INTO `spiele` (`SPID`, `TID`, `MS1ID`, `MS2ID`, `Ergebnis1`, `Ergebnis2`) VALUES
(1, 1, 2, 7, 3, 9);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `tms`
--

CREATE TABLE `tms` (
  `TMS` int(11) NOT NULL,
  `TID` int(11) DEFAULT NULL,
  `MID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `tms`
--

INSERT INTO `tms` (`TMS`, `TID`, `MID`) VALUES
(1, 1, 2),
(2, 1, 7);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `turnier`
--

CREATE TABLE `turnier` (
  `TID` int(11) NOT NULL,
  `Datum` date DEFAULT NULL,
  `name` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `turnier`
--

INSERT INTO `turnier` (`TID`, `Datum`, `name`) VALUES
(1, '2021-03-18', 'Erstes Testturnier'),
(2, '2021-03-18', 'Zweites Testturnier');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `users`
--

CREATE TABLE `users` (
  `UID` int(11) NOT NULL,
  `Pass` varchar(40) NOT NULL,
  `Status` varchar(5) NOT NULL,
  `Info` varchar(80) DEFAULT NULL,
  `Name` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `users`
--

INSERT INTO `users` (`UID`, `Pass`, `Status`, `Info`, `Name`) VALUES
(1, '202cb962ac59075b964b07152d234b70', 'User', 'TEST USER', '123'),
(2, '202cb962ac59075b964b07152d234b70', 'Admin', 'TEST Admin', 'Paul'),
(3, '530ea1472e71035353d32d341ecf6343', 'User', 'TEST USER', 'Peter');

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `mannschaft`
--
ALTER TABLE `mannschaft`
  ADD PRIMARY KEY (`MID`);

--
-- Indizes für die Tabelle `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`PID`);

--
-- Indizes für die Tabelle `ps_ms`
--
ALTER TABLE `ps_ms`
  ADD PRIMARY KEY (`PSMS_ID`),
  ADD KEY `FKMID` (`MID`),
  ADD KEY `FKPID` (`PID`);

--
-- Indizes für die Tabelle `spiele`
--
ALTER TABLE `spiele`
  ADD PRIMARY KEY (`SPID`),
  ADD KEY `FK_TIDSPIELE` (`TID`),
  ADD KEY `FK_MS1` (`MS1ID`),
  ADD KEY `FK_MS2` (`MS2ID`);

--
-- Indizes für die Tabelle `tms`
--
ALTER TABLE `tms`
  ADD PRIMARY KEY (`TMS`),
  ADD KEY `FK_TID` (`TID`),
  ADD KEY `FK_MID` (`MID`);

--
-- Indizes für die Tabelle `turnier`
--
ALTER TABLE `turnier`
  ADD PRIMARY KEY (`TID`);

--
-- Indizes für die Tabelle `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UID`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `mannschaft`
--
ALTER TABLE `mannschaft`
  MODIFY `MID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT für Tabelle `person`
--
ALTER TABLE `person`
  MODIFY `PID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT für Tabelle `ps_ms`
--
ALTER TABLE `ps_ms`
  MODIFY `PSMS_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT für Tabelle `spiele`
--
ALTER TABLE `spiele`
  MODIFY `SPID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT für Tabelle `tms`
--
ALTER TABLE `tms`
  MODIFY `TMS` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT für Tabelle `turnier`
--
ALTER TABLE `turnier`
  MODIFY `TID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT für Tabelle `users`
--
ALTER TABLE `users`
  MODIFY `UID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints der exportierten Tabellen
--

--
-- Constraints der Tabelle `ps_ms`
--
ALTER TABLE `ps_ms`
  ADD CONSTRAINT `FKMID` FOREIGN KEY (`MID`) REFERENCES `mannschaft` (`MID`) ON DELETE CASCADE,
  ADD CONSTRAINT `FKPID` FOREIGN KEY (`PID`) REFERENCES `person` (`PID`) ON DELETE CASCADE;

--
-- Constraints der Tabelle `spiele`
--
ALTER TABLE `spiele`
  ADD CONSTRAINT `FK_MS1` FOREIGN KEY (`MS1ID`) REFERENCES `mannschaft` (`MID`),
  ADD CONSTRAINT `FK_MS2` FOREIGN KEY (`MS2ID`) REFERENCES `mannschaft` (`MID`),
  ADD CONSTRAINT `FK_TIDSPIELE` FOREIGN KEY (`TID`) REFERENCES `turnier` (`TID`);

--
-- Constraints der Tabelle `tms`
--
ALTER TABLE `tms`
  ADD CONSTRAINT `FK_MID` FOREIGN KEY (`MID`) REFERENCES `mannschaft` (`MID`),
  ADD CONSTRAINT `FK_TID` FOREIGN KEY (`TID`) REFERENCES `turnier` (`TID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
