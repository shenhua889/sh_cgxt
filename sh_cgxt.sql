/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50626
Source Host           : localhost:3306
Source Database       : sh_cgxt

Target Server Type    : MYSQL
Target Server Version : 60099
File Encoding         : 65001

Date: 2016-02-26 15:49:26
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `commodity`
-- ----------------------------
DROP TABLE IF EXISTS `commodity`;
CREATE TABLE `commodity` (
`ID`  int(4) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT ,
`name`  varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`amount`  int(10) NULL DEFAULT NULL ,
`price`  int(10) NULL DEFAULT NULL ,
PRIMARY KEY (`ID`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=58

;

-- ----------------------------
-- Records of commodity
-- ----------------------------
BEGIN;
INSERT INTO `commodity` VALUES ('0001', '123', '12', '23'), ('0002', '2', null, null), ('0003', '1', null, null), ('0004', '1', null, null), ('0005', '1', null, null), ('0006', '1', null, null), ('0007', '1', null, null), ('0008', '1', null, null), ('0009', '1', null, null), ('0010', '1', null, null), ('0011', '1', null, null), ('0012', '1', null, null), ('0013', '1', null, null), ('0014', '1', null, null), ('0015', '1', null, null), ('0016', '1', null, null), ('0017', '1', null, null), ('0018', '1', null, null), ('0019', '1', null, null), ('0020', '1', null, null), ('0021', '1', null, null), ('0022', '1', null, null), ('0023', '1', null, null), ('0024', '1', null, null), ('0025', '1', null, null), ('0026', '1', null, null), ('0027', '1', null, null), ('0028', '1', null, null), ('0029', '1', null, null), ('0030', '1', null, null), ('0047', 'ert', '12', '12'), ('0048', 'hbr', '12', '12'), ('0049', 'we', '33', '33'), ('0050', 'wer', '1', '2'), ('0051', 'rg', '23', '23'), ('0052', 'gr', '44', '44'), ('0053', 'r', '3', '3'), ('0054', 'rtt', '11', '11'), ('0055', 'aa', '23', '23'), ('0056', 'aa', '333', '333'), ('0057', '123', '123', '123');
COMMIT;

-- ----------------------------
-- Table structure for `commodity_log`
-- ----------------------------
DROP TABLE IF EXISTS `commodity_log`;
CREATE TABLE `commodity_log` (
`ID`  int(4) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT ,
`commodity_ID`  int(4) NULL DEFAULT NULL ,
`commodity_Name`  varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`event`  varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`amount_old`  int(10) NULL DEFAULT NULL ,
`amount_new`  int(10) NULL DEFAULT NULL ,
`amount_change`  int(10) NULL DEFAULT NULL ,
`price_old`  int(10) NULL DEFAULT NULL ,
`price_new`  int(10) NULL DEFAULT NULL ,
`price_change`  int(10) NULL DEFAULT NULL ,
`datetime`  datetime NULL DEFAULT NULL ,
PRIMARY KEY (`ID`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=16

;

-- ----------------------------
-- Records of commodity_log
-- ----------------------------
BEGIN;
INSERT INTO `commodity_log` VALUES ('0001', null, null, '123', null, '12', null, null, '23', null, null), ('0002', null, null, '123', null, '12', null, null, '23', null, '2016-02-11 00:00:00'), ('0003', null, null, '123', null, '12', null, null, '23', null, '2005-11-05 21:21:25'), ('0004', null, '12', null, null, null, null, null, null, null, null), ('0005', null, '12', null, null, null, null, null, null, null, null), ('0006', '12', '12', null, null, null, null, null, null, null, null), ('0007', '12', '12', null, null, null, null, null, null, null, null), ('0008', '12', '12', null, null, null, null, null, null, null, null), ('0009', '12', '12', null, null, null, null, null, null, null, null), ('0010', '12', 'wer', null, null, null, null, null, null, null, null), ('0011', '12', 'we', 'gr', null, null, '13', null, null, '33', null), ('0012', '34', 'rg', '新增', null, null, '23', null, null, '23', null), ('0013', '34', 'r', '新增', null, null, '3', null, null, '3', '2016-02-11 17:29:08'), ('0014', '34', 'aa', '新增', null, null, '333', null, null, '333', '2016-02-11 17:39:41'), ('0015', '34', '123', '新增', null, null, '123', null, null, '123', '2016-02-12 16:21:08');
COMMIT;

-- ----------------------------
-- Table structure for `employee`
-- ----------------------------
DROP TABLE IF EXISTS `employee`;
CREATE TABLE `employee` (
`ID`  int(4) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT ,
`name`  varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`password`  varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`father_ID`  int(4) NULL DEFAULT NULL ,
PRIMARY KEY (`ID`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=13

;

-- ----------------------------
-- Records of employee
-- ----------------------------
BEGIN;
INSERT INTO `employee` VALUES ('0001', 'a', null, '0'), ('0002', 'b', null, '0'), ('0003', 'c', null, '2'), ('0004', 'd', null, '3'), ('0005', 'e', null, '1'), ('0006', '1', '2', '1'), ('0007', 'SDF', 'SDF', '0'), ('0008', 'DFG', 'DFG', '0'), ('0009', 'DFG', 'DFG', '1'), ('0010', '拉面', '123', '5'), ('0011', '士大夫', 'sdf ', '10'), ('0012', 'grs', 'grs', '6');
COMMIT;

-- ----------------------------
-- Table structure for `employee_commodity`
-- ----------------------------
DROP TABLE IF EXISTS `employee_commodity`;
CREATE TABLE `employee_commodity` (
`employee_ID`  int(4) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT ,
`commodity_ID`  int(4) NOT NULL DEFAULT 0 ,
`amount`  int(10) NULL DEFAULT NULL ,
`bonus`  int(5) NULL DEFAULT NULL ,
PRIMARY KEY (`employee_ID`, `commodity_ID`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of employee_commodity
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for `employee_log`
-- ----------------------------
DROP TABLE IF EXISTS `employee_log`;
CREATE TABLE `employee_log` (
`ID`  int(10) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT ,
`employee_ID`  int(10) NULL DEFAULT NULL ,
`event`  varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`datetime`  datetime NULL DEFAULT NULL ,
PRIMARY KEY (`ID`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=6

;

-- ----------------------------
-- Records of employee_log
-- ----------------------------
BEGIN;
INSERT INTO `employee_log` VALUES ('0000000001', '8', '添加用户', '2016-02-12 16:10:36'), ('0000000002', '9', '添加用户', '2016-02-12 16:10:41'), ('0000000003', '10', '添加用户', '2016-02-12 16:14:15'), ('0000000004', '11', '添加用户', '2016-02-12 16:16:36'), ('0000000005', '12', '添加用户', '2016-02-12 16:17:45');
COMMIT;

-- ----------------------------
-- Table structure for `output_log`
-- ----------------------------
DROP TABLE IF EXISTS `output_log`;
CREATE TABLE `output_log` (
`ID`  int(4) UNSIGNED NOT NULL AUTO_INCREMENT ,
`employee_ID`  int(4) NULL DEFAULT NULL ,
`commodity_NO`  int(4) NULL DEFAULT NULL ,
`amount`  int(10) NULL DEFAULT NULL ,
`datetime`  datetime NULL DEFAULT NULL ,
PRIMARY KEY (`ID`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of output_log
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Auto increment value for `commodity`
-- ----------------------------
ALTER TABLE `commodity` AUTO_INCREMENT=58;

-- ----------------------------
-- Auto increment value for `commodity_log`
-- ----------------------------
ALTER TABLE `commodity_log` AUTO_INCREMENT=16;

-- ----------------------------
-- Auto increment value for `employee`
-- ----------------------------
ALTER TABLE `employee` AUTO_INCREMENT=13;

-- ----------------------------
-- Auto increment value for `employee_commodity`
-- ----------------------------
ALTER TABLE `employee_commodity` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for `employee_log`
-- ----------------------------
ALTER TABLE `employee_log` AUTO_INCREMENT=6;

-- ----------------------------
-- Auto increment value for `output_log`
-- ----------------------------
ALTER TABLE `output_log` AUTO_INCREMENT=1;
