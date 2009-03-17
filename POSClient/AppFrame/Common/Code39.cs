using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace AppFrame.Common
{
    /// <summary>
    /// Summary description for Code39.
    /// </summary>
    public class Code39
    {
        private const int _itemSepHeight=0;
		
        SizeF _titleSize=SizeF.Empty;
        SizeF _barCodeSize=SizeF.Empty;
        SizeF _codeStringSize=SizeF.Empty;
		
        #region Barcode Title 

        private string _titleString=null;
        private Font _titleFont=null;

        public string Title
        {
            get { return _titleString; }
            set { _titleString=value; }
        }

        public Font TitleFont
        {
            get { return _titleFont; }
            set { _titleFont=value; }
        }
        #endregion

        #region Barcode code string

        private bool _showCodeString=false;
        private Font _codeStringFont=null;

        public bool ShowCodeString
        {
            get { return _showCodeString; }
            set { _showCodeString=value; }
        }

        public Font CodeStringFont
        {
            get { return _codeStringFont; }
            set { _codeStringFont=value; }
        }
        #endregion

        #region Barcode Font

        private Font _c39Font=null;
        private float _c39FontSize=5;
        private string _c39FontFileName=null;
        private string _c39FontFamilyName=null;		

        public string FontFileName
        {
            get { return _c39FontFileName; }
            set { _c39FontFileName=value; }
        }

        public string FontFamilyName
        {
            get { return _c39FontFamilyName; }
            set { _c39FontFamilyName=value; }
        }

        public float FontSize
        {
            get { return _c39FontSize; }
            set { _c39FontSize=value; }
        }
		
        private Font Code39Font
        {
            get
            {
                if (_c39Font==null)
                {
                    // Load the barcode font			
                    PrivateFontCollection pfc=new PrivateFontCollection();
                    pfc.AddFontFile(_c39FontFileName);
                    FontFamily family=new FontFamily(_c39FontFamilyName,pfc);			
                    _c39Font=new Font(family,_c39FontSize);
                }
                return _c39Font;
            }
        }

        #endregion

        public Code39()
        {
            _titleFont=new Font("Tahoma",10);
            _codeStringFont = new Font("Tahoma", 10);
        }
		
        #region Barcode Generation
        public Image GenerateBarcode(string barCode,int width,int height)
        {
            int bX = 15;
            int bY = 10;
            int bWidth = width - 2*bX;
            int bStrHeight = height/5-bY;
            int bBarcodeHeight = height*2/5 - bY;
            Bitmap bitmap = new Bitmap(width,height,PixelFormat.Format24bppRgb);
            bitmap.SetResolution((float)(721),(float)(721));
            Graphics objGraphics = Graphics.FromImage(bitmap);
            objGraphics.FillRectangle(new SolidBrush(Color.White),new Rectangle(0,0,width,height));
            //objGraphics.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, width, height));
            Rectangle titleRec = new Rectangle(bX, bY, bWidth, bStrHeight);
            Rectangle barcodeRec = new Rectangle(bX, height*2 / 5, bWidth, bBarcodeHeight);
            Rectangle barCodeStrRec = new Rectangle(bX,height*4/5,bWidth,bStrHeight);

            // draw title string
            string nameString = _titleString.Substring(0, _titleString.IndexOf("Giá"));
            string priceString = _titleString.Substring(_titleString.IndexOf("Giá"));
            if(_titleString!=null)
            {
                // calculate scale for title
                var titleStrSize = objGraphics.MeasureString(_titleString, _titleFont);
                float currTitleSize = _titleFont.Size;
                float scaledTitleSize = (bWidth * currTitleSize) / titleStrSize.Width;
                _titleFont = new Font("Arial",scaledTitleSize);
            }
            var nameSize = objGraphics.MeasureString(nameString, _titleFont);
            var priceSize = objGraphics.MeasureString(priceString, _titleFont);
            objGraphics.DrawString(nameString, _titleFont, new SolidBrush(Color.Black),
                    (float)XCentered((int)nameSize.Width,width),bY);
            objGraphics.DrawString(priceString, _titleFont, new SolidBrush(Color.Black),
                    (float)XCentered((int)priceSize.Width, width), (float)height*1/5);
            
            
            // calculate scale for barcode font
            var bcSize = objGraphics.MeasureString(barCode, Code39Font);
            float currBCSize = _c39Font.Size;
            float scaledBCSize = (bWidth * currBCSize) / bcSize.Width;
            PrivateFontCollection pfc=new PrivateFontCollection();
            pfc.AddFontFile(_c39FontFileName);
            FontFamily family=new FontFamily(_c39FontFamilyName,pfc);
            _c39Font = new Font(family, scaledBCSize);

            
            bcSize = objGraphics.MeasureString(barCode, _c39Font);
            float bcHeight = bcSize.Height;
            float startY = (float)height * 2 / 5;
            while (startY < (float)height*2/5 + (float)bBarcodeHeight)
            {
                objGraphics.DrawString(barCode, _c39Font, new SolidBrush(Color.Black),
                                       (float) bX, startY);

                startY = startY + bcHeight-19;
            }
            //objGraphics.DrawString(barCode, _c39Font, new SolidBrush(Color.Black), barcodeRec);
            
            if (_showCodeString)
            {
                // calculate scale for code
                var _codeSize = objGraphics.MeasureString(barCode, _codeStringFont);
                float currCodeSize = _codeStringFont.Size;
                float scaledCodeSize = ((bWidth-20) * currCodeSize) / _codeSize.Width;
                _codeStringFont = new Font("Arial", scaledCodeSize);
                _codeSize = objGraphics.MeasureString(barCode, _codeStringFont);
                objGraphics.FillRectangle(new SolidBrush(Color.White), barCodeStrRec);
                objGraphics.DrawString(barCode, _codeStringFont, new SolidBrush(Color.Black),(float)XCentered((int)_codeSize.Width,width),(float)height*4/5);

            }


            return bitmap;
        }

        private RectangleF CreateRectangleF(Rectangle rec)
        {
            return new RectangleF((float)rec.X,(float)rec.Y,(float)rec.Width,(float)rec.Height);
        }

        public Bitmap GenerateBarcode(string barCode)
        {
			
            int bcodeWidth=0;
            int bcodeHeight=0;

            // Get the image container...
            Bitmap  bcodeBitmap =CreateImageContainer(barCode, ref bcodeWidth, ref bcodeHeight);
            Graphics objGraphics = Graphics.FromImage(bcodeBitmap);

            // Fill the background			
            objGraphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0,0,bcodeWidth,bcodeHeight));

            int vpos=0;

            // Draw the title string
            if (_titleString!=null)			
            {
                objGraphics.DrawString(_titleString, _titleFont, new SolidBrush(Color.Black),XCentered((int)_titleSize.Width,bcodeWidth),vpos);
                vpos+=(((int)_titleSize.Height)+_itemSepHeight);
            }
            // Draw the barcode
            objGraphics.DrawString(barCode, Code39Font, new SolidBrush(Color.Black),XCentered((int)_barCodeSize.Width,bcodeWidth),vpos);

            // Draw the barcode string
            if (_showCodeString)
            {
                vpos+=(((int)_barCodeSize.Height) - 5);
                objGraphics.DrawString(barCode, _codeStringFont, new SolidBrush(Color.Black),XCentered((int)_codeStringSize.Width,bcodeWidth),vpos);
            }

            // return the image...									
            return bcodeBitmap;			
        }		

        private Bitmap CreateImageContainer(string barCode, ref int bcodeWidth, ref int bcodeHeight)
        {			

            Graphics objGraphics;	

            // Create a temporary bitmap...
            Bitmap tmpBitmap = new Bitmap(1, 1, PixelFormat.Format64bppPArgb); //Format32bppArgb
            objGraphics = Graphics.FromImage(tmpBitmap); 

            // calculate size of the barcode items...
            if (_titleString!=null)			
            {
                _titleSize=objGraphics.MeasureString(_titleString,_titleFont);				
                bcodeWidth=(int)_titleSize.Width;
                bcodeHeight=(int)_titleSize.Height+_itemSepHeight;
            }

            _barCodeSize=objGraphics.MeasureString(barCode,Code39Font);								
            bcodeWidth=Max(bcodeWidth,(int)_barCodeSize.Width);
            bcodeHeight+=(int)_barCodeSize.Height;
			
            if (_showCodeString)
            {
                _codeStringSize=objGraphics.MeasureString(barCode,_codeStringFont);
                bcodeWidth=Max(bcodeWidth,(int)_codeStringSize.Width);
                bcodeHeight+=(_itemSepHeight+(int)_codeStringSize.Height);
            }
			
            // dispose temporary objects...
            objGraphics.Dispose();
            tmpBitmap.Dispose();

            return (new Bitmap(bcodeWidth, bcodeHeight, PixelFormat.Format64bppPArgb));
        }

        #endregion


        #region Auxiliary Methods

        private int Max(int v1, int v2)
        {
            return (v1>v2 ? v1 : v2 );
        }

        private int XCentered(int localWidth, int globalWidth)
        {
            return ((globalWidth-localWidth)/2);
        }

        #endregion

    }
}