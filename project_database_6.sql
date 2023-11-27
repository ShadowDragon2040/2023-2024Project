-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2023. Nov 27. 10:57
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
  `OrszagKodId` int(11) NOT NULL,
  `VarosNevId` int(11) NOT NULL,
  `UtcaNev` varchar(128) NOT NULL,
  `IranyitoSzam` varchar(128) NOT NULL,
  `Hazszam` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `felhasznalok`
--

INSERT INTO `felhasznalok` (`Id`, `LoginNev`, `HASH`, `SALT`, `Nev`, `Jog`, `Aktivalva`, `Email`, `ProfilKep`, `OrszagKodId`, `VarosNevId`, `UtcaNev`, `IranyitoSzam`, `Hazszam`) VALUES
('03eb0937-62d3-4f07-834d-8395b27071c0', 'Odette Bouts', '$2a$04$g7BTVqUTL4i68yPlGObHm.W3LhUSPS.1ZqyKu7FIT/OGPYiPlIU8C', '$2a$04$WvOofK9xBc/mzkn3aLFmGeccWSx3.0WEpLxCwcbOU2hov/6fKJf02', 'obouts5', 6, 0, 'obouts5@live.com', 'http://dummyimage.com/138x100.png/dddddd/000000', 8, 4, 'Gina', '47', 571),
('141c7b16-8d5e-490b-9484-5e5018da5ace', 'Bendite Melloy', '$2a$04$TOKr/RnUwwiViswPAi3DDOo5arsLSgn2cmHGVHxcE/xpGjmAqdRTu', '$2a$04$bPR6w.snXYlymc32k.S4B.xk6q9VAN4S9myjo8DuvGP4WUQRFsbfO', 'bmelloyd', 7, 1, 'bmelloyd@deliciousdays.com', 'http://dummyimage.com/158x100.png/cc0000/ffffff', 9, 7, 'Cambridge', '28', 415),
('41ea78c4-2651-4ef0-88b4-95cc3da1c7ad', 'Quintana Blayd', '$2a$04$Ik0jGNcBuMO5cxYxEL3JU.tCy89Z98YXvCiRouX0fn13fsbYr8cBy', '$2a$04$zYehJtoK59nOa1kkaQQThuc8q3Yr9JX7IdqZgH8QRjTD/19UFjHyS', 'qblayd3', 6, 1, 'qblayd3@vinaora.com', 'http://dummyimage.com/173x100.png/dddddd/000000', 19, 2, 'Hooker', '67', 5145),
('520782a5-38d9-4f1e-964b-ea3fcd6b8c0b', 'Truda Patria', '$2a$04$Vb1dnPZU.uoEhQ7/qibLOurhHeU1iLfqxrN.49MquUdspvzs8bcbe', '$2a$04$JYSC4BDKyL1kZ8aDQC9ZXOLzE0uyXhfBsSCG.kOJ11NuPZfjJCaL.', 'tpatriah', 2, 1, 'tpatriah@sciencedirect.com', 'http://dummyimage.com/121x100.png/ff4444/ffffff', 4, 9, 'Jenifer', '30', 6),
('64ea3b6c-b647-4441-bcaf-f258886ef11b', 'Adelina Charnock', '$2a$04$aQHGYUSTHbR8xHW.ANTdROSPjYgqbjcOqfeeEteFTcGRWV.4LitYy', '$2a$04$AcLajGhWLORJ9SpXL..0xu1zSQiryN7YFe55Q1XGX81Mf1M1rEhC.', 'acharnock8', 3, 0, 'acharnock8@altervista.org', 'http://dummyimage.com/194x100.png/cc0000/ffffff', 13, 15, 'Marquette', '70', 532),
('68651a33-f9a5-42c7-ad42-5c52e33011b2', 'Kirbee Lashmore', '$2a$04$IAFqD7CMbHRy.RdDLkpJoOvRV6cPYU8Sd8dfBreHZx7B8JjZNNvxS', '$2a$04$G.YEstakJWC/5tLo7m1BOOp3MRmZPJjj./DPHdBs76pR3p3IxOTKC', 'klashmore0', 9, 0, 'klashmore0@yandex.ru', 'http://dummyimage.com/115x100.png/dddddd/000000', 19, 7, 'Cascade', '50', 37),
('7cc48357-5c33-48de-895a-869e099ae3ff', 'Wenda Crean', '$2a$04$sRdPea5ez3CJD/VqyPltPeF9Q1CzRLWPAM705EJDI6SqBGxwVDoPK', '$2a$04$xyzKtE/9pIC/EvtYA9sMReTTTTcoS7ClHynZ9vMntKsF6NdML8sJG', 'wcreani', 3, 1, 'wcreani@blinklist.com', 'http://dummyimage.com/104x100.png/cc0000/ffffff', 15, 20, 'Riverside', '85', 57186),
('7fed0f13-87eb-4dae-991b-3136dfa5511e', 'Anders Samart', '$2a$04$6IZrDgnIxWsHWnQgPnLvbeyNyctOg9ZA5hV9ftjDYRqxchqFk7MFu', '$2a$04$lt9FMDn5ek48Y.IOcFN83OouSdFdqFj7NivmoCEGZ0cRokJKD62Ve', 'asamartf', 9, 1, 'asamartf@samsung.com', 'http://dummyimage.com/138x100.png/dddddd/000000', 9, 8, 'Erie', '77', 2),
('87e29a15-4713-40f1-a589-8285eee2e3c7', 'Muffin Baptie', '$2a$04$eDa.20476v.3LW4cLqxgv.nuOqBA50q0Cga0mk9YU/Jda6ONgyNJu', '$2a$04$OqwsXflwCNvP.68ObeMBHeIWBeV3elCYCs27QaKtQ3pboDH5jxi1a', 'mbaptie1', 8, 0, 'mbaptie1@redcross.org', 'http://dummyimage.com/112x100.png/ff4444/ffffff', 4, 1, 'Grasskamp', '51', 65),
('8f52b918-6b74-4c2e-ae48-e9cc5f5c6397', 'Harman Walthall', '$2a$04$24urYf8leq9LdImECncmJeSr6ukR38vmdAh0Oc.7B2M95trIseXKq', '$2a$04$7Q8OE/jRvqFQB9mr7KJTkOcJVC1uHTEAfa8g9RfnCwWWsh03ElKuG', 'hwalthall7', 9, 1, 'hwalthall7@marketwatch.com', 'http://dummyimage.com/225x100.png/ff4444/ffffff', 8, 1, 'Moulton', '78', 983),
('917f7b06-86c0-4aa6-961d-03f5a7b26dac', 'Arlin Urridge', '$2a$04$pMc1sC0f0vb5vgwLrEXMbux/B2wqf2SuRmai.f3Ze3mYwIoMJ88RW', '$2a$04$d5vGRm34F5vaACQiXUqtIOeFghGGOe2T1wYwe0orfCTjN/j0Bmpc6', 'aurridgej', 10, 1, 'aurridgej@ehow.com', 'http://dummyimage.com/242x100.png/cc0000/ffffff', 19, 8, 'Sunnyside', '74', 8194),
('9d4cc6ae-0161-4327-a966-309afd0d3ef9', 'Karrie Vanyushin', '$2a$04$TCkc/Iy.Xj9eTNss6.f2h.7Bec0078vTUMirlDAVfBmF6tELCg3Pe', '$2a$04$OabBz26Ts7S8DDmOIbZqPeSmYZkMeM9FPLA8TP794hoftL4fHB0NC', 'kvanyushine', 8, 1, 'kvanyushine@about.me', 'http://dummyimage.com/221x100.png/cc0000/ffffff', 16, 6, 'Sunnyside', '21', 9),
('c7e271e4-3aa9-4f6b-b78a-86258d4b1673', 'Yoshiko Greatbank', '$2a$04$tkHpUado/TQrONCyDEiFJ.5rbAU25KVSAAfLzCvoqUjtn5bY5UMEO', '$2a$04$lk54urkAg1Xkrjr5ZfgOQueZS0TfXjEiA6hHgWi5BZdzb.II9hVmi', 'ygreatbanka', 5, 0, 'ygreatbanka@wordpress.com', 'http://dummyimage.com/122x100.png/5fa2dd/ffffff', 1, 3, 'Twin Pines', '90', 26),
('cd7167cc-5430-4f15-a3c9-d3194e4838a8', 'Elia Cadreman', '$2a$04$sdljcxkL8UKoN7WP.BEvVOJzWm7JQjyCP7RcLiJVTFNwDr6XQyWdC', '$2a$04$1CczmyLQ.DCKjbjtsjZCW.XldTodnzyGGyv9E1wTHvxdZX3LH3tiS', 'ecadreman9', 5, 1, 'ecadreman9@cbslocal.com', 'http://dummyimage.com/245x100.png/cc0000/ffffff', 12, 18, 'Monument', '40', 2),
('d8cba301-a38b-4c08-a8f6-fb7de6094af1', 'Bernette Fox', '$2a$04$82I/V9mUba4r3VC9fVH/p.tJLjxsQ956/l9B55ZDb7F0dcxMmzyqO', '$2a$04$lDWmdP6ttvuEqD1W5NTzhOPC/nRUA.V9e9BYoapLmmwT4IsPc3AoS', 'bfoxc', 5, 0, 'bfoxc@ifeng.com', 'http://dummyimage.com/170x100.png/cc0000/ffffff', 7, 10, 'Reindahl', '92', 98074),
('e3ff374c-ee07-46ba-9099-bfa71c0bf522', 'Eadmund Acott', '$2a$04$rb2bwLUiMGFtLkdtco5xpOT7KQTZyibtXWzDCHJZ4SpSuC54WhAN2', '$2a$04$KdklaW/qGsDXs1Yx/olh4uZVvoyeugkawckrji5byj/xYjMZvkJ3G', 'eacottb', 10, 1, 'eacottb@sohu.com', 'http://dummyimage.com/100x100.png/ff4444/ffffff', 3, 11, 'Oxford', '41', 7),
('e41caae3-98cf-477e-9ab4-493e90f2fc83', 'Retha Grout', '$2a$04$r3z41ncSADhRaxxVrjltfOpBjfoynA8eCyPmB2yjE4VENKW4jhvb2', '$2a$04$UZgHa0Q7wjiZx9gaF8ELY.3w/1Yypt.3kMUDQ26TlxLgKq4DjjE.6', 'rgrout4', 10, 0, 'rgrout4@purevolume.com', 'http://dummyimage.com/130x100.png/ff4444/ffffff', 5, 7, 'Mendota', '41', 96),
('e77f53dd-705c-4674-839e-d51da4ccbdcc', 'Tamara Rentoul', '$2a$04$a6jvP8D2Ah3bMZn7gpSUaufZ0I8ERudekrNaAQZh14S/Q3cBGS69C', '$2a$04$DUvjlTfZYXxK7SreFa2//OMp2FrUcaRLrpPXAiSHfUzLR69hR.m9y', 'trentoul2', 1, 0, 'trentoul2@vinaora.com', 'http://dummyimage.com/176x100.png/ff4444/ffffff', 11, 14, 'Fieldstone', '21', 22466),
('e87e41c4-179a-4917-b812-e607fbcdf619', 'Woodman Jarad', '$2a$04$1OxVfg9H.b7dTCCu8g.am.Qtl2T1/Cy94L1.7kzHS2YD7rHs.fDoa', '$2a$04$jd/jHtZULCuGoUhN7vUH6e/mc56qDdtagz3saKAZ3M2.uhxSN8m6S', 'wjaradg', 6, 0, 'wjaradg@fda.gov', 'http://dummyimage.com/225x100.png/ff4444/ffffff', 17, 4, 'Mendota', '76', 3316),
('ece48ba0-a089-4e5f-ba6a-1f559b2401cc', 'Darryl Dowle', '$2a$04$nHWXZ7in4EdihEnKJo8UEumvtJMNzAHksZ32PdZJ0Twg9CimcwpiS', '$2a$04$4RQThlBTSEtPuAzfEW5fBu7fIOyjj/qhzCaFy9jWOipTYU9vbDI6C', 'ddowle6', 3, 0, 'ddowle6@businessweek.com', 'http://dummyimage.com/223x100.png/cc0000/ffffff', 9, 20, 'Bluestem', '89', 1306);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `hozzaszolasok`
--

