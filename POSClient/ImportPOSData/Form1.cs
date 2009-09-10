using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;


namespace ImportPOSData
{
    public partial class Form1 : Form
    {
        public readonly int START_ROW = 2;
        private DataAccessLayer dal = new DataAccessLayer();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var fileOpen = new OpenFileDialog();
            fileOpen.InitialDirectory = ".\\";
            fileOpen.Filter = "Excel (*.xls)|*.xls";
            fileOpen.FilterIndex = 0;
            fileOpen.RestoreDirectory = true;
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = fileOpen.FileName;
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("Không tìm thấy file dữ liệu");
                return;
            }
            if (!File.Exists(txtFilePath.Text))
            {
                MessageBox.Show("File dữ liệu không tồn tại");
                return;
            }

            errorBindingSource.DataSource = null;
            Workbook wb = null;
            var app = new ApplicationClass(); 
            try
            {
                wb = app.Workbooks.Open(txtFilePath.Text,
                                      0,
                                      true,
                                      5,
                                      "",
                                      "",
                                      true,
                                      Type.Missing,
                                      "\t",
                                      false,
                                      false,
                                      0,
                                      true,
                                      1,
                                      0);
                if (wb.Sheets.Count == 0)
                {
                    MessageBox.Show("Format của tập tin không đúng");
                    return;
                }
                Worksheet ws = (Worksheet)wb.ActiveSheet;
                int row = START_ROW;
                int endRow = row - 1;
                while (true)
                {
                    Range range = ws.get_Range("A" + endRow, "A" + endRow);
                    if (range.Value2 == null || range.Value2.ToString() == string.Empty)
                    {
                        break;
                    }
                    else
                    {
                        endRow++;
                    }
                }

                if (endRow < row)
                {
                    MessageBox.Show("Không có dữ liệu");
                    return;
                }

                List<ErrorObject> errorList = new List<ErrorObject>();
                List<ImportObject> importList = new List<ImportObject>();

                List<string> sizesList = GetSizesList(ws, errorList);

                for (int i = row; i < endRow; i++)
                {
                    ErrorObject errorObject;
                    ImportObject obj = GetImportObject(i, ws, out errorObject, sizesList[0], "H");
                    if (errorObject != null)
                    {
                        errorList.Add(errorObject);
                    }
                    else
                    {
						if (obj != null) {
							importList.Add(obj);
						}
                    }

                    obj = GetImportObject(i, ws, out errorObject, sizesList[1], "I");
                    if (errorObject != null)
                    {
                        errorList.Add(errorObject);
                    }
                    else
                    {
						if (obj != null) {
							importList.Add(obj);
						}
                    }

                    obj = GetImportObject(i, ws, out errorObject, sizesList[2], "J");
                    if (errorObject != null)
                    {
                        errorList.Add(errorObject);
                    }
                    else
                    {
						if (obj != null) {
							importList.Add(obj);
						}
                    }

                    obj = GetImportObject(i, ws, out errorObject, sizesList[3], "K");
                    if (errorObject != null)
                    {
                        errorList.Add(errorObject);
                    }
                    else
                    {
						if (obj != null) {
							importList.Add(obj);
						}
                    }

                    obj = GetImportObject(i, ws, out errorObject, sizesList[4], "L");
                    if (errorObject != null)
                    {
                        errorList.Add(errorObject);
                    }
                    else
                    {
						if (obj != null) {
							importList.Add(obj);
						}
                    }

                    obj = GetImportObject(i, ws, out errorObject, sizesList[5], "M");
                    if (errorObject != null)
                    {
                        errorList.Add(errorObject);
                    }
                    else
                    {
						if (obj != null) {
							importList.Add(obj);
						}
                    }

                    obj = GetImportObject(i, ws, out errorObject, sizesList[6], "N");
                    if (errorObject != null)
                    {
                        errorList.Add(errorObject);
                    }
                    else
                    {
						if (obj != null) {
							importList.Add(obj);
						}
                    }
                }
                if (errorList.Count > 0)
                {
                    errorBindingSource.DataSource = errorList;
                    MessageBox.Show("Có lỗi trong dữ liệu. Xem bảng để biết chi tiết");
                    return;
                }
                if (importList.Count > 0)
                {
                    string stockInId = GetStockInId();
                    foreach (ImportObject import in importList)
                    {
                        importToDB(import, stockInId);
                    }
                }
                MessageBox.Show("Số lượng kết nhập: " + importList.Count + "/" + (endRow - row));
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                app.Quit();
                if (wb != null)
                {
                    try
                    {
                        wb.Close(null, null, null);
                    }
                    catch
                    {
                    }
                }
            }
        }
        private List<string> GetSizesList(Worksheet ws, List<ErrorObject> errorList)
        {
            List<string> list = new List<string>();

            // F
            Range range = ws.get_Range("H" + 1, "H" + 1);
            string name = range.Value2 != null ? range.Value2.ToString() : "";
            if (!string.IsNullOrEmpty(name.Trim()))
            {
                list.Add(name.Trim());
            }
            else
            {
                ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 không có Kích cỡ", RowNumber = 1 };
                errorList.Add(errorObject);
            }

            // G
            range = ws.get_Range("I" + 1, "I" + 1);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            if (!string.IsNullOrEmpty(name))
            {
                list.Add(name.Trim());
            }
            else
            {
                ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 không có Kích cỡ", RowNumber = 1 };
                errorList.Add(errorObject);
            }

            // H
            range = ws.get_Range("J" + 1, "J" + 1);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            if (!string.IsNullOrEmpty(name))
            {
                list.Add(name.Trim());
            }
            else
            {
                ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 không có Kích cỡ", RowNumber = 1 };
                errorList.Add(errorObject);
            }

            // I
            range = ws.get_Range("K" + 1, "K" + 1);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            if (!string.IsNullOrEmpty(name))
            {
                list.Add(name.Trim());
            }
            else
            {
                ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 không có Kích cỡ", RowNumber = 1 };
                errorList.Add(errorObject);
            }

            // J
            range = ws.get_Range("L" + 1, "L" + 1);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            if (!string.IsNullOrEmpty(name))
            {
                list.Add(name.Trim());
            }
            else
            {
                ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 không có Kích cỡ", RowNumber = 1 };
                errorList.Add(errorObject);
            }

            // K
            range = ws.get_Range("M" + 1, "M" + 1);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            if (!string.IsNullOrEmpty(name))
            {
                list.Add(name.Trim());
            }
            else
            {
                ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 không có Kích cỡ", RowNumber = 1 };
                errorList.Add(errorObject);
            }

            // L
            range = ws.get_Range("N" + 1, "N" + 1);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            if (!string.IsNullOrEmpty(name))
            {
                list.Add(name.Trim());
            }
            else
            {
                ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 không có department id", RowNumber = 1 };
                errorList.Add(errorObject);
            }

            return list;
        }

        private ImportObject GetImportObject(int row, Worksheet ws, out ErrorObject errorObject, string sizeName, string sizeColumn)
        {
            ImportObject obj = new ImportObject();

            StringBuilder errorMsg = new StringBuilder();

            // Type
            Range range = ws.get_Range("A" + row, "A" + row);
            string name = range.Value2 != null ? range.Value2.ToString() : "";

            if (name.Length > 500)
            {
                errorMsg.Append("Loại tối đa 500 kí tự!!");
            }
            else
            {
                obj.TypeName = name;
            }

            // Name
            range = ws.get_Range("B" + row, "B" + row);
            name = range.Value2 != null ? range.Value2.ToString() : "";

            if (name.Length > 500)
            {
                errorMsg.Append("Tên tối đa 500 kí tự!!");
            }
            else
            {
                obj.ProductName = obj.TypeName + " " + name;
            }

            // Color
            range = ws.get_Range("F" + row, "F" + row);
            name = range.Value2 != null ? range.Value2.ToString() : "";

            if (name.Length > 500)
            {
                errorMsg.Append("Màu sắc tối đa 500 kí tự!!");
            }
            else
            {
                obj.ColorName = name;
            }

            // Price
            range = ws.get_Range("C" + row, "C" + row);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            int value = 0;
            if (name == string.Empty) {
            	name = "0";
            }
            if (name == string.Empty || !Int32.TryParse(name, out value) || value < 0)
            {
                errorMsg.Append("Giá bán phải là số >= 0, tối đa " + Int32.MaxValue + " !!");
            }
            else
            {
                obj.Price = value;
            }
            
            // Mass Price
            range = ws.get_Range("D" + row, "D" + row);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            value = 0;
            if (name == string.Empty) {
            	name = "0";
            }
            if (name == string.Empty || !Int32.TryParse(name, out value) || value < 0)
            {
                errorMsg.Append("Giá bán phải là số >= 0, tối đa " + Int32.MaxValue + " !!");
            }
            else
            {
                obj.MassPrice = value;
            }
            
            // Position
            range = ws.get_Range("E" + row, "E" + row);
            name = range.Value2 != null ? range.Value2.ToString() : "";

            if (name.Length > 500)
            {
                errorMsg.Append("Màu sắc tối đa 500 kí tự!!");
            }
            else
            {
                obj.Position = name;
            }
            
            // Description
            range = ws.get_Range("O" + row, "O" + row);
            name = range.Value2 != null ? range.Value2.ToString() : "";

            if (name.Length > 500)
            {
                errorMsg.Append("Màu sắc tối đa 500 kí tự!!");
            }
            else
            {
                obj.Position = name;
            }
            
            // Size
            obj.SizeName = sizeName;

            // Số lượng
            range = ws.get_Range(sizeColumn + row, sizeColumn + row);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            
            value = 0;
            if (name == string.Empty) {
            	name = "0";
            }
            if (!Int32.TryParse(name, out value) || value < 0)
            {
                errorMsg.Append("Số lượng phải là số > 0, tối đa " + Int32.MaxValue + " !!");
            }
            else
            {
                obj.Quantity = value;
            }
            
            if (errorMsg.Length == 0)
            {
                errorObject = null;
            }
            else
            {
                errorObject = new ErrorObject{ErrorMessage = errorMsg.ToString(), RowNumber = row};
            }

            if (value == 0) 
            {
                return null;
            }
            
            return obj;
        }

        private void importToDB(ImportObject obj, string stockInId)
        {
            object id = dal.GetSingleValue("Select type_id from product_type where type_name = '" + obj.TypeName.Replace("'" , "''") + "'");
            if (id == null || id.ToString() == string.Empty)
            {
                if (obj.TypeName != string.Empty)
                {
                    id = dal.GetSingleValue("Select max(type_id) from product_type ");
                    if (id == null || id.ToString() == string.Empty)
                    {
                        id = 1;
                    }
                    else
                    {
                        id = Convert.ToInt32(id.ToString()) + 1;
                    }
                    dal.ExecuteQuery("insert into product_type(type_id, type_name) values (" + id.ToString() + ", N'" + obj.TypeName.Replace("'", "''") + "')");
                }
                else
                {
                    id = dal.GetSingleValue("Select type_id from product_type where type_id = 0");
                    if (id == null || id.ToString() == string.Empty)
                    {
                        id = 0;
                        dal.ExecuteQuery("insert into product_type(type_id, type_name) values (" + id.ToString() + ", 'Không xác định'" + "')");
                    }
                }
            }
            obj.TypeId = Convert.ToInt32(id.ToString());

            id = dal.GetSingleValue("Select color_id from product_color where color_name = '" + obj.ColorName.Replace("'", "''") + "'");
            if (id == null || id.ToString() == string.Empty)
            {
                if (obj.ColorName != string.Empty)
                {
                    id = dal.GetSingleValue("Select max(color_id) from product_color ");
                    if (id == null || id.ToString() == string.Empty)
                    {
                        id = 1;
                    }
                    else
                    {
                        id = Convert.ToInt32(id.ToString()) + 1;
                    }
                    dal.ExecuteQuery("insert into product_color(Color_id, Color_name) values (" + id.ToString() + ", N'" + obj.ColorName.Replace("'", "''") + "')");
                }
                else
                {
                    id = dal.GetSingleValue("Select Color_id from product_Color where Color_id = 0");
                    if (id == null || id.ToString() == string.Empty)
                    {
                        id = 0;
                        dal.ExecuteQuery("insert into product_Color(Color_id, Color_name) values (" + id.ToString() + ", 'Không xác định'" + "')");
                    }
                }
            }
            obj.ColorId = Convert.ToInt32(id.ToString());

            id = dal.GetSingleValue("Select size_id from product_size where size_name = '" + obj.SizeName.Replace("'", "''") + "'");
            if (id == null || id.ToString() == string.Empty)
            {
                if (obj.ColorName != string.Empty)
                {
                    id = dal.GetSingleValue("Select max(size_id) from product_size ");
                    if (id == null || id.ToString() == string.Empty)
                    {
                        id = 1;
                    }
                    else
                    {
                        id = Convert.ToInt32(id.ToString()) + 1;
                    }
                    dal.ExecuteQuery("insert into product_size(size_id, size_name) values (" + id.ToString() + ", N'" + obj.SizeName.Replace("'", "''") + "')");
                }
                else
                {
                    id = dal.GetSingleValue("Select size_id from product_size where size_id = 0");
                    if (id == null || id.ToString() == string.Empty)
                    {
                        id = 0;
                        dal.ExecuteQuery("insert into product_size(size_id, size_name) values (" + id.ToString() + ", 'Không xác định'" + "')");
                    }
                }
            }
            obj.SizeId = Convert.ToInt32(id.ToString());

            // product master
            id = dal.GetSingleValue("Select product_master_id from product_master where size_id = " 
                + obj.SizeId + " and color_id = " + obj.ColorId + " and type_id = "  + obj.TypeId 
                + " and product_name = '" + obj.ProductName + "'");
            if (id == null || id.ToString() == string.Empty)
            {
                id = dal.GetSingleValue("Select max(product_master_id) from product_master ");
                if (id == null || id.ToString() == string.Empty)
                {
                    id = 1;
                }
                else
                {
                    id = Convert.ToInt32(id.ToString()) + 1;
                }
                dal.ExecuteQuery("insert into product_master(product_master_id, product_name, size_id, color_id, type_id, create_date,description) values ('" 
                    + string.Format("{0:0000000000000}", Convert.ToInt64(id.ToString())) 
                    + "', '" + obj.ProductName.Replace("'", "''") 
                    + "', " + obj.SizeId + ", " + obj.ColorId + ", " + obj.TypeId + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"+obj.Description + "')");
                obj.ProductMasterId = string.Format("{0:0000000000000}", Convert.ToInt64(id.ToString()));
            }
            else
            {
                obj.ProductMasterId = id.ToString();
            }

						
            // product
            string dateStr = obj.ProductMasterId.Substring(6) + buildProductId();
            id = dal.GetSingleValue("Select max(product_id) from product where product_id >= '" + dateStr + "00' and product_id < '" + dateStr + "99'" );
            if (id == null || id.ToString() == string.Empty)
            {
                id = dateStr + "01";
            }
            else
            {
            	id = dateStr + string.Format("{0:00}", (Convert.ToInt64(id.ToString().Substring(id.ToString().Length - 2)) + 1));
            }
            dal.ExecuteQuery("insert into product(product_id, product_master_id, quantity, price, create_date) values ('"
                + id
                + "', '" + obj.ProductMasterId
                + "', " + obj.Quantity + ", " + obj.Price + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
            obj.ProductId = id.ToString();

            // dept-price
            id = dal.GetSingleValue("Select product_master_id from department_price where product_master_id = '" + obj.ProductMasterId + "'");
            if (id == null || id.ToString() == string.Empty)
            {
                dal.ExecuteQuery("insert into department_price(department_id, product_master_id, price,  whole_sale_price) values ("
                    + "0, '" + obj.ProductMasterId + "', " + obj.Price + ", " + obj.MassPrice + ")" );
            }
            else
            {
                dal.ExecuteQuery("update department_price set price = " + obj.Price + ", whole_sale_price = " + + obj.MassPrice
                    + " where  product_master_id = '" + obj.ProductMasterId + "'");
            }

            // stock_in_detail
            dal.ExecuteQuery("insert into stock_in_detail(stock_in_id, product_id, quantity, price, create_date) values ('"
                + stockInId + "', '"
                + obj.ProductId
                + "', " + obj.Quantity
                + ", " + obj.Price + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");

            // stock
            id = dal.GetSingleValue("Select max(stock_id) from stock");
            if (id == null || id.ToString() == string.Empty)
            {
                id = 1;
            }
            else
            {
                id = Convert.ToInt64(id.ToString()) + 1;
            }
            dal.ExecuteQuery("insert into stock(stock_id, product_id, product_master_id, quantity, good_quantity, create_date) values ("
                + id + ", '" 
                + obj.ProductId
                + "', '" + obj.ProductMasterId
                + "', " + obj.Quantity + ", " + obj.Quantity + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");

        }

        private string GetStockInId()
        {
            string dateStr = DateTime.Now.ToString("yyMMdd");
            object id = dal.GetSingleValue("Select max(stock_in_id) from stock_in where stock_in_id >= " + dateStr + "00000");
            if (id == null || id.ToString() == string.Empty)
            {
                id = dateStr + "00001";
            }
            else
            {
                id = Convert.ToInt64(id.ToString()) + 1;
            }
            dal.ExecuteQuery("insert into stock_in(stock_in_id, stock_in_date) values ('"
                + string.Format("{0:00000000000}", Convert.ToInt64(id.ToString()))
                + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");

            return string.Format("{0:00000000000}", Convert.ToInt64(id.ToString()));
        }
		
		private string buildProductId() {
			int year = DateTime.Now.Year;
			
			string month = "";
			int i = DateTime.Now.Month % 12;
			switch (i) {
				case 10: month = "A";
						break;
				case 11: month = "B";
						break;
				case 0: month = "C";
						break;
				default: month = (i) + "";
						break;
			}
			int iDay = DateTime.Now.Day;
			string day = "";
			if (iDay <= 9) {
				day = iDay + "";
			} else {
				day = Convert.ToChar(iDay - 10 + 65) + "";
			}
			
			return (DateTime.Now.Year % 100 - 8) + month + day;
		}
    }
}
