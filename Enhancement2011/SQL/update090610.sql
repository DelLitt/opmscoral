ALTER TABLE `pos`.`department_stock_out` ADD COLUMN `OTHER_DEPARTMENT_ID` VARCHAR(45) DEFAULT 0 COMMENT 'Neu defect_id = 7 thi truong nay se co gia tri' AFTER `CONFIRM_FLG`;
