using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AppFrameClient.Common
{
    public sealed class FormConstants
    {
        
        public const string SALEPOINT_LIST_FORM = "SalePointListView";
        // Form constants defined in Spring Context
        public const string MAIN_FORM = "mainView";
        public const string LOGIN_FORM = "loginView";
        public const string NEW_CUSTOMER_FORM = "newCustomerView";
        public const string EDIT_CUSTOMER_FORM = "editCustomerView";
        public const string DELETE_CUSTOMER_FORM = "deleteCustomerView";

        public const string IMPORT_GOODS_FORM = "importGoodsView";
        public const string IMPORT_GOODS_DETAIL_FORM = "importGoodsDetailView";
        public const string SEARCH_BLOCK_FORM = "GoodsIOSearchView";
        public const string STOCK_CREATE_FORM = "StockCreateView";
        public const string STOCK_SEARCH_FORM = "StockSearchView";

        public const string MAIN_STOCK_SEARCH_BY_BARCODE_FORM = "MainStockSearchByBarcodeView";
        public const string MAIN_STOCK_IN_FORM = "MainStockInView";
        public const string MAIN_STOCK_IN_EXTRA_FORM = "MainStockInExtraView";
        public const string MAIN_STOCK_IN_SEARCH_FORM = "MainStockInSearchView";
        public const string MAIN_STOCK_IN_SEARCH_REPORT_FORM = "MainStockInSearchReportView";
        public const string MAIN_STOCK_OUT_FORM = "MainStockOutView";
        public const string MAIN_STOCK_OUT_EXTRA_FORM = "MainStockOutExtraView";
        public const string MAIN_RE_STOCK_IN_EXTRA_FORM = "MainReStockInExtraView";
        public const string MAIN_REMAIN_STOCK_REPORT_FORM = "RemainStockReport";
        public const string SYNC_TO_MAIN_FORM = "SyncToMainView";

        public const string DEPARTMENT_STOCK_IN_FORM = "DepartmentStockInView";
        public const string DEPARTMENT_STOCK_SYNC_FROM_MAIN_FORM = "DepartmentStockSyncFromMainView";
        public const string DEPARTMENT_STOCK_IN_EXTRA_FORM = "DepartmentStockInExtraView";
        public const string DEPARTMENT_STOCK_IN_SEARCH_FORM = "DepartmentStockInSearchView";
        public const string DEPARTMENT_STOCK_IN_DETAIL_SEARCH_FORM = "DepartmentStockInDetailSearchView";
        public const string SEARCH_DEPARTMENT_STOCK_IN_FORM = "DepartmentStockSearchView";
        public const string DEPARTMENT_PRICE_UPDATE_FORM = "DepartmentPriceUpdateView";
        public const string UNIVERASAL_MASTER_CREATE_FORM = "UniversalMasterSaveView";
        public const string DEPARTMENT_STOCK_OUT_FORM = "DepartmentStockOutExtraView";

        public const string SALEPOINT_FORM = "SalePointView";
        public const string EMPLOYEE_FORM = "EmployeeView";

        public const string PRODUCT_MASTER_FORM = "ProductMasterView";
        public const string PRODUCT_MASTER_CREATE_FORM = "ProductMasterCreateView";
        public const string PRODUCT_MASTER_SEARCH_OR_CREATE_FORM = "ProductMasterSearchOrCreateView";
        public const string PRODUCT_MASTER_SEARCH_FORM = "ProductMasterSearchView";
        public const string PRODUCT_MASTER_SEARCH_DEPARMENT_FORM = "ProductMasterSearchDepartmentView";

        public const string GOODS_SALE_FORM = "GoodsSaleView";
        public const string GOODS_SALE_RETURN_FORM = "GoodsSaleReturnView";
        public const string GOODS_SALE_LIST_FORM = "GoodsSaleListView";
        public const string SEARCH_GOODS_SALE_LIST_FORM = "SearchGoodsSaleListView";
        
        public const string DAY_GOODS_SALE_LIST_FORM = "DayGoodsSaleListView";
        public const string MONTH_GOODS_SALE_LIST_FORM = "MonthGoodsSaleListView";
        public const string REPORT_STOCK_IN_PARAM_FORM = "ReportStockInParamView";
        public const string REPORT_STOCK_IN_FORM = "ReportStockInView";
        public static string DEPARTMENT_STOCK_IN_REPORT_FORM = "DepartmentStockInReportView";
        public static string INVENTORY_CHECKING_FORM = "InventoryCheckingView";
        public static string DEPARTMENT_STOCK_CHECKING_FORM = "DepartmentStockCheckingView";
        public static string DEPARTMENT_STOCK_VIEW_CHECKING_FORM = "DepartmentStockViewCheckingView";
        
        public static string BASE_STOCK_OUT_FORM = "BaseStockOutView";
        public static string MAIN_STOCK_OUT_REPORT_FORM = "MainStockOutReportView";
        public static string DEPARTMENT_STOCK_OUT_CONFIRM_FORM = "DepartmentStockOutConfirmView";
        public static string PROCESS_ERROR_GOODS_FORM = "ProcessErrorGoodsView";
        public static string DEPARTMENT_RESTOCK_IN_FORM="DepartmentReStockInView";

        public static string SECURITY_SETTINGS_FORM = "SecuritySettingsView";


        public static string LOAD_DATA_TO_MAIN_STOCK_FORM = "LoadDataFromDepartmentToMainView";
        public static string LOAD_DATA_FROM_MAIN_STOCK_TO_FILE_FORM = "LoadDepartmentStockInToFileFormView";
        public static string SERVER_MODE = "0";
        public static string CLIENT_MODE = "1";
        public static string SUB_STOCK_MODE = "2";
        public static string GOODS_RETURN_CHILD_FORM = "GoodsReturnChildView";
        public static string EMPLOYEE_LIST_FORM = "EmployeeListView";
        public static string DEPARTMENT_STOCK_ADHOC_CHECKING_VIEW = "DepartmentStockAdhocCheckingView";
        public static string DEPARTMENT_STOCK_FIXING_FORM = "DepartmentStockFixingView";
        public static string CHANGE_PASSWORD_FORM = "ChangePasswordView";

        public static string POS_LOG_FORM = "PosLogView";
        public static string DEPARTMENT_COST_FORM = "DepartmentCostCreateView";
        public static string EMPLOYEE_WORKINGS_FORM = "EmployeeWorkingView";
        public static string SALEPOINT_SUB_STOCK = "SalePointSubStockView";
        public static string DEPARTMENT_FAST_STOCK_OUT_VIEW = "DepartmentFastStockOutView";
        public static string DEPARTMENT_FAST_STOCK_IN_VIEW = "DepartmentFastStockInView";
        public static string STOCK_OUT_CONFIRM_FORM = "StockOutConfirmView";
        public static string CONFIRM_LOGIN_VIEW = "ConfirmLoginView";
        public static string PRODUCT_MASTER_EXTRA_FORM = "ProductMasterExtraView";
        public static string LOAD_DATABASE_IMAGE_FORM = "LoadDatabaseImageView";
        public static string SYNC_DATABASE_IMAGE_VIEW = "SyncDatabaseImageView";
    }
}
