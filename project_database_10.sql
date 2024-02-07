-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Feb 07. 08:54
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
  `FelhasznaloId` int(11) NOT NULL,
  `LoginNev` varchar(128) NOT NULL,
  `HASH` varchar(128) NOT NULL,
  `SALT` varchar(128) NOT NULL,
  `Nev` varchar(128) NOT NULL,
  `Jog` int(11) NOT NULL,
  `Aktivalva` tinyint(1) NOT NULL,
  `Email` varchar(128) NOT NULL,
  `ProfilKep` varchar(128) NOT NULL,
  `OrszagKodId` int(11) NOT NULL,
  `VarosNevId` int(11) NOT NULL,
  `UtcaNev` varchar(128) NOT NULL,
  `IranyitoSzam` varchar(128) NOT NULL,
  `Hazszam` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `felhasznalok`
--

INSERT INTO `felhasznalok` (`FelhasznaloId`, `LoginNev`, `HASH`, `SALT`, `Nev`, `Jog`, `Aktivalva`, `Email`, `ProfilKep`, `OrszagKodId`, `VarosNevId`, `UtcaNev`, `IranyitoSzam`, `Hazszam`) VALUES
(1, 'Odette Bouts', '$2a$04$g7BTVqUTL4i68yPlGObHm.W3LhUSPS.1ZqyKu7FIT/OGPYiPlIU8C', '$2a$04$WvOofK9xBc/mzkn3aLFmGeccWSx3.0WEpLxCwcbOU2hov/6fKJf02', 'obouts5', 6, 0, 'obouts5@live.com', 'http://dummyimage.com/138x100.png/dddddd/000000', 8, 4, 'Gina', '47', 571),
(2, 'Bendite Melloy', '$2a$04$TOKr/RnUwwiViswPAi3DDOo5arsLSgn2cmHGVHxcE/xpGjmAqdRTu', '$2a$04$bPR6w.snXYlymc32k.S4B.xk6q9VAN4S9myjo8DuvGP4WUQRFsbfO', 'bmelloyd', 7, 1, 'bmelloyd@deliciousdays.com', 'http://dummyimage.com/158x100.png/cc0000/ffffff', 9, 7, 'Cambridge', '28', 415),
(3, 'Quintana Blayd', '$2a$04$Ik0jGNcBuMO5cxYxEL3JU.tCy89Z98YXvCiRouX0fn13fsbYr8cBy', '$2a$04$zYehJtoK59nOa1kkaQQThuc8q3Yr9JX7IdqZgH8QRjTD/19UFjHyS', 'qblayd3', 6, 1, 'qblayd3@vinaora.com', 'http://dummyimage.com/173x100.png/dddddd/000000', 19, 2, 'Hooker', '67', 5145),
(4, 'Truda Patria', '$2a$04$Vb1dnPZU.uoEhQ7/qibLOurhHeU1iLfqxrN.49MquUdspvzs8bcbe', '$2a$04$JYSC4BDKyL1kZ8aDQC9ZXOLzE0uyXhfBsSCG.kOJ11NuPZfjJCaL.', 'tpatriah', 2, 1, 'tpatriah@sciencedirect.com', 'http://dummyimage.com/121x100.png/ff4444/ffffff', 4, 9, 'Jenifer', '30', 6),
(5, 'Adelina Charnock', '$2a$04$aQHGYUSTHbR8xHW.ANTdROSPjYgqbjcOqfeeEteFTcGRWV.4LitYy', '$2a$04$AcLajGhWLORJ9SpXL..0xu1zSQiryN7YFe55Q1XGX81Mf1M1rEhC.', 'acharnock8', 3, 0, 'acharnock8@altervista.org', 'http://dummyimage.com/194x100.png/cc0000/ffffff', 13, 15, 'Marquette', '70', 532),
(6, 'Kirbee Lashmore', '$2a$04$IAFqD7CMbHRy.RdDLkpJoOvRV6cPYU8Sd8dfBreHZx7B8JjZNNvxS', '$2a$04$G.YEstakJWC/5tLo7m1BOOp3MRmZPJjj./DPHdBs76pR3p3IxOTKC', 'klashmore0', 9, 0, 'klashmore0@yandex.ru', 'http://dummyimage.com/115x100.png/dddddd/000000', 19, 7, 'Cascade', '50', 37),
(7, 'Wenda Crean', '$2a$04$sRdPea5ez3CJD/VqyPltPeF9Q1CzRLWPAM705EJDI6SqBGxwVDoPK', '$2a$04$xyzKtE/9pIC/EvtYA9sMReTTTTcoS7ClHynZ9vMntKsF6NdML8sJG', 'wcreani', 3, 1, 'wcreani@blinklist.com', 'http://dummyimage.com/104x100.png/cc0000/ffffff', 15, 20, 'Riverside', '85', 57186),
(8, 'Anders Samart', '$2a$04$6IZrDgnIxWsHWnQgPnLvbeyNyctOg9ZA5hV9ftjDYRqxchqFk7MFu', '$2a$04$lt9FMDn5ek48Y.IOcFN83OouSdFdqFj7NivmoCEGZ0cRokJKD62Ve', 'asamartf', 9, 1, 'asamartf@samsung.com', 'http://dummyimage.com/138x100.png/dddddd/000000', 9, 8, 'Erie', '77', 2),
(9, 'Muffin Baptie', '$2a$04$eDa.20476v.3LW4cLqxgv.nuOqBA50q0Cga0mk9YU/Jda6ONgyNJu', '$2a$04$OqwsXflwCNvP.68ObeMBHeIWBeV3elCYCs27QaKtQ3pboDH5jxi1a', 'mbaptie1', 8, 0, 'mbaptie1@redcross.org', 'http://dummyimage.com/112x100.png/ff4444/ffffff', 4, 1, 'Grasskamp', '51', 65),
(10, 'Harman Walthall', '$2a$04$24urYf8leq9LdImECncmJeSr6ukR38vmdAh0Oc.7B2M95trIseXKq', '$2a$04$7Q8OE/jRvqFQB9mr7KJTkOcJVC1uHTEAfa8g9RfnCwWWsh03ElKuG', 'hwalthall7', 9, 1, 'hwalthall7@marketwatch.com', 'http://dummyimage.com/225x100.png/ff4444/ffffff', 8, 1, 'Moulton', '78', 983),
(11, 'Arlin Urridge', '$2a$04$pMc1sC0f0vb5vgwLrEXMbux/B2wqf2SuRmai.f3Ze3mYwIoMJ88RW', '$2a$04$d5vGRm34F5vaACQiXUqtIOeFghGGOe2T1wYwe0orfCTjN/j0Bmpc6', 'aurridgej', 10, 1, 'aurridgej@ehow.com', 'http://dummyimage.com/242x100.png/cc0000/ffffff', 19, 8, 'Sunnyside', '74', 8194),
(12, 'Karrie Vanyushin', '$2a$04$TCkc/Iy.Xj9eTNss6.f2h.7Bec0078vTUMirlDAVfBmF6tELCg3Pe', '$2a$04$OabBz26Ts7S8DDmOIbZqPeSmYZkMeM9FPLA8TP794hoftL4fHB0NC', 'kvanyushine', 8, 1, 'kvanyushine@about.me', 'http://dummyimage.com/221x100.png/cc0000/ffffff', 16, 6, 'Sunnyside', '21', 9),
(13, 'Yoshiko Greatbank', '$2a$04$tkHpUado/TQrONCyDEiFJ.5rbAU25KVSAAfLzCvoqUjtn5bY5UMEO', '$2a$04$lk54urkAg1Xkrjr5ZfgOQueZS0TfXjEiA6hHgWi5BZdzb.II9hVmi', 'ygreatbanka', 5, 0, 'ygreatbanka@wordpress.com', 'http://dummyimage.com/122x100.png/5fa2dd/ffffff', 1, 3, 'Twin Pines', '90', 26),
(14, 'Elia Cadreman', '$2a$04$sdljcxkL8UKoN7WP.BEvVOJzWm7JQjyCP7RcLiJVTFNwDr6XQyWdC', '$2a$04$1CczmyLQ.DCKjbjtsjZCW.XldTodnzyGGyv9E1wTHvxdZX3LH3tiS', 'ecadreman9', 5, 1, 'ecadreman9@cbslocal.com', 'http://dummyimage.com/245x100.png/cc0000/ffffff', 12, 18, 'Monument', '40', 2),
(15, 'Bernette Fox', '$2a$04$82I/V9mUba4r3VC9fVH/p.tJLjxsQ956/l9B55ZDb7F0dcxMmzyqO', '$2a$04$lDWmdP6ttvuEqD1W5NTzhOPC/nRUA.V9e9BYoapLmmwT4IsPc3AoS', 'bfoxc', 5, 0, 'bfoxc@ifeng.com', 'http://dummyimage.com/170x100.png/cc0000/ffffff', 7, 10, 'Reindahl', '92', 98074),
(16, 'Eadmund Acott', '$2a$04$rb2bwLUiMGFtLkdtco5xpOT7KQTZyibtXWzDCHJZ4SpSuC54WhAN2', '$2a$04$KdklaW/qGsDXs1Yx/olh4uZVvoyeugkawckrji5byj/xYjMZvkJ3G', 'eacottb', 10, 1, 'eacottb@sohu.com', 'http://dummyimage.com/100x100.png/ff4444/ffffff', 3, 11, 'Oxford', '41', 7),
(17, 'Retha Grout', '$2a$04$r3z41ncSADhRaxxVrjltfOpBjfoynA8eCyPmB2yjE4VENKW4jhvb2', '$2a$04$UZgHa0Q7wjiZx9gaF8ELY.3w/1Yypt.3kMUDQ26TlxLgKq4DjjE.6', 'rgrout4', 10, 0, 'rgrout4@purevolume.com', 'http://dummyimage.com/130x100.png/ff4444/ffffff', 5, 7, 'Mendota', '41', 96),
(18, 'Tamara Rentoul', '$2a$04$a6jvP8D2Ah3bMZn7gpSUaufZ0I8ERudekrNaAQZh14S/Q3cBGS69C', '$2a$04$DUvjlTfZYXxK7SreFa2//OMp2FrUcaRLrpPXAiSHfUzLR69hR.m9y', 'trentoul2', 1, 0, 'trentoul2@vinaora.com', 'http://dummyimage.com/176x100.png/ff4444/ffffff', 11, 14, 'Fieldstone', '21', 22466),
(19, 'Woodman Jarad', '$2a$04$1OxVfg9H.b7dTCCu8g.am.Qtl2T1/Cy94L1.7kzHS2YD7rHs.fDoa', '$2a$04$jd/jHtZULCuGoUhN7vUH6e/mc56qDdtagz3saKAZ3M2.uhxSN8m6S', 'wjaradg', 6, 0, 'wjaradg@fda.gov', 'http://dummyimage.com/225x100.png/ff4444/ffffff', 17, 4, 'Mendota', '76', 3316),
(20, 'Darryl Bowde', '$2a$04$nHWXZ7in4EdihEnKJo8UEumvtJMNzAHksZ32PdZJ0Twg9CimcwpiS', '$2a$04$4RQThlBTSEtPuAzfEW5fBu7fIOyjj/qhzCaFy9jWOipTYU9vbDI6C', 'ddowle6', 3, 0, 'ddowle6@businessweek.com', 'http://dummyimage.com/223x100.png/cc0000/ffffff', 9, 20, 'Bluestem', '89', 1306);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `hozzaszolasok`
--

