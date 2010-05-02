			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using AppFrame.Base;
using AppFrame.Utils;
using BarcodeLib;
using Caliburn.Core;
using Caliburn.Core.IoC;

using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Filters;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using Neodynamic.WPF;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.Common;


namespace POSServer.ViewModels.Stock.StockIn
{
    
    public class StockInConfirmViewModel : PosViewModel,IStockInConfirmViewModel  
    {

        private IShellViewModel _startViewModel;
        private bool _continousPrint;

        private bool _pricePrint;

        private bool _followQuantityPrint;

        private int _barcodeNumbers;

        private string _barcode;

        private string _barcodeText;

        public StockInConfirmViewModel(IShellViewModel startViewModel,bool _isViewOnly)
        {
            _startViewModel = startViewModel;
            IsViewOnly = _isViewOnly;
        }
		
		#region Fields

        private DateTime _createDate;
        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
                NotifyOfPropertyChange(() => CreateDate);
            }
        }
		        
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        public bool IsViewOnly
        {
            get; set;
        }

        public bool ContinousPrint
        {
            get { return _continousPrint; }
            set { _continousPrint = value; NotifyOfPropertyChange(()=>ContinousPrint);}
        }

        public bool PricePrint
        {
            get { return _pricePrint; }
            set { _pricePrint = value; NotifyOfPropertyChange(()=>PricePrint);}
        }

        public bool FollowQuantityPrint
        {
            get { return _followQuantityPrint; }
            set { _followQuantityPrint = value; NotifyOfPropertyChange(()=>FollowQuantityPrint);}
        }

        public int BarcodeNumbers
        {
            get { return _barcodeNumbers; }
            set { _barcodeNumbers = value; }
        }

        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value;NotifyOfPropertyChange(()=>Barcode); }
        }

        public string BarcodeText
        {
            get { return _barcodeText; }
            set { _barcodeText = value;NotifyOfPropertyChange(()=>BarcodeText); }
        }
        public IMainPriceLogic MainPriceLogic { get; set; }
        #endregion
		
		#region List use to fetch object for view
				#endregion
		
		#region List which just using in Data Grid
		        
        private IList _stockInDetailList;
        public IList StockInDetailList
        {
            get
            {
                return _stockInDetailList;
            }
            set
            {
                _stockInDetailList = value;
                NotifyOfPropertyChange(() => StockInDetailList);
            }
        }

        private IList _selectedStockInDetails;
        public IList SelectedStockInDetails
        {
            get { return _selectedStockInDetails; }
            set { _selectedStockInDetails = value;NotifyOfPropertyChange(()=>SelectedStockInDetails); }
        }


        private StockInDetail _selectedStockInDetail;
        public StockInDetail SelectedStockInDetail
        {
            get { return _selectedStockInDetail; }
            set { _selectedStockInDetail = value; NotifyOfPropertyChange(() => SelectedStockInDetail); }
        }
        #endregion
		
		#region Methods
		        
        public void Help()
        {
            
        }
		        
        public void Back()
        {
            Flow.Back();
        }

        public bool CanSaveConfirm
        {
            get
            {
                return !IsViewOnly;
            }
        }

        [Preview("CanSaveConfirm")]
        public void SaveConfirm()
        {
            GoToNextNode();
        }
		        
        public void Stop()
        {
            Flow.End();
        }

        public void GridSelectionChanged()
        {
            
            StockInDetail detail = SelectedStockInDetail;
            if (detail == null) return;
            Barcode = detail.Product.ProductId;
            BarcodeText = detail.ProductMaster.ProductName;
        }
        public void PrintBarcode()
        {
            if (SelectedStockInDetails == null || SelectedStockInDetails.Count == 0)
            {
                MessageBox.Show("Hay chon mot hang de in ma vach");
                return;
            }
            
            PrintDialog printDialog = new PrintDialog();
            
            // normal print
            if(printDialog.ShowDialog()!=true) return;

            //Image image = GetBarcodeImage();
            
             StockInDetail detail = SelectedStockInDetails[0] as StockInDetail;

            BarcodeProfessional bc = new BarcodeProfessional();
            bc.BarcodeUnit = BarcodeUnit.Inch;
            bc.FitBarcodeToSize = new Size(1.4,0.4);
            bc.Code = detail.Product.ProductId;
            bc.Text = detail.ProductMaster.ProductName;
            bc.Symbology = Symbology.Code128;
            DrawingVisual drawingVisual = new DrawingVisual();
            Visual[] rows = GetBarcodeVisual(SelectedStockInDetails);
            foreach (var visual in rows)
            {
                printDialog.PrintVisual(visual,"Printing barcode ...");   
            }
        }

        private Visual[] GetBarcodeVisual(IList selectedStockInDetails)
        {
            Visual[] rows = null;
            
            if(ContinousPrint)
            {
                
            }
            else
            {
                StockInDetail line = selectedStockInDetails[0] as StockInDetail;
                if(FollowQuantityPrint) // create line follow number of barcode
                { 
                    int numberOfRow = ((int)line.Quantity)/3;
                    if ((line.Quantity % 3) > 0) numberOfRow += 1;
                    rows = new Visual[numberOfRow];
                }
                else // just print 1 line
                {
                    rows = new Visual[1];
                }

                // set up barcode printing
                BarcodeProfessional bc = new BarcodeProfessional();
                bc.BarcodeUnit = BarcodeUnit.Inch;
                bc.FitBarcodeToSize = new Size(1.35, 0.9);
                bc.Code = line.Product.ProductId;
                bc.Symbology = Symbology.Code128;

                // set up extra printing information 
                string titleString = line.ProductMaster.ProductName;
                string priceString = "";
                string extraString = "";

                if (PricePrint) // if print price on barcode
                {
                    MainPrice price =
                        MainPriceLogic.FindById(new MainPricePK
                                                    {
                                                        DepartmentId = 0,
                                                        ProductMasterId = line.ProductMaster.ProductMasterId
                                                    });
                    // print price
                    priceString = "GIA:" + price.Price + ".00";
                }

                // if it has specific Color or Size
                if(line.Product.ProductColor.ColorId > 0 || line.Product.ProductSize.SizeId>0)
                {
                    // print it too
                    extraString = "M:" + line.Product.ProductColor.ColorName + " - " + "S:" +
                                  line.Product.ProductSize.SizeName;
                }
                
                // maximum barcode for print on a line
                int printBarcodes = BarcodeNumbers;
                int quantityOfLine = (int)line.Quantity;
                int barCodeWith = 140;
                for(int i=0;i<rows.Count();i++)
                {
                    DrawingVisual drawingVisual = new DrawingVisual();
                    DrawingContext drawingContext = drawingVisual.RenderOpen();
                    
                    if(FollowQuantityPrint && quantityOfLine > 0) // we get maximum barcode on a line by quantity of product
                    {
                        printBarcodes = quantityOfLine > 3 ? 3 : quantityOfLine;
                        quantityOfLine -= 3; // subtract for next row
                    }
                    
                    // create visual base on barcode
                    for(int j =0;j<printBarcodes;j++)
                    {
                        int startX = (j%3)*140;
                        
                        //drawingContext.DrawImage(bc.GetBarcodeImageSource(), barcodeRec);
                        // draw name of product

                        // write barcode first
                        Rect barcodeRec = new Rect(startX + XCentered(125, barCodeWith), 35, 130, 40); // 1.3 x 0.3 inch
                        DrawingGroup group = bc.GetBarcodeDrawing();
                        group.Transform = new TranslateTransform(startX + 5, 10);
                        
                        drawingContext.DrawDrawing(group);
                        
                        FormattedText formattedTitle = new FormattedText(
                            titleString,
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            new Typeface("Verdana"),
                            8,
                            Brushes.Black);
                        formattedTitle.SetFontSize(8 * (96.0 / 72.0));
                        formattedTitle.TextAlignment = TextAlignment.Center;
                        formattedTitle.MaxTextWidth = 135;
                        drawingContext.DrawText(formattedTitle, new Point(startX+10, 30));
                        
                        // draw extra information if it has
                        if(!string.IsNullOrEmpty(extraString))
                        {
                            FormattedText formattedExtra = new FormattedText(
                            titleString,
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            new Typeface("Verdana"),
                            8,
                            Brushes.Black);
                            formattedExtra.SetFontSize(8 * (96.0 / 72.0));
                            formattedExtra.TextAlignment = TextAlignment.Center;
                            formattedExtra.MaxTextWidth = 135;
                            drawingContext.DrawText(formattedExtra, new Point(startX+10, 88));
                        }
                        // draw price if it has information
                        if (!string.IsNullOrEmpty(priceString))
                        {
                            FormattedText formattedPrice = new FormattedText(
                            titleString,
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            new Typeface("Verdana"),
                            8,
                            Brushes.Black);
                            formattedPrice.TextAlignment = TextAlignment.Center;
                            formattedPrice.SetFontSize(8 * (96.0 / 72.0));
                            formattedPrice.MaxTextWidth = 135;
                            RotateTransform rt = new RotateTransform(90);

                            rt.CenterX = startX+10 / 2;

                            rt.CenterY = 44 / 2;

                            drawingContext.PushTransform(rt);

                            /*drawingContext.DrawText(, new Point(r.Width / 2, r.Height / 2));*/
                            drawingContext.DrawText(formattedPrice, new Point(startX+10+130, 88));
                            drawingContext.Pop();
                        }
                        
                    }
                    drawingContext.Close();
                    rows[i] = drawingVisual;
                    Console.WriteLine("MANY DRAWS :" + drawingVisual.Children.Count.ToString());
                }
            }
            return rows;
        }

        private float XCentered(float localWidth, float globalWidth)
        {
            return ((globalWidth - localWidth) / 2);
        }
        private double XCentered(double localWidth, double globalWidth)
        {
            return ((globalWidth - localWidth) / 2);
        }
        /*private Image GetBarcodeImage()
        {
            if (!ContinousPrint)
            {
                StockInDetail detail = SelectedStockInDetails[0] as StockInDetail;
                var height = 87;
                var numberToPrint = (int)detail.Quantity;
                string code = detail.Product.ProductId;

                if (numberToPrint > 3)
                {
                    height = (numberToPrint / 3) * 87;
                    numberToPrint = 3;
                }
                
                string titleString = "";
                string name = detail.ProductMaster.ProductName;
                if (PricePrint && detail.MainPrice != null)
                {
                    titleString = name + " - " + detail.MainPrice.Price.ToString() + ".00 ";
                }
                else
                {
                    titleString = name;
                }

                Barcode barcode = new Barcode();
                string barCodeStr =detail.Product.ProductId;
                string colorSize = "";
                if (detail.Product.ProductColor.ColorId > 0)
                {
                    colorSize += "M:" +
                                 deptSIDetailList[dgvDeptStockIn.CurrentRow.Index].Product.ProductMaster.ProductColor.
                                     ColorName;
                }
                if (detail.Product.ProductSize.SizeId > 0)
                {
                    if (colorSize.Length > 0)
                    {
                        colorSize += " - ";
                    }
                    colorSize += "S:" +
                                 deptSIDetailList[dgvDeptStockIn.CurrentRow.Index].Product.ProductMaster.ProductSize.
                                     SizeName;
                }

                Image imageBC = null;
                if (ClientSetting.BarcodeType == BarcodeLib.TYPE.CODE128)
                {
                    imageBC = barcode.Encode()
                }
                else
                {
                    imageBC = barcode.Encode(ClientSetting.BarcodeType, barCodeStr, Color.Black, Color.White,
                                                   (int)(1.35 * e.Graphics.DpiX), (int)(0.3 * e.Graphics.DpiY));
                }

                Bitmap bitmap1 = new Bitmap(imageBC);
                bitmap1.SetResolution(204, 204);
                /*Bitmap bitmap2 = new Bitmap(code39Gen);
                bitmap2.SetResolution(203,203);♥1♥
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

                // draw title string

                // calculate scale for title
                var titleStrSize = e.Graphics.MeasureString(titleString.PadRight(25), new Font("Arial", 10));
                float currTitleSize = new Font("Arial", 10).Size;
                float scaledTitleSize = (150 * currTitleSize) / titleStrSize.Width;
                //Font _titleFont = new Font("Arial", scaledTitleSize);
                Font _titleFont = new Font("Arial", 7);
                //string nameString = titleString.Substring(0, titleString.IndexOf(" - "));
                //string priceString = titleString.Substring(titleString.IndexOf(" - "));
                var priceTotalSize = e.Graphics.MeasureString(titleString, _titleFont);
                var colorSizeSize = e.Graphics.MeasureString(colorSize, _titleFont);
                //var nameSize = e.Graphics.MeasureString(nameString, _titleFont);
                //var priceSize = e.Graphics.MeasureString(priceString, _titleFont);
                var barCodeSize = e.Graphics.MeasureString(barCodeStr, _titleFont);
                /*Bitmap bitmapName = new Bitmap(nameString, true);
                Bitmap bitmapPrice = new Bitmap(priceString, true);♥1♥
                for (int i = 0; i < numberToPrint; i++)
                {

                    System.Drawing.Rectangle rc = new System.Drawing.Rectangle((i % 3) * 135, 50, (int)(1.4 * 100), (int)(0.4 * 100));
                    e.Graphics.DrawString(titleString, _titleFont, new SolidBrush(Color.Black),
                                          (i % 3) * 135 + XCentered(priceTotalSize.Width, 140), (float)25);

                    if (ClientSetting.BarcodeType == BarcodeLib.TYPE.CODE128)
                    {
                        e.Graphics.DrawImage(imageBC,// (i % 3) * 140 + (int)XCentered((float)(1.35 * 100), 140), (int)(25 + priceTotalSize.Height)
                                             new Rectangle((i % 3) * 135 + (int)XCentered((float)(1.3 * 100), 140),
                                                           (int)(25 + priceTotalSize.Height), (int)(1.3 * 100), (int)(0.3 * 100))
                                                           );

                    }
                    else
                    {
                        e.Graphics.DrawImage(bitmap1,
                                             new Rectangle((i % 3) * 140 + (int)XCentered((float)(1.35 * 100), 140),
                                                           (int)(25 + priceTotalSize.Height), (int)(1.35 * 100),
                                                           (int)(0.3 * 100)));
                    }

                    e.Graphics.DrawString(barCodeStr, _titleFont, new SolidBrush(Color.Black),
                                          (i % 3) * 140 + XCentered(barCodeSize.Width, 140), (float)72);
                    e.Graphics.DrawString(colorSize, _titleFont, new SolidBrush(Color.Black),
                                          (i % 3) * 140 + XCentered(colorSizeSize.Width, 140), (float)88);
                    //e.Graphics.DrawImage(barcodeControl1.GetMetaFile(), new Rectangle((i % 3) * 135, 120, (i % 3) * 135 + (int)(1.4 * 100), (int)(0.75 * 100)));                    

                }
            }
            else // continue printing
            {
                var height = 87;
                if (printList == null || printList.Count == 0)
                {
                    return;
                }
                var numberToPrint = printList.Count;

                for (int i = 0; i < numberToPrint; i++)
                {
                    string code = printList[i].ProductId;
                    var eventArgs = new MainStockInEventArgs
                    {
                        ProductMasterIdForPrice = printList[i].ProductMaster.ProductMasterId
                    };
                    EventUtility.fireEvent(GetPriceEvent, this, eventArgs);
                    string titleString = "";
                    string name = printList[i].ProductMaster.ProductName;
                    if (chkPrintPrice.Checked && eventArgs.DepartmentPrice != null)
                    {
                        titleString = name + " - " + eventArgs.DepartmentPrice.Price.ToString() + ".00 ";
                    }
                    else
                    {
                        titleString = name;
                    }

                    BarcodeLib.Barcode barcode = new Barcode();
                    string barCodeStr = printList[i].ProductId;
                    string colorSize = "";
                    if (printList[i].ProductMaster.ProductColor.ColorId > 0)
                    {
                        colorSize += "M:" +
                                     printList[i].ProductMaster.ProductColor.ColorName;
                    }
                    if (printList[i].ProductMaster.ProductSize.SizeId > 0)
                    {
                        if (colorSize.Length > 0)
                        {
                            colorSize += " - ";
                        }
                        colorSize += "S:" +
                                     printList[i].ProductMaster.ProductSize.SizeName;
                    }

                    Image imageBC = null;
                    if (ClientSetting.BarcodeType == BarcodeLib.TYPE.CODE128)
                    {
                        imageBC = barcode.Encode(ClientSetting.BarcodeType, barCodeStr
                            //, Color.Black, Color.White,
                            //(int) (1.35*e.Graphics.DpiX), (int) (0.3*e.Graphics.DpiY)
                                                        );

                    }
                    else
                    {
                        imageBC = barcode.Encode(ClientSetting.BarcodeType, barCodeStr, Color.Black, Color.White,
                                                       (int)(1.35 * e.Graphics.DpiX), (int)(0.3 * e.Graphics.DpiY));

                    }

                    Bitmap bitmap1 = new Bitmap(imageBC);
                    bitmap1.SetResolution(204, 204);
                    /*Bitmap bitmap2 = new Bitmap(code39Gen);
                    bitmap2.SetResolution(203,203);♥1♥
                    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

                    // draw title string

                    // calculate scale for title
                    var titleStrSize = e.Graphics.MeasureString(titleString.PadRight(25), new Font("Arial", 10));
                    float currTitleSize = new Font("Arial", 10).Size;
                    float scaledTitleSize = (150 * currTitleSize) / titleStrSize.Width;
                    //Font _titleFont = new Font("Arial", scaledTitleSize);
                    Font _titleFont = new Font("Arial", 7);
                    Font _barCodeFont = new Font("Arial", 8);
                    var priceTotalSize = e.Graphics.MeasureString(titleString, _titleFont);
                    var colorSizeSize = e.Graphics.MeasureString(colorSize, _titleFont);
                    var barCodeSize = e.Graphics.MeasureString(barCodeStr, _barCodeFont);


                    System.Drawing.Rectangle rc = new System.Drawing.Rectangle((i % 3) * 135, 50, (int)(1.4 * 100),
                                                                               (int)(0.4 * 100));


                    e.Graphics.DrawString(titleString, _titleFont, new SolidBrush(Color.Black),
                                          (i % 3) * 135 + XCentered(priceTotalSize.Width, 140), (float)25);

                    if (ClientSetting.BarcodeType == BarcodeLib.TYPE.CODE128)
                    {
                        e.Graphics.DrawImage(imageBC,// (i % 3) * 140 + (int)XCentered((float)(1.35 * 100), 140), (int)(25 + priceTotalSize.Height)
                                             new Rectangle((i % 3) * 135 + (int)XCentered((float)(1.3 * 100), 140),
                                                           (int)(25 + priceTotalSize.Height), (int)(1.3 * 100),
                                                           (int)(0.3 * 100))
                                             );

                    }
                    else
                    {
                        e.Graphics.DrawImage(bitmap1,
                                             new Rectangle((i % 3) * 140 + (int)XCentered((float)(1.35 * 100), 140),
                                                           (int)(25 + priceTotalSize.Height), (int)(1.35 * 100),
                                                           (int)(0.3 * 100)));
                    }

                    e.Graphics.DrawString(barCodeStr, _barCodeFont, new SolidBrush(Color.Black),
                                          (i % 3) * 140 + XCentered(barCodeSize.Width, 140), (float)72);
                    e.Graphics.DrawString(colorSize, _titleFont, new SolidBrush(Color.Black),
                                          (i % 3) * 140 + XCentered(colorSizeSize.Width, 140), (float)88);

                }
            }
        }*/

        public override void Initialize()
        {
            base.Initialize();
            CoralPOS.Models.StockIn stockIn = Flow.Session.Get(FlowConstants.SAVE_STOCK_IN) as CoralPOS.Models.StockIn;
            Description = stockIn.Description;
            stockIn.TotalQuantity = 0;
            foreach (StockInDetail inDetail in stockIn.StockInDetails)
            {
                inDetail.StockIn = stockIn;
                stockIn.TotalQuantity += inDetail.Quantity;
            }
            StockInDetailList = ObjectConverter.ConvertFrom(stockIn.StockInDetails);
            CreateDate = stockIn.CreateDate;
            SelectedStockInDetails = new ArrayList();
            BarcodeNumbers = 3;
        }

        #endregion
		
        
        
    }
}