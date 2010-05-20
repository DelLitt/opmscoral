
CREATE TABLE temp_stk_his(
	PRODUCT_ID nvarchar(20) NULL,
	good_qty int NULL,
	perror_qty int NULL,
	predmg bigint NULL
	
) 
GO
/****** Object:  Table temp_product    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE temp_product(
	TYPE_ID bigint NOT NULL,
	TYPE_NAME nvarchar(500) NULL,
	PRODUCT_MASTER_ID nvarchar(13) NOT NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	PRODUCT_NAME nvarchar(500) NULL,
	COLOR_NAME nvarchar(500) NULL,
	SIZE_NAME nvarchar(500) NULL,
	PRICE int NOT NULL,
	department_name nvarchar(500) NULL
	
) 
GO
/****** Object:  Table temp_pr    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE temp_pr(
	TYPE_ID bigint NOT NULL,
	TYPE_NAME nvarchar(500) NULL,
	PRODUCT_MASTER_ID nvarchar(13) NOT NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	PRODUCT_NAME nvarchar(500) NULL,
	COLOR_NAME nvarchar(500) NULL,
	SIZE_NAME nvarchar(500) NULL,
	PRICE int NOT NULL
	
) 
GO
/****** Object:  Table temp_dp_stockout    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE temp_dp_stockout(
	DEPARTMENT_ID bigint NOT NULL,
	DEFECT_STATUS_ID bigint NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	quantity decimal(33, 0) NULL
	
) 
GO
/****** Object:  Table temp_deptstock_max_temp    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE temp_deptstock_max_temp(
	PRODUCT_ID nvarchar(20) NULL,
	good_qty int NULL,
	perror_qty int NULL,
	predmg bigint NULL
	
) 
GO
/****** Object:  Table temp_deptstock    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE temp_deptstock(
	TYPE_ID bigint NOT NULL,
	TYPE_NAME nvarchar(500) NULL,
	PRODUCT_MASTER_ID nvarchar(13) NOT NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	PRODUCT_NAME nvarchar(500) NULL,
	COLOR_NAME nvarchar(500) NULL,
	SIZE_NAME nvarchar(500) NULL,
	PRICE int NOT NULL,
	department_name nvarchar(500) NULL
	
) 
GO
/****** Object:  Table temp_dept_stock_statistics    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE temp_dept_stock_statistics(
	department_name nvarchar(500) NULL,
	type_name nvarchar(500) NULL,
	product_id nvarchar(20) NOT NULL,
	product_name nvarchar(500) NULL,
	color_name nvarchar(500) NULL,
	size_name nvarchar(500) NULL,
	prestk_qty decimal(38, 0) NULL,
	instock_qty decimal(38, 0) NULL,
	error_qty decimal(38, 0) NULL,
	dmg_qty decimal(38, 0) NULL,
	stkout_qty decimal(38, 0) NULL,
	tmpout_qty decimal(38, 0) NULL,
	rtn_qty decimal(38, 0) NULL,
	destroy_qty decimal(38, 0) NULL,
	bkpro decimal(38, 0) NULL,
	realstock decimal(38, 0) NULL,
	temp_pri_key bigint IDENTITY(1,1)  NOT NULL
	,
 CONSTRAINT PK_temp_dept_stock_statistics_temp_pri_key PRIMARY KEY  
(
	temp_pri_key 
) 
) 
GO
/****** Object:  Table crl_usr_role    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE crl_usr_role(
	userid nvarchar(50) NOT NULL,
	roleid int NOT NULL
	,
 CONSTRAINT PK_crl_usr_role_userid PRIMARY KEY  
(
	userid ,
	roleid 
) 
) 
GO
/****** Object:  Table crl_usr_info    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE crl_usr_info(
	Username nvarchar(50) NOT NULL,
	Password nvarchar(50) NULL,
	EMPLOYEE_ID nvarchar(20) NULL,
	DEPARTMENT_ID int NULL,
	SUSPENDED bigint NULL,
	DELETED bigint NULL
	,
 CONSTRAINT PK_crl_usr_info_Username PRIMARY KEY  
(
	Username 
) 
) 
GO
/****** Object:  Table crl_trans    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE crl_trans(
	Transaction_Id nvarchar(12) NOT NULL,
	Store_Id nvarchar(5) NOT NULL,
	Register_Id nvarchar(2) NOT NULL,
	Cashier_Id nvarchar(6) NOT NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 int NULL,
	EX_FLD2 int NULL,
	EX_FLD3 int NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	Transaction_Type int NOT NULL
	,
 CONSTRAINT PK_crl_trans_Transaction_Id PRIMARY KEY  
(
	Transaction_Id 
) 
) 
GO
/****** Object:  Table crl_tax    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE crl_tax(
	TAX_ID bigint NOT NULL,
	TAX_NAME nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_tax_TAX_ID PRIMARY KEY  
(
	TAX_ID 
) 
) 
GO
/****** Object:  Table crl_sync_status    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE crl_sync_status(
	LAST_SYNC_DATE datetime NOT NULL,
	CREATE_ID nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_sync_status_LAST_SYNC_DATE PRIMARY KEY  
(
	LAST_SYNC_DATE 
) 
) 
GO
/****** Object:  Table crl_sup    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE crl_sup(
	SUPPLIER_ID bigint NOT NULL,
	SUPPLIER_NAME nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_sup_SUPPLIER_ID PRIMARY KEY  
(
	SUPPLIER_ID 
) 
) 
GO
/****** Object:  Table crl_stk_out_tmp    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE crl_stk_out_tmp(
	STOCKOUT_ID bigint NOT NULL,
	STOCK_OUT_DATE datetime NULL,
	DEPARTMENT_ID bigint NOT NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	STOCK_ID bigint NULL,
	DEFECT_STATUS_ID bigint NULL,
	CONFIRM_FLG bigint NULL
	
) 
GO
/****** Object:  Table crl_stk_out_det    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE crl_stk_out_det(
	STOCK_OUT_DETAIL_ID bigint NOT NULL,
	STOCKOUT_ID bigint NOT NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	PRODUCT_MASTER_ID nvarchar(13) NULL,
	QUANTITY bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	DEFECT_STATUS_ID bigint NULL,
	DESCRIPTION nvarchar(500) NULL,
	GOOD_QUANTITY bigint NULL,
	ERROR_QUANTITY bigint NULL,
	DAMAGE_QUANTITY bigint NULL,
	LOST_QUANTITY bigint NULL
	,
 CONSTRAINT PK_crl_stk_out_det_STOCK_OUT_DETAIL_ID PRIMARY KEY  
(
	STOCK_OUT_DETAIL_ID 
) 
) 
GO
/****** Object:  Table crl_stk_out_cst    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE crl_stk_out_cst(
	STOCK_OUT_ID bigint NOT NULL,
	COST_TYPE bigint NOT NULL,
	STOCKOUT_ID bigint NOT NULL,
	COST bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_stk_out_cst_STOCK_OUT_ID PRIMARY KEY  
(
	STOCK_OUT_ID ,
	COST_TYPE 
) 
) 
GO
/****** Object:  Table crl_stk_out    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE crl_stk_out(
	STOCKOUT_ID bigint NOT NULL,
	STOCK_OUT_DATE datetime NULL,
	DEPARTMENT_ID bigint NOT NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	STOCK_ID bigint NULL,
	DEFECT_STATUS_ID bigint NULL,
	CONFIRM_FLG bigint NULL,
	EX_FLD1 int NULL,
	EX_FLD2 int NULL,
	EX_FLD3 int NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_stk_out_STOCKOUT_ID PRIMARY KEY  
(
	STOCKOUT_ID 
) 
) 
GO
/****** Object:  Table crl_stk_in_det    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE crl_stk_in_det(
	STOCK_IN_ID nvarchar(11) NOT NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	PRODUCT_MASTER_ID nvarchar(13) NULL,
	QUANTITY bigint NULL,
	PRICE bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	STOCK_IN_TYPE bigint NULL,
	SELL_PRICE bigint NULL
	,
 CONSTRAINT PK_crl_stk_in_det_STOCK_IN_ID PRIMARY KEY  
(
	STOCK_IN_ID ,
	PRODUCT_ID 
) 
) 
GO
/****** Object:  Table crl_stk_in    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE crl_stk_in(
	STOCK_IN_ID nvarchar(11) NOT NULL,
	STOCK_IN_DATE datetime NULL,
	CREATE_DATE datetime NULL,
	DESCRIPTION nvarchar(2000) NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	STOCK_IN_COST bigint NULL,
	STOCK_IN_TYPE bigint NULL,
	CONFIRM_FLG bigint NULL
	,
 CONSTRAINT PK_crl_stk_in_STOCK_IN_ID PRIMARY KEY  
(
	STOCK_IN_ID 
) 
) 
GO
/****** Object:  Table crl_stk_def_stat    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE crl_stk_def_stat(
	DEFECT_STATUS_ID bigint NOT NULL,
	DEFECT_STATUS_NAME nvarchar(200) NOT NULL
	,
 CONSTRAINT PK_crl_stk_def_stat_DEFECT_STATUS_ID PRIMARY KEY  
(
	DEFECT_STATUS_ID 
) 
) 
GO
/****** Object:  Table crl_sim_prd    Script Date: 01/22/2010 00:05:10 ******/

GO

