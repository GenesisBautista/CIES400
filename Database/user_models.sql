-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`tblUserType`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`tblUserType` (
  `userTypeId` INT NOT NULL AUTO_INCREMENT,
  `type` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`userTypeId`),
  UNIQUE INDEX `userTypeId_UNIQUE` (`userTypeId` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`tblUser`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`tblUser` (
  `id` VARCHAR(45) NOT NULL,
  `username` VARCHAR(100) NOT NULL,
  `password` VARCHAR(100) NOT NULL,
  `hint` VARCHAR(255) NOT NULL,
  `firstName` VARCHAR(32) NULL,
  `lastName` VARCHAR(32) NULL,
  `create_time` DATETIME NULL,
  `birthDate` DATETIME NULL,
  `tblUserType_userTypeId` INT NOT NULL,
  UNIQUE INDEX `username_UNIQUE` (`username` ASC) VISIBLE,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `fk_tblUser_tblUserType_idx` (`tblUserType_userTypeId` ASC) VISIBLE,
  CONSTRAINT `fk_tblUser_tblUserType`
    FOREIGN KEY (`tblUserType_userTypeId`)
    REFERENCES `mydb`.`tblUserType` (`userTypeId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
