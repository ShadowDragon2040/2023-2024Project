-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Ápr 12. 07:48
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
('03c66e48-f575-4ffb-9252-f307d1b473e0', 1547, 'Balazs', 'vardai.balazs22@gmail.com', 1, 'AQAAAAIAAYagAAAAEIJgdW+Z4wG/Z7BKteT5hJbgMe6GkiWMJcpWF8fpFd/gUgZaTTb4hqLKPmQ3+dNpRQ==', '2024-04-05 08:54:02', ''),
('1310d8a6-1174-4480-b815-41379c654d11', 9827, 'string', 'string', 1, '$2a$11$Edek6dtSHiOGR.Do3625POM8qUthmpRydiN4WG5EUTengKwaIXQ/S', '2024-04-10 09:34:21', ''),
('1d90a3d3-ada0-458f-a242-25c26616dc68', 4975, 'test', 'test', 1, '$2a$11$4uwIzlRrHg1nCsWPE5ugT.KN2DLRt1dw/oWP6nv1ovYOHmW964oqu', '2024-04-10 12:00:40', ''),
('5b09a8c4-620d-4a41-8518-8027cc718fa3', 5666, 'testuser', 'balintpejko@gmail.com', 1, '$2a$11$ZsCWipTqN.PuxfVgpkcDo.nEeZUqvAdnMSsRiyeFsuxal2EMOv90i', '2024-04-10 12:38:12', ''),
('bcb02b97-6eae-41b6-be73-b6059d7d4dd8', 1008, 'testaesdsad', 'asdoisadjoadoisad', 0, '$2a$11$Z3gJp8vn0QUJPjrCxzHliedazIeA.Rs3seQrltAK.cAkbh6a9Iktm', '2024-04-10 09:36:33', ''),
('ee8b35cc-3cea-4445-b7c2-7b4022a3ae02', 4712, 'Balint', 'pejkob@kkszki.hu', 0, '$2a$11$87hOBvGa7BmXPd2liJdLKOIbJOsX969.yzYZBCCESbACZkGogZ9jO', '2024-04-10 10:29:25', ''),
('f1065d80-06e0-45a7-8959-fdd409a26da1', 5736, 'string1', 'string1', 0, '$2a$11$LM3FBsGcd58SrKcZsDtOM.msilipGdOE1fvEKqPXKLYiobwp2QZo.', '2024-04-10 09:34:39', '');

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
(2, '03c66e48-f575-4ffb-9252-f307d1b473e0', 'Kína', 'Söul', 'CHinchin utca', '8495', '69', 'Első lépcső');

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
(53, '03c66e48-f575-4ffb-9252-f307d1b473e0', 21, 'Looks amazing on my desk, very sturdy.', 5),
(55, '03c66e48-f575-4ffb-9252-f307d1b473e0', 4, 'Quality is okay, expected more.', 4),
(56, '03c66e48-f575-4ffb-9252-f307d1b473e0', 4, 'Perfect for the holiday season!', 5),
(58, '03c66e48-f575-4ffb-9252-f307d1b473e0', 8, 'Unique design, I get lots of compliments.', 4),
(61, '03c66e48-f575-4ffb-9252-f307d1b473e0', 26, 'Good quality, but a bit overpriced.', 4),
(63, '03c66e48-f575-4ffb-9252-f307d1b473e0', 6, 'Well-made and durable, would buy again.', 4),
(65, '03c66e48-f575-4ffb-9252-f307d1b473e0', 24, 'Not the best quality, expected more.', 3),
(66, '03c66e48-f575-4ffb-9252-f307d1b473e0', 7, 'Could be improved, but overall satisfied.', 4),
(68, '03c66e48-f575-4ffb-9252-f307d1b473e0', 26, 'Quality is okay, expected more.', 4);

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
(39, '03c66e48-f575-4ffb-9252-f307d1b473e0', 3, '32a852', 6, '2024-04-05 09:19:44', 0),
(40, '03c66e48-f575-4ffb-9252-f307d1b473e0', 22, '000000', 30, '2024-04-05 09:23:10', 1),
(42, '03c66e48-f575-4ffb-9252-f307d1b473e0', 27, 'ffffff', 9, '2024-04-05 09:23:10', 1),
(44, '03c66e48-f575-4ffb-9252-f307d1b473e0', 6, '5431b5', 4, '2024-04-05 09:23:10', 1),
(47, '03c66e48-f575-4ffb-9252-f307d1b473e0', 6, 'f7eb81', 8, '2024-04-05 09:23:10', 0);

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
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

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