GO
CREATE TABLE crl_sim_prd(
	BASE_PRODUCT_ID bigint NOT NULL,
	OTHER_PRODUCT_ID bigint NOT NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_sim_prd_BASE_PRODUCT_ID PRIMARY KEY  
(
	BASE_PRODUCT_ID ,
	OTHER_PRODUCT_ID 
) 
) 
GO
/****** Object:  Table crl_sche_tmplate    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_sche_tmplate(
	EMPLOYEE_ID nvarchar(20) NOT NULL,
	SCHEDULE_ID bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	MONDAY bigint NULL,
	TUESDAY bigint NULL,
	WEDNESDAY bigint NULL,
	THURSDAY bigint NULL,
	FRIDAY bigint NULL,
	SATURDAY bigint NULL,
	SUNDAY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	START_DATE datetime NULL,
	END_DATE datetime NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL
	,
 CONSTRAINT PK_crl_sche_tmplate_EMPLOYEE_ID PRIMARY KEY  
(
	EMPLOYEE_ID ,
	SCHEDULE_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_sale_trans    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_sale_trans(
	Sale_Transaction_Id nvarchar(10) NOT NULL,
	Transaction_Id nvarchar(12) NOT NULL,
	POS_Transaction_Id nvarchar(10) NOT NULL,
	Store_Id nvarchar(5) NOT NULL,
	Register_Id nvarchar(2) NOT NULL,
	Cashier_Id nvarchar(6) NOT NULL,
	Purchase_Order_Id nvarchar(15) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 int NULL,
	EX_FLD2 int NULL,
	EX_FLD3 int NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_sale_trans_Sale_Transaction_Id PRIMARY KEY  
(
	Sale_Transaction_Id 
) 
) 
GO
/****** Object:  Table crl_role    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_role(
	id int NOT NULL,
	name nvarchar(50) NULL
	,
 CONSTRAINT PK_crl_role_id PRIMARY KEY  
(
	id 
) 
) 
GO
/****** Object:  Table crl_ret_trans    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_ret_trans(
	Return_Transaction_Id nvarchar(15) NOT NULL,
	Transaction_Id nvarchar(12) NOT NULL,
	POS_Transaction_Id nvarchar(10) NOT NULL,
	Store_Id nvarchar(5) NOT NULL,
	Register_Id nvarchar(2) NOT NULL,
	Cashier_Id nvarchar(6) NOT NULL,
	Customer_Id nvarchar(15) NULL,
	Purchase_Order_Id nvarchar(15) NULL,
	Return_Id nvarchar(15) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 int NULL,
	EX_FLD2 int NULL,
	EX_FLD3 int NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_ret_trans_Return_Transaction_Id PRIMARY KEY  
(
	Return_Transaction_Id 
) 
) 
GO
/****** Object:  Table crl_ret_prd    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_ret_prd(
	RETURN_PRODUCT_ID bigint NOT NULL,
	PRODUCT_ID nvarchar(20) NULL,
	PRODUCT_MASTER_ID nvarchar(13) NULL,
	DESCRIPTION bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	QUANTITY bigint NULL
	,
 CONSTRAINT PK_crl_ret_prd_RETURN_PRODUCT_ID PRIMARY KEY  
(
	RETURN_PRODUCT_ID 
) 
) 
GO
/****** Object:  Table crl_ret_blk_in    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_ret_blk_in(
	BLOCK_IN_ID bigint NOT NULL,
	BLOCK_DETAIL_ID bigint NOT NULL,
	DESCRIPTION nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_ret_blk_in_BLOCK_IN_ID PRIMARY KEY  
(
	BLOCK_IN_ID ,
	BLOCK_DETAIL_ID 
) 
) 
GO
/****** Object:  Table crl_reicpt_out_cst    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_reicpt_out_cst(
	RECEIPT_OUT_ID bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	COST_TYPE bigint NOT NULL,
	COST bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_reicpt_out_cst_RECEIPT_OUT_ID PRIMARY KEY  
(
	RECEIPT_OUT_ID ,
	DEPARTMENT_ID ,
	COST_TYPE 
) 
) 
GO
/****** Object:  Table crl_reicpt_out    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_reicpt_out(
	RECEIPT_OUT_ID bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	RECEIPT_OUT_NAME bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_reicpt_out_RECEIPT_OUT_ID PRIMARY KEY  
(
	RECEIPT_OUT_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_reicpt    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_reicpt(
	RECEIPT_ID nvarchar(20) NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	PURCHASE_ORDER_ID nvarchar(20) NOT NULL,
	RECEIPT_NAME nvarchar(500) NULL,
	RECEIPT_NUMBER nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_reicpt_RECEIPT_ID PRIMARY KEY  
(
	RECEIPT_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_promo    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_promo(
	PROMOTION_ID bigint NOT NULL,
	PROMOTION_NAME nvarchar(500) NULL,
	DISCOUNT_PRICE bigint NULL,
	DISCOUNT_PERCENT bigint NULL,
	PROMOTION_TYPE bigint NULL,
	GIFT_PRODUCT_ID bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_promo_PROMOTION_ID PRIMARY KEY  
(
	PROMOTION_ID 
) 
) 
GO
/****** Object:  Table crl_prd_unit    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_prd_unit(
	UNIT_ID int NOT NULL,
	UNIT_NAME nvarchar(30) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(20) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(20) NULL,
	EXCLUSIVE_KEY int NULL,
	DEL_FLG int NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_prd_unit_UNIT_ID PRIMARY KEY  
(
	UNIT_ID 
) 
) 
GO
/****** Object:  Table crl_prd_typ    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_prd_typ(
	TYPE_ID bigint NOT NULL,
	TYPE_NAME nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 int NULL,
	EX_FLD2 int NULL,
	EX_FLD3 int NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_prd_typ_TYPE_ID PRIMARY KEY  
(
	TYPE_ID 
) 
) 
GO
/****** Object:  Table crl_prd_mst    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_prd_mst(
	PRODUCT_MASTER_ID nvarchar(13) NOT NULL,
	PRODUCT_NAME nvarchar(500) NULL,
	DESCRIPTION nvarchar(500) NULL,
	IMAGE_PATH nvarchar(500) NULL,
	CATEGORY_ID bigint NULL,
	COUNTRY_ID bigint NULL,
	UNIT_ID bigint NULL,
	TYPE_ID bigint NULL,
	MANUFACTURER_ID bigint NULL,
	SUPPLIER_ID bigint NULL,
	PACKAGER_ID bigint NULL,
	DISTRIBUTOR_ID bigint NULL,
	BARCODE nvarchar(13) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG int NULL,
	EX_FLD1 int NULL,
	EX_FLD2 int NULL,
	EX_FLD3 int NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_prd_mst_PRODUCT_MASTER_ID PRIMARY KEY  
(
	PRODUCT_MASTER_ID 
) 
) 
GO
/****** Object:  Table crl_prd    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_prd(
	PRODUCT_ID nvarchar(20) NOT NULL,
	PRODUCT_MASTER_ID nvarchar(13) NULL,
	BLOCK_ID bigint NULL,
	BLOCK_DETAIL_ID nvarchar(10) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	QUANTITY bigint NULL,
	PRICE bigint NULL,
	TAX_ID bigint NULL,
	EX_FLD1 int NULL,
	EX_FLD2 int NULL,
	EX_FLD3 int NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	BARCODE nvarchar(20) NULL
	,
 CONSTRAINT PK_crl_prd_PRODUCT_ID PRIMARY KEY  
(
	PRODUCT_ID 
) 
) 
GO
/****** Object:  Table crl_pos_trans    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_pos_trans(
	POS_Transaction_Id nvarchar(10) NOT NULL,
	Transaction_Id nvarchar(12) NOT NULL,
	Store_Id nvarchar(5) NOT NULL,
	Register_Id nvarchar(2) NOT NULL,
	Cashier_Id nvarchar(6) NOT NULL,
	Amount_In decimal(13, 2) NULL,
	Amount_Out decimal(13, 2) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	EX_FLD1 int NULL,
	EX_FLD2 int NULL,
	EX_FLD3 int NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	DEL_FLG int NULL
	,
 CONSTRAINT PK_crl_pos_trans_POS_Transaction_Id PRIMARY KEY  
(
	POS_Transaction_Id 
) 
) 
GO
/****** Object:  Table crl_pos_log    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_pos_log(
	Id bigint IDENTITY(1,1)  NOT NULL,
	Date datetime NOT NULL,
	Thread nvarchar(255) NOT NULL,
	Level nvarchar(50) NOT NULL,
	Logger nvarchar(255) NOT NULL,
	Message nvarchar(500) NOT NULL,
	Exception nvarchar(2000) NULL,
	Pos_User nvarchar(100) NULL,
	Pos_Action nvarchar(100) NULL
	,
 CONSTRAINT PK_crl_pos_log_Id PRIMARY KEY  
(
	Id 
) 
) 
GO
/****** Object:  Table crl_pkgr    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_pkgr(
	PACKAGER_ID bigint NOT NULL,
	PACKAGER_NAME nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_pkgr_PACKAGER_ID PRIMARY KEY  
(
	PACKAGER_ID 
) 
) 
GO
/****** Object:  Table crl_pblsh_cpn    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_pblsh_cpn(
	COUPON_ID bigint NOT NULL,
	PUBLISHED_COUPON_ID bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	START_DATE datetime NULL,
	END_DATE datetime NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_pblsh_cpn_COUPON_ID PRIMARY KEY  
(
	COUPON_ID ,
	PUBLISHED_COUPON_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_other_trans_log    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_other_trans_log(
	TRANSACTION_DATE datetime NOT NULL,
	TABLE_NAME bigint NOT NULL,
	FIELD_NAME bigint NULL,
	ACTION nvarchar(500) NULL,
	VALUE_BEFORE nvarchar(500) NULL,
	VALUE_AFTER nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_other_trans_log_TRANSACTION_DATE PRIMARY KEY  
(
	TRANSACTION_DATE 
) 
) 
GO
/****** Object:  Table crl_mnftr    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_mnftr(
	MANUFACTURER_ID bigint NOT NULL,
	MANUFACTURER_NAME nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_mnftr_MANUFACTURER_ID PRIMARY KEY  
(
	MANUFACTURER_ID 
) 
) 
GO
/****** Object:  Table crl_mn_stk_his    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_mn_stk_his(
	STOCK_HISTORY_ID bigint IDENTITY(1,1)  NOT NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	PRODUCT_MASTER_ID nvarchar(13) NOT NULL,
	QUANTITY bigint NOT NULL,
	CREATE_ID nvarchar(50) NULL,
	CREATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	STOCK_ID bigint NOT NULL,
	DESCRIPTION nvarchar(200) NULL,
	GOOD_COUNT bigint NULL,
	ERROR_COUNT bigint NULL,
	DAMAGE_COUNT bigint NULL,
	LOST_COUNT bigint NULL,
	UNCONFIRM_COUNT bigint NULL
	,
 CONSTRAINT PK_crl_mn_stk_his_STOCK_HISTORY_ID PRIMARY KEY  
(
	STOCK_HISTORY_ID 
) 
) 
GO
/****** Object:  Table crl_mn_stk    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_mn_stk(
	STOCK_ID bigint NOT NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	PRODUCT_MASTER_ID nvarchar(13) NULL,
	QUANTITY bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	GOOD_QUANTITY bigint NULL,
	ERROR_QUANTITY bigint NULL,
	DAMAGE_QUANTITY bigint NULL,
	LOST_QUANTITY bigint NULL,
	UNCONFIRM_QUANTITY bigint NULL,
	POSITION nvarchar(200) NULL
	,
 CONSTRAINT PK_crl_mn_stk_STOCK_ID PRIMARY KEY  
(
	STOCK_ID 
) 
) 
GO
/****** Object:  Table crl_mn_price    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_mn_price(
	DEPARTMENT_ID int NOT NULL,
	PRODUCT_MASTER_ID nvarchar(13) NOT NULL,
	PRICE int NOT NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY int NULL,
	DEL_FLG int NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	WHOLE_SALE_PRICE bigint NULL
	,
 CONSTRAINT PK_crl_mn_price_DEPARTMENT_ID PRIMARY KEY  
(
	DEPARTMENT_ID ,
	PRODUCT_MASTER_ID 
) 
) 
GO
/****** Object:  Table crl_gift    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_gift(
	GIFT_ID bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	GIFT_NAME nvarchar(500) NULL,
	QUANTITY bigint NULL,
	SUPPLIER_ID bigint NULL,
	PRICE bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_gift_GIFT_ID PRIMARY KEY  
(
	GIFT_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_ex_prd_size    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_ex_prd_size(
	SIZE_ID int NOT NULL,
	SIZE_NAME nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 int NULL,
	EX_FLD2 int NULL,
	EX_FLD3 int NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	,
 CONSTRAINT PK_crl_ex_prd_size_SIZE_ID PRIMARY KEY  
(
	SIZE_ID 
) 
) 
GO
/****** Object:  Table crl_ex_prd_color    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_ex_prd_color(
	COLOR_ID int NOT NULL,
	COLOR_NAME nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 int NULL,
	EX_FLD2 int NULL,
	EX_FLD3 int NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_ex_prd_color_COLOR_ID PRIMARY KEY  
(
	COLOR_ID 
) 
) 
GO
/****** Object:  Table crl_emp_wrkg_days    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_emp_wrkg_days(
	EMPLOYEE_ID nvarchar(20) NOT NULL,
	WORKING_DAY datetime NOT NULL,
	PERIOD bigint NULL,
	DEPARTMENT_ID bigint NOT NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	START_TIME datetime NULL,
	END_TIME datetime NULL
	,
 CONSTRAINT PK_crl_emp_wrkg_days_EMPLOYEE_ID PRIMARY KEY  
(
	EMPLOYEE_ID ,
	WORKING_DAY 
) 
) 
GO
/****** Object:  Table crl_emp_reward    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_emp_reward(
	EMPLOYEE_ID nvarchar(20) NOT NULL,
	REWARD_DATE datetime NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	REWARD_VALUE bigint NULL,
	REWARD_NAME nvarchar(500) NULL,
	MONEY_VALUE bigint NULL,
	GIFT_ID bigint NULL,
	GIFT_PRODUCT_ID bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_emp_reward_EMPLOYEE_ID PRIMARY KEY  
(
	EMPLOYEE_ID ,
	REWARD_DATE ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_emp_money    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_emp_money(
	EMPLOYEE_ID nvarchar(20) NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	DATE_LOGIN datetime NULL,
	DATE_LOGOUT datetime NULL,
	WORKING_DAY nvarchar(45) NOT NULL,
	IN_MONEY bigint NULL,
	OUT_MONEY bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_emp_money_EMPLOYEE_ID PRIMARY KEY  
(
	EMPLOYEE_ID ,
	DEPARTMENT_ID ,
	WORKING_DAY 
) 
) 
GO
/****** Object:  Table crl_emp_info    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_emp_info(
	EMPLOYEE_ID nvarchar(20) NOT NULL,
	EMPLOYEE_NAME nvarchar(500) NULL,
	ADDRESS nvarchar(500) NULL,
	BIRTHDAY datetime NULL,
	CONTRACT_ID bigint NULL,
	SALARY bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	MANAGER nvarchar(20) NULL,
	BARCODE nvarchar(10) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_emp_info_EMPLOYEE_ID PRIMARY KEY  
(
	EMPLOYEE_ID 
) 
) 
GO
/****** Object:  Table crl_emp_dayoff    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_emp_dayoff(
	EMPLOYEE_ID nvarchar(20) NOT NULL,
	DAYOFF_TIME datetime NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_emp_dayoff_EMPLOYEE_ID PRIMARY KEY  
(
	EMPLOYEE_ID ,
	DAYOFF_TIME ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_emp    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_emp(
	EMPLOYEE_ID nvarchar(20) NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	START_DATE datetime NULL,
	END_DATE datetime NULL
	,
 CONSTRAINT PK_crl_emp_EMPLOYEE_ID PRIMARY KEY  
(
	EMPLOYEE_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_distbtor    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_distbtor(
	DISTRIBUTOR_ID bigint NOT NULL,
	DISTRIBUTOR_NAME nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_distbtor_DISTRIBUTOR_ID PRIMARY KEY  
(
	DISTRIBUTOR_ID 
) 
) 
GO
/****** Object:  Table crl_dept_timeline    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_timeline(
	DEPARTMENT_ID bigint NOT NULL,
	PERIOD bigint NOT NULL,
	START_TIME datetime NULL,
	END_TIME datetime NULL,
	WORKING_DAY datetime NOT NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(45) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(45) NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_dept_timeline_DEPARTMENT_ID PRIMARY KEY  
(
	DEPARTMENT_ID ,
	PERIOD 
) 
) 
GO
/****** Object:  Table crl_dept_stk_temp_valid_save    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_stk_temp_valid_save(
	DEPARTMENT_ID bigint NOT NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	PRODUCT_MASTER_ID nvarchar(13) NULL,
	QUANTITY bigint NULL,
	ON_STORE_PRICE bigint NULL,
	CREATE_DATE datetime NOT NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	GOOD_QUANTITY bigint NULL,
	ERROR_QUANTITY bigint NULL,
	LOST_QUANTITY bigint NULL,
	DAMAGE_QUANTITY bigint NULL,
	UNCONFIRM_QUANTITY bigint NULL,
	FIXED bigint NOT NULL
	,
 CONSTRAINT PK_crl_dept_stk_temp_valid_save_DEPARTMENT_ID PRIMARY KEY  
(
	DEPARTMENT_ID ,
	PRODUCT_ID ,
	CREATE_DATE 
) 
) 
GO
/****** Object:  Table crl_dept_stk_temp_valid    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_stk_temp_valid(
	DEPARTMENT_ID bigint NOT NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	PRODUCT_MASTER_ID nvarchar(13) NULL,
	QUANTITY int NULL,
	ON_STORE_PRICE bigint NULL,
	CREATE_DATE datetime NOT NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	GOOD_QUANTITY int NULL,
	ERROR_QUANTITY int NULL,
	LOST_QUANTITY int NULL,
	DAMAGE_QUANTITY int NULL,
	UNCONFIRM_QUANTITY int NULL,
	FIXED bigint NOT NULL
	,
 CONSTRAINT PK_crl_dept_stk_temp_valid_DEPARTMENT_ID PRIMARY KEY  
(
	DEPARTMENT_ID ,
	PRODUCT_ID ,
	CREATE_DATE 
) 
) 
GO
/****** Object:  Table crl_dept_stk_out_det    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_stk_out_det(
	STOCK_OUT_ID bigint NOT NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	PRODUCT_MASTER_ID nvarchar(13) NULL,
	DEPARTMENT_ID bigint NOT NULL,
	QUANTITY bigint NULL,
	DESCRIPTION nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	DEFECT_STATUS_ID bigint NULL,
	STOCK_OUT_DETAIL_ID bigint NOT NULL,
	GOOD_QUANTITY bigint NULL,
	ERROR_QUANTITY bigint NULL,
	DAMAGE_QUANTITY bigint NULL,
	LOST_QUANTITY bigint NULL,
	UNCONFIRM_QUANTITY bigint NULL
	,
 CONSTRAINT PK_crl_dept_stk_out_det_STOCK_OUT_DETAIL_ID PRIMARY KEY  
(
	STOCK_OUT_DETAIL_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_stk_out_cst    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_stk_out_cst(
	STOCK_OUT_ID bigint NOT NULL,
	COST_TYPE bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	COST bigint NOT NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_dept_stk_out_cst_STOCK_OUT_ID PRIMARY KEY  
(
	STOCK_OUT_ID ,
	COST_TYPE ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_stk_out    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_stk_out(
	STOCK_OUT_ID bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	STOCK_OUT_DATE datetime NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	DESCRIPTION nvarchar(200) NULL,
	DEFECT_STATUS_ID bigint NULL,
	CONFIRM_FLG bigint NOT NULL,
	OTHER_DEPARTMENT_ID bigint NULL
	,
 CONSTRAINT PK_crl_dept_stk_out_STOCK_OUT_ID PRIMARY KEY  
(
	STOCK_OUT_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_stk_in_his    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_stk_in_his(
	STOCK_IN_ID nvarchar(15) NOT NULL,
	SOURCE_DEPARTMENTID bigint NOT NULL,
	STOCK_OUT_ID bigint NOT NULL,
	DEST_DEPARTMENT_ID bigint NOT NULL,
	DESCRIPTION nvarchar(200) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_dept_stk_in_his_STOCK_IN_ID PRIMARY KEY  
(
	STOCK_IN_ID ,
	STOCK_OUT_ID ,
	SOURCE_DEPARTMENTID ,
	DEST_DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_stk_in_det    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_stk_in_det(
	STOCK_IN_ID nvarchar(15) NOT NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	PRODUCT_MASTER_ID nvarchar(13) NULL,
	DEPARTMENT_ID bigint NOT NULL,
	QUANTITY bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	PRICE bigint NULL,
	ON_STORE_PRICE bigint NULL,
	SOLD bigint NULL
	,
 CONSTRAINT PK_crl_dept_stk_in_det_STOCK_IN_ID PRIMARY KEY  
(
	STOCK_IN_ID ,
	PRODUCT_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_stk_in_cst    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_stk_in_cst(
	STOCK_IN_ID nvarchar(15) NOT NULL,
	COST_TYPE bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	COST bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_dept_stk_in_cst_STOCK_IN_ID PRIMARY KEY  
(
	STOCK_IN_ID ,
	COST_TYPE ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_stk_in    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_stk_in(
	STOCK_IN_ID nvarchar(15) NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	STOCK_IN_DATE datetime NULL,
	DESCRIPTION nvarchar(2000) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	EXPORT_STATUS bigint NULL,
	STOCK_IN_COST bigint NULL,
	STOCK_IN_TYPE bigint NULL
	,
 CONSTRAINT PK_crl_dept_stk_in_STOCK_IN_ID PRIMARY KEY  
(
	STOCK_IN_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_stk_his    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_stk_his(
	DEPARTMENT_STOCK_HISTORY_ID bigint IDENTITY(1,1)  NOT NULL,
	PRODUCT_ID nvarchar(20) NULL,
	PRODUCT_MASTER_ID nvarchar(13) NULL,
	QUANTITY int NULL,
	CREATE_ID nvarchar(50) NULL,
	CREATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	DESCRIPTION nvarchar(200) NULL,
	GOOD_COUNT int NULL,
	ERROR_COUNT int NULL,
	DAMAGE_COUNT int NULL,
	LOST_COUNT int NULL,
	UNCONFIRM_COUNT int NULL,
	DEPARTMENT_ID bigint NOT NULL
	,
 CONSTRAINT PK_crl_dept_stk_his_DEPARTMENT_STOCK_HISTORY_ID PRIMARY KEY  
(
	DEPARTMENT_STOCK_HISTORY_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_stk    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_stk(
	DEPARTMENT_ID bigint NOT NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	PRODUCT_MASTER_ID nvarchar(13) NULL,
	QUANTITY int NULL,
	ON_STORE_PRICE int NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	GOOD_QUANTITY int NULL,
	ERROR_QUANTITY int NULL,
	LOST_QUANTITY int NULL,
	DAMAGE_QUANTITY int NULL,
	UNCONFIRM_QUANTITY int NULL,
	POSITION nvarchar(200) NULL
	,
 CONSTRAINT PK_crl_dept_stk_DEPARTMENT_ID PRIMARY KEY  
(
	DEPARTMENT_ID ,
	PRODUCT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_ret_po    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_ret_po(
	PURCHASE_ORDER_ID nvarchar(20) NOT NULL,
	PURCHASE_ORDER_DETAIL_ID bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	RETURN_DATE datetime NULL,
	DESCRIPTION nvarchar(500) NULL,
	QUANTITY bigint NULL,
	CREATE_DATE datetime NOT NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	NEXT_PURCHASE_ORDER_ID nvarchar(20) NULL,
	PRODUCT_ID nvarchar(20) NULL,
	PRICE bigint NULL
	,
 CONSTRAINT PK_crl_dept_ret_po_PURCHASE_ORDER_ID PRIMARY KEY  
(
	PURCHASE_ORDER_ID ,
	PURCHASE_ORDER_DETAIL_ID ,
	DEPARTMENT_ID ,
	CREATE_DATE 
) 
) 
GO
/****** Object:  Table crl_dept_ret_det    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_ret_det(
	DEPARTMENT_RETURN_ID bigint NOT NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	PRODUCT_MASTER_ID nvarchar(13) NULL,
	DEPARTMENT_ID bigint NOT NULL,
	QUANTITY bigint NULL,
	DESCRIPTION nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_dept_ret_det_DEPARTMENT_RETURN_ID PRIMARY KEY  
(
	DEPARTMENT_RETURN_ID ,
	PRODUCT_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_ret_cost    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_ret_cost(
	DEPARTMENT_RETURN_ID bigint NOT NULL,
	COST_TYPE bigint NOT NULL,
	COST bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_dept_ret_cost_DEPARTMENT_RETURN_ID PRIMARY KEY  
(
	DEPARTMENT_RETURN_ID ,
	COST_TYPE 
) 
) 
GO
/****** Object:  Table crl_dept_ret    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_ret(
	DEPARTMENT_RETURN_ID bigint NOT NULL,
	PRODUCT_ID nvarchar(20) NULL,
	DEPARTMENT_ID bigint NULL,
	RETURN_STATUS bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_dept_ret_DEPARTMENT_RETURN_ID PRIMARY KEY  
(
	DEPARTMENT_RETURN_ID 
) 
) 
GO
/****** Object:  Table crl_dept_prmtn    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_prmtn(
	DEPARTMENT_PROMOTION_ID bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	PROMOTION_ID bigint NOT NULL,
	PRODUCT_ID nvarchar(20) NOT NULL,
	START_DATE datetime NULL,
	END_DATE datetime NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_dept_prmtn_DEPARTMENT_PROMOTION_ID PRIMARY KEY  
(
	DEPARTMENT_PROMOTION_ID 
) 
) 
GO
/****** Object:  Table crl_dept_po_promo    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_po_promo(
	PURCHASE_ORDER_ID nvarchar(20) NOT NULL,
	PURCHASE_ORDER_DETAIL_ID bigint NOT NULL,
	ID bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	GIFT_DEPARTMENT_ID bigint NOT NULL,
	DEPARTMENT_PROMOTION_ID bigint NULL,
	GIFT_ID bigint NULL,
	GIFT_PRODUCT_ID bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_dept_po_promo_PURCHASE_ORDER_ID PRIMARY KEY  
(
	PURCHASE_ORDER_ID ,
	PURCHASE_ORDER_DETAIL_ID ,
	ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_po_log    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_po_log(
	PURCHASE_ORDER_LOG_ID bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	PURCHASE_ORDER_ID nvarchar(20) NOT NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_dept_po_log_PURCHASE_ORDER_LOG_ID PRIMARY KEY  
(
	PURCHASE_ORDER_LOG_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_po_det_log    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_po_det_log(
	PURCHASE_ORDER_DETAIL_LOG_ID bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	PURCHASE_ORDER_DETAIL_ID bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_dept_po_det_log_PURCHASE_ORDER_DETAIL_LOG_ID PRIMARY KEY  
(
	PURCHASE_ORDER_DETAIL_LOG_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_po_det    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_po_det(
	PURCHASE_ORDER_ID nvarchar(20) NOT NULL,
	PURCHASE_ORDER_DETAIL_ID bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	PRODUCT_ID nvarchar(20) NULL,
	QUANTITY bigint NULL,
	PRICE bigint NULL,
	PURCHASE_STATUS bigint NULL,
	TAX_ID bigint NULL,
	PURCHASE_TYPE bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	PRODUCT_MASTER_ID nvarchar(13) NOT NULL,
	NOTE nvarchar(200) NULL
	,
 CONSTRAINT PK_crl_dept_po_det_PURCHASE_ORDER_ID PRIMARY KEY  
(
	PURCHASE_ORDER_ID ,
	PURCHASE_ORDER_DETAIL_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_po    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_po(
	PURCHASE_ORDER_ID nvarchar(20) NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	PURCHASE_PRICE bigint NULL,
	ORDER_STATUS bigint NULL,
	CUSTOMER_ID bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	PURCHASE_DESCRIPTION nvarchar(500) NULL
	,
 CONSTRAINT PK_crl_dept_po_PURCHASE_ORDER_ID PRIMARY KEY  
(
	PURCHASE_ORDER_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_dept_mng    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_mng(
	DEPARTMENT_ID bigint NOT NULL,
	EMPLOYEE_ID nvarchar(20) NOT NULL,
	POSITION bigint NULL,
	CREATE_ID nvarchar(45) NULL,
	CREATE_DATE datetime NULL,
	UPDATE_ID nvarchar(45) NULL,
	UPDATE_DATE datetime NULL,
	WORKING_DAY datetime NOT NULL,
	START_TIME datetime NULL,
	END_TIME datetime NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_dept_mng_DEPARTMENT_ID PRIMARY KEY  
(
	DEPARTMENT_ID ,
	EMPLOYEE_ID ,
	WORKING_DAY 
) 
) 
GO
/****** Object:  Table crl_dept_cost    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept_cost(
	DEPARTMENT_ID bigint NOT NULL,
	COST_DATE datetime NOT NULL,
	COST_TYPE bigint NULL,
	COST_NAME nvarchar(500) NULL,
	COST_DESCRIPTION nvarchar(500) NULL,
	COST bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_dept_cost_DEPARTMENT_ID PRIMARY KEY  
(
	DEPARTMENT_ID ,
	COST_DATE 
) 
) 
GO
/****** Object:  Table crl_dept    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_dept(
	DEPARTMENT_ID bigint NOT NULL,
	DEPARTMENT_NAME nvarchar(500) NULL,
	ADDRESS nvarchar(500) NULL,
	ACTIVE bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	START_DATE datetime NULL
	,
 CONSTRAINT PK_crl_dept_DEPARTMENT_ID PRIMARY KEY  
(
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_cust_det    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_cust_det(
	CUSTOMER_ID bigint NOT NULL,
	ADDRESS nvarchar(500) NULL,
	COUNTRY_ID bigint NULL,
	BIRTHDAY date NULL,
	PASSPORT_NUMBER nvarchar(500) NULL,
	CMND nvarchar(500) NULL,
	MONEY_SPENT bigint NULL,
	BUY_COUNT bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL
	,
 CONSTRAINT PK_crl_cust_det_CUSTOMER_ID PRIMARY KEY  
(
	CUSTOMER_ID 
) 
) 
GO
/****** Object:  Table crl_cust    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_cust(
	CUSTOMER_ID bigint NOT NULL,
	CUSTOMER_NAME nvarchar(500) NULL,
	MONEY_SPENT bigint NULL,
	BUY_COUNT bigint NULL,
	NEAREST_COME_1 datetime NULL,
	NEAREST_COME_2 datetime NULL,
	NEAREST_COME_3 datetime NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_cust_CUSTOMER_ID PRIMARY KEY  
(
	CUSTOMER_ID 
) 
) 
GO
/****** Object:  Table crl_ctry    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_ctry(
	COUNTRY_ID bigint NOT NULL,
	COUNTRY_NAME nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_ctry_COUNTRY_ID PRIMARY KEY  
(
	COUNTRY_ID 
) 
) 
GO
/****** Object:  Table crl_coupon_typ    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_coupon_typ(
	COUPON_TYPE_ID bigint NOT NULL,
	COUPON_TYPE_NAME nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_coupon_typ_COUPON_TYPE_ID PRIMARY KEY  
(
	COUPON_TYPE_ID 
) 
) 
GO
/****** Object:  Table crl_coupon    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_coupon(
	COUPON_ID bigint NOT NULL,
	COUPON_NAME nvarchar(500) NULL,
	COUPON_TYPE bigint NULL,
	DISCOUNT_VALUE bigint NULL,
	DISCOUNT_PERCENT bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_coupon_COUPON_ID PRIMARY KEY  
(
	COUPON_ID 
) 
) 
GO
/****** Object:  Table crl_contract    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_contract(
	CONTRACT_ID bigint NOT NULL,
	DEPARTMENT_ID bigint NOT NULL,
	CONTRACT_NAME nvarchar(500) NULL,
	CONTRACT_TYPE bigint NULL,
	START_DATE datetime NULL,
	END_DATE datetime NULL,
	EMPLOYEE_ID nvarchar(20) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_contract_CONTRACT_ID PRIMARY KEY  
(
	CONTRACT_ID ,
	DEPARTMENT_ID 
) 
) 
GO
/****** Object:  Table crl_cat    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_cat(
	CATEGORY_ID bigint NOT NULL,
	PARENT_CATEGORY_ID bigint NULL,
	CATEGORY_NAME nvarchar(500) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 int NULL,
	EX_FLD2 int NULL,
	EX_FLD3 int NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_cat_CATEGORY_ID PRIMARY KEY  
(
	CATEGORY_ID 
) 
) 
GO
/****** Object:  Table crl_cash_io_trans    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_cash_io_trans(
	Cash_In_Out_Transaction_Id nvarchar(15) NOT NULL,
	Transaction_Id nvarchar(12) NOT NULL,
	Store_Id nvarchar(5) NOT NULL,
	Register_Id nvarchar(2) NOT NULL,
	Cashier_Id nvarchar(6) NOT NULL,
	Amount decimal(13, 2) NULL,
	Reason_Code int NULL,
	Customer_Id nvarchar(15) NULL,
	Comment nvarchar(1000) NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 int NULL,
	EX_FLD2 int NULL,
	EX_FLD3 int NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_cash_io_trans_Cash_In_Out_Transaction_Id PRIMARY KEY  
(
	Cash_In_Out_Transaction_Id 
) 
) 
GO
/****** Object:  Table crl_blk_in_det    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_blk_in_det(
	BLOCK_ID bigint NOT NULL,
	BLOCK_DETAIL_ID nvarchar(10) NOT NULL,
	DETAIL_VALUE nvarchar(500) NULL,
	MANUFACTURE_ID bigint NULL,
	PACKAGER_ID bigint NULL,
	COUNTRY_ID bigint NULL,
	SUPPLIER_ID bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL,
	STOCK_IN_ID bigint NULL,
	IMPORT_DATE datetime NULL
	,
 CONSTRAINT PK_crl_blk_in_det_BLOCK_ID PRIMARY KEY  
(
	BLOCK_ID ,
	BLOCK_DETAIL_ID 
) 
) 
GO
/****** Object:  Table crl_blk_in_cost    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_blk_in_cost(
	BLOCK_ID bigint NOT NULL,
	COST_TYPE bigint NOT NULL,
	COST bigint NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_blk_in_cost_BLOCK_ID PRIMARY KEY  
(
	BLOCK_ID ,
	COST_TYPE 
) 
) 
GO
/****** Object:  Table crl_blk_in    Script Date: 01/22/2010 00:05:09 ******/

