/*
SQLyog Community Edition- MySQL GUI v7.1 
MySQL - 5.0.51b-community-nt : Database - pyc
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

/*Table structure for table `company` */

DROP TABLE IF EXISTS `company`;

CREATE TABLE `company` (
  `COMPANY_ID` int(10) unsigned NOT NULL auto_increment,
  `COMPANY_NAME` varchar(500) collate utf8_bin default NULL,
  `ADDRESS` varchar(500) collate utf8_bin default NULL,
  `PHONE` varchar(50) collate utf8_bin default NULL,
  `CREATE_DATE` datetime default NULL,
  `CREATE_USER` varchar(100) collate utf8_bin default NULL,
  `UPDATE_DATE` datetime default NULL,
  `UPDATE_USER` varchar(100) collate utf8_bin default NULL,
  `FAX` varchar(50) collate utf8_bin default NULL,
  `REPRESENT_NAME` varchar(100) collate utf8_bin default NULL,
  `REPRESENT_PHONE` varchar(50) collate utf8_bin default NULL,
  `REPRESENT_FAX` varchar(50) collate utf8_bin default NULL,
  `DESCRIPTION` varchar(500) collate utf8_bin default NULL,
  PRIMARY KEY  (`COMPANY_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `company` */

/*Table structure for table `contract` */

DROP TABLE IF EXISTS `contract`;

CREATE TABLE `contract` (
  `CONTRACT_ID` int(10) unsigned NOT NULL auto_increment,
  `CONTRACT_NUMBER` varchar(30) collate utf8_bin default NULL,
  `CUSTOMER_ID` int(10) unsigned default NULL,
  `COMPANY_ID` int(10) unsigned default NULL,
  `CONTRACT_DATE` datetime default NULL,
  `CREATE_DATE` datetime default NULL,
  `CREATE_USER` varchar(100) collate utf8_bin default NULL,
  `UPDATE_DATE` datetime default NULL,
  `UPDATE_USER` varchar(100) collate utf8_bin default NULL,
  `CONTRACT_TYPE_ID` int(10) unsigned default NULL,
  `DESCRIPTION` varchar(500) collate utf8_bin default NULL,
  PRIMARY KEY  (`CONTRACT_ID`),
  KEY `CONTRACT_TYPE_ID` (`CONTRACT_TYPE_ID`),
  KEY `FK_contract_company` (`COMPANY_ID`),
  KEY `FK_contract` (`CUSTOMER_ID`),
  CONSTRAINT `contract_ibfk_1` FOREIGN KEY (`CONTRACT_TYPE_ID`) REFERENCES `contract_type_master` (`CONTRACT_TYPE_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_contract` FOREIGN KEY (`CUSTOMER_ID`) REFERENCES `customer` (`CUSTOMER_ID`),
  CONSTRAINT `FK_contract_company` FOREIGN KEY (`COMPANY_ID`) REFERENCES `company` (`COMPANY_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `contract` */

insert  into `contract`(`CONTRACT_ID`,`CONTRACT_NUMBER`,`CUSTOMER_ID`,`COMPANY_ID`,`CONTRACT_DATE`,`CREATE_DATE`,`CREATE_USER`,`UPDATE_DATE`,`UPDATE_USER`,`CONTRACT_TYPE_ID`,`DESCRIPTION`) values (1,'11',NULL,NULL,'2009-01-01 00:00:00',NULL,NULL,NULL,NULL,NULL,NULL),(2,'12333',NULL,NULL,'2008-02-01 00:00:00','0000-00-00 00:00:00','','0000-00-00 00:00:00','',NULL,'');

/*Table structure for table `contract_machine` */

DROP TABLE IF EXISTS `contract_machine`;

CREATE TABLE `contract_machine` (
  `CONTRACT_ID` int(10) unsigned NOT NULL,
  `MACHINE_ID` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`CONTRACT_ID`,`MACHINE_ID`),
  KEY `CONTRACT_MACHINE_FKIndex1` (`CONTRACT_ID`),
  KEY `CONTRACT_MACHINE_FKIndex2` (`MACHINE_ID`),
  CONSTRAINT `contract_machine_ibfk_1` FOREIGN KEY (`CONTRACT_ID`) REFERENCES `contract` (`CONTRACT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `contract_machine_ibfk_2` FOREIGN KEY (`MACHINE_ID`) REFERENCES `machine` (`MACHINE_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `contract_machine` */

/*Table structure for table `contract_type_master` */

DROP TABLE IF EXISTS `contract_type_master`;

CREATE TABLE `contract_type_master` (
  `CONTRACT_TYPE_ID` int(10) unsigned NOT NULL auto_increment,
  `CONTRACT_TYPE_NAME` varchar(500) collate utf8_bin default NULL,
  PRIMARY KEY  (`CONTRACT_TYPE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `contract_type_master` */

/*Table structure for table `customer` */

DROP TABLE IF EXISTS `customer`;

CREATE TABLE `customer` (
  `CUSTOMER_ID` int(10) unsigned NOT NULL auto_increment,
  `CUSTOMER_NAME` varchar(500) collate utf8_bin default NULL,
  `ADDRESS` varchar(1000) collate utf8_bin default NULL,
  `COMPANY_ID` int(10) unsigned default NULL,
  `PHONE` varchar(50) collate utf8_bin default NULL,
  `FAX` varchar(50) collate utf8_bin default NULL,
  `CREATE_DATE` datetime default NULL,
  `CREATE_USER` varchar(100) collate utf8_bin default NULL,
  `UPDATE_DATE` datetime default NULL,
  `UPDATE_USER` varchar(100) collate utf8_bin default NULL,
  `DESCRIPTION` varchar(500) collate utf8_bin default NULL,
  PRIMARY KEY  (`CUSTOMER_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `customer` */

/*Table structure for table `employee` */

DROP TABLE IF EXISTS `employee`;

CREATE TABLE `employee` (
  `EMPLOYEE_ID` int(10) unsigned NOT NULL auto_increment,
  `ROLE_MASTER_ROLE_ID` int(10) unsigned NOT NULL,
  `EMPLOYEE_NAME` varchar(500) collate utf8_bin default NULL,
  `ROLE_ID` int(10) unsigned default NULL,
  `ADDRESS` varchar(500) collate utf8_bin default NULL,
  `PHONE` varchar(50) collate utf8_bin default NULL,
  `LOGIN_NAME` varchar(100) collate utf8_bin default NULL,
  `CREATE_DATE` datetime default NULL,
  `CREATE_USER` varchar(100) collate utf8_bin default NULL,
  `UPDATE_DATE` datetime default NULL,
  `UPDATE_USER` varchar(100) collate utf8_bin default NULL,
  `DESCRIPTION` varchar(500) collate utf8_bin default NULL,
  PRIMARY KEY  (`EMPLOYEE_ID`),
  KEY `EMPLOYEE_FKIndex1` (`ROLE_MASTER_ROLE_ID`),
  CONSTRAINT `employee_ibfk_1` FOREIGN KEY (`ROLE_MASTER_ROLE_ID`) REFERENCES `role_master` (`ROLE_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `employee` */

/*Table structure for table `employee_request` */

DROP TABLE IF EXISTS `employee_request`;

CREATE TABLE `employee_request` (
  `REQUEST_ID` int(30) NOT NULL,
  `EMPLOYEE_ID` int(10) unsigned NOT NULL,
  `REQUEST_ACTION_TYPE_ID` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`REQUEST_ID`,`EMPLOYEE_ID`,`REQUEST_ACTION_TYPE_ID`),
  KEY `EMPLOYEE_REQUEST_FKIndex1` (`EMPLOYEE_ID`),
  KEY `EMPLOYEE_REQUEST_FKIndex2` (`REQUEST_ID`),
  KEY `EMPLOYEE_REQUEST_FKIndex3` (`REQUEST_ACTION_TYPE_ID`),
  CONSTRAINT `employee_request_ibfk_1` FOREIGN KEY (`EMPLOYEE_ID`) REFERENCES `employee` (`EMPLOYEE_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `employee_request_ibfk_3` FOREIGN KEY (`REQUEST_ACTION_TYPE_ID`) REFERENCES `request_action_type_master` (`REQUEST_ACTION_TYPE_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_employee_request` FOREIGN KEY (`REQUEST_ID`) REFERENCES `request` (`REQUEST_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `employee_request` */

/*Table structure for table `machine` */

DROP TABLE IF EXISTS `machine`;

CREATE TABLE `machine` (
  `MACHINE_ID` int(10) unsigned NOT NULL auto_increment,
  `MACHINE_NAME` varchar(500) collate utf8_bin default NULL,
  `MACHINE_TYPE` int(10) default NULL,
  `SERIAL_NUMBER` varchar(100) collate utf8_bin default NULL,
  `MODEL` varchar(500) collate utf8_bin default NULL,
  `COUNTER_NO` varchar(100) collate utf8_bin default NULL,
  `COLOR` varchar(100) collate utf8_bin default NULL,
  `FAX_TX` varchar(100) collate utf8_bin default NULL,
  `RECEIVE_RX` varchar(100) collate utf8_bin default NULL,
  `PREPORT_MASTER` varchar(100) collate utf8_bin default NULL,
  `COPY` varchar(100) collate utf8_bin default NULL,
  `CREATE_DATE` datetime default NULL,
  `CREATE_USER` varchar(100) collate utf8_bin default NULL,
  `UPDATE_DATE` datetime default NULL,
  `UPDATE_USER` varchar(100) collate utf8_bin default NULL,
  `Description` varchar(1000) collate utf8_bin default NULL,
  PRIMARY KEY  (`MACHINE_ID`),
  KEY `FK_machine` (`MACHINE_TYPE`),
  CONSTRAINT `FK_machine` FOREIGN KEY (`MACHINE_TYPE`) REFERENCES `machine_type_master` (`type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `machine` */

/*Table structure for table `machine_type_master` */

DROP TABLE IF EXISTS `machine_type_master`;

CREATE TABLE `machine_type_master` (
  `type_id` int(11) NOT NULL auto_increment,
  `type_name` varchar(500) collate utf8_bin default NULL,
  PRIMARY KEY  (`type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `machine_type_master` */

/*Table structure for table `replace_part` */

DROP TABLE IF EXISTS `replace_part`;

CREATE TABLE `replace_part` (
  `REPLACE_PART_ID` int(10) unsigned NOT NULL auto_increment,
  `REQUEST_ID` int(30) default NULL,
  `PART_NO` varchar(30) collate utf8_bin default NULL,
  `DESCRIPTION` varchar(500) collate utf8_bin default NULL,
  `QUANTITY` int(10) unsigned default NULL,
  `PRICE_USD` decimal(10,2) default NULL,
  `PRICE_VND` decimal(10,2) default NULL,
  `CREATE_DATE` datetime default NULL,
  `CREATE_USER` varchar(100) collate utf8_bin default NULL,
  `UPDATE_DATE` datetime default NULL,
  `UPDATE_USER` varchar(100) collate utf8_bin default NULL,
  PRIMARY KEY  (`REPLACE_PART_ID`),
  KEY `REPLACE_PART_FKIndex1` (`REQUEST_ID`),
  CONSTRAINT `FK_replace_part` FOREIGN KEY (`REQUEST_ID`) REFERENCES `request` (`REQUEST_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `replace_part` */

/*Table structure for table `request` */

DROP TABLE IF EXISTS `request`;

CREATE TABLE `request` (
  `REQUEST_ID` int(30) NOT NULL auto_increment,
  `CUSTOMER_ID` int(10) unsigned NOT NULL,
  `COMPANY_ID` int(10) unsigned NOT NULL,
  `CONTRACT_ID` int(10) unsigned default NULL,
  `MACHINE_ID` int(10) unsigned default NULL,
  `FOLLOW_UP_REQUEST_ID` int(10) unsigned default NULL,
  `CUSTOMER_CALL_DATE` datetime default NULL,
  `REPORT_DATE` datetime default NULL,
  `FINISH_DATE` datetime default NULL,
  `SERVICE_TYPE` int(10) unsigned default NULL,
  `PROBLEM_REPORT` varchar(1000) collate utf8_bin default NULL,
  `SYMPTOM` varchar(1000) collate utf8_bin default NULL,
  `CAUSE` varchar(1000) collate utf8_bin default NULL,
  `ACTION` varchar(1000) collate utf8_bin default NULL,
  `CUSTOMER_OPINION` varchar(1000) collate utf8_bin default NULL,
  `CREATE_DATE` datetime default NULL,
  `CREATE_USER` varchar(100) collate utf8_bin default NULL,
  `UPDATE_DATE` datetime default NULL,
  `UPDATE_USER` varchar(100) collate utf8_bin default NULL,
  `REQUEST_COST` decimal(10,2) default NULL,
  `TEMP_CUSTOMER_NAME` varchar(500) collate utf8_bin default NULL,
  `TEMP_COMPANY_NAME` varchar(500) collate utf8_bin default NULL,
  `TEMP_ADDRESS` varchar(500) collate utf8_bin default NULL,
  `TEMP_PHONE` varchar(50) collate utf8_bin default NULL,
  `TEMP_FAX` varchar(50) collate utf8_bin default NULL,
  PRIMARY KEY  (`REQUEST_ID`),
  KEY `REQUEST_FKIndex1` (`COMPANY_ID`),
  KEY `REQUEST_FKIndex2` (`CUSTOMER_ID`),
  KEY `REQUEST_FKIndex3` (`CONTRACT_ID`),
  KEY `FK_request_machine` (`MACHINE_ID`),
  CONSTRAINT `FK_request_machine` FOREIGN KEY (`MACHINE_ID`) REFERENCES `machine` (`MACHINE_ID`),
  CONSTRAINT `request_ibfk_1` FOREIGN KEY (`COMPANY_ID`) REFERENCES `company` (`COMPANY_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `request_ibfk_2` FOREIGN KEY (`CUSTOMER_ID`) REFERENCES `customer` (`CUSTOMER_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `request_ibfk_3` FOREIGN KEY (`CONTRACT_ID`) REFERENCES `contract` (`CONTRACT_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `request` */

/*Table structure for table `request_action_type_master` */

DROP TABLE IF EXISTS `request_action_type_master`;

CREATE TABLE `request_action_type_master` (
  `REQUEST_ACTION_TYPE_ID` int(10) unsigned NOT NULL,
  `REQUEST_ACTION_TYPE_NAME` varchar(500) collate utf8_bin default NULL,
  PRIMARY KEY  (`REQUEST_ACTION_TYPE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `request_action_type_master` */

/*Table structure for table `request_status` */

DROP TABLE IF EXISTS `request_status`;

CREATE TABLE `request_status` (
  `REQUEST_STATUS_ID` int(10) unsigned NOT NULL,
  `REQUEST_ID` int(30) NOT NULL,
  `STATUS_TYPE` int(10) unsigned default NULL,
  `CREATE_DATE` datetime default NULL,
  `CREATE_USER` varchar(100) collate utf8_bin default NULL,
  `UPDATE_DATE` datetime default NULL,
  `UPDATE_USER` varchar(100) collate utf8_bin default NULL,
  `DESCRIPTION` varchar(1000) collate utf8_bin default NULL,
  PRIMARY KEY  (`REQUEST_STATUS_ID`),
  KEY `REQUEST_STATUS_FKIndex1` (`REQUEST_ID`),
  KEY `REQUEST_STATUS_FKIndex2` (`STATUS_TYPE`),
  CONSTRAINT `FK_request_status` FOREIGN KEY (`REQUEST_ID`) REFERENCES `request` (`REQUEST_ID`),
  CONSTRAINT `request_status_ibfk_2` FOREIGN KEY (`STATUS_TYPE`) REFERENCES `status_type_master` (`STATUS_TYPE`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `request_status` */

/*Table structure for table `role_master` */

DROP TABLE IF EXISTS `role_master`;

CREATE TABLE `role_master` (
  `ROLE_ID` int(10) unsigned NOT NULL,
  `ROLE_NAME` varchar(500) collate utf8_bin default NULL,
  PRIMARY KEY  (`ROLE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `role_master` */

/*Table structure for table `status_type_master` */

DROP TABLE IF EXISTS `status_type_master`;

CREATE TABLE `status_type_master` (
  `STATUS_TYPE` int(10) unsigned NOT NULL,
  `STATUS_NAME` varchar(500) collate utf8_bin default NULL,
  PRIMARY KEY  (`STATUS_TYPE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

/*Data for the table `status_type_master` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
