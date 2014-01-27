//Init Tables.
 CREATE TABLE `a7754519_medpil`.`patient_info` (
`phone` BIGINT NOT NULL ,
`name` VARCHAR( 100 ) NOT NULL ,
`age` INT NULL ,
`DOB` DATE NULL ,
`sex` ENUM( 'M', 'F' ) NULL ,
PRIMARY KEY ( `phone` )
) ENGINE = MYISAM 

 CREATE TABLE `a7754519_medpil`.`records` (
`recordno` INT UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT ,
`userid` BIGINT NOT NULL ,
`problem` VARCHAR( 1024 ) NULL ,
`diagnosis` VARCHAR( 1024 ) NULL ,
`medication` VARCHAR( 1024 ) NULL ,
`reports` VARCHAR( 1024 ) NULL ,
PRIMARY KEY ( `recordno` )
) ENGINE = MYISAM 


