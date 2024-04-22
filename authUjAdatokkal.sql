-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Ápr 22. 09:24
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `auth`
--
CREATE DATABASE IF NOT EXISTS `auth` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `auth`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `aspnetrole`
--

CREATE TABLE `aspnetrole` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `aspnetrole`
--

INSERT INTO `aspnetrole` (`Id`, `Name`) VALUES
('81f1660f-8329-4f49-9b16-7a1592d43d7e', 'ADMIN'),
('49d1592d-dc96-4868-834e-fa4e837e3d97', 'USER');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `aspnetuserrole`
--

CREATE TABLE `aspnetuserrole` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `aspnetuserrole`
--

INSERT INTO `aspnetuserrole` (`UserId`, `RoleId`) VALUES
('1310d8a6-1174-4480-b815-41379c654d11', '81f1660f-8329-4f49-9b16-7a1592d43d7e');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `EmailCode` int(11) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `AktivalasIdopotja` datetime NOT NULL DEFAULT current_timestamp(),
  `ProfilKep` mediumblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `EmailCode`, `UserName`, `Email`, `EmailConfirmed`, `PasswordHash`, `AktivalasIdopotja`, `ProfilKep`) VALUES
('1310d8a6-1174-4480-b815-41379c654d11', 9827, 'string', 'string', 1, '$2a$11$Edek6dtSHiOGR.Do3625POM8qUthmpRydiN4WG5EUTengKwaIXQ/S', '2024-04-10 09:34:21', ''),
('14bd25b6-bf98-423b-b060-471bfaf81452', 8663, 'Balazs', 'vardai.balazs22@gmail.com', 1, '$2a$11$qa/gdLq5gvoCVxalW2pjReDjr2UZ9.BF8d1GNnWgu6qJyp.08YjPO', '2024-04-16 12:55:24', ''),
('2b9b3815-ea87-490f-8d27-238bf18b8ca7', 5748, 'Judit', 'szaboj@kkszki.hu', 1, '$2a$11$6Gcpk9SdR3OwXNEJ6gFujOeCYyAkV7qrb0H2hMiiGC4TxZ4NZO5AC', '2024-04-22 09:11:50', ''),
('7a27d9fc-7483-4098-b7f4-dfa679aefc81', 7897, 'Balint', 'pejkob@kkszki.hu', 1, '$2a$11$nD2y7AjVWZ4b2v4TTciuKugeMyoZUlXc9e1LvEe9HU.bJop4S5SUW', '2024-04-22 09:10:53', '');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ftpfiles`
--

CREATE TABLE `ftpfiles` (
  `id` int(11) NOT NULL,
  `file` varchar(255) NOT NULL,
  `timestamp` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `ftpfiles`
--

INSERT INTO `ftpfiles` (`id`, `file`, `timestamp`) VALUES
(1, 'asd', '2024-03-24 14:53:45'),
(4, 'C:\\Users\\User\\Pictures\\Képernyőkép 2024-03-24 135937.png', '2024-03-24 15:57:35'),
(5, 'C:\\Users\\User\\Pictures\\Képernyőkép 2024-03-24 114236.png', '2024-03-24 15:58:03'),
(6, 'C:\\Users\\User\\Pictures\\Képernyőkép 2024-03-24 114236.png', '2024-03-24 15:59:13'),
(7, 'C:\\Users\\User\\Pictures\\Képernyőkép 2024-03-24 114236.png', '2024-03-24 16:00:42'),
(8, 'C:\\Users\\User\\Pictures\\Képernyőkép 2024-03-24 114236.png', '2024-03-24 16:01:14'),
(9, 'C:\\Users\\User\\Pictures\\Képernyőkép 2024-03-24 114236.png', '2024-03-24 16:02:35'),
(10, 'C:\\Users\\User\\Pictures\\Képernyőkép 2024-03-24 135937.png', '2024-03-24 17:27:36'),
(11, 'C:\\Users\\pbálint\\Pictures\\Screenshots\\Képernyőkép 2024-02-06 100052.png', '2024-03-25 09:34:39'),
(12, 'C:\\Users\\pbálint\\Documents\\GitHub\\2023-2024Project\\Kepek\\3dBencyBlender.jpg', '2024-03-25 10:34:02'),
(13, 'C:\\Users\\pbálint\\Documents\\GitHub\\2023-2024Project\\Kepek\\abslikeresin.jpg', '2024-03-25 10:34:09'),
(14, 'C:\\Users\\pbálint\\Documents\\GitHub\\2023-2024Project\\Kepek\\fdmboatmodell.jpg', '2024-03-25 10:34:19'),
(15, 'C:\\Users\\pbálint\\Documents\\GitHub\\2023-2024Project\\Kepek\\Pencil_Holder.jpg', '2024-03-25 10:35:11'),
(16, 'C:\\Users\\pbálint\\Documents\\GitHub\\2023-2024Project\\Kepek\\layerheightcomparison.jpg', '2024-03-25 10:35:29'),
(17, 'C:\\Users\\pbálint\\Documents\\GitHub\\2023-2024Project\\Kepek\\3D_Printed_House.jpg', '2024-03-25 10:35:38'),
(18, 'C:\\Users\\pbálint\\Pictures\\Screenshots\\Képernyőkép 2024-01-24 095750.png', '2024-03-26 08:19:47'),
(19, 'C:\\Users\\pbálint\\Pictures\\Screenshots\\Képernyőkép 2024-02-21 101309.png', '2024-03-26 12:56:19'),
(20, 'C:\\Users\\pbálint\\Pictures\\Screenshots\\Képernyőkép 2024-01-24 095702.png', '2024-03-26 13:52:11');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `helyadatok`
--

CREATE TABLE `helyadatok` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `OrszagNev` varchar(128) NOT NULL,
  `VarosNev` varchar(128) NOT NULL,
  `UtcaNev` varchar(128) NOT NULL,
  `Iranyitoszam` varchar(128) NOT NULL,
  `Hazszam` varchar(128) NOT NULL,
  `Egyeb` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `helyadatok`
--

INSERT INTO `helyadatok` (`Id`, `UserId`, `OrszagNev`, `VarosNev`, `UtcaNev`, `Iranyitoszam`, `Hazszam`, `Egyeb`) VALUES
(1, '14bd25b6-bf98-423b-b060-471bfaf81452', 'Magyarország', 'Miskolc', 'Sarok utca', '6284', '65', ''),
(2, '2b9b3815-ea87-490f-8d27-238bf18b8ca7', 'Kína', 'Söul', 'CHinchin utca', '8495', '69', 'Első lépcső'),
(3, '7a27d9fc-7483-4098-b7f4-dfa679aefc81', 'Anglia', 'Londoff', 'Temze utca', '6958', '5', 'A folyóba ne ugorj bele'),
(4, '1310d8a6-1174-4480-b815-41379c654d11', 'Magyarország', 'IzéHozé', 'Jani utca', '6268', '15', 'ADMIN VAGYOK');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `hozzaszolasok`
--

CREATE TABLE `hozzaszolasok` (
  `HozzaszolasId` int(11) NOT NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `TermekId` int(11) NOT NULL,
  `Leiras` varchar(255) NOT NULL,
  `Ertekeles` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `hozzaszolasok`
--

INSERT INTO `hozzaszolasok` (`HozzaszolasId`, `UserId`, `TermekId`, `Leiras`, `Ertekeles`) VALUES
(52, '1310d8a6-1174-4480-b815-41379c654d11', 1, 'Great product, highly recommended!', 5),
(53, '14bd25b6-bf98-423b-b060-471bfaf81452', 21, 'Looks amazing on my desk, very sturdy.', 5),
(54, '1310d8a6-1174-4480-b815-41379c654d11', 26, 'Not what I expected, but still good.', 3),
(55, '14bd25b6-bf98-423b-b060-471bfaf81452', 4, 'Quality is okay, expected more.', 4),
(56, '1310d8a6-1174-4480-b815-41379c654d11', 4, 'Perfect for the holiday season!', 5),
(57, '14bd25b6-bf98-423b-b060-471bfaf81452', 12, 'Beautiful and functional, worth the price.', 5),
(58, '14bd25b6-bf98-423b-b060-471bfaf81452', 8, 'Unique design, I get lots of compliments.', 4),
(59, '14bd25b6-bf98-423b-b060-471bfaf81452', 6, 'Comfortable and stylish, love it!', 2),
(60, '1310d8a6-1174-4480-b815-41379c654d11', 22, 'Could be better, but it serves its purpose.', 2),
(61, '2b9b3815-ea87-490f-8d27-238bf18b8ca7', 26, 'Good quality, but a bit overpriced.', 4),
(62, '7a27d9fc-7483-4098-b7f4-dfa679aefc81', 12, 'Exactly what I needed, great buy.', 5),
(63, '2b9b3815-ea87-490f-8d27-238bf18b8ca7', 6, 'Well-made and durable, would buy again.', 4),
(64, '1310d8a6-1174-4480-b815-41379c654d11', 27, 'Not what I expected, disappointed.', 1),
(65, '2b9b3815-ea87-490f-8d27-238bf18b8ca7', 24, 'Not the best quality, expected more.', 3),
(66, '2b9b3815-ea87-490f-8d27-238bf18b8ca7', 7, 'Could be improved, but overall satisfied.', 4),
(67, '7a27d9fc-7483-4098-b7f4-dfa679aefc81', 15, 'Good value for money, happy with the purchase.', 4),
(68, '2b9b3815-ea87-490f-8d27-238bf18b8ca7', 26, 'Quality is okay, expected more.', 4),
(69, '7a27d9fc-7483-4098-b7f4-dfa679aefc81', 21, 'Unique and stylish, stands out.', 5),
(70, '14bd25b6-bf98-423b-b060-471bfaf81452', 4, 'Unique and stylish, stands out.', 3),
(71, '7a27d9fc-7483-4098-b7f4-dfa679aefc81', 3, 'Good quality, but a bit overpriced.', 3);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kategoriak`
--

