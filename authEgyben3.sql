-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Már 24. 15:22
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
-- Tábla szerkezet ehhez a táblához `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `EmailCode` int(11) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `AktivalasIdopotja` datetime NOT NULL DEFAULT current_timestamp(),
  `ProfilKep` mediumblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `EmailCode`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`, `AktivalasIdopotja`, `ProfilKep`) VALUES
('', 0, 'eatrw', NULL, 'wetzs@gmail.com', NULL, 0, 'retwzrsturduztesafez5ste264578452354', NULL, NULL, NULL, 0, 0, NULL, 0, 0, '2024-03-18 09:50:06', '');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ftpfiles`
--

CREATE TABLE `ftpfiles` (
  `id` int(11) NOT NULL,
  `file` varchar(255) NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `ftpfiles`
--

INSERT INTO `ftpfiles` (`id`, `file`, `timestamp`) VALUES
(1, 'asd', '2024-03-24 13:53:45');

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
(1, '', 1, 'Great product, highly recommended!', 5),
(2, '', 2, 'Looks amazing on my desk, very sturdy.', 4),
(3, '', 3, 'Comfortable and stylish, love it!', 5),
(4, '', 4, 'Excellent quality, very happy with the purchase.', 5),
(5, '', 5, 'Unique design, I get lots of compliments.', 4),
(6, '', 6, 'Perfect for the holiday season!', 5),
(7, '', 7, 'Not what I expected, but still good.', 3),
(8, '', 8, 'Could be better, but it serves its purpose.', 2),
(9, '', 9, 'Quality is okay, expected more.', 3),
(10, '', 10, 'Beautiful and functional, worth the price.', 5),
(12, '', 12, 'Not what I expected, disappointed.', 2),
(13, '', 13, 'Good quality, but a bit overpriced.', 3),
(14, '', 14, 'Exactly what I needed, great buy.', 5),
(15, '', 15, 'Could be improved, but overall satisfied.', 3),
(16, '', 16, 'Well-made and durable, would buy again.', 4),
(17, '', 17, 'Good value for money, happy with the purchase.', 4),
(18, '', 18, 'Unique and stylish, stands out.', 5);

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
  `SzinHex` int(11) NOT NULL,
  `VasarlasIdopontja` date NOT NULL,
  `SikeresSzalitas` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `szamlazas`
--

INSERT INTO `szamlazas` (`SzamlazasId`, `UserId`, `TermekId`, `SzinHex`, `VasarlasIdopontja`, `SikeresSzalitas`) VALUES
(1, '', 1, 0, '2023-11-01', 1),
(2, '', 2, 0, '2023-11-02', 1),
(3, '', 3, 0, '2023-11-03', 0),
(4, '', 4, 0, '2023-11-04', 1),
(5, '', 5, 0, '2023-11-05', 1),
(6, '', 6, 0, '2023-11-06', 1),
(7, '', 7, 0, '2023-11-07', 0),
(8, '', 8, 0, '2023-11-08', 1),
(9, '', 9, 0, '2023-11-09', 0),
(10, '', 10, 0, '2023-11-10', 1),
(12, '', 12, 0, '2023-11-12', 0),
(13, '', 13, 0, '2023-11-13', 1),
(14, '', 14, 0, '2023-11-14', 1),
(15, '', 15, 0, '2023-11-15', 1),
(16, '', 16, 0, '2023-11-16', 0),
(17, '', 17, 0, '2023-11-17', 1),
(18, '', 18, 0, '2023-11-18', 0);

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
  `TagKapcsoloId` int(11) NOT NULL,
  `TermekTagKapcsoloId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `tagkapcsolo`
--