GO

GO
CREATE TABLE crl_blk_in(
	BLOCK_ID bigint NOT NULL,
	BLOCK_NAME nvarchar(500) NULL,
	IMPORT_DATE datetime NULL,
	CREATE_DATE datetime NULL,
	CREATE_ID nvarchar(50) NULL,
	UPDATE_DATE datetime NULL,
	UPDATE_ID nvarchar(50) NULL,
	EXCLUSIVE_KEY bigint NULL,
	DEL_FLG bigint NULL,
	EX_FLD1 bigint NULL,
	EX_FLD2 bigint NULL,
	EX_FLD3 bigint NULL,
	EX_FLD4 nvarchar(45) NULL,
	EX_FLD5 nvarchar(45) NULL
	,
 CONSTRAINT PK_crl_blk_in_BLOCK_ID PRIMARY KEY  
(
	BLOCK_ID 
) 
) 
GO
/****** Object:  Default DF__crl_blk_i__BLOCK__7E6CC920    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in ADD  DEFAULT (NULL) FOR BLOCK_NAME
GO
/****** Object:  Default DF__crl_blk_i__IMPOR__7F60ED59    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in ADD  DEFAULT (NULL) FOR IMPORT_DATE
GO
/****** Object:  Default DF__crl_blk_i__CREAT__00551192    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_blk_i__CREAT__014935CB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_blk_i__UPDAT__023D5A04    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_blk_i__UPDAT__03317E3D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_blk_i__EXCLU__0425A276    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_blk_i__DEL_F__0519C6AF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__060DEAE8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__07020F21    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__07F6335A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__08EA5793    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__09DE7BCC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_5A829C6CEB90470DAEE1CBCAAC878160    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in ADD  CONSTRAINT MSmerge_df_rowguid_5A829C6CEB90470DAEE1CBCAAC878160  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_blk_in__COST__0BC6C43E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_cost ADD  DEFAULT (NULL) FOR COST
GO
/****** Object:  Default DF__crl_blk_i__CREAT__0CBAE877    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_cost ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_blk_i__CREAT__0DAF0CB0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_cost ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_blk_i__UPDAT__0EA330E9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_cost ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_blk_i__UPDAT__0F975522    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_cost ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_blk_i__EXCLU__108B795B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_cost ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_blk_i__DEL_F__117F9D94    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_cost ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__1273C1CD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_cost ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__1367E606    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_cost ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__145C0A3F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_cost ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__15502E78    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_cost ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__164452B1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_cost ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_AEAC4CF2DFC14406B6DCCB51CCE8FF8A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_cost ADD  CONSTRAINT MSmerge_df_rowguid_AEAC4CF2DFC14406B6DCCB51CCE8FF8A  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_blk_i__BLOCK__182C9B23    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (N'') FOR BLOCK_DETAIL_ID
GO
/****** Object:  Default DF__crl_blk_i__DETAI__1920BF5C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR DETAIL_VALUE
GO
/****** Object:  Default DF__crl_blk_i__MANUF__1A14E395    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR MANUFACTURE_ID
GO
/****** Object:  Default DF__crl_blk_i__PACKA__1B0907CE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR PACKAGER_ID
GO
/****** Object:  Default DF__crl_blk_i__COUNT__1BFD2C07    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR COUNTRY_ID
GO
/****** Object:  Default DF__crl_blk_i__SUPPL__1CF15040    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR SUPPLIER_ID
GO
/****** Object:  Default DF__crl_blk_i__CREAT__1DE57479    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_blk_i__CREAT__1ED998B2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_blk_i__UPDAT__1FCDBCEB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_blk_i__UPDAT__20C1E124    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_blk_i__EXCLU__21B6055D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_blk_i__DEL_F__22AA2996    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__239E4DCF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__24927208    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__25869641    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__267ABA7A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_blk_i__EX_FL__276EDEB3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_blk_i__STOCK__286302EC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR STOCK_IN_ID
GO
/****** Object:  Default DF__crl_blk_i__IMPOR__29572725    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  DEFAULT (NULL) FOR IMPORT_DATE
GO
/****** Object:  Default MSmerge_df_rowguid_5ACAAB0E340F4404B80FCF7E326DBAA7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_blk_in_det ADD  CONSTRAINT MSmerge_df_rowguid_5ACAAB0E340F4404B80FCF7E326DBAA7  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_cash___Amoun__2B3F6F97    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT (NULL) FOR Amount
GO
/****** Object:  Default DF__crl_cash___Reaso__2C3393D0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT (NULL) FOR Reason_Code
GO
/****** Object:  Default DF__crl_cash___Custo__2D27B809    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT (NULL) FOR Customer_Id
GO
/****** Object:  Default DF__crl_cash___Comme__2E1BDC42    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT (NULL) FOR Comment
GO
/****** Object:  Default DF__crl_cash___CREAT__2F10007B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_cash___CREAT__300424B4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_cash___UPDAT__30F848ED    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_cash___UPDAT__31EC6D26    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_cash___EXCLU__32E0915F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_cash___DEL_F__33D4B598    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_cash___EX_FL__34C8D9D1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_cash___EX_FL__35BCFE0A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_cash___EX_FL__36B12243    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_cash___EX_FL__37A5467C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_cash___EX_FL__38996AB5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_C7AD2966BF384A9888BBBD43FF19849D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cash_io_trans ADD  CONSTRAINT MSmerge_df_rowguid_C7AD2966BF384A9888BBBD43FF19849D  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_cat__PARENT___3A81B327    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cat ADD  DEFAULT (NULL) FOR PARENT_CATEGORY_ID
GO
/****** Object:  Default DF__crl_cat__CATEGOR__3B75D760    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cat ADD  DEFAULT (NULL) FOR CATEGORY_NAME
GO
/****** Object:  Default DF__crl_cat__CREATE___3C69FB99    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cat ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_cat__CREATE___3D5E1FD2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cat ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_cat__UPDATE___3E52440B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cat ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_cat__UPDATE___3F466844    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cat ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_cat__EXCLUSI__403A8C7D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cat ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_cat__DEL_FLG__412EB0B6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cat ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_cat__EX_FLD1__4222D4EF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cat ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_cat__EX_FLD2__4316F928    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cat ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_cat__EX_FLD3__440B1D61    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cat ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_cat__EX_FLD4__44FF419A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cat ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_cat__EX_FLD5__45F365D3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cat ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_AAD0D407FCF84443B38D9C6BF1FDE360    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cat ADD  CONSTRAINT MSmerge_df_rowguid_AAD0D407FCF84443B38D9C6BF1FDE360  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_contr__CONTR__47DBAE45    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (NULL) FOR CONTRACT_NAME
GO
/****** Object:  Default DF__crl_contr__CONTR__48CFD27E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (NULL) FOR CONTRACT_TYPE
GO
/****** Object:  Default DF__crl_contr__START__49C3F6B7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (NULL) FOR START_DATE
GO
/****** Object:  Default DF__crl_contr__END_D__4AB81AF0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (NULL) FOR END_DATE
GO
/****** Object:  Default DF__crl_contr__EMPLO__4BAC3F29    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (N'') FOR EMPLOYEE_ID
GO
/****** Object:  Default DF__crl_contr__CREAT__4CA06362    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_contr__CREAT__4D94879B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_contr__UPDAT__4E88ABD4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_contr__UPDAT__4F7CD00D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_contr__EXCLU__5070F446    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_contr__DEL_F__5165187F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_contr__EX_FL__52593CB8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_contr__EX_FL__534D60F1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_contr__EX_FL__5441852A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_contr__EX_FL__5535A963    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_contr__EX_FL__5629CD9C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_E2BBA345CDEA4A4699B91401DB1CD3CD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_contract ADD  CONSTRAINT MSmerge_df_rowguid_E2BBA345CDEA4A4699B91401DB1CD3CD  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_coupo__COUPO__5812160E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT (NULL) FOR COUPON_NAME
GO
/****** Object:  Default DF__crl_coupo__COUPO__59063A47    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT (NULL) FOR COUPON_TYPE
GO
/****** Object:  Default DF__crl_coupo__DISCO__59FA5E80    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT (NULL) FOR DISCOUNT_VALUE
GO
/****** Object:  Default DF__crl_coupo__DISCO__5AEE82B9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT (NULL) FOR DISCOUNT_PERCENT
GO
/****** Object:  Default DF__crl_coupo__CREAT__5BE2A6F2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_coupo__CREAT__5CD6CB2B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_coupo__UPDAT__5DCAEF64    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_coupo__UPDAT__5EBF139D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_coupo__EXCLU__5FB337D6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_coupo__DEL_F__60A75C0F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_coupo__EX_FL__619B8048    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_coupo__EX_FL__628FA481    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_coupo__EX_FL__6383C8BA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_coupo__EX_FL__6477ECF3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_coupo__EX_FL__656C112C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_4B47EDD01EFF4205AAAFCFCB9EAB5EAB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon ADD  CONSTRAINT MSmerge_df_rowguid_4B47EDD01EFF4205AAAFCFCB9EAB5EAB  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_coupo__COUPO__6754599E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon_typ ADD  DEFAULT (NULL) FOR COUPON_TYPE_NAME
GO
/****** Object:  Default DF__crl_coupo__CREAT__68487DD7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon_typ ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_coupo__CREAT__693CA210    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon_typ ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_coupo__UPDAT__6A30C649    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon_typ ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_coupo__UPDAT__6B24EA82    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon_typ ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_coupo__EXCLU__6C190EBB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon_typ ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_coupo__DEL_F__6D0D32F4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon_typ ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_coupo__EX_FL__6E01572D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon_typ ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_coupo__EX_FL__6EF57B66    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon_typ ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_coupo__EX_FL__6FE99F9F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon_typ ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_coupo__EX_FL__70DDC3D8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon_typ ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_coupo__EX_FL__71D1E811    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon_typ ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_A7AC2D59E51842E990AB4FD0A64BA020    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_coupon_typ ADD  CONSTRAINT MSmerge_df_rowguid_A7AC2D59E51842E990AB4FD0A64BA020  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_ctry__COUNTR__73BA3083    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ctry ADD  DEFAULT (NULL) FOR COUNTRY_NAME
GO
/****** Object:  Default DF__crl_ctry__CREATE__74AE54BC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ctry ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_ctry__CREATE__75A278F5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ctry ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_ctry__UPDATE__76969D2E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ctry ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_ctry__UPDATE__778AC167    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ctry ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_ctry__EXCLUS__787EE5A0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ctry ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_ctry__DEL_FL__797309D9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ctry ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_ctry__EX_FLD__7A672E12    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ctry ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_ctry__EX_FLD__7B5B524B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ctry ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_ctry__EX_FLD__7C4F7684    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ctry ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_ctry__EX_FLD__7D439ABD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ctry ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_ctry__EX_FLD__7E37BEF6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ctry ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_5ACD34EBE819460C888F5B438FF3D4DB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ctry ADD  CONSTRAINT MSmerge_df_rowguid_5ACD34EBE819460C888F5B438FF3D4DB  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_cust__CUSTOM__00200768    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR CUSTOMER_NAME
GO
/****** Object:  Default DF__crl_cust__MONEY___01142BA1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR MONEY_SPENT
GO
/****** Object:  Default DF__crl_cust__BUY_CO__02084FDA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR BUY_COUNT
GO
/****** Object:  Default DF__crl_cust__NEARES__02FC7413    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR NEAREST_COME_1
GO
/****** Object:  Default DF__crl_cust__NEARES__03F0984C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR NEAREST_COME_2
GO
/****** Object:  Default DF__crl_cust__NEARES__04E4BC85    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR NEAREST_COME_3
GO
/****** Object:  Default DF__crl_cust__CREATE__05D8E0BE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_cust__CREATE__06CD04F7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_cust__UPDATE__07C12930    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_cust__UPDATE__08B54D69    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_cust__EXCLUS__09A971A2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_cust__DEL_FL__0A9D95DB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_cust__EX_FLD__0B91BA14    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_cust__EX_FLD__0C85DE4D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_cust__EX_FLD__0D7A0286    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_cust__EX_FLD__0E6E26BF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_cust__EX_FLD__0F624AF8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_0F802BBC71164C87A8832071DF722695    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust ADD  CONSTRAINT MSmerge_df_rowguid_0F802BBC71164C87A8832071DF722695  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_cust___ADDRE__114A936A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust_det ADD  DEFAULT (NULL) FOR ADDRESS
GO
/****** Object:  Default DF__crl_cust___COUNT__123EB7A3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust_det ADD  DEFAULT (NULL) FOR COUNTRY_ID
GO
/****** Object:  Default DF__crl_cust___BIRTH__1332DBDC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust_det ADD  DEFAULT (NULL) FOR BIRTHDAY
GO
/****** Object:  Default DF__crl_cust___PASSP__14270015    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust_det ADD  DEFAULT (NULL) FOR PASSPORT_NUMBER
GO
/****** Object:  Default DF__crl_cust_d__CMND__151B244E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust_det ADD  DEFAULT (NULL) FOR CMND
GO
/****** Object:  Default DF__crl_cust___MONEY__160F4887    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust_det ADD  DEFAULT (NULL) FOR MONEY_SPENT
GO
/****** Object:  Default DF__crl_cust___BUY_C__17036CC0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust_det ADD  DEFAULT (NULL) FOR BUY_COUNT
GO
/****** Object:  Default DF__crl_cust___CREAT__17F790F9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust_det ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_cust___CREAT__18EBB532    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust_det ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_cust___UPDAT__19DFD96B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust_det ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_cust___UPDAT__1AD3FDA4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust_det ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_cust___EXCLU__1BC821DD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust_det ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_cust___DEL_F__1CBC4616    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust_det ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default MSmerge_df_rowguid_E5E2DEB3568D472B8DD1C103AF02B6ED    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_cust_det ADD  CONSTRAINT MSmerge_df_rowguid_E5E2DEB3568D472B8DD1C103AF02B6ED  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept__DEPART__1EA48E88    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT (NULL) FOR DEPARTMENT_NAME
GO
/****** Object:  Default DF__crl_dept__ADDRES__1F98B2C1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT (NULL) FOR ADDRESS
GO
/****** Object:  Default DF__crl_dept__ACTIVE__208CD6FA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT ('0') FOR ACTIVE
GO
/****** Object:  Default DF__crl_dept__CREATE__2180FB33    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept__CREATE__22751F6C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept__UPDATE__236943A5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept__UPDATE__245D67DE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept__EXCLUS__25518C17    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept__DEL_FL__2645B050    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept__EX_FLD__2739D489    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept__EX_FLD__282DF8C2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept__EX_FLD__29221CFB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept__EX_FLD__2A164134    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept__EX_FLD__2B0A656D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_dept__START___2BFE89A6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  DEFAULT (NULL) FOR START_DATE
GO
/****** Object:  Default MSmerge_df_rowguid_66CD410A2882452083D344AA5CF4863C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept ADD  CONSTRAINT MSmerge_df_rowguid_66CD410A2882452083D344AA5CF4863C  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___COST___2DE6D218    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT (NULL) FOR COST_TYPE
GO
/****** Object:  Default DF__crl_dept___COST___2EDAF651    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT (NULL) FOR COST_NAME
GO
/****** Object:  Default DF__crl_dept___COST___2FCF1A8A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT (NULL) FOR COST_DESCRIPTION
GO
/****** Object:  Default DF__crl_dept_c__COST__30C33EC3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT (NULL) FOR COST
GO
/****** Object:  Default DF__crl_dept___CREAT__31B762FC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__32AB8735    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__339FAB6E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__3493CFA7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__3587F3E0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__367C1819    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__37703C52    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__3864608B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__395884C4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__3A4CA8FD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__3B40CD36    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_6168F5CFDC994666B91A380B7065A230    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_cost ADD  CONSTRAINT MSmerge_df_rowguid_6168F5CFDC994666B91A380B7065A230  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___POSIT__3D2915A8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_mng ADD  DEFAULT ('0') FOR POSITION
GO
/****** Object:  Default DF__crl_dept___CREAT__3E1D39E1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_mng ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___CREAT__3F115E1A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_mng ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__40058253    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_mng ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__40F9A68C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_mng ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___START__41EDCAC5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_mng ADD  DEFAULT (NULL) FOR START_TIME
GO
/****** Object:  Default DF__crl_dept___END_T__42E1EEFE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_mng ADD  DEFAULT (NULL) FOR END_TIME
GO
/****** Object:  Default DF__crl_dept___DEL_F__43D61337    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_mng ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__44CA3770    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_mng ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__45BE5BA9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_mng ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__46B27FE2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_mng ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__47A6A41B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_mng ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__489AC854    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_mng ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_7C6981637B82412BA09877CD39EED648    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_mng ADD  CONSTRAINT MSmerge_df_rowguid_7C6981637B82412BA09877CD39EED648  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PURCH__4A8310C6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (N'') FOR PURCHASE_ORDER_ID
GO
/****** Object:  Default DF__crl_dept___PURCH__4B7734FF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (NULL) FOR PURCHASE_PRICE
GO
/****** Object:  Default DF__crl_dept___ORDER__4C6B5938    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (NULL) FOR ORDER_STATUS
GO
/****** Object:  Default DF__crl_dept___CUSTO__4D5F7D71    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (NULL) FOR CUSTOMER_ID
GO
/****** Object:  Default DF__crl_dept___CREAT__4E53A1AA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__4F47C5E3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__503BEA1C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__51300E55    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__5224328E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__531856C7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__540C7B00    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__55009F39    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__55F4C372    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__56E8E7AB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__57DD0BE4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_dept___PURCH__58D1301D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  DEFAULT (N'') FOR PURCHASE_DESCRIPTION
GO
/****** Object:  Default MSmerge_df_rowguid_CC6863CE71814138B3C564133CFF5D36    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po ADD  CONSTRAINT MSmerge_df_rowguid_CC6863CE71814138B3C564133CFF5D36  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PURCH__5AB9788F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (N'') FOR PURCHASE_ORDER_ID
GO
/****** Object:  Default DF__crl_dept___PRODU__5BAD9CC8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_dept___QUANT__5CA1C101    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default DF__crl_dept___PRICE__5D95E53A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR PRICE
GO
/****** Object:  Default DF__crl_dept___PURCH__5E8A0973    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR PURCHASE_STATUS
GO
/****** Object:  Default DF__crl_dept___TAX_I__5F7E2DAC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR TAX_ID
GO
/****** Object:  Default DF__crl_dept___PURCH__607251E5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR PURCHASE_TYPE
GO
/****** Object:  Default DF__crl_dept___CREAT__6166761E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__625A9A57    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__634EBE90    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__6442E2C9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__65370702    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__662B2B3B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__671F4F74    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__681373AD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__690797E6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__69FBBC1F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__6AEFE058    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_dept___PRODU__6BE40491    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (N'') FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_dept_p__NOTE__6CD828CA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  DEFAULT (NULL) FOR NOTE
GO
/****** Object:  Default MSmerge_df_rowguid_257818B0B825468EAD27CE4D5EBB247D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det ADD  CONSTRAINT MSmerge_df_rowguid_257818B0B825468EAD27CE4D5EBB247D  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PURCH__6EC0713C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det_log ADD  DEFAULT (NULL) FOR PURCHASE_ORDER_DETAIL_ID
GO
/****** Object:  Default DF__crl_dept___CREAT__6FB49575    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det_log ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__70A8B9AE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det_log ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__719CDDE7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det_log ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__72910220    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det_log ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__73852659    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det_log ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__74794A92    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det_log ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__756D6ECB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det_log ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__76619304    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det_log ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__7755B73D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det_log ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__7849DB76    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det_log ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__793DFFAF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det_log ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_C72B00C7E4B34A37B381DD3BE6507814    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_det_log ADD  CONSTRAINT MSmerge_df_rowguid_C72B00C7E4B34A37B381DD3BE6507814  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PURCH__7B264821    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_log ADD  DEFAULT (N'') FOR PURCHASE_ORDER_ID
GO
/****** Object:  Default DF__crl_dept___CREAT__7C1A6C5A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_log ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__7D0E9093    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_log ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__7E02B4CC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_log ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__7EF6D905    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_log ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__7FEAFD3E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_log ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__00DF2177    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_log ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__01D345B0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_log ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__02C769E9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_log ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__03BB8E22    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_log ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__04AFB25B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_log ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__05A3D694    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_log ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_73535E690B9B4B798C9CD2A5F5EA0165    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_log ADD  CONSTRAINT MSmerge_df_rowguid_73535E690B9B4B798C9CD2A5F5EA0165  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PURCH__078C1F06    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT (N'') FOR PURCHASE_ORDER_ID
GO
/****** Object:  Default DF__crl_dept___DEPAR__0880433F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT (NULL) FOR DEPARTMENT_PROMOTION_ID
GO
/****** Object:  Default DF__crl_dept___GIFT___09746778    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT (NULL) FOR GIFT_ID
GO
/****** Object:  Default DF__crl_dept___GIFT___0A688BB1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT (NULL) FOR GIFT_PRODUCT_ID
GO
/****** Object:  Default DF__crl_dept___CREAT__0B5CAFEA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__0C50D423    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__0D44F85C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__0E391C95    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__0F2D40CE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__10216507    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__11158940    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__1209AD79    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__12FDD1B2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__13F1F5EB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__14E61A24    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_707542F0786842A48175FCD9C147CEB5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_po_promo ADD  CONSTRAINT MSmerge_df_rowguid_707542F0786842A48175FCD9C147CEB5  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PRODU__16CE6296    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_dept___START__17C286CF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  DEFAULT (NULL) FOR START_DATE
GO
/****** Object:  Default DF__crl_dept___END_D__18B6AB08    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  DEFAULT (NULL) FOR END_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__19AACF41    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__1A9EF37A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__1B9317B3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__1C873BEC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__1D7B6025    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__1E6F845E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__1F63A897    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__2057CCD0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__214BF109    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__22401542    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__2334397B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_811123CF523C46E4979D4A9CFDF204E3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_prmtn ADD  CONSTRAINT MSmerge_df_rowguid_811123CF523C46E4979D4A9CFDF204E3  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PRODU__251C81ED    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  DEFAULT (NULL) FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_dept___DEPAR__2610A626    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  DEFAULT (NULL) FOR DEPARTMENT_ID
GO
/****** Object:  Default DF__crl_dept___RETUR__2704CA5F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  DEFAULT (NULL) FOR RETURN_STATUS
GO
/****** Object:  Default DF__crl_dept___CREAT__27F8EE98    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__28ED12D1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__29E1370A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__2AD55B43    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__2BC97F7C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__2CBDA3B5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__2DB1C7EE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__2EA5EC27    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__2F9A1060    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__308E3499    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__318258D2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_A2F5424762D745AB98D0FD543EE758AD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret ADD  CONSTRAINT MSmerge_df_rowguid_A2F5424762D745AB98D0FD543EE758AD  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept_r__COST__336AA144    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_cost ADD  DEFAULT (NULL) FOR COST
GO
/****** Object:  Default DF__crl_dept___CREAT__345EC57D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_cost ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__3552E9B6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_cost ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__36470DEF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_cost ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__373B3228    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_cost ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__382F5661    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_cost ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__39237A9A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_cost ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__3A179ED3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_cost ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__3B0BC30C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_cost ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__3BFFE745    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_cost ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__3CF40B7E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_cost ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__3DE82FB7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_cost ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_268E07B8911742409A8A4E69B6CA35A7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_cost ADD  CONSTRAINT MSmerge_df_rowguid_268E07B8911742409A8A4E69B6CA35A7  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PRODU__3FD07829    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_dept___PRODU__40C49C62    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT (NULL) FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_dept___QUANT__41B8C09B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default DF__crl_dept___DESCR__42ACE4D4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT (NULL) FOR DESCRIPTION
GO
/****** Object:  Default DF__crl_dept___CREAT__43A1090D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__44952D46    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__4589517F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__467D75B8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__477199F1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__4865BE2A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__4959E263    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__4A4E069C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__4B422AD5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__4C364F0E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__4D2A7347    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_837A9630A5914976AC702E5AA2A7F698    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_det ADD  CONSTRAINT MSmerge_df_rowguid_837A9630A5914976AC702E5AA2A7F698  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PURCH__4F12BBB9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (N'') FOR PURCHASE_ORDER_ID
GO
/****** Object:  Default DF__crl_dept___RETUR__5006DFF2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR RETURN_DATE
GO
/****** Object:  Default DF__crl_dept___DESCR__50FB042B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR DESCRIPTION
GO
/****** Object:  Default DF__crl_dept___QUANT__51EF2864    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default DF__crl_dept___CREAT__52E34C9D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__53D770D6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__54CB950F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__55BFB948    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__56B3DD81    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__57A801BA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__589C25F3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__59904A2C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__5A846E65    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__5B78929E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_dept___NEXT___5C6CB6D7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR NEXT_PURCHASE_ORDER_ID
GO
/****** Object:  Default DF__crl_dept___PRODU__5D60DB10    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_dept___PRICE__5E54FF49    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  DEFAULT (NULL) FOR PRICE
GO
/****** Object:  Default MSmerge_df_rowguid_AD85CFB1A49C45C596C0BAD8D8508117    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_ret_po ADD  CONSTRAINT MSmerge_df_rowguid_AD85CFB1A49C45C596C0BAD8D8508117  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PRODU__603D47BB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_dept___PRODU__61316BF4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_dept___QUANT__6225902D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default DF__crl_dept___ON_ST__6319B466    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR ON_STORE_PRICE
GO
/****** Object:  Default DF__crl_dept___CREAT__640DD89F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__6501FCD8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__65F62111    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__66EA454A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__67DE6983    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__68D28DBC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__69C6B1F5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__6ABAD62E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__6BAEFA67    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__6CA31EA0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__6D9742D9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_dept___GOOD___6E8B6712    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR GOOD_QUANTITY
GO
/****** Object:  Default DF__crl_dept___ERROR__6F7F8B4B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR ERROR_QUANTITY
GO
/****** Object:  Default DF__crl_dept___LOST___7073AF84    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR LOST_QUANTITY
GO
/****** Object:  Default DF__crl_dept___DAMAG__7167D3BD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR DAMAGE_QUANTITY
GO
/****** Object:  Default DF__crl_dept___UNCON__725BF7F6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR UNCONFIRM_QUANTITY
GO
/****** Object:  Default DF__crl_dept___POSIT__73501C2F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  DEFAULT (NULL) FOR POSITION
GO
/****** Object:  Default MSmerge_df_rowguid_E3794C1F6907430B88C1A1DEEEBC9F13    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk ADD  CONSTRAINT MSmerge_df_rowguid_E3794C1F6907430B88C1A1DEEEBC9F13  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PRODU__753864A1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT (NULL) FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_dept___PRODU__762C88DA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT (NULL) FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_dept___QUANT__7720AD13    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default DF__crl_dept___CREAT__7814D14C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___CREAT__7908F585    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__79FD19BE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__7AF13DF7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___EXCLU__7BE56230    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT ('1') FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__7CD98669    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__7DCDAAA2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__7EC1CEDB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__7FB5F314    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__00AA174D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__019E3B86    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_dept___DESCR__02925FBF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT (NULL) FOR DESCRIPTION
GO
/****** Object:  Default DF__crl_dept___GOOD___038683F8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT ('0') FOR GOOD_COUNT
GO
/****** Object:  Default DF__crl_dept___ERROR__047AA831    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT ('0') FOR ERROR_COUNT
GO
/****** Object:  Default DF__crl_dept___DAMAG__056ECC6A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT ('0') FOR DAMAGE_COUNT
GO
/****** Object:  Default DF__crl_dept___LOST___0662F0A3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT ('0') FOR LOST_COUNT
GO
/****** Object:  Default DF__crl_dept___UNCON__075714DC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  DEFAULT ('0') FOR UNCONFIRM_COUNT
GO
/****** Object:  Default MSmerge_df_rowguid_96C977626FFB41FA8BB1B0B627ECBF05    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his ADD  CONSTRAINT MSmerge_df_rowguid_96C977626FFB41FA8BB1B0B627ECBF05  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___STOCK__093F5D4E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT (N'') FOR STOCK_IN_ID
GO
/****** Object:  Default DF__crl_dept___STOCK__0A338187    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT (NULL) FOR STOCK_IN_DATE
GO
/****** Object:  Default DF__crl_dept___DESCR__0B27A5C0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT (NULL) FOR DESCRIPTION
GO
/****** Object:  Default DF__crl_dept___CREAT__0C1BC9F9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__0D0FEE32    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__0E04126B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__0EF836A4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__0FEC5ADD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__10E07F16    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__11D4A34F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__12C8C788    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__13BCEBC1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__14B10FFA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__15A53433    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_dept___EXPOR__1699586C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT ('0') FOR EXPORT_STATUS
GO
/****** Object:  Default DF__crl_dept___STOCK__178D7CA5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT ('0') FOR STOCK_IN_COST
GO
/****** Object:  Default DF__crl_dept___STOCK__1881A0DE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  DEFAULT ('0') FOR STOCK_IN_TYPE
GO
/****** Object:  Default MSmerge_df_rowguid_B30A2A9BBE4B4D6F81EE9BBF9E441FDC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in ADD  CONSTRAINT MSmerge_df_rowguid_B30A2A9BBE4B4D6F81EE9BBF9E441FDC  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___STOCK__1A69E950    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_cst ADD  DEFAULT (N'') FOR STOCK_IN_ID
GO
/****** Object:  Default DF__crl_dept_s__COST__1B5E0D89    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_cst ADD  DEFAULT (NULL) FOR COST
GO
/****** Object:  Default DF__crl_dept___CREAT__1C5231C2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_cst ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__1D4655FB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_cst ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__1E3A7A34    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_cst ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__1F2E9E6D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_cst ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__2022C2A6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_cst ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__2116E6DF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_cst ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__220B0B18    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_cst ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__22FF2F51    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_cst ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__23F3538A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_cst ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__24E777C3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_cst ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__25DB9BFC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_cst ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_A8A1894D9F384FD1BC0D4F82AC1B926C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_cst ADD  CONSTRAINT MSmerge_df_rowguid_A8A1894D9F384FD1BC0D4F82AC1B926C  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___STOCK__27C3E46E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (N'') FOR STOCK_IN_ID
GO
/****** Object:  Default DF__crl_dept___PRODU__28B808A7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_dept___PRODU__29AC2CE0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (NULL) FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_dept___QUANT__2AA05119    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default DF__crl_dept___CREAT__2B947552    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__2C88998B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__2D7CBDC4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__2E70E1FD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__2F650636    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__30592A6F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__314D4EA8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__324172E1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__3335971A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__3429BB53    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__351DDF8C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_dept___PRICE__361203C5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (NULL) FOR PRICE
GO
/****** Object:  Default DF__crl_dept___ON_ST__370627FE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT (NULL) FOR ON_STORE_PRICE
GO
/****** Object:  Default DF__crl_dept_s__SOLD__37FA4C37    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  DEFAULT ('0') FOR SOLD
GO
/****** Object:  Default MSmerge_df_rowguid_22123830A5624B1ABACD31D5D77080A3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_det ADD  CONSTRAINT MSmerge_df_rowguid_22123830A5624B1ABACD31D5D77080A3  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___DESCR__39E294A9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_his ADD  DEFAULT (NULL) FOR DESCRIPTION
GO
/****** Object:  Default DF__crl_dept___CREAT__3AD6B8E2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_his ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__3BCADD1B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_his ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__3CBF0154    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_his ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__3DB3258D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_his ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__3EA749C6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_his ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__3F9B6DFF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_his ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__408F9238    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_his ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__4183B671    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_his ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__4277DAAA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_his ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__436BFEE3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_his ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__4460231C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_his ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_E2201C047DC74230A0954B2E22B752F5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_in_his ADD  CONSTRAINT MSmerge_df_rowguid_E2201C047DC74230A0954B2E22B752F5  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___STOCK__46486B8E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT (NULL) FOR STOCK_OUT_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__473C8FC7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__4830B400    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__4924D839    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__4A18FC72    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__4B0D20AB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__4C0144E4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__4CF5691D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__4DE98D56    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__4EDDB18F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__4FD1D5C8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__50C5FA01    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_dept___DESCR__51BA1E3A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT (NULL) FOR DESCRIPTION
GO
/****** Object:  Default DF__crl_dept___DEFEC__52AE4273    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT (NULL) FOR DEFECT_STATUS_ID
GO
/****** Object:  Default DF__crl_dept___CONFI__53A266AC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT ('0') FOR CONFIRM_FLG
GO
/****** Object:  Default DF__crl_dept___OTHER__54968AE5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  DEFAULT ('0') FOR OTHER_DEPARTMENT_ID
GO
/****** Object:  Default MSmerge_df_rowguid_881C1554B8C04DA980968BDB58CB3812    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out ADD  CONSTRAINT MSmerge_df_rowguid_881C1554B8C04DA980968BDB58CB3812  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___CREAT__567ED357    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_cst ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__5772F790    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_cst ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__58671BC9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_cst ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__595B4002    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_cst ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__5A4F643B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_cst ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__5B438874    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_cst ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__5C37ACAD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_cst ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__5D2BD0E6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_cst ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__5E1FF51F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_cst ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__5F141958    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_cst ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__60083D91    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_cst ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_575388CC445E4D60A565C124FBAFC833    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_cst ADD  CONSTRAINT MSmerge_df_rowguid_575388CC445E4D60A565C124FBAFC833  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PRODU__61F08603    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_dept___PRODU__62E4AA3C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (NULL) FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_dept___QUANT__63D8CE75    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default DF__crl_dept___DESCR__64CCF2AE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (NULL) FOR DESCRIPTION
GO
/****** Object:  Default DF__crl_dept___CREAT__65C116E7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__66B53B20    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__67A95F59    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__689D8392    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__6991A7CB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__6A85CC04    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__6B79F03D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__6C6E1476    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__6D6238AF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__6E565CE8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__6F4A8121    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_dept___DEFEC__703EA55A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT (NULL) FOR DEFECT_STATUS_ID
GO
/****** Object:  Default DF__crl_dept___STOCK__7132C993    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT ('0') FOR STOCK_OUT_DETAIL_ID
GO
/****** Object:  Default DF__crl_dept___GOOD___7226EDCC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT ('0') FOR GOOD_QUANTITY
GO
/****** Object:  Default DF__crl_dept___ERROR__731B1205    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT ('0') FOR ERROR_QUANTITY
GO
/****** Object:  Default DF__crl_dept___DAMAG__740F363E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT ('0') FOR DAMAGE_QUANTITY
GO
/****** Object:  Default DF__crl_dept___LOST___75035A77    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT ('0') FOR LOST_QUANTITY
GO
/****** Object:  Default DF__crl_dept___UNCON__75F77EB0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  DEFAULT ('0') FOR UNCONFIRM_QUANTITY
GO
/****** Object:  Default MSmerge_df_rowguid_C807DEF816D64EF281AFA03AEB5B80FC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_out_det ADD  CONSTRAINT MSmerge_df_rowguid_C807DEF816D64EF281AFA03AEB5B80FC  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PRODU__77DFC722    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_dept___PRODU__78D3EB5B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT (NULL) FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_dept___QUANT__79C80F94    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default DF__crl_dept___ON_ST__7ABC33CD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT (NULL) FOR ON_STORE_PRICE
GO
/****** Object:  Default DF__crl_dept___CREAT__7BB05806    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__7CA47C3F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__7D98A078    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__7E8CC4B1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT ('0') FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__7F80E8EA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__00750D23    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__0169315C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__025D5595    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__035179CE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__04459E07    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_dept___GOOD___0539C240    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT ('0') FOR GOOD_QUANTITY
GO
/****** Object:  Default DF__crl_dept___ERROR__062DE679    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT ('0') FOR ERROR_QUANTITY
GO
/****** Object:  Default DF__crl_dept___LOST___07220AB2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT ('0') FOR LOST_QUANTITY
GO
/****** Object:  Default DF__crl_dept___DAMAG__08162EEB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT ('0') FOR DAMAGE_QUANTITY
GO
/****** Object:  Default DF__crl_dept___UNCON__090A5324    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT ('0') FOR UNCONFIRM_QUANTITY
GO
/****** Object:  Default DF__crl_dept___FIXED__09FE775D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  DEFAULT ('0') FOR FIXED
GO
/****** Object:  Default MSmerge_df_rowguid_9475FE24ABF84564B6B325DA105CF587    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid ADD  CONSTRAINT MSmerge_df_rowguid_9475FE24ABF84564B6B325DA105CF587  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PRODU__0BE6BFCF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_dept___PRODU__0CDAE408    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_dept___QUANT__0DCF0841    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default DF__crl_dept___ON_ST__0EC32C7A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR ON_STORE_PRICE
GO
/****** Object:  Default DF__crl_dept___CREAT__0FB750B3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__10AB74EC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__119F9925    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___EXCLU__1293BD5E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_dept___DEL_F__1387E197    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__147C05D0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__15702A09    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__16644E42    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__1758727B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__184C96B4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_dept___GOOD___1940BAED    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR GOOD_QUANTITY
GO
/****** Object:  Default DF__crl_dept___ERROR__1A34DF26    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR ERROR_QUANTITY
GO
/****** Object:  Default DF__crl_dept___LOST___1B29035F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR LOST_QUANTITY
GO
/****** Object:  Default DF__crl_dept___DAMAG__1C1D2798    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR DAMAGE_QUANTITY
GO
/****** Object:  Default DF__crl_dept___UNCON__1D114BD1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT (NULL) FOR UNCONFIRM_QUANTITY
GO
/****** Object:  Default DF__crl_dept___FIXED__1E05700A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  DEFAULT ('0') FOR FIXED
GO
/****** Object:  Default MSmerge_df_rowguid_85F7E41574F240B582998E675E76D224    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_temp_valid_save ADD  CONSTRAINT MSmerge_df_rowguid_85F7E41574F240B582998E675E76D224  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_dept___PERIO__1FEDB87C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_timeline ADD  DEFAULT ('1') FOR PERIOD
GO
/****** Object:  Default DF__crl_dept___START__20E1DCB5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_timeline ADD  DEFAULT (NULL) FOR START_TIME
GO
/****** Object:  Default DF__crl_dept___END_T__21D600EE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_timeline ADD  DEFAULT (NULL) FOR END_TIME
GO
/****** Object:  Default DF__crl_dept___CREAT__22CA2527    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_timeline ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_dept___CREAT__23BE4960    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_timeline ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_dept___UPDAT__24B26D99    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_timeline ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_dept___UPDAT__25A691D2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_timeline ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_dept___DEL_F__269AB60B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_timeline ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_dept___EX_FL__278EDA44    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_timeline ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_dept___EX_FL__2882FE7D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_timeline ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_dept___EX_FL__297722B6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_timeline ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_dept___EX_FL__2A6B46EF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_timeline ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_dept___EX_FL__2B5F6B28    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_timeline ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_7A9D656C610F4C2B9C33A05840653E05    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_timeline ADD  CONSTRAINT MSmerge_df_rowguid_7A9D656C610F4C2B9C33A05840653E05  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_distb__DISTR__2D47B39A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_distbtor ADD  DEFAULT (NULL) FOR DISTRIBUTOR_NAME
GO
/****** Object:  Default DF__crl_distb__CREAT__2E3BD7D3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_distbtor ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_distb__CREAT__2F2FFC0C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_distbtor ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_distb__UPDAT__30242045    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_distbtor ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_distb__UPDAT__3118447E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_distbtor ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_distb__EXCLU__320C68B7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_distbtor ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_distb__DEL_F__33008CF0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_distbtor ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_distb__EX_FL__33F4B129    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_distbtor ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_distb__EX_FL__34E8D562    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_distbtor ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_distb__EX_FL__35DCF99B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_distbtor ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_distb__EX_FL__36D11DD4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_distbtor ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_distb__EX_FL__37C5420D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_distbtor ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_60C0B7BE4183404E920B7A2FB8AFBF79    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_distbtor ADD  CONSTRAINT MSmerge_df_rowguid_60C0B7BE4183404E920B7A2FB8AFBF79  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_emp__EMPLOYE__39AD8A7F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  DEFAULT (N'') FOR EMPLOYEE_ID
GO
/****** Object:  Default DF__crl_emp__CREATE___3AA1AEB8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_emp__CREATE___3B95D2F1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_emp__UPDATE___3C89F72A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_emp__UPDATE___3D7E1B63    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_emp__EXCLUSI__3E723F9C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_emp__DEL_FLG__3F6663D5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_emp__EX_FLD1__405A880E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_emp__EX_FLD2__414EAC47    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_emp__EX_FLD3__4242D080    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_emp__EX_FLD4__4336F4B9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_emp__EX_FLD5__442B18F2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_emp__START_D__451F3D2B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  DEFAULT (NULL) FOR START_DATE
GO
/****** Object:  Default DF__crl_emp__END_DAT__46136164    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  DEFAULT (NULL) FOR END_DATE
GO
/****** Object:  Default MSmerge_df_rowguid_B7FA69F61257480BA728D9B490ABCBB3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp ADD  CONSTRAINT MSmerge_df_rowguid_B7FA69F61257480BA728D9B490ABCBB3  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_emp_d__EMPLO__47FBA9D6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_dayoff ADD  DEFAULT (N'') FOR EMPLOYEE_ID
GO
/****** Object:  Default DF__crl_emp_d__CREAT__48EFCE0F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_dayoff ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_emp_d__CREAT__49E3F248    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_dayoff ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_emp_d__UPDAT__4AD81681    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_dayoff ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_emp_d__UPDAT__4BCC3ABA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_dayoff ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_emp_d__EXCLU__4CC05EF3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_dayoff ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_emp_d__DEL_F__4DB4832C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_dayoff ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_emp_d__EX_FL__4EA8A765    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_dayoff ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_emp_d__EX_FL__4F9CCB9E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_dayoff ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_emp_d__EX_FL__5090EFD7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_dayoff ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_emp_d__EX_FL__51851410    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_dayoff ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_emp_d__EX_FL__52793849    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_dayoff ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_B5541F747C97416C8A44624F593D63C1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_dayoff ADD  CONSTRAINT MSmerge_df_rowguid_B5541F747C97416C8A44624F593D63C1  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_emp_i__EMPLO__546180BB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (N'') FOR EMPLOYEE_ID
GO
/****** Object:  Default DF__crl_emp_i__EMPLO__5555A4F4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR EMPLOYEE_NAME
GO
/****** Object:  Default DF__crl_emp_i__ADDRE__5649C92D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR ADDRESS
GO
/****** Object:  Default DF__crl_emp_i__BIRTH__573DED66    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR BIRTHDAY
GO
/****** Object:  Default DF__crl_emp_i__CONTR__5832119F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR CONTRACT_ID
GO
/****** Object:  Default DF__crl_emp_i__SALAR__592635D8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR SALARY
GO
/****** Object:  Default DF__crl_emp_i__CREAT__5A1A5A11    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_emp_i__CREAT__5B0E7E4A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_emp_i__UPDAT__5C02A283    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_emp_i__UPDAT__5CF6C6BC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_emp_i__MANAG__5DEAEAF5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (N'0') FOR MANAGER
GO
/****** Object:  Default DF__crl_emp_i__BARCO__5EDF0F2E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR BARCODE
GO
/****** Object:  Default DF__crl_emp_i__EXCLU__5FD33367    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_emp_i__DEL_F__60C757A0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_emp_i__EX_FL__61BB7BD9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_emp_i__EX_FL__62AFA012    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_emp_i__EX_FL__63A3C44B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_emp_i__EX_FL__6497E884    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_emp_i__EX_FL__658C0CBD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_FEE1E29D68234976B32E7C9503F1B6C6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_info ADD  CONSTRAINT MSmerge_df_rowguid_FEE1E29D68234976B32E7C9503F1B6C6  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_emp_m__DATE___6774552F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT (NULL) FOR DATE_LOGIN
GO
/****** Object:  Default DF__crl_emp_m__DATE___68687968    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT (NULL) FOR DATE_LOGOUT
GO
/****** Object:  Default DF__crl_emp_m__IN_MO__695C9DA1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT ('0') FOR IN_MONEY
GO
/****** Object:  Default DF__crl_emp_m__OUT_M__6A50C1DA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT ('0') FOR OUT_MONEY
GO
/****** Object:  Default DF__crl_emp_m__CREAT__6B44E613    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_emp_m__CREAT__6C390A4C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_emp_m__UPDAT__6D2D2E85    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_emp_m__UPDAT__6E2152BE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_emp_m__EXCLU__6F1576F7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_emp_m__DEL_F__70099B30    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_emp_m__EX_FL__70FDBF69    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_emp_m__EX_FL__71F1E3A2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_emp_m__EX_FL__72E607DB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_emp_m__EX_FL__73DA2C14    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_emp_m__EX_FL__74CE504D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_4228BB10C42A4769923EA022AEAC1FCD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_money ADD  CONSTRAINT MSmerge_df_rowguid_4228BB10C42A4769923EA022AEAC1FCD  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_emp_r__EMPLO__76B698BF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (N'') FOR EMPLOYEE_ID
GO
/****** Object:  Default DF__crl_emp_r__REWAR__77AABCF8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR REWARD_VALUE
GO
/****** Object:  Default DF__crl_emp_r__REWAR__789EE131    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR REWARD_NAME
GO
/****** Object:  Default DF__crl_emp_r__MONEY__7993056A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR MONEY_VALUE
GO
/****** Object:  Default DF__crl_emp_r__GIFT___7A8729A3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR GIFT_ID
GO
/****** Object:  Default DF__crl_emp_r__GIFT___7B7B4DDC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR GIFT_PRODUCT_ID
GO
/****** Object:  Default DF__crl_emp_r__CREAT__7C6F7215    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_emp_r__CREAT__7D63964E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_emp_r__UPDAT__7E57BA87    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_emp_r__UPDAT__7F4BDEC0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_emp_r__EXCLU__004002F9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_emp_r__DEL_F__01342732    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_emp_r__EX_FL__02284B6B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_emp_r__EX_FL__031C6FA4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_emp_r__EX_FL__041093DD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_emp_r__EX_FL__0504B816    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_emp_r__EX_FL__05F8DC4F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_8420CDCCB1BB4B61A703CA67888A52F0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_reward ADD  CONSTRAINT MSmerge_df_rowguid_8420CDCCB1BB4B61A703CA67888A52F0  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_emp_w__EMPLO__07E124C1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT (N'') FOR EMPLOYEE_ID
GO
/****** Object:  Default DF__crl_emp_w__PERIO__08D548FA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT (NULL) FOR PERIOD
GO
/****** Object:  Default DF__crl_emp_w__CREAT__09C96D33    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_emp_w__CREAT__0ABD916C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_emp_w__UPDAT__0BB1B5A5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_emp_w__UPDAT__0CA5D9DE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_emp_w__EXCLU__0D99FE17    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_emp_w__DEL_F__0E8E2250    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_emp_w__EX_FL__0F824689    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_emp_w__EX_FL__10766AC2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_emp_w__EX_FL__116A8EFB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_emp_w__EX_FL__125EB334    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_emp_w__EX_FL__1352D76D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_emp_w__START__1446FBA6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT (NULL) FOR START_TIME
GO
/****** Object:  Default DF__crl_emp_w__END_T__153B1FDF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  DEFAULT (NULL) FOR END_TIME
GO
/****** Object:  Default MSmerge_df_rowguid_7AD7E7B4250040C0BC8F0252E1CC4005    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_emp_wrkg_days ADD  CONSTRAINT MSmerge_df_rowguid_7AD7E7B4250040C0BC8F0252E1CC4005  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_ex_pr__COLOR__17236851    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_color ADD  DEFAULT (NULL) FOR COLOR_NAME
GO
/****** Object:  Default DF__crl_ex_pr__CREAT__18178C8A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_color ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_ex_pr__CREAT__190BB0C3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_color ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_ex_pr__UPDAT__19FFD4FC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_color ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_ex_pr__UPDAT__1AF3F935    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_color ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_ex_pr__EXCLU__1BE81D6E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_color ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_ex_pr__DEL_F__1CDC41A7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_color ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_ex_pr__EX_FL__1DD065E0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_color ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_ex_pr__EX_FL__1EC48A19    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_color ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_ex_pr__EX_FL__1FB8AE52    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_color ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_ex_pr__EX_FL__20ACD28B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_color ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_ex_pr__EX_FL__21A0F6C4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_color ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_D2AF90882FE34F7D98CDD57253003372    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_color ADD  CONSTRAINT MSmerge_df_rowguid_D2AF90882FE34F7D98CDD57253003372  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_ex_pr__SIZE___23893F36    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_size ADD  DEFAULT (NULL) FOR SIZE_NAME
GO
/****** Object:  Default DF__crl_ex_pr__CREAT__247D636F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_size ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_ex_pr__CREAT__257187A8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_size ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_ex_pr__UPDAT__2665ABE1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_size ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_ex_pr__UPDAT__2759D01A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_size ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_ex_pr__EXCLU__284DF453    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_size ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_ex_pr__DEL_F__2942188C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_size ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_ex_pr__EX_FL__2A363CC5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_size ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_ex_pr__EX_FL__2B2A60FE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_size ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_ex_pr__EX_FL__2C1E8537    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_size ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_ex_pr__EX_FL__2D12A970    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_size ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_ex_pr__EX_FL__2E06CDA9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_size ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_46034CC1D69745D6A619B89E4FB1CD42    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ex_prd_size ADD  CONSTRAINT MSmerge_df_rowguid_46034CC1D69745D6A619B89E4FB1CD42  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_gift__GIFT_N__2FEF161B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT (NULL) FOR GIFT_NAME
GO
/****** Object:  Default DF__crl_gift__QUANTI__30E33A54    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default DF__crl_gift__SUPPLI__31D75E8D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT (NULL) FOR SUPPLIER_ID
GO
/****** Object:  Default DF__crl_gift__PRICE__32CB82C6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT (NULL) FOR PRICE
GO
/****** Object:  Default DF__crl_gift__CREATE__33BFA6FF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_gift__CREATE__34B3CB38    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_gift__UPDATE__35A7EF71    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_gift__UPDATE__369C13AA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_gift__EXCLUS__379037E3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_gift__DEL_FL__38845C1C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_gift__EX_FLD__39788055    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_gift__EX_FLD__3A6CA48E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_gift__EX_FLD__3B60C8C7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_gift__EX_FLD__3C54ED00    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_gift__EX_FLD__3D491139    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_09E614D8F03C4DC18C3CBB909F074354    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_gift ADD  CONSTRAINT MSmerge_df_rowguid_09E614D8F03C4DC18C3CBB909F074354  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_mn_pr__PRODU__3F3159AB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  DEFAULT (N'') FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_mn_pr__PRICE__40257DE4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  DEFAULT ('0') FOR PRICE
GO
/****** Object:  Default DF__crl_mn_pr__CREAT__4119A21D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_mn_pr__CREAT__420DC656    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_mn_pr__UPDAT__4301EA8F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_mn_pr__UPDAT__43F60EC8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_mn_pr__EXCLU__44EA3301    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_mn_pr__DEL_F__45DE573A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_mn_pr__EX_FL__46D27B73    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_mn_pr__EX_FL__47C69FAC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_mn_pr__EX_FL__48BAC3E5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_mn_pr__EX_FL__49AEE81E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_mn_pr__EX_FL__4AA30C57    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_mn_pr__WHOLE__4B973090    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  DEFAULT ('0') FOR WHOLE_SALE_PRICE
GO
/****** Object:  Default MSmerge_df_rowguid_A987C76DD4E645FAB2D9C660982FF749    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_price ADD  CONSTRAINT MSmerge_df_rowguid_A987C76DD4E645FAB2D9C660982FF749  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_mn_st__PRODU__4D7F7902    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_mn_st__PRODU__4E739D3B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT (NULL) FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_mn_st__QUANT__4F67C174    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default DF__crl_mn_st__CREAT__505BE5AD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_mn_st__CREAT__515009E6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_mn_st__UPDAT__52442E1F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_mn_st__UPDAT__53385258    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_mn_st__EXCLU__542C7691    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_mn_st__DEL_F__55209ACA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_mn_st__EX_FL__5614BF03    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_mn_st__EX_FL__5708E33C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_mn_st__EX_FL__57FD0775    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_mn_st__EX_FL__58F12BAE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_mn_st__EX_FL__59E54FE7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_mn_st__GOOD___5AD97420    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT ('0') FOR GOOD_QUANTITY
GO
/****** Object:  Default DF__crl_mn_st__ERROR__5BCD9859    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT ('0') FOR ERROR_QUANTITY
GO
/****** Object:  Default DF__crl_mn_st__DAMAG__5CC1BC92    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT ('0') FOR DAMAGE_QUANTITY
GO
/****** Object:  Default DF__crl_mn_st__LOST___5DB5E0CB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT ('0') FOR LOST_QUANTITY
GO
/****** Object:  Default DF__crl_mn_st__UNCON__5EAA0504    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT ('0') FOR UNCONFIRM_QUANTITY
GO
/****** Object:  Default DF__crl_mn_st__POSIT__5F9E293D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  DEFAULT (NULL) FOR POSITION
GO
/****** Object:  Default MSmerge_df_rowguid_214056E22A2F4EB8BEF26B7B2D17B66F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk ADD  CONSTRAINT MSmerge_df_rowguid_214056E22A2F4EB8BEF26B7B2D17B66F  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_mn_st__PRODU__618671AF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_mn_st__PRODU__627A95E8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT (N'') FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_mn_st__CREAT__636EBA21    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_mn_st__CREAT__6462DE5A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_mn_st__UPDAT__65570293    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_mn_st__UPDAT__664B26CC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_mn_st__EXCLU__673F4B05    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT ('1') FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_mn_st__DEL_F__68336F3E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_mn_st__EX_FL__69279377    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_mn_st__EX_FL__6A1BB7B0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_mn_st__EX_FL__6B0FDBE9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_mn_st__EX_FL__6C040022    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_mn_st__EX_FL__6CF8245B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_mn_st__DESCR__6DEC4894    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT (NULL) FOR DESCRIPTION
GO
/****** Object:  Default DF__crl_mn_st__GOOD___6EE06CCD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT ('0') FOR GOOD_COUNT
GO
/****** Object:  Default DF__crl_mn_st__ERROR__6FD49106    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT ('0') FOR ERROR_COUNT
GO
/****** Object:  Default DF__crl_mn_st__DAMAG__70C8B53F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT ('0') FOR DAMAGE_COUNT
GO
/****** Object:  Default DF__crl_mn_st__LOST___71BCD978    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT ('0') FOR LOST_COUNT
GO
/****** Object:  Default DF__crl_mn_st__UNCON__72B0FDB1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  DEFAULT ('0') FOR UNCONFIRM_COUNT
GO
/****** Object:  Default MSmerge_df_rowguid_E6FE7D430C6A4262B354F9E089E8BC85    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his ADD  CONSTRAINT MSmerge_df_rowguid_E6FE7D430C6A4262B354F9E089E8BC85  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_mnftr__MANUF__74994623    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mnftr ADD  DEFAULT (NULL) FOR MANUFACTURER_NAME
GO
/****** Object:  Default DF__crl_mnftr__CREAT__758D6A5C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mnftr ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_mnftr__CREAT__76818E95    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mnftr ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_mnftr__UPDAT__7775B2CE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mnftr ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_mnftr__UPDAT__7869D707    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mnftr ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_mnftr__EXCLU__795DFB40    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mnftr ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_mnftr__DEL_F__7A521F79    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mnftr ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_mnftr__EX_FL__7B4643B2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mnftr ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_mnftr__EX_FL__7C3A67EB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mnftr ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_mnftr__EX_FL__7D2E8C24    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mnftr ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_mnftr__EX_FL__7E22B05D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mnftr ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_mnftr__EX_FL__7F16D496    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mnftr ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_8460424E3C9B4BD6BE75DEAA3ABF21B5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mnftr ADD  CONSTRAINT MSmerge_df_rowguid_8460424E3C9B4BD6BE75DEAA3ABF21B5  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_other__FIELD__00FF1D08    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT (NULL) FOR FIELD_NAME
GO
/****** Object:  Default DF__crl_other__ACTIO__01F34141    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT (NULL) FOR ACTION
GO
/****** Object:  Default DF__crl_other__VALUE__02E7657A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT (NULL) FOR VALUE_BEFORE
GO
/****** Object:  Default DF__crl_other__VALUE__03DB89B3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT (NULL) FOR VALUE_AFTER
GO
/****** Object:  Default DF__crl_other__CREAT__04CFADEC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_other__CREAT__05C3D225    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_other__UPDAT__06B7F65E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_other__UPDAT__07AC1A97    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_other__EXCLU__08A03ED0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_other__DEL_F__09946309    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_other__EX_FL__0A888742    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_other__EX_FL__0B7CAB7B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_other__EX_FL__0C70CFB4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_other__EX_FL__0D64F3ED    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_other__EX_FL__0E591826    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_407560A1230640A3A6F6CB6B4C222F21    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_other_trans_log ADD  CONSTRAINT MSmerge_df_rowguid_407560A1230640A3A6F6CB6B4C222F21  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_pblsh__START__10416098    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pblsh_cpn ADD  DEFAULT (NULL) FOR START_DATE
GO
/****** Object:  Default DF__crl_pblsh__END_D__113584D1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pblsh_cpn ADD  DEFAULT (NULL) FOR END_DATE
GO
/****** Object:  Default DF__crl_pblsh__CREAT__1229A90A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pblsh_cpn ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_pblsh__CREAT__131DCD43    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pblsh_cpn ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_pblsh__UPDAT__1411F17C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pblsh_cpn ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_pblsh__UPDAT__150615B5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pblsh_cpn ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_pblsh__EXCLU__15FA39EE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pblsh_cpn ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_pblsh__DEL_F__16EE5E27    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pblsh_cpn ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_pblsh__EX_FL__17E28260    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pblsh_cpn ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_pblsh__EX_FL__18D6A699    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pblsh_cpn ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_pblsh__EX_FL__19CACAD2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pblsh_cpn ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_pblsh__EX_FL__1ABEEF0B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pblsh_cpn ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_pblsh__EX_FL__1BB31344    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pblsh_cpn ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_8299D448535E47A9A68FB24557C5E53E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pblsh_cpn ADD  CONSTRAINT MSmerge_df_rowguid_8299D448535E47A9A68FB24557C5E53E  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_pkgr__PACKAG__1D9B5BB6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pkgr ADD  DEFAULT (NULL) FOR PACKAGER_NAME
GO
/****** Object:  Default DF__crl_pkgr__CREATE__1E8F7FEF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pkgr ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_pkgr__CREATE__1F83A428    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pkgr ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_pkgr__UPDATE__2077C861    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pkgr ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_pkgr__UPDATE__216BEC9A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pkgr ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_pkgr__EXCLUS__226010D3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pkgr ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_pkgr__DEL_FL__2354350C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pkgr ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_pkgr__EX_FLD__24485945    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pkgr ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_pkgr__EX_FLD__253C7D7E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pkgr ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_pkgr__EX_FLD__2630A1B7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pkgr ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_pkgr__EX_FLD__2724C5F0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pkgr ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_pkgr__EX_FLD__2818EA29    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pkgr ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_495BD26EDD6443FCA0E710FB8175DDB3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pkgr ADD  CONSTRAINT MSmerge_df_rowguid_495BD26EDD6443FCA0E710FB8175DDB3  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_pos_l__Excep__2A01329B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_log ADD  DEFAULT (NULL) FOR Exception
GO
/****** Object:  Default DF__crl_pos_l__Pos_U__2AF556D4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_log ADD  DEFAULT (NULL) FOR Pos_User
GO
/****** Object:  Default DF__crl_pos_l__Pos_A__2BE97B0D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_log ADD  DEFAULT (NULL) FOR Pos_Action
GO
/****** Object:  Default MSmerge_df_rowguid_3C5A6C0FF8234E388CE46FCA7E90F2E8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_log ADD  CONSTRAINT MSmerge_df_rowguid_3C5A6C0FF8234E388CE46FCA7E90F2E8  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_pos_t__Amoun__2DD1C37F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_trans ADD  DEFAULT (NULL) FOR Amount_In
GO
/****** Object:  Default DF__crl_pos_t__Amoun__2EC5E7B8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_trans ADD  DEFAULT (NULL) FOR Amount_Out
GO
/****** Object:  Default DF__crl_pos_t__CREAT__2FBA0BF1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_trans ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_pos_t__CREAT__30AE302A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_trans ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_pos_t__UPDAT__31A25463    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_trans ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_pos_t__UPDAT__3296789C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_trans ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_pos_t__EXCLU__338A9CD5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_trans ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_pos_t__EX_FL__347EC10E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_trans ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_pos_t__EX_FL__3572E547    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_trans ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_pos_t__EX_FL__36670980    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_trans ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_pos_t__EX_FL__375B2DB9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_trans ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_pos_t__EX_FL__384F51F2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_trans ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_pos_t__DEL_F__3943762B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_trans ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default MSmerge_df_rowguid_C9A1A88070E543208BCF29EBCC2E920E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_trans ADD  CONSTRAINT MSmerge_df_rowguid_C9A1A88070E543208BCF29EBCC2E920E  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_prd__PRODUCT__3B2BBE9D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_prd__PRODUCT__3C1FE2D6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_prd__BLOCK_I__3D14070F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR BLOCK_ID
GO
/****** Object:  Default DF__crl_prd__BLOCK_D__3E082B48    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR BLOCK_DETAIL_ID
GO
/****** Object:  Default DF__crl_prd__CREATE___3EFC4F81    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_prd__CREATE___3FF073BA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_prd__UPDATE___40E497F3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_prd__UPDATE___41D8BC2C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_prd__EXCLUSI__42CCE065    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_prd__DEL_FLG__43C1049E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_prd__QUANTIT__44B528D7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default DF__crl_prd__PRICE__45A94D10    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR PRICE
GO
/****** Object:  Default DF__crl_prd__TAX_ID__469D7149    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR TAX_ID
GO
/****** Object:  Default DF__crl_prd__EX_FLD1__47919582    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_prd__EX_FLD2__4885B9BB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_prd__EX_FLD3__4979DDF4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_prd__EX_FLD4__4A6E022D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_prd__EX_FLD5__4B622666    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_prd__BARCODE__4C564A9F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  DEFAULT (N'') FOR BARCODE
GO
/****** Object:  Default MSmerge_df_rowguid_2DF5B7C569724E57BB7DD3BA0ABAB1BC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd ADD  CONSTRAINT MSmerge_df_rowguid_2DF5B7C569724E57BB7DD3BA0ABAB1BC  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_prd_m__PRODU__4E3E9311    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (N'') FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_prd_m__PRODU__4F32B74A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR PRODUCT_NAME
GO
/****** Object:  Default DF__crl_prd_m__DESCR__5026DB83    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR DESCRIPTION
GO
/****** Object:  Default DF__crl_prd_m__IMAGE__511AFFBC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR IMAGE_PATH
GO
/****** Object:  Default DF__crl_prd_m__CATEG__520F23F5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR CATEGORY_ID
GO
/****** Object:  Default DF__crl_prd_m__COUNT__5303482E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR COUNTRY_ID
GO
/****** Object:  Default DF__crl_prd_m__UNIT___53F76C67    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR UNIT_ID
GO
/****** Object:  Default DF__crl_prd_m__TYPE___54EB90A0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR TYPE_ID
GO
/****** Object:  Default DF__crl_prd_m__MANUF__55DFB4D9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR MANUFACTURER_ID
GO
/****** Object:  Default DF__crl_prd_m__SUPPL__56D3D912    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR SUPPLIER_ID
GO
/****** Object:  Default DF__crl_prd_m__PACKA__57C7FD4B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR PACKAGER_ID
GO
/****** Object:  Default DF__crl_prd_m__DISTR__58BC2184    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR DISTRIBUTOR_ID
GO
/****** Object:  Default DF__crl_prd_m__BARCO__59B045BD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (N'') FOR BARCODE
GO
/****** Object:  Default DF__crl_prd_m__CREAT__5AA469F6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_prd_m__CREAT__5B988E2F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_prd_m__UPDAT__5C8CB268    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_prd_m__UPDAT__5D80D6A1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_prd_m__EXCLU__5E74FADA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT ('0') FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_prd_m__DEL_F__5F691F13    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_prd_m__EX_FL__605D434C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_prd_m__EX_FL__61516785    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_prd_m__EX_FL__62458BBE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_prd_m__EX_FL__6339AFF7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_prd_m__EX_FL__642DD430    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_99DC74DED62C47D382AC7CBA77BE331E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_mst ADD  CONSTRAINT MSmerge_df_rowguid_99DC74DED62C47D382AC7CBA77BE331E  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_prd_t__TYPE___66161CA2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_typ ADD  DEFAULT (NULL) FOR TYPE_NAME
GO
/****** Object:  Default DF__crl_prd_t__CREAT__670A40DB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_typ ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_prd_t__CREAT__67FE6514    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_typ ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_prd_t__UPDAT__68F2894D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_typ ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_prd_t__UPDAT__69E6AD86    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_typ ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_prd_t__EXCLU__6ADAD1BF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_typ ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_prd_t__DEL_F__6BCEF5F8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_typ ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_prd_t__EX_FL__6CC31A31    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_typ ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_prd_t__EX_FL__6DB73E6A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_typ ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_prd_t__EX_FL__6EAB62A3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_typ ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_prd_t__EX_FL__6F9F86DC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_typ ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_prd_t__EX_FL__7093AB15    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_typ ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_23AC048525824270BE2A87814DFCFAF6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_typ ADD  CONSTRAINT MSmerge_df_rowguid_23AC048525824270BE2A87814DFCFAF6  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_prd_u__UNIT___727BF387    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_unit ADD  DEFAULT (NULL) FOR UNIT_NAME
GO
/****** Object:  Default DF__crl_prd_u__CREAT__737017C0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_unit ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_prd_u__CREAT__74643BF9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_unit ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_prd_u__UPDAT__75586032    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_unit ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_prd_u__UPDAT__764C846B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_unit ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_prd_u__EXCLU__7740A8A4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_unit ADD  DEFAULT ('0') FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_prd_u__DEL_F__7834CCDD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_unit ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_prd_u__EX_FL__7928F116    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_unit ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_prd_u__EX_FL__7A1D154F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_unit ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_prd_u__EX_FL__7B113988    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_unit ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_prd_u__EX_FL__7C055DC1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_unit ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_prd_u__EX_FL__7CF981FA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_unit ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_8B0CDDB6C33C40D2AC846AF661A89A1A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_prd_unit ADD  CONSTRAINT MSmerge_df_rowguid_8B0CDDB6C33C40D2AC846AF661A89A1A  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_promo__PROMO__7EE1CA6C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR PROMOTION_NAME
GO
/****** Object:  Default DF__crl_promo__DISCO__7FD5EEA5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR DISCOUNT_PRICE
GO
/****** Object:  Default DF__crl_promo__DISCO__00CA12DE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR DISCOUNT_PERCENT
GO
/****** Object:  Default DF__crl_promo__PROMO__01BE3717    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR PROMOTION_TYPE
GO
/****** Object:  Default DF__crl_promo__GIFT___02B25B50    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR GIFT_PRODUCT_ID
GO
/****** Object:  Default DF__crl_promo__CREAT__03A67F89    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_promo__CREAT__049AA3C2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_promo__UPDAT__058EC7FB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_promo__UPDAT__0682EC34    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_promo__EXCLU__0777106D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_promo__DEL_F__086B34A6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_promo__EX_FL__095F58DF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_promo__EX_FL__0A537D18    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_promo__EX_FL__0B47A151    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_promo__EX_FL__0C3BC58A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_promo__EX_FL__0D2FE9C3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_582F7857B7AD4323ACC197C07E89C45A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_promo ADD  CONSTRAINT MSmerge_df_rowguid_582F7857B7AD4323ACC197C07E89C45A  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_reicp__RECEI__0F183235    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT (N'') FOR RECEIPT_ID
GO
/****** Object:  Default DF__crl_reicp__PURCH__100C566E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT (N'') FOR PURCHASE_ORDER_ID
GO
/****** Object:  Default DF__crl_reicp__RECEI__11007AA7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT (NULL) FOR RECEIPT_NAME
GO
/****** Object:  Default DF__crl_reicp__RECEI__11F49EE0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT (NULL) FOR RECEIPT_NUMBER
GO
/****** Object:  Default DF__crl_reicp__CREAT__12E8C319    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_reicp__CREAT__13DCE752    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_reicp__UPDAT__14D10B8B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_reicp__UPDAT__15C52FC4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_reicp__EXCLU__16B953FD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_reicp__DEL_F__17AD7836    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_reicp__EX_FL__18A19C6F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_reicp__EX_FL__1995C0A8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_reicp__EX_FL__1A89E4E1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_reicp__EX_FL__1B7E091A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_reicp__EX_FL__1C722D53    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_84FC04E5BC7240CBB89F04A0DB4AC153    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt ADD  CONSTRAINT MSmerge_df_rowguid_84FC04E5BC7240CBB89F04A0DB4AC153  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_reicp__RECEI__1E5A75C5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out ADD  DEFAULT (NULL) FOR RECEIPT_OUT_NAME
GO
/****** Object:  Default DF__crl_reicp__CREAT__1F4E99FE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_reicp__CREAT__2042BE37    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_reicp__UPDAT__2136E270    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_reicp__UPDAT__222B06A9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_reicp__EXCLU__231F2AE2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_reicp__DEL_F__24134F1B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_reicp__EX_FL__25077354    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_reicp__EX_FL__25FB978D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_reicp__EX_FL__26EFBBC6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_reicp__EX_FL__27E3DFFF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_reicp__EX_FL__28D80438    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_7DCC30272DB740BDA16DACEAF478FC6F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out ADD  CONSTRAINT MSmerge_df_rowguid_7DCC30272DB740BDA16DACEAF478FC6F  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_reicpt__COST__2AC04CAA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out_cst ADD  DEFAULT (NULL) FOR COST
GO
/****** Object:  Default DF__crl_reicp__CREAT__2BB470E3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out_cst ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_reicp__CREAT__2CA8951C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out_cst ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_reicp__UPDAT__2D9CB955    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out_cst ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_reicp__UPDAT__2E90DD8E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out_cst ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_reicp__EXCLU__2F8501C7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out_cst ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_reicp__DEL_F__30792600    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out_cst ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_reicp__EX_FL__316D4A39    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out_cst ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_reicp__EX_FL__32616E72    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out_cst ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_reicp__EX_FL__335592AB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out_cst ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_reicp__EX_FL__3449B6E4    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out_cst ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_reicp__EX_FL__353DDB1D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out_cst ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_A5C0A9542DA148A1960AFFE51F2C475D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_reicpt_out_cst ADD  CONSTRAINT MSmerge_df_rowguid_A5C0A9542DA148A1960AFFE51F2C475D  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_ret_b__DESCR__3726238F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_blk_in ADD  DEFAULT (NULL) FOR DESCRIPTION
GO
/****** Object:  Default DF__crl_ret_b__CREAT__381A47C8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_blk_in ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_ret_b__CREAT__390E6C01    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_blk_in ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_ret_b__UPDAT__3A02903A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_blk_in ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_ret_b__UPDAT__3AF6B473    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_blk_in ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_ret_b__EXCLU__3BEAD8AC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_blk_in ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_ret_b__DEL_F__3CDEFCE5    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_blk_in ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_ret_b__EX_FL__3DD3211E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_blk_in ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_ret_b__EX_FL__3EC74557    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_blk_in ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_ret_b__EX_FL__3FBB6990    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_blk_in ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_ret_b__EX_FL__40AF8DC9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_blk_in ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_ret_b__EX_FL__41A3B202    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_blk_in ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_6D69931AED534E819AC1F5D9B784240A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_blk_in ADD  CONSTRAINT MSmerge_df_rowguid_6D69931AED534E819AC1F5D9B784240A  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_ret_p__PRODU__438BFA74    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT (NULL) FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_ret_p__PRODU__44801EAD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT (NULL) FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_ret_p__DESCR__457442E6    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT (NULL) FOR DESCRIPTION
GO
/****** Object:  Default DF__crl_ret_p__CREAT__4668671F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_ret_p__CREAT__475C8B58    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_ret_p__UPDAT__4850AF91    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_ret_p__UPDAT__4944D3CA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_ret_p__EXCLU__4A38F803    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_ret_p__DEL_F__4B2D1C3C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_ret_p__EX_FL__4C214075    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_ret_p__EX_FL__4D1564AE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_ret_p__EX_FL__4E0988E7    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_ret_p__EX_FL__4EFDAD20    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_ret_p__EX_FL__4FF1D159    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_ret_p__QUANT__50E5F592    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default MSmerge_df_rowguid_AF93719F09F248E6B56EC782AA389FE3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_prd ADD  CONSTRAINT MSmerge_df_rowguid_AF93719F09F248E6B56EC782AA389FE3  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_ret_t__Custo__52CE3E04    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  DEFAULT (NULL) FOR Customer_Id
GO
/****** Object:  Default DF__crl_ret_t__Purch__53C2623D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  DEFAULT (NULL) FOR Purchase_Order_Id
GO
/****** Object:  Default DF__crl_ret_t__Retur__54B68676    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  DEFAULT (NULL) FOR Return_Id
GO
/****** Object:  Default DF__crl_ret_t__CREAT__55AAAAAF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_ret_t__CREAT__569ECEE8    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_ret_t__UPDAT__5792F321    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_ret_t__UPDAT__5887175A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_ret_t__EXCLU__597B3B93    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_ret_t__DEL_F__5A6F5FCC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_ret_t__EX_FL__5B638405    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_ret_t__EX_FL__5C57A83E    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_ret_t__EX_FL__5D4BCC77    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_ret_t__EX_FL__5E3FF0B0    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_ret_t__EX_FL__5F3414E9    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_2CCDD04E95D342F8999A5549DC3F9B47    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_ret_trans ADD  CONSTRAINT MSmerge_df_rowguid_2CCDD04E95D342F8999A5549DC3F9B47  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_role__name__611C5D5B    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_role ADD  DEFAULT (NULL) FOR name
GO
/****** Object:  Default MSmerge_df_rowguid_382091B93E46443DABEE3BF194F4D4DE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_role ADD  CONSTRAINT MSmerge_df_rowguid_382091B93E46443DABEE3BF194F4D4DE  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_sale___Purch__6304A5CD    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sale_trans ADD  DEFAULT (NULL) FOR Purchase_Order_Id
GO
/****** Object:  Default DF__crl_sale___CREAT__63F8CA06    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sale_trans ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_sale___CREAT__64ECEE3F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sale_trans ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_sale___UPDAT__65E11278    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sale_trans ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_sale___UPDAT__66D536B1    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sale_trans ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_sale___EXCLU__67C95AEA    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sale_trans ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_sale___DEL_F__68BD7F23    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sale_trans ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_sale___EX_FL__69B1A35C    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sale_trans ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_sale___EX_FL__6AA5C795    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sale_trans ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_sale___EX_FL__6B99EBCE    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sale_trans ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_sale___EX_FL__6C8E1007    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sale_trans ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_sale___EX_FL__6D823440    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sale_trans ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_F7A3884B3B6742D1ACEFFDB9C6032630    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sale_trans ADD  CONSTRAINT MSmerge_df_rowguid_F7A3884B3B6742D1ACEFFDB9C6032630  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_sche___EMPLO__6F6A7CB2    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (N'') FOR EMPLOYEE_ID
GO
/****** Object:  Default DF__crl_sche___MONDA__705EA0EB    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR MONDAY
GO
/****** Object:  Default DF__crl_sche___TUESD__7152C524    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR TUESDAY
GO
/****** Object:  Default DF__crl_sche___WEDNE__7246E95D    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR WEDNESDAY
GO
/****** Object:  Default DF__crl_sche___THURS__733B0D96    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR THURSDAY
GO
/****** Object:  Default DF__crl_sche___FRIDA__742F31CF    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR FRIDAY
GO
/****** Object:  Default DF__crl_sche___SATUR__75235608    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR SATURDAY
GO
/****** Object:  Default DF__crl_sche___SUNDA__76177A41    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR SUNDAY
GO
/****** Object:  Default DF__crl_sche___DEL_F__770B9E7A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR DEL_FLG
GO
/****** Object:  Default DF__crl_sche___EX_FL__77FFC2B3    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_sche___EX_FL__78F3E6EC    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_sche___EX_FL__79E80B25    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_sche___EX_FL__7ADC2F5E    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_sche___EX_FL__7BD05397    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_sche___START__7CC477D0    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR START_DATE
GO
/****** Object:  Default DF__crl_sche___END_D__7DB89C09    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR END_DATE
GO
/****** Object:  Default DF__crl_sche___CREAT__7EACC042    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_sche___CREAT__7FA0E47B    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_sche___UPDAT__009508B4    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_sche___UPDAT__01892CED    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_sche___EXCLU__027D5126    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sche_tmplate ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default MSmerge_df_rowguid_785489AED3734EF794E415E6C9B0189E    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sche_tmplate ADD  CONSTRAINT MSmerge_df_rowguid_785489AED3734EF794E415E6C9B0189E  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_sim_p__CREAT__04659998    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sim_prd ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_sim_p__CREAT__0559BDD1    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sim_prd ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_sim_p__UPDAT__064DE20A    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sim_prd ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_sim_p__UPDAT__07420643    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sim_prd ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_sim_p__EXCLU__08362A7C    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sim_prd ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_sim_p__DEL_F__092A4EB5    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sim_prd ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_sim_p__EX_FL__0A1E72EE    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sim_prd ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_sim_p__EX_FL__0B129727    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sim_prd ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_sim_p__EX_FL__0C06BB60    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sim_prd ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_sim_p__EX_FL__0CFADF99    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sim_prd ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_sim_p__EX_FL__0DEF03D2    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sim_prd ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_DAEE13998FDD477C8D2067FC8932E322    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sim_prd ADD  CONSTRAINT MSmerge_df_rowguid_DAEE13998FDD477C8D2067FC8932E322  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_stk_d__DEFEC__0FD74C44    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_def_stat ADD  DEFAULT (N'') FOR DEFECT_STATUS_NAME
GO
/****** Object:  Default MSmerge_df_rowguid_5F56B3A70AF8483E86CFE7CD420FDD8A    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_def_stat ADD  CONSTRAINT MSmerge_df_rowguid_5F56B3A70AF8483E86CFE7CD420FDD8A  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_stk_i__STOCK__11BF94B6    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT (N'') FOR STOCK_IN_ID
GO
/****** Object:  Default DF__crl_stk_i__STOCK__12B3B8EF    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT (NULL) FOR STOCK_IN_DATE
GO
/****** Object:  Default DF__crl_stk_i__CREAT__13A7DD28    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_stk_i__DESCR__149C0161    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT (NULL) FOR DESCRIPTION
GO
/****** Object:  Default DF__crl_stk_i__CREAT__1590259A    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_stk_i__UPDAT__168449D3    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_stk_i__UPDAT__17786E0C    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_stk_i__EXCLU__186C9245    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_stk_i__DEL_F__1960B67E    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_stk_i__EX_FL__1A54DAB7    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_stk_i__EX_FL__1B48FEF0    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_stk_i__EX_FL__1C3D2329    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_stk_i__EX_FL__1D314762    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_stk_i__EX_FL__1E256B9B    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_stk_i__STOCK__1F198FD4    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT ('0') FOR STOCK_IN_COST
GO
/****** Object:  Default DF__crl_stk_i__STOCK__200DB40D    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT (NULL) FOR STOCK_IN_TYPE
GO
/****** Object:  Default DF__crl_stk_i__CONFI__2101D846    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  DEFAULT ('0') FOR CONFIRM_FLG
GO
/****** Object:  Default MSmerge_df_rowguid_1E0EC8F417F74596A01E3BEF2D655545    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in ADD  CONSTRAINT MSmerge_df_rowguid_1E0EC8F417F74596A01E3BEF2D655545  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_stk_i__STOCK__22EA20B8    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (N'') FOR STOCK_IN_ID
GO
/****** Object:  Default DF__crl_stk_i__PRODU__23DE44F1    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_stk_i__PRODU__24D2692A    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_stk_i__QUANT__25C68D63    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default DF__crl_stk_i__PRICE__26BAB19C    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR PRICE
GO
/****** Object:  Default DF__crl_stk_i__CREAT__27AED5D5    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_stk_i__CREAT__28A2FA0E    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_stk_i__UPDAT__29971E47    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_stk_i__UPDAT__2A8B4280    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_stk_i__EXCLU__2B7F66B9    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_stk_i__DEL_F__2C738AF2    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_stk_i__EX_FL__2D67AF2B    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_stk_i__EX_FL__2E5BD364    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_stk_i__EX_FL__2F4FF79D    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_stk_i__EX_FL__30441BD6    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_stk_i__EX_FL__3138400F    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_stk_i__STOCK__322C6448    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR STOCK_IN_TYPE
GO
/****** Object:  Default DF__crl_stk_i__SELL___33208881    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  DEFAULT (NULL) FOR SELL_PRICE
GO
/****** Object:  Default MSmerge_df_rowguid_C2BD40E1FEAA4DF68477292C132EF3E9    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_in_det ADD  CONSTRAINT MSmerge_df_rowguid_C2BD40E1FEAA4DF68477292C132EF3E9  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_stk_o__STOCK__3508D0F3    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT (NULL) FOR STOCK_OUT_DATE
GO
/****** Object:  Default DF__crl_stk_o__CREAT__35FCF52C    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_stk_o__CREAT__36F11965    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_stk_o__UPDAT__37E53D9E    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_stk_o__UPDAT__38D961D7    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_stk_o__EXCLU__39CD8610    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_stk_o__DEL_F__3AC1AA49    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_stk_o__STOCK__3BB5CE82    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT (NULL) FOR STOCK_ID
GO
/****** Object:  Default DF__crl_stk_o__DEFEC__3CA9F2BB    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT (NULL) FOR DEFECT_STATUS_ID
GO
/****** Object:  Default DF__crl_stk_o__CONFI__3D9E16F4    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT ('0') FOR CONFIRM_FLG
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__3E923B2D    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__3F865F66    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__407A839F    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__416EA7D8    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__4262CC11    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_BCEFC80F03B24D72BB2EB1A8E8E2D332    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out ADD  CONSTRAINT MSmerge_df_rowguid_BCEFC80F03B24D72BB2EB1A8E8E2D332  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_stk_ou__COST__444B1483    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_cst ADD  DEFAULT (NULL) FOR COST
GO
/****** Object:  Default DF__crl_stk_o__CREAT__453F38BC    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_cst ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_stk_o__CREAT__46335CF5    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_cst ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_stk_o__UPDAT__4727812E    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_cst ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_stk_o__UPDAT__481BA567    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_cst ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_stk_o__EXCLU__490FC9A0    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_cst ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_stk_o__DEL_F__4A03EDD9    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_cst ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__4AF81212    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_cst ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__4BEC364B    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_cst ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__4CE05A84    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_cst ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__4DD47EBD    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_cst ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__4EC8A2F6    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_cst ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_A6B47504F8494F3D8BBC5CB7986494B5    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_cst ADD  CONSTRAINT MSmerge_df_rowguid_A6B47504F8494F3D8BBC5CB7986494B5  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_stk_o__PRODU__50B0EB68    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__crl_stk_o__PRODU__51A50FA1    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (NULL) FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__crl_stk_o__QUANT__529933DA    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (NULL) FOR QUANTITY
GO
/****** Object:  Default DF__crl_stk_o__CREAT__538D5813    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_stk_o__CREAT__54817C4C    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_stk_o__UPDAT__5575A085    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_stk_o__UPDAT__5669C4BE    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_stk_o__EXCLU__575DE8F7    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_stk_o__DEL_F__58520D30    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__59463169    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__5A3A55A2    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__5B2E79DB    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__5C229E14    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__5D16C24D    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_stk_o__DEFEC__5E0AE686    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (NULL) FOR DEFECT_STATUS_ID
GO
/****** Object:  Default DF__crl_stk_o__DESCR__5EFF0ABF    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT (NULL) FOR DESCRIPTION
GO
/****** Object:  Default DF__crl_stk_o__GOOD___5FF32EF8    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT ('0') FOR GOOD_QUANTITY
GO
/****** Object:  Default DF__crl_stk_o__ERROR__60E75331    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT ('0') FOR ERROR_QUANTITY
GO
/****** Object:  Default DF__crl_stk_o__DAMAG__61DB776A    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT ('0') FOR DAMAGE_QUANTITY
GO
/****** Object:  Default DF__crl_stk_o__LOST___62CF9BA3    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  DEFAULT ('0') FOR LOST_QUANTITY
GO
/****** Object:  Default MSmerge_df_rowguid_379F41D61AC14F099519D9909B794447    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_det ADD  CONSTRAINT MSmerge_df_rowguid_379F41D61AC14F099519D9909B794447  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_stk_o__STOCK__64B7E415    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT (NULL) FOR STOCK_OUT_DATE
GO
/****** Object:  Default DF__crl_stk_o__CREAT__65AC084E    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_stk_o__CREAT__66A02C87    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_stk_o__UPDAT__679450C0    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_stk_o__UPDAT__688874F9    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_stk_o__EXCLU__697C9932    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_stk_o__DEL_F__6A70BD6B    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__6B64E1A4    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__6C5905DD    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__6D4D2A16    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__6E414E4F    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_stk_o__EX_FL__6F357288    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default DF__crl_stk_o__STOCK__702996C1    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT (NULL) FOR STOCK_ID
GO
/****** Object:  Default DF__crl_stk_o__DEFEC__711DBAFA    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT (NULL) FOR DEFECT_STATUS_ID
GO
/****** Object:  Default DF__crl_stk_o__CONFI__7211DF33    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  DEFAULT ('0') FOR CONFIRM_FLG
GO
/****** Object:  Default MSmerge_df_rowguid_CA060EF0C80B4B588D4FD95B6BF841F5    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_stk_out_tmp ADD  CONSTRAINT MSmerge_df_rowguid_CA060EF0C80B4B588D4FD95B6BF841F5  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_sup__SUPPLIE__73FA27A5    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sup ADD  DEFAULT (NULL) FOR SUPPLIER_NAME
GO
/****** Object:  Default DF__crl_sup__CREATE___74EE4BDE    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sup ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_sup__CREATE___75E27017    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sup ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_sup__UPDATE___76D69450    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sup ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_sup__UPDATE___77CAB889    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sup ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_sup__EXCLUSI__78BEDCC2    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sup ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_sup__DEL_FLG__79B300FB    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sup ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_sup__EX_FLD1__7AA72534    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sup ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_sup__EX_FLD2__7B9B496D    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sup ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_sup__EX_FLD3__7C8F6DA6    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sup ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_sup__EX_FLD4__7D8391DF    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sup ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_sup__EX_FLD5__7E77B618    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sup ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_E541C932B4A84FF79E2B3B864871503B    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sup ADD  CONSTRAINT MSmerge_df_rowguid_E541C932B4A84FF79E2B3B864871503B  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_sync___CREAT__005FFE8A    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sync_status ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default MSmerge_df_rowguid_58031977DF7948DFA093BC20A3DEDEF6    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_sync_status ADD  CONSTRAINT MSmerge_df_rowguid_58031977DF7948DFA093BC20A3DEDEF6  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_tax__TAX_NAM__024846FC    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_tax ADD  DEFAULT (NULL) FOR TAX_NAME
GO
/****** Object:  Default DF__crl_tax__CREATE___033C6B35    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_tax ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_tax__CREATE___04308F6E    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_tax ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_tax__UPDATE___0524B3A7    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_tax ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_tax__UPDATE___0618D7E0    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_tax ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_tax__EXCLUSI__070CFC19    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_tax ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_tax__DEL_FLG__08012052    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_tax ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_tax__EX_FLD1__08F5448B    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_tax ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_tax__EX_FLD2__09E968C4    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_tax ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_tax__EX_FLD3__0ADD8CFD    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_tax ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_tax__EX_FLD4__0BD1B136    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_tax ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_tax__EX_FLD5__0CC5D56F    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_tax ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_FE6D50DE73EF481A92A0796B30602124    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_tax ADD  CONSTRAINT MSmerge_df_rowguid_FE6D50DE73EF481A92A0796B30602124  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_trans__CREAT__0EAE1DE1    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_trans ADD  DEFAULT (NULL) FOR CREATE_DATE
GO
/****** Object:  Default DF__crl_trans__CREAT__0FA2421A    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_trans ADD  DEFAULT (NULL) FOR CREATE_ID
GO
/****** Object:  Default DF__crl_trans__UPDAT__10966653    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_trans ADD  DEFAULT (NULL) FOR UPDATE_DATE
GO
/****** Object:  Default DF__crl_trans__UPDAT__118A8A8C    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_trans ADD  DEFAULT (NULL) FOR UPDATE_ID
GO
/****** Object:  Default DF__crl_trans__EXCLU__127EAEC5    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_trans ADD  DEFAULT (NULL) FOR EXCLUSIVE_KEY
GO
/****** Object:  Default DF__crl_trans__DEL_F__1372D2FE    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_trans ADD  DEFAULT ('0') FOR DEL_FLG
GO
/****** Object:  Default DF__crl_trans__EX_FL__1466F737    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_trans ADD  DEFAULT (NULL) FOR EX_FLD1
GO
/****** Object:  Default DF__crl_trans__EX_FL__155B1B70    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_trans ADD  DEFAULT (NULL) FOR EX_FLD2
GO
/****** Object:  Default DF__crl_trans__EX_FL__164F3FA9    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_trans ADD  DEFAULT (NULL) FOR EX_FLD3
GO
/****** Object:  Default DF__crl_trans__EX_FL__174363E2    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_trans ADD  DEFAULT (NULL) FOR EX_FLD4
GO
/****** Object:  Default DF__crl_trans__EX_FL__1837881B    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_trans ADD  DEFAULT (NULL) FOR EX_FLD5
GO
/****** Object:  Default MSmerge_df_rowguid_80F13460916C47C39B765FB043E48C99    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_trans ADD  CONSTRAINT MSmerge_df_rowguid_80F13460916C47C39B765FB043E48C99  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_usr_i__Usern__1A1FD08D    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_usr_info ADD  DEFAULT (N'') FOR Username
GO
/****** Object:  Default DF__crl_usr_i__Passw__1B13F4C6    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_usr_info ADD  DEFAULT (NULL) FOR Password
GO
/****** Object:  Default DF__crl_usr_i__EMPLO__1C0818FF    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_usr_info ADD  DEFAULT (NULL) FOR EMPLOYEE_ID
GO
/****** Object:  Default DF__crl_usr_i__DEPAR__1CFC3D38    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_usr_info ADD  DEFAULT (NULL) FOR DEPARTMENT_ID
GO
/****** Object:  Default DF__crl_usr_i__SUSPE__1DF06171    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_usr_info ADD  DEFAULT ('0') FOR SUSPENDED
GO
/****** Object:  Default DF__crl_usr_i__DELET__1EE485AA    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_usr_info ADD  DEFAULT ('0') FOR DELETED
GO
/****** Object:  Default MSmerge_df_rowguid_84176774A9C74B85BD97A74F9876F9C4    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_usr_info ADD  CONSTRAINT MSmerge_df_rowguid_84176774A9C74B85BD97A74F9876F9C4  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__crl_usr_r__useri__20CCCE1C    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_usr_role ADD  DEFAULT (N'') FOR userid
GO
/****** Object:  Default MSmerge_df_rowguid_7C60F9C63FCF4CB7814DFF3153CE8CE6    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE crl_usr_role ADD  CONSTRAINT MSmerge_df_rowguid_7C60F9C63FCF4CB7814DFF3153CE8CE6  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__temp_dept__depar__22B5168E    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR department_name
GO
/****** Object:  Default DF__temp_dept__type___23A93AC7    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR type_name
GO
/****** Object:  Default DF__temp_dept__produ__249D5F00    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (N'') FOR product_id
GO
/****** Object:  Default DF__temp_dept__produ__25918339    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR product_name
GO
/****** Object:  Default DF__temp_dept__color__2685A772    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR color_name
GO
/****** Object:  Default DF__temp_dept__size___2779CBAB    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR size_name
GO
/****** Object:  Default DF__temp_dept__prest__286DEFE4    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR prestk_qty
GO
/****** Object:  Default DF__temp_dept__insto__2962141D    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR instock_qty
GO
/****** Object:  Default DF__temp_dept__error__2A563856    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR error_qty
GO
/****** Object:  Default DF__temp_dept__dmg_q__2B4A5C8F    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR dmg_qty
GO
/****** Object:  Default DF__temp_dept__stkou__2C3E80C8    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR stkout_qty
GO
/****** Object:  Default DF__temp_dept__tmpou__2D32A501    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR tmpout_qty
GO
/****** Object:  Default DF__temp_dept__rtn_q__2E26C93A    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR rtn_qty
GO
/****** Object:  Default DF__temp_dept__destr__2F1AED73    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR destroy_qty
GO
/****** Object:  Default DF__temp_dept__bkpro__300F11AC    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR bkpro
GO
/****** Object:  Default DF__temp_dept__reals__310335E5    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  DEFAULT (NULL) FOR realstock
GO
/****** Object:  Default MSmerge_df_rowguid_8879A68B96984FADB0EDDDE7221F223E    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics ADD  CONSTRAINT MSmerge_df_rowguid_8879A68B96984FADB0EDDDE7221F223E  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__temp_dept__TYPE___32EB7E57    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_deptstock ADD  DEFAULT (NULL) FOR TYPE_NAME
GO
/****** Object:  Default DF__temp_dept__PRODU__33DFA290    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_deptstock ADD  DEFAULT (N'') FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__temp_dept__PRODU__34D3C6C9    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_deptstock ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__temp_dept__PRODU__35C7EB02    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_deptstock ADD  DEFAULT (NULL) FOR PRODUCT_NAME
GO
/****** Object:  Default DF__temp_dept__COLOR__36BC0F3B    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_deptstock ADD  DEFAULT (NULL) FOR COLOR_NAME
GO
/****** Object:  Default DF__temp_dept__SIZE___37B03374    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_deptstock ADD  DEFAULT (NULL) FOR SIZE_NAME
GO
/****** Object:  Default DF__temp_dept__PRICE__38A457AD    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_deptstock ADD  DEFAULT ('0') FOR PRICE
GO
/****** Object:  Default DF__temp_dept__depar__39987BE6    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_deptstock ADD  DEFAULT (NULL) FOR department_name
GO
/****** Object:  Default MSmerge_df_rowguid_CEC727CEF89E405E84C3370C833B7770    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_deptstock ADD  CONSTRAINT MSmerge_df_rowguid_CEC727CEF89E405E84C3370C833B7770  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__temp_dept__PRODU__3B80C458    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_deptstock_max_temp ADD  DEFAULT (NULL) FOR PRODUCT_ID
GO
/****** Object:  Default DF__temp_dept__good___3C74E891    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_deptstock_max_temp ADD  DEFAULT ('0') FOR good_qty
GO
/****** Object:  Default DF__temp_dept__perro__3D690CCA    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_deptstock_max_temp ADD  DEFAULT ('0') FOR perror_qty
GO
/****** Object:  Default DF__temp_dept__predm__3E5D3103    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_deptstock_max_temp ADD  DEFAULT (NULL) FOR predmg
GO
/****** Object:  Default MSmerge_df_rowguid_8DF95550EFD54F1EB89ED1A6D0F3FA3F    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_deptstock_max_temp ADD  CONSTRAINT MSmerge_df_rowguid_8DF95550EFD54F1EB89ED1A6D0F3FA3F  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__temp_dp_s__DEFEC__40457975    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dp_stockout ADD  DEFAULT (NULL) FOR DEFECT_STATUS_ID
GO
/****** Object:  Default DF__temp_dp_s__PRODU__41399DAE    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dp_stockout ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__temp_dp_s__quant__422DC1E7    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dp_stockout ADD  DEFAULT (NULL) FOR quantity
GO
/****** Object:  Default MSmerge_df_rowguid_05A2537B53A64A9097DA6E5D9925B702    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dp_stockout ADD  CONSTRAINT MSmerge_df_rowguid_05A2537B53A64A9097DA6E5D9925B702  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__temp_pr__TYPE_NA__44160A59    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_pr ADD  DEFAULT (NULL) FOR TYPE_NAME
GO
/****** Object:  Default DF__temp_pr__PRODUCT__450A2E92    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_pr ADD  DEFAULT (N'') FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__temp_pr__PRODUCT__45FE52CB    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_pr ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__temp_pr__PRODUCT__46F27704    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_pr ADD  DEFAULT (NULL) FOR PRODUCT_NAME
GO
/****** Object:  Default DF__temp_pr__COLOR_N__47E69B3D    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_pr ADD  DEFAULT (NULL) FOR COLOR_NAME
GO
/****** Object:  Default DF__temp_pr__SIZE_NA__48DABF76    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_pr ADD  DEFAULT (NULL) FOR SIZE_NAME
GO
/****** Object:  Default DF__temp_pr__PRICE__49CEE3AF    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_pr ADD  DEFAULT ('0') FOR PRICE
GO
/****** Object:  Default MSmerge_df_rowguid_853FB9DB51DA4C4AB56D9993EC87BE83    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_pr ADD  CONSTRAINT MSmerge_df_rowguid_853FB9DB51DA4C4AB56D9993EC87BE83  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__temp_prod__TYPE___4BB72C21    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_product ADD  DEFAULT (NULL) FOR TYPE_NAME
GO
/****** Object:  Default DF__temp_prod__PRODU__4CAB505A    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_product ADD  DEFAULT (N'') FOR PRODUCT_MASTER_ID
GO
/****** Object:  Default DF__temp_prod__PRODU__4D9F7493    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_product ADD  DEFAULT (N'') FOR PRODUCT_ID
GO
/****** Object:  Default DF__temp_prod__PRODU__4E9398CC    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_product ADD  DEFAULT (NULL) FOR PRODUCT_NAME
GO
/****** Object:  Default DF__temp_prod__COLOR__4F87BD05    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_product ADD  DEFAULT (NULL) FOR COLOR_NAME
GO
/****** Object:  Default DF__temp_prod__SIZE___507BE13E    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_product ADD  DEFAULT (NULL) FOR SIZE_NAME
GO
/****** Object:  Default DF__temp_prod__PRICE__51700577    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_product ADD  DEFAULT ('0') FOR PRICE
GO
/****** Object:  Default DF__temp_prod__depar__526429B0    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_product ADD  DEFAULT (NULL) FOR department_name
GO
/****** Object:  Default MSmerge_df_rowguid_A95C86CB4FB04E039FA89BD34C32FD0B    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_product ADD  CONSTRAINT MSmerge_df_rowguid_A95C86CB4FB04E039FA89BD34C32FD0B  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Default DF__temp_stk___PRODU__544C7222    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_stk_his ADD  DEFAULT (NULL) FOR PRODUCT_ID
GO
/****** Object:  Default DF__temp_stk___good___5540965B    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_stk_his ADD  DEFAULT ('0') FOR good_qty
GO
/****** Object:  Default DF__temp_stk___perro__5634BA94    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_stk_his ADD  DEFAULT ('0') FOR perror_qty
GO
/****** Object:  Default DF__temp_stk___predm__5728DECD    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_stk_his ADD  DEFAULT (NULL) FOR predmg
GO
/****** Object:  Default MSmerge_df_rowguid_555E0B5976BE4A198308FB536A62350D    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_stk_his ADD  CONSTRAINT MSmerge_df_rowguid_555E0B5976BE4A198308FB536A62350D  DEFAULT (newsequentialid()) FOR rowguid
GO
/****** Object:  Check repl_identity_range_4BB15C0D_0082_4A23_8210_FA882B5DAD8A    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_dept_stk_his  WITH NOCHECK ADD  CONSTRAINT repl_identity_range_4BB15C0D_0082_4A23_8210_FA882B5DAD8A CHECK  ((DEPARTMENT_STOCK_HISTORY_ID>=(1) AND DEPARTMENT_STOCK_HISTORY_ID<=(10001) OR DEPARTMENT_STOCK_HISTORY_ID>(10001) AND DEPARTMENT_STOCK_HISTORY_ID<=(20001)))
GO
ALTER TABLE crl_dept_stk_his CHECK CONSTRAINT repl_identity_range_4BB15C0D_0082_4A23_8210_FA882B5DAD8A
GO
/****** Object:  Check repl_identity_range_22307351_62C6_422C_852C_381DFE59FC0F    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_mn_stk_his  WITH NOCHECK ADD  CONSTRAINT repl_identity_range_22307351_62C6_422C_852C_381DFE59FC0F CHECK  ((STOCK_HISTORY_ID>=(1) AND STOCK_HISTORY_ID<=(10001) OR STOCK_HISTORY_ID>(10001) AND STOCK_HISTORY_ID<=(20001)))
GO
ALTER TABLE crl_mn_stk_his CHECK CONSTRAINT repl_identity_range_22307351_62C6_422C_852C_381DFE59FC0F
GO
/****** Object:  Check repl_identity_range_9B84EC2F_7421_46A1_A56F_532B72235B79    Script Date: 01/22/2010 00:05:09 ******/
ALTER TABLE crl_pos_log  WITH NOCHECK ADD  CONSTRAINT repl_identity_range_9B84EC2F_7421_46A1_A56F_532B72235B79 CHECK  ((Id>=(1) AND Id<=(10001) OR Id>(10001) AND Id<=(20001)))
GO
ALTER TABLE crl_pos_log CHECK CONSTRAINT repl_identity_range_9B84EC2F_7421_46A1_A56F_532B72235B79
GO
/****** Object:  Check repl_identity_range_B4D461A8_C08D_4C29_9FE2_16DBC83A9CBF    Script Date: 01/22/2010 00:05:10 ******/
ALTER TABLE temp_dept_stock_statistics  WITH NOCHECK ADD  CONSTRAINT repl_identity_range_B4D461A8_C08D_4C29_9FE2_16DBC83A9CBF CHECK  ((temp_pri_key>=(1) AND temp_pri_key<=(10001) OR temp_pri_key>(10001) AND temp_pri_key<=(20001)))
GO
ALTER TABLE temp_dept_stock_statistics CHECK CONSTRAINT repl_identity_range_B4D461A8_C08D_4C29_9FE2_16DBC83A9CBF
GO
