-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: db
-- Üretim Zamanı: 25 Nis 2021, 20:56:51
-- Sunucu sürümü: 8.0.23
-- PHP Sürümü: 7.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `stackoverflow`
--

DELIMITER $$
--
-- Yordamlar
--
CREATE DEFINER=`root`@`%` PROCEDURE `AddTagConnection` (IN `src` VARCHAR(100), IN `trg` VARCHAR(100), IN `weight` VARCHAR(100))  BEGIN
    DECLARE sid INT DEFAULT 0;
    DECLARE tid INT DEFAULT 0;
    DECLARE tempId INT DEFAULT 0;
    DECLARE cid INT DEFAULT 0;

    SELECT id 
    INTO sid
    FROM tag
    WHERE name = src;

    IF sid = 0 THEN
        INSERT INTO tag (name) VALUES (src);
        SELECT LAST_INSERT_ID() INTO sid;
    END IF;
    
 	SELECT id 
    INTO tid
    FROM tag
    WHERE name = trg;
    
    IF tid = 0 THEN
        INSERT INTO tag (name) VALUES (trg);
        SELECT LAST_INSERT_ID() INTO tid;
    END IF;
    
    IF tid < sid THEN
    	SET tempId = tid;
        SET tid = sid;
        SET sid = tempId;
    END IF;
    
 	SELECT id 
    INTO cid
    FROM connection
    WHERE srcId = sid AND trgId = tid;
    
    IF cid = 0 THEN
		INSERT INTO connection (srcId, trgId, weight) VALUES (sid, tid, weight);
    END IF;
 
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `connection`
--

CREATE TABLE `connection` (
  `id` int NOT NULL,
  `srcId` int NOT NULL,
  `trgId` int NOT NULL,
  `weight` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `tag`
--

CREATE TABLE `tag` (
  `id` int NOT NULL,
  `name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `connection`
--
ALTER TABLE `connection`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `tag`
--
ALTER TABLE `tag`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ix_tag_name` (`name`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `connection`
--
ALTER TABLE `connection`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `tag`
--
ALTER TABLE `tag`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
