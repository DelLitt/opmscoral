			 

			 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AppFrame.Base;
using AppFrame.Utils;
using AppFrame.WPF;
using CoralPOS.Models;
using Neodynamic.WPF;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;


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

		public StockInConfirmViewModel(bool _isViewOnly)
		{
			_startViewModel = ShellViewModel.Current;
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

		//[Preview("CanSaveConfirm")]
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
			Visual[] rows = GetBarcodeVisual(SelectedStockInDetails);
			foreach (var visual in rows)
			{
				printDialog.PrintVisual(visual,"Printing barcode ...");   
			}
		}

		private Visual[] GetBarcodeVisual(IList selectedStockInDetails)
		{
			Visual[] rows = null;
			int barcodeWidth = 140;

			if(ContinousPrint)
			{
				rows = new Visual[1];
				int count = 1;
				DrawingVisual drawingVisual = new DrawingVisual();

				//create barcode list needed to print
				IList<BarcodeLine> barcodeLines = new List<BarcodeLine>();

				foreach (StockInDetail line in SelectedStockInDetails)
				{
					// just create max 3  barcodes
					if (count > 3) break;

					// set up barcode printing
					BarcodeProfessional bc = new BarcodeProfessional();
					bc.BarcodeUnit = BarcodeUnit.Inch;
					bc.FitBarcodeToSize = new Size(1.1, 0.8);
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
					if (line.Product.ProductColor.ColorId > 0 || line.Product.ProductSize.SizeId > 0)
					{
						// print it too
						extraString = "M:" + line.Product.ProductColor.ColorName + " - " + "S:" +
									  line.Product.ProductSize.SizeName;
					}

					BarcodeLine barcodeLine = new BarcodeLine
													  {
														  TitleString = titleString,
														  BarcodeString = line.Product.ProductId,
														  ExtraString = extraString,
														  Barcode = bc.GetBarcodeDrawing(),
														  PriceString = priceString
													  };
					barcodeLines.Add(barcodeLine);
					count += 1;
				}
				// draw barcode line
				CreateBarcodeLine(barcodeLines, drawingVisual, barcodeWidth);
				rows[0] = drawingVisual;
			}
			else
			{
				StockInDetail line = selectedStockInDetails[0] as StockInDetail;
				if (FollowQuantityPrint) // create line follow number of barcode
				{
					int numberOfRow = ((int)line.Quantity) / 3;
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
				bc.FitBarcodeToSize = new Size(1.1, 0.8);
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
				if (line.Product.ProductColor.ColorId > 0 || line.Product.ProductSize.SizeId > 0)
				{
					// print it too
					extraString = "M:" + line.Product.ProductColor.ColorName + " - " + "S:" +
								  line.Product.ProductSize.SizeName;
				}

				// maximum barcode for print on a line
				int printBarcodes = BarcodeNumbers;
				int quantityOfLine = (int)line.Quantity;

				for (int i = 0; i < rows.Count(); i++)
				{
					DrawingVisual drawingVisual = new DrawingVisual();
					DrawingContext drawingContext = drawingVisual.RenderOpen();

					if (FollowQuantityPrint && quantityOfLine > 0) // we get maximum barcode on a line by quantity of product
					{
						printBarcodes = quantityOfLine > 3 ? 3 : quantityOfLine;
						quantityOfLine -= 3; // subtract for next row
					}
					//create barcode list needed to print
					IList<BarcodeLine> barcodeLines = new List<BarcodeLine>();
					for (int j = 0; j < printBarcodes; j++)
					{
						BarcodeLine barcodeLine = new BarcodeLine
													  {
														  TitleString = titleString,
														  BarcodeString = line.Product.ProductId,
														  ExtraString = extraString,
														  Barcode = bc.GetBarcodeDrawing(),
														  PriceString = priceString
													  };
						barcodeLines.Add(barcodeLine);
					}
					// draw barcode line
					CreateBarcodeLine(barcodeLines, drawingVisual, barcodeWidth);
					rows[i] = drawingVisual;
				}
			}
			return rows;
		}

		private void CreateBarcodeLine(IList<BarcodeLine> barcodeLines, DrawingVisual drawingVisual,int barcodeWidth)
		{
			DrawingContext drawingContext = drawingVisual.RenderOpen();
			// create visual base on barcode
			for (int index = 0; index < barcodeLines.Count; index++)
			{
				BarcodeLine line = barcodeLines[index];
				int startX = (index % 3) * 140;
				//drawingContext.DrawImage(bc.GetBarcodeImageSource(), barcodeRec);
				// draw name of product

				// write barcode first
				//Rect barcodeRec = new Rect(startX + XCentered(125, barCodeWith), 35, 130, 40); // 1.3 x 0.3 inch
				DrawingGroup group = line.Barcode;
				group.Transform = new TranslateTransform(startX, 10);

				drawingContext.DrawDrawing(group);
				// erase the title area
				drawingContext.DrawRectangle(Brushes.White, null, new Rect(startX + 5, 0, barcodeWidth, 30));
				// erase the footer area
				drawingContext.DrawRectangle(Brushes.White, null, new Rect(startX + 5, 68, barcodeWidth, 40));

				#region useless
				/*FormattedText formattedTitle = new FormattedText(
					titleString,
					CultureInfo.GetCultureInfo("en-us"),
					FlowDirection.LeftToRight,
					new Typeface("Verdana"),
					8,
					Brushes.Black);*/

				#endregion
				FormattedText formattedTitle = WPFUtils.CreateFormattedText(line.TitleString, 8, Brushes.Black,
																			new Typeface("Verdana"), 120,
																			TextAlignment.Center);
				formattedTitle.SetFontSize(8 * (96.0 / 72.0));
				formattedTitle.TextAlignment = TextAlignment.Center;
				formattedTitle.MaxTextWidth = 120;
				drawingContext.DrawText(formattedTitle, new Point(startX + 10, 10));
				// draw barcode string
				FormattedText formattedBarcode = WPFUtils.CreateFormattedText(line.BarcodeString, 7, Brushes.Black,
																			new Typeface("Verdana"), 120,
																			TextAlignment.Center);

				drawingContext.DrawText(formattedBarcode, new Point(startX + 10, 68));

				// draw extra information if it has
				if (!string.IsNullOrEmpty(line.ExtraString))
				{
					FormattedText formattedExtra = WPFUtils.CreateFormattedText(line.ExtraString, 7, Brushes.Black,
																			new Typeface("Verdana"), 120,
																			TextAlignment.Center);
					drawingContext.DrawText(formattedExtra, new Point(startX + 10, 80));
				}
				// draw price if it has information
				if (!string.IsNullOrEmpty(line.PriceString))
				{
					FormattedText formattedPrice = WPFUtils.CreateFormattedText(line.PriceString, 7, Brushes.Black,
																			new Typeface("Verdana"), 100,
																			TextAlignment.Center);

					// transform text to vertical
					RotateTransform rt = new RotateTransform(-90);
					// center point using for rotating text
					rt.CenterX = startX + barcodeWidth - 10;
					rt.CenterY = 92;

					drawingContext.PushTransform(rt);
					/*drawingContext.DrawText(, new Point(r.Width / 2, r.Height / 2));*/
					drawingContext.DrawText(formattedPrice, new Point(startX + barcodeWidth - 10, 92));
					drawingContext.Pop();
				}

			}
			drawingContext.Close();
		}

		private float XCentered(float localWidth, float globalWidth)
		{
			return ((globalWidth - localWidth) / 2);
		}
		private double XCentered(double localWidth, double globalWidth)
		{
			return ((globalWidth - localWidth) / 2);
		}
		

		protected override void OnInitialize()
		{
			base.OnInitialize();
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

	public class BarcodeLine
	{
		public string TitleString { get; set; }
		public string BarcodeString { get; set; }
		public string ExtraString { get; set; }
		public DrawingGroup Barcode { get; set; }

		public string PriceString { get; set; }
	}
}