CREATE TABLE `kategoriak` (
  `KategoriaId` int(11) NOT NULL,
  `KategoriaNev` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `kategoriak`
--

INSERT INTO `kategoriak` (`KategoriaId`, `KategoriaNev`) VALUES
(1, 'Home decor'),
(2, 'Gaming'),
(3, 'Movies'),
(4, 'Accessories'),
(5, 'Festive decoration'),
(6, 'Statues'),
(7, 'Miniatures'),
(8, 'Wall decor'),
(9, 'Other'),
(10, 'Furniture');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szamlazas`
--

CREATE TABLE `szamlazas` (
  `SzamlazasId` int(11) NOT NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `TermekId` int(11) NOT NULL,
  `SzinHex` varchar(32) NOT NULL,
  `darab` int(11) NOT NULL,
  `VasarlasIdopontja` datetime NOT NULL,
  `SikeresSzalitas` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `szamlazas`
--

INSERT INTO `szamlazas` (`SzamlazasId`, `UserId`, `TermekId`, `SzinHex`, `darab`, `VasarlasIdopontja`, `SikeresSzalitas`) VALUES
(39, '1310d8a6-1174-4480-b815-41379c654d11', 3, '32a852', 6, '2024-04-05 09:19:44', 0),
(40, '1310d8a6-1174-4480-b815-41379c654d11', 22, '000000', 30, '2024-04-05 09:23:10', 1),
(41, '14bd25b6-bf98-423b-b060-471bfaf81452', 12, 'ab9fcc', 1, '2024-04-05 09:23:10', 0),
(42, '14bd25b6-bf98-423b-b060-471bfaf81452', 27, 'ffffff', 9, '2024-04-05 09:23:10', 1),
(43, '14bd25b6-bf98-423b-b060-471bfaf81452', 24, 'ffffff', 3, '2024-04-05 09:23:10', 0),
(44, '2b9b3815-ea87-490f-8d27-238bf18b8ca7', 6, '5431b5', 4, '2024-04-05 09:23:10', 1),
(45, '2b9b3815-ea87-490f-8d27-238bf18b8ca7', 23, 'de2393', 20, '2024-04-05 09:23:10', 1),
(46, '7a27d9fc-7483-4098-b7f4-dfa679aefc81', 21, '820774', 5, '2024-04-05 09:23:10', 1),
(47, '7a27d9fc-7483-4098-b7f4-dfa679aefc81', 6, 'f7eb81', 8, '2024-04-05 09:23:10', 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tagek`
--

CREATE TABLE `tagek` (
  `TagId` int(11) NOT NULL,
  `TagNev` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `tagek`
--

INSERT INTO `tagek` (`TagId`, `TagNev`) VALUES
(1, 'Star Wars'),
(2, 'Sci-Fi'),
(3, 'Fantasy'),
(4, 'Adventure'),
(5, 'Action'),
(6, 'Mystery'),
(7, 'Romance'),
(8, 'Thriller'),
(9, 'Comedy'),
(10, 'Drama'),
(11, 'Historical'),
(12, 'Superhero'),
(13, 'Animation'),
(14, 'Horror'),
(15, 'Documentary'),
(16, 'Sports'),
(17, 'Technology'),
(18, 'Travel'),
(19, 'Nature'),
(20, 'Music');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tagkapcsolo`
--

CREATE TABLE `tagkapcsolo` (
  `Id` int(11) NOT NULL,
  `TagekId` int(11) NOT NULL,
  `TermekekId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `tagkapcsolo`
--

INSERT INTO `tagkapcsolo` (`Id`, `TagekId`, `TermekekId`) VALUES
(1, 5, 2),
(2, 19, 12),
(3, 15, 27),
(4, 13, 4),
(5, 4, 8),
(6, 14, 22),
(7, 3, 22),
(8, 11, 25),
(9, 4, 21),
(10, 1, 7),
(11, 12, 21),
(12, 12, 6),
(13, 13, 27),
(14, 3, 8),
(15, 7, 15),
(16, 6, 26),
(17, 15, 12),
(18, 16, 12),
(19, 11, 27),
(20, 14, 21);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `termekek`
--

CREATE TABLE `termekek` (
  `TermekId` int(11) NOT NULL,
  `TermekNev` varchar(128) NOT NULL,
  `Ar` int(11) NOT NULL,
  `Leiras` varchar(255) NOT NULL,
  `Menyiseg` int(11) NOT NULL,
  `KategoriaId` int(11) NOT NULL,
  `Keputvonal` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `termekek`
--

INSERT INTO `termekek` (`TermekId`, `TermekNev`, `Ar`, `Leiras`, `Menyiseg`, `KategoriaId`, `Keputvonal`) VALUES
(1, '3D Printed House', 5503, 'A 2-bedroom 3D printed house', 8, 9, 'http://printfusion.nhely.hu/test/3D_Printed_House.jpg'),
(2, 'Animal Wall Lamps', 6870, 'Decorative Animal Inspired Wall Lamps', 80, 8, 'http://printfusion.nhely.hu/test/3D_Printed_Animal_Lamps.jpg'),
(3, '3D_Printed_Chair', 8050, 'A fully 3D printed chair with ergonomic and natural looking design.', 200, 10, 'http://printfusion.nhely.hu/test/3D_Printed_Chair.jpg'),
(4, 'Mini Christmas Tree Decor', 1110, 'Adorable tabletop-sized mini Christmas tree for festive decor', 36, 5, 'http://printfusion.nhely.hu/test/Mini_Christmass_Tree_Decoration.jpg'),
(5, 'Christmass Tree Decoration', 260, 'Beautiful Christmass Tree Decoration', 75, 5, 'http://printfusion.nhely.hu/test/3D_Printed_Christmass_Decoration.jpg'),
(6, 'Designer Office Chair', 1415, 'Ergonomically designed office chair for a stylish and comfortable workspace', 190, 10, 'http://printfusion.nhely.hu/test/Designer_Office_Chair.jpg'),
(7, 'Concrete Bench and Table', 22000, 'An affordable City Bench and table combo made with 3D printed concrete.', 230, 10, 'http://printfusion.nhely.hu/test/City_Bench.jpg'),
(8, 'Printed Vase Containers', 2000, '3D Printed Vase Containers for all of your needs.', 120, 1, 'http://printfusion.nhely.hu/test/3D_Printed_Containers.jpg'),
(12, 'Modern Coffee Table', 75200, 'Elegant 3D printed coffee table with metal legs', 12, 10, 'http://printfusion.nhely.hu/test/Coffe_Table.jpg'),
(15, 'Contemporary Dining Chair', 12750, 'Comfortable 3D printed dining chair with sleek design', 20, 10, 'http://printfusion.nhely.hu/test/Dining_Chair.jpg'),
(21, 'Artistic Head', 10000, 'An artistic design head.', 30, 1, 'http://printfusion.nhely.hu/test/Human_Skull.jpg'),
(22, 'Pencil Holder', 200, 'A styled pencil holder made for any modern looking office.', 126, 4, 'http://printfusion.nhely.hu/test/Pencil_Holder.jpg'),
(23, 'Modular Open Shelves', 3000, 'A modular open shelf, that can be made to fit any wall sizes.', 25, 8, 'http://printfusion.nhely.hu/test/Wall_Open_Cabinet.jpg'),
(24, 'Tree Wall Decoration', 8000, 'An artistic depiction of a tree', 4, 8, 'http://printfusion.nhely.hu/test/3D_Printed_Wall_Decoration.jpg'),
(25, 'Figure Collection', 5000, 'A small array of different figures', 1, 7, 'http://printfusion.nhely.hu/test/image1.png'),
(26, 'Knight warriors', 3000, '3 knight figures', 7, 7, 'http://printfusion.nhely.hu/test/image2.jpg'),
(27, 'Orc figures', 2000, '3 small figures of Orcs', 17, 7, 'http://printfusion.nhely.hu/test/image3.jpg');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20240304075233_createIdentity', '8.0.1');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `aspnetrole`
--
ALTER TABLE `aspnetrole`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Name` (`Name`);

--
-- A tábla indexei `aspnetuserrole`
--
ALTER TABLE `aspnetuserrole`
  ADD PRIMARY KEY (`UserId`),
  ADD KEY `RoleId` (`RoleId`);

--
-- A tábla indexei `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserName` (`UserName`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- A tábla indexei `ftpfiles`
--
ALTER TABLE `ftpfiles`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `helyadatok`
--
ALTER TABLE `helyadatok`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `UserId` (`UserId`);

--
-- A tábla indexei `hozzaszolasok`
--
ALTER TABLE `hozzaszolasok`
  ADD PRIMARY KEY (`HozzaszolasId`),
  ADD KEY `FelhasznaloId` (`TermekId`),
  ADD KEY `hozzaszolas_ibfk_1` (`TermekId`),
  ADD KEY `UserId` (`UserId`);

--
-- A tábla indexei `kategoriak`
--
ALTER TABLE `kategoriak`
  ADD PRIMARY KEY (`KategoriaId`);

--
-- A tábla indexei `szamlazas`
--
ALTER TABLE `szamlazas`
  ADD PRIMARY KEY (`SzamlazasId`),
  ADD KEY `FelhasznaloId` (`TermekId`),
  ADD KEY `szamlazas_ibfk_1` (`TermekId`),
  ADD KEY `UserId` (`UserId`);

--
-- A tábla indexei `tagek`
--
ALTER TABLE `tagek`
  ADD PRIMARY KEY (`TagId`);

--
-- A tábla indexei `tagkapcsolo`
--
ALTER TABLE `tagkapcsolo`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `TagKapcsoloId` (`TagekId`),
  ADD KEY `TermekekId` (`TermekekId`);

--
-- A tábla indexei `termekek`
--
ALTER TABLE `termekek`
  ADD PRIMARY KEY (`TermekId`),
  ADD KEY `KategoriaId` (`KategoriaId`);

--
-- A tábla indexei `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `ftpfiles`
--
ALTER TABLE `ftpfiles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `helyadatok`
--
ALTER TABLE `helyadatok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `hozzaszolasok`
--
ALTER TABLE `hozzaszolasok`
  MODIFY `HozzaszolasId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=72;

--
-- AUTO_INCREMENT a táblához `kategoriak`
--
ALTER TABLE `kategoriak`
  MODIFY `KategoriaId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT a táblához `szamlazas`
--
ALTER TABLE `szamlazas`
  MODIFY `SzamlazasId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=48;

--
-- AUTO_INCREMENT a táblához `tagek`
--
ALTER TABLE `tagek`
  MODIFY `TagId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `tagkapcsolo`
--
ALTER TABLE `tagkapcsolo`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `termekek`
--
ALTER TABLE `termekek`
  MODIFY `TermekId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `aspnetuserrole`
--
ALTER TABLE `aspnetuserrole`
  ADD CONSTRAINT `aspnetuserrole_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`),
  ADD CONSTRAINT `aspnetuserrole_ibfk_2` FOREIGN KEY (`RoleId`) REFERENCES `aspnetrole` (`Id`);

--
-- Megkötések a táblához `helyadatok`
--
ALTER TABLE `helyadatok`
  ADD CONSTRAINT `helyadatok_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `hozzaszolasok`
--
ALTER TABLE `hozzaszolasok`
  ADD CONSTRAINT `hozzaszolasok_ibfk_1` FOREIGN KEY (`TermekId`) REFERENCES `termekek` (`TermekId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `hozzaszolasok_ibfk_2` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `szamlazas`
--
ALTER TABLE `szamlazas`
  ADD CONSTRAINT `szamlazas_ibfk_1` FOREIGN KEY (`TermekId`) REFERENCES `termekek` (`TermekId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `szamlazas_ibfk_2` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `tagkapcsolo`
--
ALTER TABLE `tagkapcsolo`
  ADD CONSTRAINT `tagkapcsolo_ibfk_2` FOREIGN KEY (`TagekId`) REFERENCES `tagek` (`TagId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `tagkapcsolo_ibfk_3` FOREIGN KEY (`TermekekId`) REFERENCES `termekek` (`TermekId`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `termekek`
--
ALTER TABLE `termekek`
  ADD CONSTRAINT `termekek_ibfk_3` FOREIGN KEY (`KategoriaId`) REFERENCES `kategoriak` (`KategoriaId`) ON DELETE CASCADE ON UPDATE CASCADE;

DELIMITER $$
--
-- Események
--
CREATE DEFINER=`root`@`localhost` EVENT `delete_old_records` ON SCHEDULE EVERY 1 DAY STARTS '2024-03-24 15:03:43' ON COMPLETION NOT PRESERVE ENABLE DO begin
    delete from ftpfiles
    where 
    Timestamp < timestamp(current_date() - interval 1 day);
end$$

DELIMITER ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