INSERT INTO `tagkapcsolo` (`Id`, `TagKapcsoloId`, `TermekTagKapcsoloId`) VALUES
(1, 1, 1),
(2, 2, 2),
(3, 3, 3),
(4, 4, 4),
(5, 5, 5),
(6, 6, 6),
(7, 7, 7),
(8, 8, 8),
(9, 9, 9),
(10, 10, 10),
(12, 12, 12),
(13, 13, 13),
(14, 14, 14),
(15, 15, 15),
(16, 16, 16),
(17, 17, 17),
(18, 18, 18);

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
(1, '3D Printed House', 5503, 'A 2-bedroom 3D printed house', 8, 1, 'images/3D_Printed_House.jpg'),
(2, 'Animal Wall Lamps', 6870, 'Decorative Animal Inspired Wall Lamps', 80, 8, 'images/3D_Printed_Animal_Lamps.jpg'),
(3, '3D_Printed_Chair', 8050, 'A fully 3D printed chair with ergonomic and natural looking design.', 200, 10, 'images/3D_Printed_Chair.jpg'),
(4, 'Mini Christmas Tree Decor', 1110, 'Adorable tabletop-sized mini Christmas tree for festive decor', 36, 2, 'images/Mini_Christmass_Tree_Decoration.jpg'),
(5, 'Christmass Tree Decoration', 260, 'Beautiful Christmass Tree Decoration', 75, 5, 'images/3D_Printed_Christmass_Decoration.jpg'),
(6, 'Designer Office Chair', 1415, 'Ergonomically designed office chair for a stylish and comfortable workspace', 190, 10, 'path/to/image18.jpg'),
(7, 'Concrete Bench and Table', 22000, 'An affordable City Bench and table combo made with 3D printed concrete.', 230, 10, 'images/City_Bench.jpg'),
(8, 'Printed Vase Containers', 2000, '3D Printed Vase Containers for all of your needs.', 120, 1, 'images/3D_Printed_Containers.jpg'),
(9, 'Portable Electric Blender', 6755, 'Compact and portable electric blender for on-the-go smoothies', 95, 9, 'path/to/image11.jpg'),
(10, 'Ultra HD Smart TV', 13670, 'Ultra HD smart TV with advanced features for an immersive viewing experience', 220, 9, 'path/to/image15.jpg'),
(12, 'Modern Coffee Table', 7523, 'Elegant 3D printed coffee table with metal legs', 12, 10, 'path/to/image2.jpg'),
(13, 'Premium Wireless Speaker', 1075, 'Premium wireless speaker for high-quality audio streaming', 170, 9, 'path/to/image17.jpg'),
(14, 'Smart Home Security Camera', 8572, 'Advanced smart home security camera for monitoring your space', 130, 9, 'path/to/image7.jpg'),
(15, 'Contemporary Dining Chair', 12750, 'Comfortable 3D printed dining chair with sleek design', 20, 10, 'path/to/image3.jpg'),
(16, 'Outdoor Adventure Backpack', 1225, 'Durable outdoor adventure backpack with multiple compartments', 210, 9, 'path/to/image19.jpg'),
(17, 'Home Theater Sound System', 150, 'Immersive home theater sound system for a cinematic experience', 250, 9, 'path/to/image12.jpg'),
(18, 'Compact Air Purifier', 7057, 'Compact air purifier for maintaining clean and fresh indoor air', 110, 9, 'path/to/image9.jpg');

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
-- A tábla indexei `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- A tábla indexei `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- A tábla indexei `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- A tábla indexei `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- A tábla indexei `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- A tábla indexei `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- A tábla indexei `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

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
  ADD KEY `TagKapcsoloId` (`TagKapcsoloId`),
  ADD KEY `TermekTagKapcsoloId` (`TermekTagKapcsoloId`);

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
-- AUTO_INCREMENT a táblához `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `ftpfiles`
--
ALTER TABLE `ftpfiles`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `helyadatok`
--
ALTER TABLE `helyadatok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `hozzaszolasok`
--
ALTER TABLE `hozzaszolasok`
  MODIFY `HozzaszolasId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT a táblához `kategoriak`
--
ALTER TABLE `kategoriak`
  MODIFY `KategoriaId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT a táblához `szamlazas`
--
ALTER TABLE `szamlazas`
  MODIFY `SzamlazasId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

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
  MODIFY `TermekId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Megkötések a táblához `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Megkötések a táblához `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Megkötések a táblához `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Megkötések a táblához `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

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
  ADD CONSTRAINT `tagkapcsolo_ibfk_2` FOREIGN KEY (`TagKapcsoloId`) REFERENCES `tagek` (`TagId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `tagkapcsolo_ibfk_3` FOREIGN KEY (`Id`) REFERENCES `termekek` (`TermekId`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `termekek`
--
ALTER TABLE `termekek`
  ADD CONSTRAINT `termekek_ibfk_3` FOREIGN KEY (`KategoriaId`) REFERENCES `kategoriak` (`KategoriaId`) ON DELETE CASCADE ON UPDATE CASCADE;

DELIMITER $$
--
-- Események
--
CREATE DEFINER=`root`@`localhost` EVENT `delete_old_records` ON SCHEDULE EVERY 1 MINUTE STARTS '2024-03-24 15:03:43' ON COMPLETION NOT PRESERVE ENABLE DO begin
    delete from ftpfiles
    where 
    Timestamp < timestamp(current_date() - interval 1 day);
end$$

DELIMITER ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
