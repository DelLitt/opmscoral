using System;
using System.Collections;
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
    public partial class Form2 : Form
    {
        public readonly int START_ROW = 2;
        private DataAccessLayer dal = new DataAccessLayer();

        public Form2()
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

                List<int> departmentsList = GetDepartmentsList(ws, errorList);
                if(departmentsList.Count != 7)
                {
                    return;
                }
                int deptCount = 0;
                for (int i = row; i < endRow; i++)
                {
                    ErrorObject errorObject;
                    ImportObject obj = GetImportObject(i, ws, out errorObject, departmentsList[0], "F");
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

                    obj = GetImportObject(i, ws, out errorObject, departmentsList[1], "G");
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

                    obj = GetImportObject(i, ws, out errorObject, departmentsList[2], "H");
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

                    obj = GetImportObject(i, ws, out errorObject, departmentsList[3], "I");
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

                    obj = GetImportObject(i, ws, out errorObject, departmentsList[4], "J");
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

                    obj = GetImportObject(i, ws, out errorObject, departmentsList[5], "K");
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

                    obj = GetImportObject(i, ws, out errorObject, departmentsList[6], "L");
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

                if (importList.Count > 0)
                {
                    ErrorObject errorObject;
                    Dictionary<long, int> stockOutIdMap = new Dictionary<long, int>();
                    string stockInId = GetStockInId();
                    foreach (ImportObject import in importList)
                    {
                        importToDB(import, stockInId, stockOutIdMap, out errorObject);
                        if (errorObject != null)
                        {
                            errorList.Add(errorObject);
                        }
                    }
                }
                MessageBox.Show("Số lượng xuất: " + importList.Count + "/" + (endRow - row));
                if (errorList.Count > 0)
                {
                    errorBindingSource.DataSource = errorList;
                    return;
                }
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

        private List<int> GetDepartmentsList(Worksheet ws,List<ErrorObject> errorList )
        {
            List<int> list = new List<int>();
            
            // F
            Range range = ws.get_Range("F" + 1, "F" + 1);
            string name = range.Value2 != null ? range.Value2.ToString() : "";
            if(!string.IsNullOrEmpty(name))
            {
                int deptId = 0;
                Int32.TryParse(name, out deptId);
                if(deptId>0)
                list.Add(deptId);
                else
                {
                    ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 " + name + " không phải là department id", RowNumber = 1 };
                    errorList.Add(errorObject);
                }
            }
            else
            {
                ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 không có department id", RowNumber = 1 };
                errorList.Add(errorObject);
            }

            // G
            range = ws.get_Range("G" + 1, "G" + 1);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            if (!string.IsNullOrEmpty(name))
            {
                int deptId = 0;
                Int32.TryParse(name, out deptId);
                if (deptId > 0)
                    list.Add(deptId);
                else
                {
                    ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 " + name + " không phải là department id", RowNumber = 1 };
                    errorList.Add(errorObject);
                }
            }
            else
            {
                ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 không có department id", RowNumber = 1 };
                errorList.Add(errorObject);
            }

            // H
            range = ws.get_Range("H" + 1, "H" + 1);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            if (!string.IsNullOrEmpty(name))
            {
                int deptId = 0;
                Int32.TryParse(name.Trim(), out deptId);
                if (deptId > 0)
                    list.Add(deptId);
                else
                {
                    ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 " + name + " không phải là department id", RowNumber = 1 };
                    errorList.Add(errorObject);
                }
            }
            else
            {
                ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 không có department id", RowNumber = 1 };
                errorList.Add(errorObject);
            }

            // I
            range = ws.get_Range("I" + 1, "I" + 1);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            if (!string.IsNullOrEmpty(name))
            {
                int deptId = 0;
                Int32.TryParse(name, out deptId);
                if (deptId > 0)
                    list.Add(deptId);
                else
                {
                    ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 " + name + " không phải là department id", RowNumber = 1 };
                    errorList.Add(errorObject);
                }
            }
            else
            {
                ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 không có department id", RowNumber = 1 };
                errorList.Add(errorObject);
            }

            // J
            range = ws.get_Range("J" + 1, "J" + 1);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            if (!string.IsNullOrEmpty(name))
            {
                int deptId = 0;
                Int32.TryParse(name, out deptId);
                if (deptId > 0)
                    list.Add(deptId);
                else
                {
                    ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 " + name + " không phải là department id", RowNumber = 1 };
                    errorList.Add(errorObject);
                }
            }
            else
            {
                ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 không có department id", RowNumber = 1 };
                errorList.Add(errorObject);
            }

            // K
            range = ws.get_Range("K" + 1, "K" + 1);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            if (!string.IsNullOrEmpty(name))
            {
                int deptId = 0;
                Int32.TryParse(name, out deptId);
                if (deptId > 0)
                    list.Add(deptId);
                else
                {
                    ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 " + name + " không phải là department id", RowNumber = 1 };
                    errorList.Add(errorObject);
                }
            }
            else
            {
                ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 không có department id", RowNumber = 1 };
                errorList.Add(errorObject);
            }

            // L
            range = ws.get_Range("L" + 1, "L" + 1);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            if (!string.IsNullOrEmpty(name))
            {
                int deptId = 0;
                Int32.TryParse(name, out deptId);
                if (deptId > 0)
                    list.Add(deptId);
                else
                {
                    ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 " + name + " không phải là department id", RowNumber = 1 };
                    errorList.Add(errorObject);
                }
            }
            else
            {
                ErrorObject errorObject = new ErrorObject { ErrorMessage = "Dòng 1 không có department id", RowNumber = 1 };
                errorList.Add(errorObject);
            }

            return list;
        }

        private ImportObject GetImportObject(int row, Worksheet ws, out ErrorObject errorObject, long deptId, string sizeColumn)
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
                obj.TypeName = name.Trim();
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
                //obj.ProductName = obj.TypeName + " " + name.Trim();
                obj.ProductName = name.Trim();
            }

            // Color
            range = ws.get_Range("C" + row, "C" + row);
            name = range.Value2 != null ? range.Value2.ToString() : "";

            if (name.Length > 500)
            {
                errorMsg.Append("Màu sắc tối đa 500 kí tự!!");
            }
            else
            {
                obj.ColorName = name.Trim();
            }

            // Price
            /*range = ws.get_Range("C" + row, "C" + row);
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
            }*/
            
            // Size
            range = ws.get_Range("D" + row, "D" + row);
            name = range.Value2 != null ? range.Value2.ToString() : "";

            if (name.Length > 500)
            {
                errorMsg.Append("Kích cỡ tối đa 500 kí tự!!");
            }
            else
            {
                obj.SizeName = obj.SizeName + " " + name.Trim();
            }
            
            // Position
            /*range = ws.get_Range("E" + row, "E" + row);
            name = range.Value2 != null ? range.Value2.ToString() : "";

            if (name.Length > 500)
            {
                errorMsg.Append("Màu sắc tối đa 500 kí tự!!");
            }
            else
            {
                obj.Position = name;
            }*/
            
            // Description
            range = ws.get_Range("M" + row, "M" + row);
            name = range.Value2 != null ? range.Value2.ToString() : "";

            if (name.Length > 500)
            {
                errorMsg.Append("Ghi chú tối đa 500 kí tự!!");
            }
            else
            {
                obj.Description = name.Trim();
            }
            
            // Size
            obj.deptId = deptId;

            // Số lượng
            range = ws.get_Range(sizeColumn + row, sizeColumn + row);
            name = range.Value2 != null ? range.Value2.ToString() : "";
            
            int value = 0;
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
            obj.Row = row;
            if (value == 0) 
            {
                return null;
            }
            
            return obj;
        }

        private void importToDB(ImportObject obj, string stockInId, Dictionary<long, int> stockOutIdMap, out ErrorObject errorObject)
        {
            StringBuilder errorMsg = new StringBuilder();
            object id = dal.GetSingleValue("Select type_id from product_type where type_name = '" + obj.TypeName.Replace("'" , "''") + "'");
            if (id == null || id.ToString() == string.Empty)
            {
                errorMsg.Append("Không tồn tại loại!!");
            } else
            {
                obj.TypeId = Convert.ToInt32(id.ToString());
            }

            id = dal.GetSingleValue("Select color_id from product_color where color_name = '" + obj.ColorName.Replace("'", "''") + "'");
            if (id == null || id.ToString() == string.Empty)
            {
                errorMsg.Append("Không tồn tại màu sắc!!");
            } else
            {
                obj.ColorId = Convert.ToInt32(id.ToString());
            }
            

            id = dal.GetSingleValue("Select size_id from product_size where size_name = '" + obj.SizeName.Replace("'", "''").Trim() + "'");
            if (id == null || id.ToString() == string.Empty)
            {
                errorMsg.Append("Không tồn tại kích cỡ!!");
            } else
            {
                obj.SizeId = Convert.ToInt32(id.ToString());
            }
            

            // product master
            if (errorMsg.Length == 0)
            {
                string sqlPM = "Select product_master_id from product_master where size_id = "
                               + obj.SizeId + " and color_id = " + obj.ColorId + " and type_id = " + obj.TypeId
                               + " and product_name = '" + obj.ProductName + "'";
                id = dal.GetSingleValue(sqlPM);
                if (id == null || id.ToString() == string.Empty)
                {
                    errorMsg.Append("Không tồn tại sản phẩm!!");
                }
                else
                {
                    obj.ProductMasterId = id.ToString();
                }


                // stock

                if (obj.ProductMasterId != null)
                {
                    IList<IList<object>> updateList = new List<IList<object>>();

                    string sqlSl =
                        "select stock_id, product_id, quantity, good_quantity from stock where product_master_id = '" +
                        obj.ProductMasterId + "' order by create_date desc ";
                    IList<IList<object>> listStock =
                        dal.GetListValue(sqlSl, 4);
                    if (listStock != null && listStock.Count > 0)
                    {
                        long quantity = obj.Quantity;
                        foreach (IList<object> list in listStock)
                        {
                            if(quantity == 0 )
                            {
                                break;
                            }
                            long goodQty = Int64.Parse(list[3].ToString());
                            long stockQty = Int64.Parse(list[2].ToString());
                            if(goodQty == 0)
                            {
                                continue;
                            }
                            if (quantity >= goodQty)
                            {
                                list[3] = 0;
                                quantity -= goodQty;
                                stockQty -= goodQty;
                                if (stockQty < 0)
                                {
                                    stockQty = 0;
                                }
                                list[2] = stockQty;
                            }
                            else
                            {
                                list[3] = goodQty - quantity;
                                stockQty -= quantity;
                                quantity = 0;
                                if (stockQty < 0)
                                {
                                    stockQty = 0;
                                }
                                list[2] = stockQty;
                            }
                            updateList.Add(list);
                            if (quantity == 0)
                            {
                                break;
                            }
                        }
                        if (quantity > 0)
                        {
                            // error
                        }
                        else if (updateList.Count > 0)
                        {
                            foreach (IList<object> list in updateList)
                            {
                                string strUpdateStock = "update stock set quantity = " + list[2].ToString() +
                                                        ", good_quantity = " + list[3].ToString()
                                                        + " where  stock_id = " + list[0].ToString() + "";
                                dal.ExecuteQuery(strUpdateStock);

                                int stockOutId = 0;
                                stockOutIdMap.TryGetValue(obj.deptId, out stockOutId);
                                if (stockOutId == 0)
                                {
                                    stockOutId = GetStockOutId(obj.deptId);
                                    stockOutIdMap[obj.deptId] = stockOutId;
                                }
                                id = dal.GetSingleValue("Select max(stock_out_detail_id) from stock_out_detail");
                                if (id == null || id.ToString() == string.Empty)
                                {
                                    id = 1;
                                }
                                else
                                {
                                    id = Convert.ToInt64(id.ToString()) + 1;
                                }
                                dal.ExecuteQuery("insert into stock_out_detail(stock_out_detail_id, stockout_id, product_id, product_master_id, quantity, good_quantity, create_date,update_date,create_id,update_id,exclusive_key,defect_status_id,description) values ("
                                                 + id
                                                 + ", " + stockOutId
                                                 + ", '" + list[1]
                                                 + "', '" + obj.ProductMasterId
                                                 + "', " + obj.Quantity + ", " + obj.Quantity + ", '" +
                                                 DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" +
                                                 DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                                                 "','admin','admin',1,0,'Export goods')");
                            }
                        }
                    }
                }
            }
            if (errorMsg.Length == 0)
            {
                errorObject = null;
            }
            else
            {
                errorObject = new ErrorObject { ErrorMessage = errorMsg.ToString(), RowNumber = obj.Row };
            }
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

        private int GetStockOutId(long deptId)
        {
            object id = dal.GetSingleValue("Select max(stockout_id) from stock_out");
            if (id == null || id.ToString() == string.Empty)
            {
                id = 1;
            }
            else
            {
                id = Convert.ToInt64(id.ToString()) + 1;
            }
            dal.ExecuteQuery("insert into stock_out(stockout_id, department_id,create_date,stock_out_date,update_date,create_id,update_id,exclusive_key,defect_status_id) values ("
                + id
                + ", " + deptId + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"+
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','admin','admin',1,0)");

            return Convert.ToInt32(id.ToString());
        }

		private string buildProductId() {
			int year = DateTime.Now.Year;
			
			string month = "";
			int i = DateTime.Now.Month % 12;
			switch (i) {
				case 9: month = "A";
						break;
				case 10: month = "B";
						break;
				case 11: month = "C";
						break;
				default: month = (i + 1) + "";
						break;
			}
			int iDay = DateTime.Now.Day;
			string day = "";
			if (iDay <= 9) {
				day = iDay + "";
			} else {
				day = Convert.ToChar(iDay - 9 + 65) + "";
			}
			
			return (DateTime.Now.Year % 100 - 8) + month + day;
		}
    }
}