CREATE TABLE `hozzaszolasok` (
  `HozzaszolasId` int(11) NOT NULL,
  `FelhasznaloId` int(11) NOT NULL,
  `TermekId` int(11) NOT NULL,
  `Leiras` varchar(255) NOT NULL,
  `Ertekeles` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `hozzaszolasok`
--

INSERT INTO `hozzaszolasok` (`HozzaszolasId`, `FelhasznaloId`, `TermekId`, `Leiras`, `Ertekeles`) VALUES
(1, 1, 1, 'Great product, highly recommended!', 5),
(2, 2, 2, 'Looks amazing on my desk, very sturdy.', 4),
(3, 3, 3, 'Comfortable and stylish, love it!', 5),
(4, 4, 4, 'Excellent quality, very happy with the purchase.', 4),
(5, 5, 5, 'Unique design, I get lots of compliments.', 4),
(6, 6, 6, 'Perfect for the holiday season!', 5),
(7, 7, 7, 'Not what I expected, but still good.', 3),
(8, 8, 8, 'Could be better, but it serves its purpose.', 2),
(9, 9, 9, 'Quality is okay, expected more.', 3),
(10, 10, 10, 'Beautiful and functional, worth the price.', 5),
(11, 11, 11, 'Highly recommend, great addition to my collection.', 5),
(12, 12, 12, 'Not what I expected, disappointed.', 2),
(13, 13, 13, 'Good quality, but a bit overpriced.', 3),
(14, 14, 14, 'Exactly what I needed, great buy.', 5),
(15, 15, 15, 'Could be improved, but overall satisfied.', 3),
(16, 16, 16, 'Well-made and durable, would buy again.', 4),
(17, 17, 17, 'Good value for money, happy with the purchase.', 4),
(18, 18, 18, 'Unique and stylish, stands out.', 5),
(19, 19, 19, 'Not the best quality, expected more.', 2),
(20, 20, 20, 'Great design, but a bit expensive.', 4);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kategoriak`
--

CREATE TABLE `kategoriak` (
  `KategoriaId` int(11) NOT NULL,
  `KategoriaNev` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `orszagok`
--

CREATE TABLE `orszagok` (
  `OrszagId` int(11) NOT NULL,
  `OrszagKod` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `orszagok`
--

INSERT INTO `orszagok` (`OrszagId`, `OrszagKod`) VALUES
(1, 'RU'),
(2, 'US'),
(3, 'SE'),
(4, 'CN'),
(5, 'FI'),
(6, 'SI'),
(7, 'BR'),
(8, 'UZ'),
(9, 'PH'),
(10, 'CN'),
(11, 'PW'),
(12, 'GR'),
(13, 'MM'),
(14, 'BR'),
(15, 'BD'),
(16, 'PS'),
(17, 'BO'),
(18, 'RU'),
(19, 'SY'),
(20, 'CN');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szamlazas`
--

CREATE TABLE `szamlazas` (
  `SzamlazasId` int(11) NOT NULL,
  `FelhasznaloId` int(11) NOT NULL,
  `TermekId` int(11) NOT NULL,
  `SzinHex` int(11) NOT NULL,
  `VasarlasIdopontja` date NOT NULL,
  `SikeresSzalitas` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `szamlazas`
--

INSERT INTO `szamlazas` (`SzamlazasId`, `FelhasznaloId`, `TermekId`, `SzinHex`, `VasarlasIdopontja`, `SikeresSzalitas`) VALUES
(1, 1, 1, 0, '2023-11-01', 1),
(2, 2, 2, 0, '2023-11-02', 1),
(3, 3, 3, 0, '2023-11-03', 0),
(4, 4, 4, 0, '2023-11-04', 1),
(5, 5, 5, 0, '2023-11-05', 1),
(6, 6, 6, 0, '2023-11-06', 1),
(7, 7, 7, 0, '2023-11-07', 0),
(8, 8, 8, 0, '2023-11-08', 1),
(9, 9, 9, 0, '2023-11-09', 0),
(10, 10, 10, 0, '2023-11-10', 1),
(11, 11, 11, 0, '2023-11-11', 1),
(12, 12, 12, 0, '2023-11-12', 0),
(13, 13, 13, 0, '2023-11-13', 1),
(14, 14, 14, 0, '2023-11-14', 1),
(15, 15, 15, 0, '2023-11-15', 1),
(16, 16, 16, 0, '2023-11-16', 0),
(17, 17, 17, 0, '2023-11-17', 1),
(18, 18, 18, 0, '2023-11-18', 0),
(19, 19, 19, 0, '2023-11-19', 1),
(20, 20, 20, 0, '2023-11-20', 1);

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
(11, 11, 11),
(12, 12, 12),
(13, 13, 13),
(14, 14, 14),
(15, 15, 15),
(16, 16, 16),
(17, 17, 17),
(18, 18, 18),
(19, 19, 19),
(20, 20, 20);

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
  `TagId` int(11) NOT NULL,
  `Keputvonal` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `termekek`
--

INSERT INTO `termekek` (`TermekId`, `TermekNev`, `Ar`, `Leiras`, `Menyiseg`, `KategoriaId`, `TagId`, `Keputvonal`) VALUES
(1, '3D Printed House', 5503, 'A 2-bedroom 3D printed house', 8, 0, 1, 'images/3D_Printed_House.jpg'),
(2, 'Animal Wall Lamps', 6870, 'Decorative Animal Inspired Wall Lamps', 80, 0, 5, 'images/3D_Printed_Animal_Lamps.jpg'),
(3, '3D_Printed_Chair', 8050, 'A fully 3D printed chair with ergonomic and natural looking design.', 200, 0, 16, 'images/3D_Printed_Chair.jpg'),
(4, 'Mini Christmas Tree Decor', 1110, 'Adorable tabletop-sized mini Christmas tree for festive decor', 36, 0, 6, 'images/Mini_Christmass_Tree_Decoration.jpg'),
(5, 'Christmass Tree Decoration', 260, 'Beautiful Christmass Tree Decoration', 75, 0, 14, 'images/3D_Printed_Christmass_Decoration.jpg'),
(6, 'Designer Office Chair', 1415, 'Ergonomically designed office chair for a stylish and comfortable workspace', 190, 0, 18, 'path/to/image18.jpg'),
(7, 'Concrete Bench and Table', 22000, 'An affordable City Bench and table combo made with 3D printed concrete.', 230, 0, 20, 'images/City_Bench.jpg'),
(8, 'Printed Vase Containers', 2000, '3D Printed Vase Containers for all of your needs.', 120, 0, 4, 'images/3D_Printed_Containers.jpg'),
(9, 'Portable Electric Blender', 6755, 'Compact and portable electric blender for on-the-go smoothies', 95, 0, 11, 'path/to/image11.jpg'),
(10, 'Ultra HD Smart TV', 13670, 'Ultra HD smart TV with advanced features for an immersive viewing experience', 220, 0, 15, 'path/to/image15.jpg'),
(11, 'Professional DSLR Camera', 1080, 'High-performance professional DSLR camera for photography enthusiasts', 180, 0, 10, 'path/to/image10.jpg'),
(12, 'Modern Coffee Table', 7523, 'Elegant 3D printed coffee table with metal legs', 12, 0, 2, 'path/to/image2.jpg'),
(13, 'Premium Wireless Speaker', 1075, 'Premium wireless speaker for high-quality audio streaming', 170, 0, 17, 'path/to/image17.jpg'),
(14, 'Smart Home Security Camera', 8572, 'Advanced smart home security camera for monitoring your space', 130, 0, 7, 'path/to/image7.jpg'),
(15, 'Contemporary Dining Chair', 12750, 'Comfortable 3D printed dining chair with sleek design', 20, 0, 3, 'path/to/image3.jpg'),
(16, 'Outdoor Adventure Backpack', 1225, 'Durable outdoor adventure backpack with multiple compartments', 210, 0, 19, 'path/to/image19.jpg'),
(17, 'Home Theater Sound System', 150, 'Immersive home theater sound system for a cinematic experience', 250, 0, 12, 'path/to/image12.jpg'),
(18, 'Compact Air Purifier', 7057, 'Compact air purifier for maintaining clean and fresh indoor air', 110, 0, 9, 'path/to/image9.jpg'),
(19, 'Wireless Noise-Canceling Headphones', 96785, 'Premium wireless headphones with noise-canceling technology', 140, 0, 8, 'path/to/image8.jpg'),
(20, 'Smart Fitness Tracker', 880, 'Intelligent fitness tracker for tracking your health and workouts', 135, 0, 13, 'path/to/image13.jpg');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `varosok`
--

CREATE TABLE `varosok` (
  `VarosId` int(11) NOT NULL,
  `VarosNev` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `varosok`
--

INSERT INTO `varosok` (`VarosId`, `VarosNev`) VALUES
(1, 'Nangang'),
(2, 'Nanyanchuan'),
(3, 'Ngora'),
(4, 'Buenos Aires'),
(5, 'Sanyi'),
(6, 'Almirante'),
(7, 'Buçimas'),
(8, 'Kudus'),
(9, 'Semambung'),
(10, 'Las Higueras'),
(11, 'Eauripik'),
(12, 'Juzhen'),
(13, 'Kinamayan'),
(14, 'Belén de Escobar'),
(15, 'Mozdok'),
(16, 'Shixi'),
(17, 'Lingdong'),
(18, 'Orhon'),
(19, 'Ústí nad Labem'),
(20, 'Topory');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `felhasznalok`
--
ALTER TABLE `felhasznalok`
  ADD PRIMARY KEY (`FelhasznaloId`),
  ADD KEY `OrszágKodId` (`OrszagKodId`,`VarosNevId`),
  ADD KEY `VarosNevId` (`VarosNevId`);

--
-- A tábla indexei `hozzaszolasok`
--
ALTER TABLE `hozzaszolasok`
  ADD PRIMARY KEY (`HozzaszolasId`),
  ADD KEY `FelhasznaloId` (`FelhasznaloId`,`TermekId`),
  ADD KEY `hozzaszolas_ibfk_1` (`TermekId`);

--
-- A tábla indexei `kategoriak`
--
ALTER TABLE `kategoriak`
  ADD PRIMARY KEY (`KategoriaId`);

--
-- A tábla indexei `orszagok`
--
ALTER TABLE `orszagok`
  ADD PRIMARY KEY (`OrszagId`);

--
-- A tábla indexei `szamlazas`
--
ALTER TABLE `szamlazas`
  ADD PRIMARY KEY (`SzamlazasId`),
  ADD KEY `FelhasznaloId` (`FelhasznaloId`,`TermekId`),
  ADD KEY `szamlazas_ibfk_1` (`TermekId`);

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
  ADD KEY `TagId` (`TagId`),
  ADD KEY `KategoriaIndex` (`KategoriaId`);

--
-- A tábla indexei `varosok`
--
ALTER TABLE `varosok`
  ADD PRIMARY KEY (`VarosId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `felhasznalok`
--
ALTER TABLE `felhasznalok`
  MODIFY `FelhasznaloId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `hozzaszolasok`
--
ALTER TABLE `hozzaszolasok`
  MODIFY `HozzaszolasId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `kategoriak`
--
ALTER TABLE `kategoriak`
  MODIFY `KategoriaId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `orszagok`
--
ALTER TABLE `orszagok`
  MODIFY `OrszagId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

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
  MODIFY `TermekId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `varosok`
--
ALTER TABLE `varosok`
  MODIFY `VarosId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `felhasznalok`
--
ALTER TABLE `felhasznalok`
  ADD CONSTRAINT `felhasznalok_ibfk_1` FOREIGN KEY (`OrszagKodId`) REFERENCES `orszagok` (`OrszagId`),
  ADD CONSTRAINT `felhasznalok_ibfk_2` FOREIGN KEY (`VarosNevId`) REFERENCES `varosok` (`VarosId`);

--
-- Megkötések a táblához `hozzaszolasok`
--
ALTER TABLE `hozzaszolasok`
  ADD CONSTRAINT `hozzaszolasok_ibfk_1` FOREIGN KEY (`TermekId`) REFERENCES `termekek` (`TermekId`),
  ADD CONSTRAINT `hozzaszolasok_ibfk_2` FOREIGN KEY (`FelhasznaloId`) REFERENCES `felhasznalok` (`FelhasznaloId`);

--
-- Megkötések a táblához `kategoriak`
--
ALTER TABLE `kategoriak`
  ADD CONSTRAINT `kategoriak_ibfk_1` FOREIGN KEY (`KategoriaId`) REFERENCES `termekek` (`KategoriaId`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `szamlazas`
--
ALTER TABLE `szamlazas`
  ADD CONSTRAINT `szamlazas_ibfk_1` FOREIGN KEY (`TermekId`) REFERENCES `termekek` (`TermekId`),
  ADD CONSTRAINT `szamlazas_ibfk_2` FOREIGN KEY (`FelhasznaloId`) REFERENCES `felhasznalok` (`FelhasznaloId`);

--
-- Megkötések a táblához `tagkapcsolo`
--
ALTER TABLE `tagkapcsolo`
  ADD CONSTRAINT `tagkapcsolo_ibfk_1` FOREIGN KEY (`TagKapcsoloId`) REFERENCES `tagek` (`TagId`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `termekek`
--
ALTER TABLE `termekek`
  ADD CONSTRAINT `termekek_ibfk_2` FOREIGN KEY (`TagId`) REFERENCES `tagkapcsolo` (`TermekTagKapcsoloId`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
