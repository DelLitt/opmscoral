//Ron Levy - 12/09/2008
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Rafael.Windows.Forms.ListBox
{
    public partial class CoralListBox : System.Windows.Forms.ListBox
    {

        #region Constants

        // Page Up/Down
        private const int VK_PRIOR = 0x21;
        private const int VK_NEXT = 0x22;

        // End/Home
        private const int VK_END = 0x23;
        private const int VK_HOME = 0x24;

        // Arrow keys
        private const int VK_LEFT = 0x25;
        private const int VK_UP = 0x26;
        private const int VK_RIGHT = 0x27;
        private const int VK_DOWN = 0x28;

        private const int WM_KEYDOWN = 0x100;
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_LBUTTONDOWN = 0x201;

        #endregion
       
        private IList _disabledList = new ArrayList();
        private Brush disableBrush = SystemBrushes.GrayText;

        private Color enabledItemColor = Color.Black;
        [DefaultValue(typeof(Color), "Black"), Description("Gets or sets the color of enabled items in the DisableListBox.")]
        public Color EnabledItemColor
        {
            get { return enabledItemColor; }
            set { enabledItemColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of disabled items in the DisableListBox.
        /// </summary>
        private Color disabledItemColor = Color.Gray;
        [DefaultValue(typeof(Color), "Gray"), Description("Gets or sets the color of disabled items in the DisableListBox.")]
        public Color DisabledItemColor
        {
            get { return disabledItemColor; }
            set { disabledItemColor = value; }
        }

        #region WndProc

        /// <summary>
        /// The DisableListBox's window procedure.
        /// </summary>
        /// <param name="m">A Windows Message Object.</param>
        protected override void WndProc(ref Message m)
        {
            int enabledItemsCount = EnabledItems.Count;
            int wParam = m.WParam.ToInt32();

            // Intercept mouse selection
            if (m.Msg == WM_MOUSEMOVE || m.Msg == WM_LBUTTONDOWN)
            {
                // Get params as ints
                int lParam = m.LParam.ToInt32();
                
                // Get mouse location
                Point clickedPt = new Point();
                clickedPt.X = lParam & 0x0000FFFF;
                clickedPt.Y = lParam >> 16;

                // If point is on a disabled item, ignore mouse
                for (int i = 0; i < Items.Count; i++)
                    if (ExistInDisabledList(_disabledList,Items[i]) && GetItemRectangle(i).Contains(clickedPt))
                        return;
            }

            // Intercept keyboard selection
            if (m.Msg == WM_KEYDOWN)
                // Handle single down
                if (wParam == VK_DOWN || wParam == VK_RIGHT)
                {
                    // Select next enabled item
                    for (int i = SelectedIndex + 1; i < Items.Count; i++)
                        if (!ExistInDisabledList(_disabledList,Items[i]))
                        {
                            SelectedIndex = i;
                            break;
                        }

                    return;
                }
                // Handle single up
                else if (wParam == VK_UP || wParam == VK_LEFT)
                {
                    // Select previous enabled item
                    for (int i = SelectedIndex - 1; i >= 0; i--)
                        if (!ExistInDisabledList(_disabledList,Items[i]))
                        {
                            SelectedIndex = i;
                            break;
                        }

                    return;
                }
                // Handle page up
                else if (wParam == VK_PRIOR)
                {
                    // Ignore if empty
                    if (!HasItemEnabled())
                        return;

                    // Get current selected index
                    int currentIndex = Math.Max(0, SelectedIndex);

                    // Get number of items to jump
                    int toJump = NumVisibleItems() - 1;

                    // Check if there are enough items to jump a full page
                    if (currentIndex >= toJump)
                    {
                        // Jump at least a full page if possible
                        for (int i = currentIndex - toJump; i >= 0; i--)
                            if (!ExistInDisabledList(_disabledList,Items[i]))
                            {
                                SelectedIndex = i;
                                return;
                            }
                    }
                    // If there aren't enough items, try to jump as far as possible
                    else
                        toJump = currentIndex;

                    // Jump as far as possible without ending on a disabled item
                    for (int i = currentIndex - toJump; i <= currentIndex; i++)
                        if (!ExistInDisabledList(_disabledList,Items[i]))
                        {
                            SelectedIndex = i;
                            break;
                        }

                    return;
                }
                // Handle page down
                else if (wParam == VK_NEXT)
                {
                    // Ignore if empty
                    if (!HasItemEnabled())
                        return;

                    // Get current selected index
                    int currentIndex = Math.Max(0, SelectedIndex);

                    // Get number of items to jump
                    int toJump = NumVisibleItems() - 1;

                    // Check if there are enough items to jump a full page
                    if (currentIndex + toJump < enabledItemsCount)
                    {
                        // Jmup at least a full page if possible
                        for (int i = currentIndex + toJump; i < enabledItemsCount; i++)
                            if (!ExistInDisabledList(_disabledList,Items[i]))
                            {
                                SelectedIndex = i;
                                return;
                            }
                    }
                    // If there aren't enough items, try to jump as far as possible
                    else
                        toJump = enabledItemsCount - currentIndex - 1;

                    // Jump as far as possible without ending on a disabled item
                    for (int i = currentIndex + toJump; i >= currentIndex; i--)
                        if (!ExistInDisabledList(_disabledList,Items[i]))
                        {
                            SelectedIndex = i;
                            break;
                        }

                    return;
                }
                // Handle end
                else if (wParam == VK_END)
                {
                    // Select closest enabled item to end
                    for (int i = enabledItemsCount - 1; i >= 0; i--)
                        if (!ExistInDisabledList(_disabledList,Items[i]))
                        {
                            SelectedIndex = i;
                            break;
                        }

                    return;
                }
                // Handle home
                else if (wParam == VK_HOME)
                {
                    // Select closest enabled item to start
                    for (int i = 0; i < enabledItemsCount; i++)
                        if (!ExistInDisabledList(_disabledList,Items[i]))
                        {
                            SelectedIndex = i;
                            break;
                        }
                    return;
                }

            base.WndProc(ref m);
        }

        public override void Refresh()
        {
            base.Refresh();
            if(Items.Count == 0 )
            {
                return;
            }
            int selIndex = Math.Max(0, SelectedIndex);
            if(ExistInDisabledList(_disabledList, Items[selIndex]))
            {
                int oldIndex = selIndex;
                for (int i = 0; i < Items.Count; i++)
                {
                    if (!ExistInDisabledList(_disabledList, Items[i]))
                    {
                        selIndex = i;
                        break;
                    }
                }
                if(selIndex == oldIndex)
                {
                    ClearSelected();
                }
                else
                {
                    SelectedIndex = selIndex;
                }
            }
            
        }

        private int NumVisibleItems()
        {
            return this.Height / this.ItemHeight;
        }

        public IList EnabledItems
        {
            get
            {
                ObjectCollection col = Items;
                IList result = new ArrayList();
                foreach (var obj in col)
                {
                    if (!ExistInDisabledList(_disabledList, obj))
                    {
                        result.Add(obj);
                    }
                }
                return result;
            }
        }

        private bool HasItemEnabled()
        {
            int count = 0;
            foreach (var item in Items)
            {
                if(ExistInDisabledList(_disabledList,item))
                {
                    count++;
                }
            }
            return count < Items.Count ? true : false;
        }

        #endregion

        [Description("The Column in the datasource to flag the disabled items.\nMust be a bool column.")]
        public IList DisabledRows
        {
            get { return _disabledList; }
            set { _disabledList = value; }
        }

        public CoralListBox()
        {
            InitializeComponent();
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            
        }

        private int GetNextEnabled(IList disabledList, int SelectedIndex)
        {
            int currIndex = SelectedIndex;
            bool found = false;
            while(!found)
            {
                if(currIndex < Items.Count - 1)
                {
                    currIndex += 1;
                    if(!ExistInDisabledList(_disabledList,Items[currIndex]))
                    {
                        found = true; 
                    }
                }
                else
                {
                    found = true;
                }
            }
            
            return currIndex;
        }
        
        public IList SelectedEnabledIndices
        {
            get
            {
                SelectedIndexCollection indices = SelectedIndices;
                IList result = new ArrayList();
                foreach (int index in indices)
                {
                    if (!ExistInDisabledList(_disabledList, Items[index]))
                    {
                        result.Add(index);
                    }
                }
                return result;     
            }
        }
        public IList SelectedEnabledItems
        {
            get
            {
                SelectedObjectCollection col = SelectedItems;
                IList result =new ArrayList();
                foreach (var obj in col)
                {
                    if(!ExistInDisabledList(_disabledList,obj))
                    {
                        result.Add(obj);
                    }
                }
                return result;    
            }
        }

        
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Color color = EnabledItemColor;
      
                    if (!IsDesignMode())    //Only if we are not in design mode
                    {
                        
                        base.DrawMode = DrawMode.OwnerDrawFixed;
                        using (Brush myBrush = new SolidBrush(this.Enabled ? e.ForeColor : SystemColors.GrayText))
                        {
                            // Draw the background of the ListBox control for each item.
                            e.DrawBackground();
                            //Create the list of disabled items
                            
                                object obj = this.Items[Math.Max(e.Index,0)];

                                // Draw the current item text based on the current Font and the custom brush settings.
                                if (ExistInDisabledList(_disabledList, obj))
                                {
                                    color = DisabledItemColor;
                                }
                                else
                                {
                                    color = EnabledItemColor;
                                }

                                // Align text
                                Rectangle shiftedBounds;
                                TextFormatFlags alignment;
                                if (base.RightToLeft == RightToLeft.No)
                                {
                                    // To look the same as ListBox, the bounds have to be shifted
                                    shiftedBounds = new Rectangle(e.Bounds.X - 1, e.Bounds.Y, e.Bounds.Width,
                                                                  e.Bounds.Height);
                                    alignment = TextFormatFlags.Left;
                                }
                                else
                                {
                                    // To look the same as ListBox, the bounds have to be shifted
                                    shiftedBounds = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width,
                                                                  e.Bounds.Height);
                                    alignment = TextFormatFlags.Right;
                                }

                                // Get string to display
                                string displayString = GetItemText(Items[e.Index]);

                                // Draw the string
                                TextRenderer.DrawText(e.Graphics, displayString, e.Font, shiftedBounds, color, alignment);

                                //If the selected item is a disabled item dont select it
                                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                                {
                                    if (!ExistInDisabledList(_disabledList, obj))
                                    {
                                        e.DrawFocusRectangle();
                                    }
                                    //this.Invalidate(true);
                                }
                            
                        }
                    }
                    else
                    {
                        // do nuthin ... 
                    }
                
                #region unused code
                /*else
                {
                    Brush myBrush = Brushes.Black;
                    if (!this.Enabled)
                        myBrush = Brushes.Gray;
                    if (this.Items.Count > 0)
                    {                        
                        string item = this.Items[e.Index].ToString();
                       
                        //Check if the item is disabled
                        if (item.StartsWith(_prefix))
                        {
                            item = item.Remove(0, _prefix.Length);
                            myBrush = Brushes.Gray;
                        }
                        if (!item.StartsWith(_prefix))
                        {
                            // Draw the background of the ListBox control for each item.
                            e.DrawBackground();
                        }
                        // Draw the current item text based on the current Font and the custom brush settings.
                        e.Graphics.DrawString(item, e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                        //If the selected item is a disabled item dont select it
                        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected && item.StartsWith(_prefix))
                        {
                            this.SelectedIndex = -1;
                            //this.SetSelected(e.Index, false);
                            this.Invalidate();
                        }
                        //if the selected item is not disable change the text color to white
                        else if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        {
                            myBrush = Brushes.White;
                            e.Graphics.DrawString(item, e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                            e.DrawFocusRectangle();
                        }
                        else
                        {
                            if (!item.StartsWith(_prefix))
                            // If the ListBox has focus, draw a focus rectangle around the selected item.
                            e.DrawFocusRectangle();
                        }
                    }
                    else
                    {
                        // Draw the current item text based on the current Font and the custom brush settings.
                        e.Graphics.DrawString(this.Name.ToString(), e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
                        // If the ListBox has focus, draw a focus rectangle around the selected item.
                        e.DrawFocusRectangle();
                    }                    
                }*/
#endregion
                base.OnDrawItem(e);
        }

        private bool ExistInDisabledList(IList disabledList, object o)
        {
            if(disabledList == null)
            {
                return false;
            }
                
            foreach (object obj in disabledList)
            {
                if(obj.Equals(o))
                {
                    return true;
                }
            }
            return false;
        }
        #region IsDesignMode

        private bool IsDesignMode()
        {
            return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }

        #endregion
    }
}
