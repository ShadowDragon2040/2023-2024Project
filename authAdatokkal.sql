-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Ápr 05. 10:12
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

--
-- A tábla adatainak kiíratása `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('dd8fa84e-d702-4d1b-bc81-7948a2a1083f', 'USER', 'USER', NULL);

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

--
-- A tábla adatainak kiíratása `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
('03c66e48-f575-4ffb-9252-f307d1b473e0', 'dd8fa84e-d702-4d1b-bc81-7948a2a1083f'),
('0bb5579f-84d4-4120-beda-8012fe6a9816', 'dd8fa84e-d702-4d1b-bc81-7948a2a1083f'),
('26d1e535-4d3c-4c2d-a4cf-c4c3e48d310f', 'dd8fa84e-d702-4d1b-bc81-7948a2a1083f');

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
('03c66e48-f575-4ffb-9252-f307d1b473e0', 1547, 'Balazs', 'BALAZS', 'vardai.balazs22@gmail.com', 'VARDAI.BALAZS22@GMAIL.COM', 1, 'AQAAAAIAAYagAAAAEIJgdW+Z4wG/Z7BKteT5hJbgMe6GkiWMJcpWF8fpFd/gUgZaTTb4hqLKPmQ3+dNpRQ==', '5ZHHI5SV3UKLE2OXVWS3FFAZYZFNF7X3', '7fc461ac-e756-476b-967e-f3c9ec6a7603', NULL, 0, 0, NULL, 1, 0, '2024-04-05 08:54:02', ''),
('0bb5579f-84d4-4120-beda-8012fe6a9816', 2003, 'Balint', 'BALINT', 'pejkob@kkszki.hu', 'PEJKOB@KKSZKI.HU', 1, 'AQAAAAIAAYagAAAAEKhnQ5rzrUs87l66JuSTG1pQCl2M4X/EaH4T17rqj3pW7w/14eHoG/UEMqpzexwEiA==', '4DXEAYHC6SNQEELSXNLM6DKVGJJEXQHE', '2e10709c-dcfe-4661-ab9b-680f611b23bb', NULL, 0, 0, NULL, 1, 0, '2024-04-05 08:55:12', ''),
('26d1e535-4d3c-4c2d-a4cf-c4c3e48d310f', 8220, 'Judit', 'JUDIT', 'szaboj@kkszki.hu', 'SZABOJ@KKSZKI.HU', 1, 'AQAAAAIAAYagAAAAEE8YKq86JvUY3LJxA3mr9yljZH6LHLeBlO+h3t2ii1JbWFNZQ1Z0tPQggQSuRTizyw==', '4UDYEDEEE4S4EQICF4NHLTYB6CGQTWNO', '6e4b75cb-ca6a-49d7-95e6-4d13db91a7fa', NULL, 0, 0, NULL, 1, 0, '2024-04-05 08:56:47', '');

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
(1, '0bb5579f-84d4-4120-beda-8012fe6a9816', 'Magyarország', 'Miskolc', 'Sarok utca', '6284', '65', ''),
(2, '03c66e48-f575-4ffb-9252-f307d1b473e0', 'Kína', 'Söul', 'CHinchin utca', '8495', '69', 'Első lépcső'),
(3, '26d1e535-4d3c-4c2d-a4cf-c4c3e48d310f', 'Anglia', 'Londoff', 'Temze utca', '6958', '5', 'A folyóba ne ugorj bele');

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
(52, '0bb5579f-84d4-4120-beda-8012fe6a9816', 1, 'Great product, highly recommended!', 5),
(53, '03c66e48-f575-4ffb-9252-f307d1b473e0', 21, 'Looks amazing on my desk, very sturdy.', 5),
(54, '26d1e535-4d3c-4c2d-a4cf-c4c3e48d310f', 26, 'Not what I expected, but still good.', 3),
(55, '03c66e48-f575-4ffb-9252-f307d1b473e0', 4, 'Quality is okay, expected more.', 4),
(56, '03c66e48-f575-4ffb-9252-f307d1b473e0', 4, 'Perfect for the holiday season!', 5),
(57, '0bb5579f-84d4-4120-beda-8012fe6a9816', 12, 'Beautiful and functional, worth the price.', 5),
(58, '03c66e48-f575-4ffb-9252-f307d1b473e0', 8, 'Unique design, I get lots of compliments.', 4),
(59, '0bb5579f-84d4-4120-beda-8012fe6a9816', 6, 'Comfortable and stylish, love it!', 2),
(60, '0bb5579f-84d4-4120-beda-8012fe6a9816', 22, 'Could be better, but it serves its purpose.', 2),
(61, '03c66e48-f575-4ffb-9252-f307d1b473e0', 26, 'Good quality, but a bit overpriced.', 4),
(62, '26d1e535-4d3c-4c2d-a4cf-c4c3e48d310f', 12, 'Exactly what I needed, great buy.', 5),
(63, '03c66e48-f575-4ffb-9252-f307d1b473e0', 6, 'Well-made and durable, would buy again.', 4),
(64, '0bb5579f-84d4-4120-beda-8012fe6a9816', 27, 'Not what I expected, disappointed.', 1),
(65, '03c66e48-f575-4ffb-9252-f307d1b473e0', 24, 'Not the best quality, expected more.', 3),
(66, '03c66e48-f575-4ffb-9252-f307d1b473e0', 7, 'Could be improved, but overall satisfied.', 4),
(67, '26d1e535-4d3c-4c2d-a4cf-c4c3e48d310f', 15, 'Good value for money, happy with the purchase.', 4),
(68, '03c66e48-f575-4ffb-9252-f307d1b473e0', 26, 'Quality is okay, expected more.', 4),
(69, '26d1e535-4d3c-4c2d-a4cf-c4c3e48d310f', 21, 'Unique and stylish, stands out.', 5),
(70, '0bb5579f-84d4-4120-beda-8012fe6a9816', 4, 'Unique and stylish, stands out.', 3),
(71, '26d1e535-4d3c-4c2d-a4cf-c4c3e48d310f', 3, 'Good quality, but a bit overpriced.', 3);

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
(41, '26d1e535-4d3c-4c2d-a4cf-c4c3e48d310f', 12, 'ab9fcc', 1, '2024-04-05 09:23:10', 0),
(42, '03c66e48-f575-4ffb-9252-f307d1b473e0', 27, 'ffffff', 9, '2024-04-05 09:23:10', 1),
(43, '0bb5579f-84d4-4120-beda-8012fe6a9816', 24, 'ffffff', 3, '2024-04-05 09:23:10', 0),
(44, '03c66e48-f575-4ffb-9252-f307d1b473e0', 6, '5431b5', 4, '2024-04-05 09:23:10', 1),
(45, '26d1e535-4d3c-4c2d-a4cf-c4c3e48d310f', 23, 'de2393', 20, '2024-04-05 09:23:10', 1),
(46, '26d1e535-4d3c-4c2d-a4cf-c4c3e48d310f', 21, '820774', 5, '2024-04-05 09:23:10', 1),
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
