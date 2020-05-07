-- MySQL dump 10.13  Distrib 5.7.9, for Win32 (AMD64)
--
-- Host: localhost    Database: db_gestaoescolar
-- ------------------------------------------------------
-- Server version	5.7.11-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `gesc_professor`
--

DROP TABLE IF EXISTS `gesc_professor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gesc_professor` (
  `PRO_IN_CODIGO` int(11) NOT NULL AUTO_INCREMENT,
  `PRO_ST_NOME` varchar(50) DEFAULT NULL,
  `PRO_ST_SENHA` varchar(20) DEFAULT NULL,
  `PRO_ST_CPF` varchar(14) DEFAULT NULL,
  `PRO_CH_TIPO` varchar(1) DEFAULT NULL COMMENT 'Tipo do Usuário\nP: Professor\nS: Secretaria',
  PRIMARY KEY (`PRO_IN_CODIGO`),
  UNIQUE KEY `PRO_ST_CPF_UNIQUE` (`PRO_ST_CPF`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='Tabela de Usuários/Professores';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gesc_professor`
--

LOCK TABLES `gesc_professor` WRITE;
/*!40000 ALTER TABLE `gesc_professor` DISABLE KEYS */;
INSERT INTO `gesc_professor` VALUES (1,'Andre Bento Soares','12345678','43750055807','P');
/*!40000 ALTER TABLE `gesc_professor` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-04-16 11:08:37