CREATE TABLE `hozzaszolasok` (
  `Id` int(11) NOT NULL,
  `FelhasznaloId` char(36) NOT NULL,
  `TermekId` char(36) NOT NULL,
  `Leiras` varchar(255) NOT NULL,
  `Ertekeles` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `hozzaszolasok`
--

INSERT INTO `hozzaszolasok` (`Id`, `FelhasznaloId`, `TermekId`, `Leiras`, `Ertekeles`) VALUES
(1, '03eb0937-62d3-4f07-834d-8395b27071c0', '42e75260-a29f-44cb-b0e0-02b768a6c883', 'Great product, highly recommended!', 5),
(2, '141c7b16-8d5e-490b-9484-5e5018da5ace', 'b6660432-5bb8-45bb-aedd-6d2bac5efdac', 'Looks amazing on my desk, very sturdy.', 4),
(3, '41ea78c4-2651-4ef0-88b4-95cc3da1c7ad', 'c01399c9-8f07-49d4-ba86-94e75ffca5e3', 'Comfortable and stylish, love it!', 5),
(4, '520782a5-38d9-4f1e-964b-ea3fcd6b8c0b', '64dba051-42a3-4f91-a02f-29c78ee93403', 'Excellent quality, very happy with the purchase.', 4),
(5, '64ea3b6c-b647-4441-bcaf-f258886ef11b', '459ec989-8181-4e2d-b769-dd9137f0053e', 'Unique design, I get lots of compliments.', 4),
(6, '68651a33-f9a5-42c7-ad42-5c52e33011b2', '59770c96-f720-4997-801f-9a62ad61481e', 'Perfect for the holiday season!', 5),
(7, '7cc48357-5c33-48de-895a-869e099ae3ff', 'bb176948-3443-4bad-8f3c-bec6c33001e0', 'Not what I expected, but still good.', 3),
(8, '7fed0f13-87eb-4dae-991b-3136dfa5511e', 'ee15d984-0ee8-4d2c-ae0d-a690fb91f08c', 'Could be better, but it serves its purpose.', 2),
(9, '87e29a15-4713-40f1-a589-8285eee2e3c7', 'e06352f2-b3a7-458e-90b0-b6da7ec90aab', 'Quality is okay, expected more.', 3),
(10, '8f52b918-6b74-4c2e-ae48-e9cc5f5c6397', '9bd9514c-60cb-4aa8-8dad-d7c049fcf608', 'Beautiful and functional, worth the price.', 5),
(11, '917f7b06-86c0-4aa6-961d-03f5a7b26dac', '7814c6d4-f7ff-42ec-89bc-ad67daa5f6a8', 'Highly recommend, great addition to my collection.', 5),
(12, '9d4cc6ae-0161-4327-a966-309afd0d3ef9', 'd28492dc-5456-4683-a9f3-4b3a9d0f5488', 'Not what I expected, disappointed.', 2),
(13, 'c7e271e4-3aa9-4f6b-b78a-86258d4b1673', 'ee7996ea-4006-486b-97b8-78bb777612d4', 'Good quality, but a bit overpriced.', 3),
(14, 'cd7167cc-5430-4f15-a3c9-d3194e4838a8', '5afa9423-0638-46f2-8d82-9d13d30b7e2d', 'Exactly what I needed, great buy.', 5),
(15, 'd8cba301-a38b-4c08-a8f6-fb7de6094af1', '81ca1bb1-1e4d-47a6-ac44-f47f937f16a5', 'Could be improved, but overall satisfied.', 3),
(16, 'e3ff374c-ee07-46ba-9099-bfa71c0bf522', '4f0c0e07-56d4-402a-88fe-851364659245', 'Well-made and durable, would buy again.', 4),
(17, 'e41caae3-98cf-477e-9ab4-493e90f2fc83', 'ba1721d7-b6f4-4ab5-9a79-42dbeaf2be26', 'Good value for money, happy with the purchase.', 4),
(18, 'ece48ba0-a089-4e5f-ba6a-1f559b2401cc', '5e8bfbcd-d70c-4040-8aa2-446d07a9bd91', 'Unique and stylish, stands out.', 5),
(19, 'e87e41c4-179a-4917-b812-e607fbcdf619', 'cda82adc-e167-4141-abc0-54c552644254', 'Not the best quality, expected more.', 2),
(20, 'e87e41c4-179a-4917-b812-e607fbcdf619', '611a36e3-d1ef-4c75-800d-254fd201d490', 'Great design, but a bit expensive.', 4);

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
  `Id` int(11) NOT NULL,
  `FelhasznaloId` char(36) NOT NULL,
  `TermekId` char(36) NOT NULL,
  `VasarlasIdopontja` date NOT NULL,
  `SikeresSzalitas` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `szamlazas`
--

INSERT INTO `szamlazas` (`Id`, `FelhasznaloId`, `TermekId`, `VasarlasIdopontja`, `SikeresSzalitas`) VALUES
(1, '03eb0937-62d3-4f07-834d-8395b27071c0', '42e75260-a29f-44cb-b0e0-02b768a6c883', '2023-11-01', 1),
(2, '141c7b16-8d5e-490b-9484-5e5018da5ace', 'b6660432-5bb8-45bb-aedd-6d2bac5efdac', '2023-11-02', 1),
(3, '41ea78c4-2651-4ef0-88b4-95cc3da1c7ad', 'c01399c9-8f07-49d4-ba86-94e75ffca5e3', '2023-11-03', 0),
(4, '520782a5-38d9-4f1e-964b-ea3fcd6b8c0b', '64dba051-42a3-4f91-a02f-29c78ee93403', '2023-11-04', 1),
(5, '64ea3b6c-b647-4441-bcaf-f258886ef11b', '459ec989-8181-4e2d-b769-dd9137f0053e', '2023-11-05', 1),
(6, '68651a33-f9a5-42c7-ad42-5c52e33011b2', '59770c96-f720-4997-801f-9a62ad61481e', '2023-11-06', 1),
(7, '7cc48357-5c33-48de-895a-869e099ae3ff', 'bb176948-3443-4bad-8f3c-bec6c33001e0', '2023-11-07', 0),
(8, '7fed0f13-87eb-4dae-991b-3136dfa5511e', 'ee15d984-0ee8-4d2c-ae0d-a690fb91f08c', '2023-11-08', 1),
(9, '87e29a15-4713-40f1-a589-8285eee2e3c7', 'e06352f2-b3a7-458e-90b0-b6da7ec90aab', '2023-11-09', 0),
(10, '8f52b918-6b74-4c2e-ae48-e9cc5f5c6397', '9bd9514c-60cb-4aa8-8dad-d7c049fcf608', '2023-11-10', 1),
(11, '917f7b06-86c0-4aa6-961d-03f5a7b26dac', '7814c6d4-f7ff-42ec-89bc-ad67daa5f6a8', '2023-11-11', 1),
(12, '9d4cc6ae-0161-4327-a966-309afd0d3ef9', 'd28492dc-5456-4683-a9f3-4b3a9d0f5488', '2023-11-12', 0),
(13, 'c7e271e4-3aa9-4f6b-b78a-86258d4b1673', 'ee7996ea-4006-486b-97b8-78bb777612d4', '2023-11-13', 1),
(14, 'cd7167cc-5430-4f15-a3c9-d3194e4838a8', '5afa9423-0638-46f2-8d82-9d13d30b7e2d', '2023-11-14', 1),
(15, 'd8cba301-a38b-4c08-a8f6-fb7de6094af1', '81ca1bb1-1e4d-47a6-ac44-f47f937f16a5', '2023-11-15', 1),
(16, 'e3ff374c-ee07-46ba-9099-bfa71c0bf522', '4f0c0e07-56d4-402a-88fe-851364659245', '2023-11-16', 0),
(17, 'e41caae3-98cf-477e-9ab4-493e90f2fc83', 'ba1721d7-b6f4-4ab5-9a79-42dbeaf2be26', '2023-11-17', 1),
(18, 'ece48ba0-a089-4e5f-ba6a-1f559b2401cc', '5e8bfbcd-d70c-4040-8aa2-446d07a9bd91', '2023-11-18', 0),
(19, 'e87e41c4-179a-4917-b812-e607fbcdf619', 'cda82adc-e167-4141-abc0-54c552644254', '2023-11-19', 1),
(20, 'e87e41c4-179a-4917-b812-e607fbcdf619', '611a36e3-d1ef-4c75-800d-254fd201d490', '2023-11-20', 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szinek`
--

CREATE TABLE `szinek` (
  `SzinId` int(11) NOT NULL,
  `SzinHex` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `szinek`
--

INSERT INTO `szinek` (`SzinId`, `SzinHex`) VALUES
(1, '#5f91f2'),
(2, '#c888a3'),
(3, '#71e7b3'),
(4, '#42b58f'),
(5, '#618531'),
(6, '#cc6127'),
(7, '#340be6'),
(8, '#3489cb'),
(9, '#595481'),
(10, '#efe21a'),
(11, '#26f4dd'),
(12, '#3648aa'),
(13, '#29f7cb'),
(14, '#8e06d6'),
(15, '#603dc8'),
(16, '#d8728a'),
(17, '#e9ffc8'),
(18, '#982d1f'),
(19, '#ab5610'),
(20, '#7ec260');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szinkapcsolo`
--

CREATE TABLE `szinkapcsolo` (
  `Id` int(11) NOT NULL,
  `SzinKapcsoloId` int(11) NOT NULL,
  `TermekSzinKapcsoloId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `szinkapcsolo`
--

INSERT INTO `szinkapcsolo` (`Id`, `SzinKapcsoloId`, `TermekSzinKapcsoloId`) VALUES
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
  `Id` char(36) NOT NULL,
  `TermekNev` varchar(128) NOT NULL,
  `Ar` int(11) NOT NULL,
  `Leiras` varchar(255) NOT NULL,
  `Menyiseg` int(11) NOT NULL,
  `SzinId` int(11) NOT NULL,
  `TagId` int(11) NOT NULL,
  `Keputvonal` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `termekek`
--

INSERT INTO `termekek` (`Id`, `TermekNev`, `Ar`, `Leiras`, `Menyiseg`, `SzinId`, `TagId`, `Keputvonal`) VALUES
('42e75260-a29f-44cb-b0e0-02b768a6c883', '3D Printed House', 5503, 'A 2-bedroom 3D printed house', 8, 1, 1, 'path/to/image1.jpg'),
('459ec989-8181-4e2d-b769-dd9137f0053e', 'Practice Butterfly Knife', 6870, 'High-quality practice butterfly knife for enthusiasts', 80, 5, 5, 'path/to/image5.jpg'),
('4f0c0e07-56d4-402a-88fe-851364659245', 'Foldable Electric Scooter', 1260, 'Foldable electric scooter for convenient urban commuting', 200, 16, 16, 'path/to/image16.jpg'),
('59770c96-f720-4997-801f-9a62ad61481e', 'Mini Christmas Tree Decor', 1110, 'Adorable tabletop-sized mini Christmas tree for festive decor', 36, 6, 6, 'path/to/image6.jpg'),
('5afa9423-0638-46f2-8d82-9d13d30b7e2d', 'Gourmet Espresso Machine', 5576, 'Premium gourmet espresso machine for coffee connoisseurs', 75, 14, 14, 'path/to/image14.jpg'),
('5e8bfbcd-d70c-4040-8aa2-446d07a9bd91', 'Designer Office Chair', 1415, 'Ergonomically designed office chair for a stylish and comfortable workspace', 190, 18, 18, 'path/to/image18.jpg'),
('611a36e3-d1ef-4c75-800d-254fd201d490', 'Smart Home Thermostat', 1460, 'Smart home thermostat for energy-efficient temperature control', 230, 20, 20, 'path/to/image20.jpg'),
('64dba051-42a3-4f91-a02f-29c78ee93403', 'Insulated Stainless Steel Flask', 90684, 'Premium quality insulated stainless steel flask for outdoor adventures', 120, 4, 4, 'path/to/image4.jpg'),
('7814c6d4-f7ff-42ec-89bc-ad67daa5f6a8', 'Portable Electric Blender', 6755, 'Compact and portable electric blender for on-the-go smoothies', 95, 11, 11, 'path/to/image11.jpg'),
('81ca1bb1-1e4d-47a6-ac44-f47f937f16a5', 'Ultra HD Smart TV', 13670, 'Ultra HD smart TV with advanced features for an immersive viewing experience', 220, 15, 15, 'path/to/image15.jpg'),
('9bd9514c-60cb-4aa8-8dad-d7c049fcf608', 'Professional DSLR Camera', 1080, 'High-performance professional DSLR camera for photography enthusiasts', 180, 10, 10, 'path/to/image10.jpg'),
('b6660432-5bb8-45bb-aedd-6d2bac5efdac', 'Modern Coffee Table', 7523, 'Elegant 3D printed coffee table with metal legs', 12, 2, 2, 'path/to/image2.jpg'),
('ba1721d7-b6f4-4ab5-9a79-42dbeaf2be26', 'Premium Wireless Speaker', 1075, 'Premium wireless speaker for high-quality audio streaming', 170, 17, 17, 'path/to/image17.jpg'),
('bb176948-3443-4bad-8f3c-bec6c33001e0', 'Smart Home Security Camera', 8572, 'Advanced smart home security camera for monitoring your space', 130, 7, 7, 'path/to/image7.jpg'),
('c01399c9-8f07-49d4-ba86-94e75ffca5e3', 'Contemporary Dining Chair', 12750, 'Comfortable 3D printed dining chair with sleek design', 20, 3, 3, 'path/to/image3.jpg'),
('cda82adc-e167-4141-abc0-54c552644254', 'Outdoor Adventure Backpack', 1225, 'Durable outdoor adventure backpack with multiple compartments', 210, 19, 19, 'path/to/image19.jpg'),
('d28492dc-5456-4683-a9f3-4b3a9d0f5488', 'Home Theater Sound System', 150, 'Immersive home theater sound system for a cinematic experience', 250, 12, 12, 'path/to/image12.jpg'),
('e06352f2-b3a7-458e-90b0-b6da7ec90aab', 'Compact Air Purifier', 7057, 'Compact air purifier for maintaining clean and fresh indoor air', 110, 9, 9, 'path/to/image9.jpg'),
('ee15d984-0ee8-4d2c-ae0d-a690fb91f08c', 'Wireless Noise-Canceling Headphones', 96785, 'Premium wireless headphones with noise-canceling technology', 140, 8, 8, 'path/to/image8.jpg'),
('ee7996ea-4006-486b-97b8-78bb777612d4', 'Smart Fitness Tracker', 880, 'Intelligent fitness tracker for tracking your health and workouts', 135, 13, 13, 'path/to/image13.jpg');

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
  ADD PRIMARY KEY (`Id`),
  ADD KEY `OrszágKodId` (`OrszagKodId`,`VarosNevId`),
  ADD KEY `VarosNevId` (`VarosNevId`);

--
-- A tábla indexei `hozzaszolasok`
--
ALTER TABLE `hozzaszolasok`
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
-- A tábla indexei `szinkapcsolo`
--
ALTER TABLE `szinkapcsolo`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `SzinKapcsoloId` (`SzinKapcsoloId`),
  ADD KEY `TermekSzinKapcsoloId` (`TermekSzinKapcsoloId`);

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
-- AUTO_INCREMENT a táblához `hozzaszolasok`
--
ALTER TABLE `hozzaszolasok`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `orszagok`
--
ALTER TABLE `orszagok`
  MODIFY `OrszagId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `szamlazas`
--
ALTER TABLE `szamlazas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `szinek`
--
ALTER TABLE `szinek`
  MODIFY `SzinId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `szinkapcsolo`
--
ALTER TABLE `szinkapcsolo`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

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
  ADD CONSTRAINT `hozzaszolasok_ibfk_1` FOREIGN KEY (`TermekId`) REFERENCES `termekek` (`Id`),
  ADD CONSTRAINT `hozzaszolasok_ibfk_2` FOREIGN KEY (`FelhasznaloId`) REFERENCES `felhasznalok` (`Id`);

--
-- Megkötések a táblához `szamlazas`
--
ALTER TABLE `szamlazas`
  ADD CONSTRAINT `szamlazas_ibfk_1` FOREIGN KEY (`TermekId`) REFERENCES `termekek` (`Id`),
  ADD CONSTRAINT `szamlazas_ibfk_2` FOREIGN KEY (`FelhasznaloId`) REFERENCES `felhasznalok` (`Id`);

--
-- Megkötések a táblához `szinkapcsolo`
--
ALTER TABLE `szinkapcsolo`
  ADD CONSTRAINT `szinkapcsolo_ibfk_1` FOREIGN KEY (`SzinKapcsoloId`) REFERENCES `szinek` (`SzinId`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `tagkapcsolo`
--
ALTER TABLE `tagkapcsolo`
  ADD CONSTRAINT `tagkapcsolo_ibfk_1` FOREIGN KEY (`TagKapcsoloId`) REFERENCES `tagek` (`TagId`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `termekek`
--
ALTER TABLE `termekek`
  ADD CONSTRAINT `termekek_ibfk_1` FOREIGN KEY (`TagId`) REFERENCES `tagkapcsolo` (`TermekTagKapcsoloId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `termekek_ibfk_2` FOREIGN KEY (`SzinId`) REFERENCES `szinkapcsolo` (`TermekSzinKapcsoloId`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
