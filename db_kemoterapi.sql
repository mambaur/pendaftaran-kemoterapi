-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 14, 2020 at 06:52 AM
-- Server version: 10.1.31-MariaDB
-- PHP Version: 7.2.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_kemoterapi`
--

-- --------------------------------------------------------

--
-- Table structure for table `data_pasien_kemoterapi`
--

CREATE TABLE `data_pasien_kemoterapi` (
  `NO_RM_PASIEN` bigint(20) NOT NULL,
  `ID_PETUGAS` bigint(20) DEFAULT NULL,
  `NAMA_PASIEN` text,
  `TANGGAL_LAHIR_PASIEN` varchar(30) DEFAULT NULL,
  `JENIS_KELAMIN_PASIEN` enum('Laki-laki','Perempuan','','') DEFAULT NULL,
  `AGAMA_PASIEN` enum('Islam','Kristen','Hindu','Budha') DEFAULT NULL,
  `ALAMAT_PASIEN` text,
  `PEKERJAAN_PASIEN` text,
  `NOMOR_TELEPON_PASIEN` bigint(20) DEFAULT NULL,
  `JENIS_PENYAKIT_` text,
  `TANGGAL_KEMOTERAPI` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `data_pasien_kemoterapi`
--

INSERT INTO `data_pasien_kemoterapi` (`NO_RM_PASIEN`, `ID_PETUGAS`, `NAMA_PASIEN`, `TANGGAL_LAHIR_PASIEN`, `JENIS_KELAMIN_PASIEN`, `AGAMA_PASIEN`, `ALAMAT_PASIEN`, `PEKERJAAN_PASIEN`, `NOMOR_TELEPON_PASIEN`, `JENIS_PENYAKIT_`, `TANGGAL_KEMOTERAPI`) VALUES
(1232, 1111, 'Adindaaa', '5/30/2020', 'Perempuan', 'Hindu', 'sddwdw', 'wdwdw', 3232323, 'dwdw', '5/30/2020'),
(3242, 1111, 'Fina Bela Qori', '5/18/2020', 'Perempuan', 'Kristen', 'Jakarta', 'efefef', 0, 'wefefe', '1/1/2021'),
(5643, 1111, 'Rezhi Silvia', '4/1/2020', 'Perempuan', 'Islam', 'Lumajang', ' rgrg', 433434, 'jdhfkjfr', '4/1/2020'),
(34343, 1111, 'Elis', '5/18/2020', 'Perempuan', 'Islam', 'grgrg', 'frfr', 345454, 'grgrgrgr', '5/1/2021'),
(5657657, 1111, 'Anggita', '4/1/2020', 'Perempuan', 'Islam', 'Lumajang', 'eefe', 32432, 'rrvr', '4/1/2020'),
(43546546, 1111, 'Ahira', '10/1/2020', 'Laki-laki', 'Islam', 'fefefefe', 'feefefee', 654654, 'nhnhnhnh', '10/1/2020');

-- --------------------------------------------------------

--
-- Table structure for table `data_petugas`
--

CREATE TABLE `data_petugas` (
  `ID_PETUGAS` bigint(20) NOT NULL,
  `NAMA_PETUGAS` text,
  `TANGGAL_LAHIR_PETUGAS` text,
  `ALAMAT_PETUGAS` text,
  `AGAMA_PETUGAS` text,
  `NOMOR_TELEPON_PETUGAS` bigint(20) DEFAULT NULL,
  `USERNAME` varchar(255) NOT NULL,
  `PASSWORD` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `data_petugas`
--

INSERT INTO `data_petugas` (`ID_PETUGAS`, `NAMA_PETUGAS`, `TANGGAL_LAHIR_PETUGAS`, `ALAMAT_PETUGAS`, `AGAMA_PETUGAS`, `NOMOR_TELEPON_PETUGAS`, `USERNAME`, `PASSWORD`) VALUES
(1111, 'Nafa Maharaniasasa', '11/4/1999', 'Dusun Gladak Kembar, RT 025, RW 005, Desa Purwoagung, Kecamatan Tegaldlimo, Kabupaten Banyuwangi, Provinsi Jawa Timur', 'Islam', 83110728767, 'nafa', 'nafa123'),
(1112, 'Inggar Diyas Tantri', '6/1/2020 11:38:28 PM', 'Perumahan Bumi Mangli Permai, Blok D14, Jember', 'Islam', 81232773106, 'inggar', 'inggar123'),
(1113, 'Alfia Nasha Fresbiasandi', '12/7/1998', 'Jl Kawi No. 2 Berbek, Nganjuk', 'Islam', 85608054702, 'alfia', 'alfia123'),
(1114, 'Ivanis Shani Yuniarti', '1998-06-17', 'Perum Bumi Nirwana', 'Islam', 82134567234, 'ivanis', 'ivanis123'),
(1115, 'Tania Sukma Wanti', '2/1/2000', 'Jl Nanas Gang 3 No 21A', 'Islam', 85338331114, 'tania', 'tania123');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `data_pasien_kemoterapi`
--
ALTER TABLE `data_pasien_kemoterapi`
  ADD PRIMARY KEY (`NO_RM_PASIEN`),
  ADD KEY `FK_MENDAFTARKAN` (`ID_PETUGAS`);

--
-- Indexes for table `data_petugas`
--
ALTER TABLE `data_petugas`
  ADD PRIMARY KEY (`ID_PETUGAS`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `data_pasien_kemoterapi`
--
ALTER TABLE `data_pasien_kemoterapi`
  ADD CONSTRAINT `FK_MENDAFTARKAN` FOREIGN KEY (`ID_PETUGAS`) REFERENCES `data_petugas` (`ID_PETUGAS`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
