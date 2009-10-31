/*
SQLyog Community Edition- MySQL GUI v7.1 
MySQL - 5.1.36-community-log : Database - test
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

CREATE DATABASE /*!32312 IF NOT EXISTS*/`test` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_bin */;

USE `test`;

/*Table structure for table `cashinouttransaction` */

DROP TABLE IF EXISTS `cashinouttransaction`;

CREATE TABLE `cashinouttransaction` (
  `Cash_In_Out_Transaction_Id` varchar(15) COLLATE utf8_bin NOT NULL,
  `Transaction_Id` varchar(12) COLLATE utf8_bin NOT NULL,
  `Store_Id` varchar(5) COLLATE utf8_bin NOT NULL,
  `Register_Id` varchar(2) COLLATE utf8_bin NOT NULL,
  `Cashier_Id` varchar(6) COLLATE utf8_bin NOT NULL,
  `Amount` decimal(13,2) DEFAULT NULL,
  `Reason_Code` int(11) DEFAULT NULL,
  `Customer_Id` varchar(15) COLLATE utf8_bin DEFAULT NULL,
  `Comment` varchar(1000) COLLATE utf8_bin DEFAULT NULL,
  `CREATE_DATE` datetime DEFAULT NULL,
  `CREATE_ID` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `UPDATE_DATE` datetime DEFAULT NULL,
  `UPDATE_ID` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `EXCLUSIVE_KEY` int(10) unsigned DEFAULT NULL,
  `DEL_FLG` int(10) unsigned DEFAULT '0',
  `EX_FLD1` int(11) DEFAULT NULL,
  `EX_FLD2` int(11) DEFAULT NULL,
  `EX_FLD3` int(11) DEFAULT NULL,
  `EX_FLD4` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `EX_FLD5` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`Cash_In_Out_Transaction_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Table structure for table `postransaction` */

DROP TABLE IF EXISTS `postransaction`;

CREATE TABLE `postransaction` (
  `POS_Transaction_Id` varchar(10) COLLATE utf8_bin NOT NULL,
  `Transaction_Id` varchar(12) COLLATE utf8_bin NOT NULL,
  `Store_Id` varchar(5) COLLATE utf8_bin NOT NULL,
  `Register_Id` varchar(2) COLLATE utf8_bin NOT NULL,
  `Cashier_Id` varchar(6) COLLATE utf8_bin NOT NULL,
  `Amount_In` decimal(13,2) DEFAULT NULL,
  `Amount_Out` decimal(13,2) DEFAULT NULL,
  `CREATE_DATE` datetime DEFAULT NULL,
  `CREATE_ID` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `UPDATE_DATE` datetime DEFAULT NULL,
  `UPDATE_ID` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `EXCLUSIVE_KEY` int(10) unsigned DEFAULT NULL,
  `EX_FLD1` int(11) DEFAULT NULL,
  `EX_FLD2` int(11) DEFAULT NULL,
  `EX_FLD3` int(11) DEFAULT NULL,
  `EX_FLD4` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `EX_FLD5` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `DEL_FLG` int(1) DEFAULT '0',
  PRIMARY KEY (`POS_Transaction_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Table structure for table `returntransaction` */

DROP TABLE IF EXISTS `returntransaction`;

CREATE TABLE `returntransaction` (
  `Return_Transaction_Id` varchar(15) COLLATE utf8_bin NOT NULL,
  `Transaction_Id` varchar(12) COLLATE utf8_bin NOT NULL,
  `POS_Transaction_Id` varchar(10) COLLATE utf8_bin NOT NULL,
  `Store_Id` varchar(5) COLLATE utf8_bin NOT NULL,
  `Register_Id` varchar(2) COLLATE utf8_bin NOT NULL,
  `Cashier_Id` varchar(6) COLLATE utf8_bin NOT NULL,
  `Customer_Id` varchar(15) COLLATE utf8_bin DEFAULT NULL,
  `Purchase_Order_Id` varchar(15) COLLATE utf8_bin DEFAULT NULL,
  `Return_Id` varchar(15) COLLATE utf8_bin DEFAULT NULL,
  `CREATE_DATE` datetime DEFAULT NULL,
  `CREATE_ID` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `UPDATE_DATE` datetime DEFAULT NULL,
  `UPDATE_ID` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `EXCLUSIVE_KEY` int(10) unsigned DEFAULT NULL,
  `DEL_FLG` int(10) unsigned DEFAULT '0',
  `EX_FLD1` int(11) DEFAULT NULL,
  `EX_FLD2` int(11) DEFAULT NULL,
  `EX_FLD3` int(11) DEFAULT NULL,
  `EX_FLD4` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `EX_FLD5` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`Return_Transaction_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Table structure for table `saletransaction` */

DROP TABLE IF EXISTS `saletransaction`;

CREATE TABLE `saletransaction` (
  `Sale_Transaction_Id` varchar(10) COLLATE utf8_bin NOT NULL,
  `Transaction_Id` varchar(12) COLLATE utf8_bin NOT NULL,
  `POS_Transaction_Id` varchar(10) COLLATE utf8_bin NOT NULL,
  `Store_Id` varchar(5) COLLATE utf8_bin NOT NULL,
  `Register_Id` varchar(2) COLLATE utf8_bin NOT NULL,
  `Cashier_Id` varchar(6) COLLATE utf8_bin NOT NULL,
  `Purchase_Order_Id` varchar(15) COLLATE utf8_bin DEFAULT NULL,
  `CREATE_DATE` datetime DEFAULT NULL,
  `CREATE_ID` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `UPDATE_DATE` datetime DEFAULT NULL,
  `UPDATE_ID` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `EXCLUSIVE_KEY` int(10) unsigned DEFAULT NULL,
  `DEL_FLG` int(10) unsigned DEFAULT '0',
  `EX_FLD1` int(11) DEFAULT NULL,
  `EX_FLD2` int(11) DEFAULT NULL,
  `EX_FLD3` int(11) DEFAULT NULL,
  `EX_FLD4` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `EX_FLD5` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`Sale_Transaction_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Table structure for table `transaction` */

DROP TABLE IF EXISTS `transaction`;

CREATE TABLE `transaction` (
  `Transaction_Id` varchar(12) COLLATE utf8_bin NOT NULL,
  `Store_Id` varchar(5) COLLATE utf8_bin NOT NULL,
  `Register_Id` varchar(2) COLLATE utf8_bin NOT NULL,
  `Cashier_Id` varchar(6) COLLATE utf8_bin NOT NULL,
  `CREATE_DATE` datetime DEFAULT NULL,
  `CREATE_ID` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `UPDATE_DATE` datetime DEFAULT NULL,
  `UPDATE_ID` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `EXCLUSIVE_KEY` int(10) unsigned DEFAULT NULL,
  `DEL_FLG` int(10) unsigned DEFAULT '0',
  `EX_FLD1` int(11) DEFAULT NULL,
  `EX_FLD2` int(11) DEFAULT NULL,
  `EX_FLD3` int(11) DEFAULT NULL,
  `EX_FLD4` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `EX_FLD5` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `Transaction_Type` int(5) NOT NULL,
  PRIMARY KEY (`Transaction_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
