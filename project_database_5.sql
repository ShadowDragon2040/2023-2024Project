-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Nov 10. 09:59
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `project_database`
--
CREATE DATABASE IF NOT EXISTS `project_database` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `project_database`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalok`
--

CREATE TABLE `felhasznalok` (
  `Id` char(36) NOT NULL,
  `LoginNev` varchar(128) NOT NULL,
  `HASH` varchar(128) NOT NULL,
  `SALT` varchar(128) NOT NULL,
  `Nev` varchar(128) NOT NULL,
  `Jog` int(11) NOT NULL,
  `Aktivalva` tinyint(1) NOT NULL,
  `Email` varchar(128) NOT NULL,
  `ProfilKep` varchar(128) NOT NULL,
  `OrszágKodId` int(11) NOT NULL,
  `VarosNevId` int(11) NOT NULL,
  `UtcaNev` varchar(128) NOT NULL,
  `IranyitoSzam` varchar(128) NOT NULL,
  `Hazszam` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `hozzaszolas`
--

CREATE TABLE `hozzaszolas` (
  `Id` int(11) NOT NULL,
  `FelhasznaloId` char(36) NOT NULL,
  `TermekId` char(36) NOT NULL,
  `Leiras` varchar(255) NOT NULL,
  `Ertekeles` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `orszagok`
--

CREATE TABLE `orszagok` (
  `OrszagId` int(11) NOT NULL,
  `OrszagKod` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szamlazas`
--

CREATE TABLE `szamlazas` (
  `Id` int(11) NOT NULL,
  `FelhasznaloId` char(36) NOT NULL,
  `TermekId` char(36) NOT NULL,
  `VasarlasIdopontja` date NOT NULL,
  `SikeresSzalitas` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szinek`
--

CREATE TABLE `szinek` (
  `SzinId` int(11) NOT NULL,
  `SzinHex` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tagek`
--

CREATE TABLE `tagek` (
  `TagId` int(11) NOT NULL,
  `TagNev` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `termekek`
--

CREATE TABLE `termekek` (
  `Id` char(36) NOT NULL,
  `TermekNev` varchar(128) NOT NULL,
  `Ar` int(11) NOT NULL,
  `Leiras` varchar(255) NOT NULL,
  `Menyiseg` int(11) NOT NULL,
  `SzinId` int(11) NOT NULL,
  `TagId` int(11) NOT NULL,
  `Keputvonal` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `varosok`
--

CREATE TABLE `varosok` (
  `VarosId` int(11) NOT NULL,
  `VarosNev` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `felhasznalok`
--
ALTER TABLE `felhasznalok`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `OrszágKodId` (`OrszágKodId`,`VarosNevId`),
  ADD KEY `VarosNevId` (`VarosNevId`);

--
-- A tábla indexei `hozzaszolas`
--
ALTER TABLE `hozzaszolas`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FelhasznaloId` (`FelhasznaloId`,`TermekId`),
  ADD KEY `hozzaszolas_ibfk_1` (`TermekId`);

--
-- A tábla indexei `orszagok`
--
ALTER TABLE `orszagok`
  ADD PRIMARY KEY (`OrszagId`);

--
-- A tábla indexei `szamlazas`
--
ALTER TABLE `szamlazas`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `FelhasznaloId` (`FelhasznaloId`,`TermekId`),
  ADD KEY `szamlazas_ibfk_1` (`TermekId`);

--
-- A tábla indexei `szinek`
--
ALTER TABLE `szinek`
  ADD PRIMARY KEY (`SzinId`);

--
-- A tábla indexei `tagek`
--
ALTER TABLE `tagek`
  ADD PRIMARY KEY (`TagId`);

--
-- A tábla indexei `termekek`
--
ALTER TABLE `termekek`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `SzinValasztek` (`SzinId`),
  ADD KEY `TagId` (`TagId`);

--
-- A tábla indexei `varosok`
--
ALTER TABLE `varosok`
  ADD PRIMARY KEY (`VarosId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `hozzaszolas`
--
ALTER TABLE `hozzaszolas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `orszagok`
--
ALTER TABLE `orszagok`
  MODIFY `OrszagId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `szamlazas`
--
ALTER TABLE `szamlazas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `szinek`
--
ALTER TABLE `szinek`
  MODIFY `SzinId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `tagek`
--
ALTER TABLE `tagek`
  MODIFY `TagId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `varosok`
--
ALTER TABLE `varosok`
  MODIFY `VarosId` int(11) NOT NULL AUTO_INCREMENT;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `felhasznalok`
--
ALTER TABLE `felhasznalok`
  ADD CONSTRAINT `felhasznalok_ibfk_1` FOREIGN KEY (`OrszágKodId`) REFERENCES `orszagok` (`OrszagId`),
  ADD CONSTRAINT `felhasznalok_ibfk_2` FOREIGN KEY (`VarosNevId`) REFERENCES `varosok` (`VarosId`);

--
-- Megkötések a táblához `hozzaszolas`
--
ALTER TABLE `hozzaszolas`
  ADD CONSTRAINT `hozzaszolas_ibfk_1` FOREIGN KEY (`TermekId`) REFERENCES `termekek` (`Id`),
  ADD CONSTRAINT `hozzaszolas_ibfk_2` FOREIGN KEY (`FelhasznaloId`) REFERENCES `felhasznalok` (`Id`);

--
-- Megkötések a táblához `szamlazas`
--
ALTER TABLE `szamlazas`
  ADD CONSTRAINT `szamlazas_ibfk_1` FOREIGN KEY (`TermekId`) REFERENCES `termekek` (`Id`),
  ADD CONSTRAINT `szamlazas_ibfk_2` FOREIGN KEY (`FelhasznaloId`) REFERENCES `felhasznalok` (`Id`);

--
-- Megkötések a táblához `termekek`
--
ALTER TABLE `termekek`
  ADD CONSTRAINT `termekek_ibfk_1` FOREIGN KEY (`TagId`) REFERENCES `tagek` (`TagId`),
  ADD CONSTRAINT `termekek_ibfk_2` FOREIGN KEY (`SzinId`) REFERENCES `szinek` (`SzinId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
