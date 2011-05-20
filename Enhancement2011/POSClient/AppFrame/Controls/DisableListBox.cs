/* Written by Scott Sherin. July, 2009.
 * Do not interact directly with the Items or ItemEnables collections. I
 * decided to expose the ItemEnables collection since the Items collection
 * is exposed and to allow more flexibility for other developers. Note that
 * changing one of the collections without changing the other could have
 * unwanted side effects, which is why the Add/Insert/Remove/RemoveAt/Clear
 * Item methods are available.                                               */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace MCCM.Objects
{
    /// <summary>
    /// Represents a Windows control to display a list of items which can be enabled or disabled.
    /// </summary>
    public class DisableListBox : ListBox
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

        #region Variables

        private List<bool> itemEnables = new List<bool>();
        private Color enabledItemColor = Color.Black;
        private Color disabledItemColor = Color.Gray;
        private string enableMember = string.Empty;

        // Set to normal so name shows up in design mode
        private DrawMode drawMode = DrawMode.Normal;

        // Holds enable property descriptor
        private PropertyDescriptor enableProperty = null;

        // Stops control from drawing while updating
        private bool suspendDraw = false;

        // Ensures DataManager events are only registered once
        bool dataManagerEventsRegistered = false;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the item enables of the DisableListBox. ItemEnables[i] defines whether Items[i] is enabled.
        /// </summary>
        [Description("Gets the item enables of the DisableListBox. ItemEnables[i] defines whether Items[i] is enabled.")]
        public List<bool> ItemEnables
        {
            get { return itemEnables; }
        }

        /// <summary>
        /// Gets or sets the color of enabled items in the DisableListBox.
        /// </summary>
        [DefaultValue(typeof(Color), "Black"), Description("Gets or sets the color of enabled items in the DisableListBox.")]
        public Color EnabledItemColor
        {
            get { return enabledItemColor; }
            set { enabledItemColor = value; }
        }

        /// <summary>
        /// Gets or sets the color of disabled items in the DisableListBox.
        /// </summary>
        [DefaultValue(typeof(Color), "Gray"), Description("Gets or sets the color of disabled items in the DisableListBox.")]
        public Color DisabledItemColor
        {
            get { return disabledItemColor; }
            set { disabledItemColor = value; }
        }

        /// <summary>
        /// Gets or sets the property which defines if the item is enabled in the DisableListBox.
        /// </summary>
        [DefaultValue(""), Description("Gets or sets the property which defines if the item is enabled in the DisableListBox."), Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string EnableMember
        {
            get { return enableMember; }
            set
            {
                enableMember = value;
                OnEnableMemberChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Hidden Properties

        /// <summary>
        /// Gets or sets the drawing mode for the control.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override DrawMode DrawMode
        {
            get { return drawMode; }
            set
            {
                drawMode = value;

                // Keeps base.DrawMode set to Normal so name shows up in the designer
                if (!IsDesignMode()) base.DrawMode = value;
            }
        }

        /// <summary>
        /// Gets or sets the method in which items are selected in the DisableListBox.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override SelectionMode SelectionMode
        {
            get { return base.SelectionMode; }
            set { base.SelectionMode = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the items in the DisableListBox are sorted alphabetically.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool Sorted
        {
            get { return base.Sorted; }
            set { base.Sorted = value; }
        }

        /// <summary>
        /// Sorts the items in the DisableListBox.
        /// </summary>
        protected override void Sort()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the DisableListBox class.
        /// </summary>
        public DisableListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        #endregion

        #region EnableMemberChanged Event

        /// <summary>
        /// Occurs when the EnableMember property changes.
        /// </summary>
        public event EventHandler EnableMemberChanged;

        /// <summary>
        /// Raises the EnableMemberChanged event.
        /// </summary>
        /// <param name="e">A System.EventArgs that contains the event data.</param>
        protected virtual void OnEnableMemberChanged(EventArgs e)
        {
            RefreshItemEnables();
            Invalidate();

            if (EnableMemberChanged != null)
                EnableMemberChanged(this, e);
        }

        #endregion

        #region EnableMemberError Event

        /// <summary>
        /// Occurs when an EnableMember property value cannot be converted to boolean.
        /// </summary>
        public event EventHandler EnableMemberError;

        /// <summary>
        /// Provides data for the DisableListBox.EnableMemberError event.
        /// </summary>
        public class EnableMemberErrorEventArgs : EventArgs
        {
            private Exception _exception = null;
            private int _index = -1;

            /// <summary>
            /// Gets the exception that represents the error.
            /// </summary>
            public Exception Exception { get { return _exception; } }

            /// <summary>
            /// Gets the index of the item whose EnableMember couldn't be converted.
            /// </summary>
            public int Index { get { return _index; } }

            /// <summary>
            /// Initializes a new instace of the DisableListBox.EnableMemberErrorEventArgs class.
            /// </summary>
            /// <param name="exception">The exception that occurred.</param>
            /// <param name="index">The index of the item whose EnableMember couldn't be converted.</param>
            public EnableMemberErrorEventArgs(Exception exception, int index)
            {
                _exception = exception;
                _index = index;
            }
        }

        /// <summary>
        /// Raises the EnableMemberError event.
        /// </summary>
        /// <param name="e">A DisableListBox.EnableMemberErrorEventArgs that contains the event data.</param>
        protected virtual void OnEnableMemberError(EnableMemberErrorEventArgs e)
        {
            if (EnableMemberError != null)
                EnableMemberError(this, e);
        }

        #endregion

        #region DataSourceChanged Event

        /// <summary>
        /// Raises the System.Windows.Forms.ListControl.DataSourceChanged event.
        /// </summary>
        /// <param name="e">A System.EventArgs that contains the event data.</param>
        protected override void OnDataSourceChanged(EventArgs e)
        {
            if (!dataManagerEventsRegistered)
            {
                DataManager.ListChanged += new ListChangedEventHandler(DataManager_ListChanged);
                DataManager.ItemChanged += new ItemChangedEventHandler(DataManager_ItemChanged);
                dataManagerEventsRegistered = true;
            }

            suspendDraw = true;

            base.OnDataSourceChanged(e);
            RefreshItemEnables();

            suspendDraw = false;
        }

        #endregion

        #region DataManager EventHandlers

        void DataManager_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                // Handle items being added
                case ListChangedType.ItemAdded:
                    ItemEnables.Insert(e.NewIndex, ProduceEnable(e.NewIndex));
                    break;
                // Handle items being deleted
                case ListChangedType.ItemDeleted:
                    ItemEnables.RemoveAt(e.NewIndex);
                    break;
            }
        }

        void DataManager_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            // Handle items changing
            if (e.Index > -1)
                SetEnabledAt(e.Index, ProduceEnable(e.Index));
        }

        #endregion

        #region Add/Remove/Clear

        /// <summary>
        /// Adds an item to the list of items for a DisableListBox.
        /// </summary>
        /// <param name="item">An object representing the item to add.</param>
        /// <param name="enabled">Whether the item is enabled for selection or not.</param>
        public void AddItem(object item, bool enabled)
        {
            Items.Add(item);
            ItemEnables.Add(enabled);
        }

        /// <summary>
        /// Inserts an item into the DisableListBox at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index location where the item is inserted.</param>
        /// <param name="item">An object representing the item to insert.</param>
        /// <param name="enabled">Whether the item is enabled for selection or not.</param>
        public void InsertItem(int index, object item, bool enabled)
        {
            Items.Insert(index, item);
            ItemEnables.Insert(index, enabled);
        }

        /// <summary>
        /// Removes an item from the list of items for a DisableListBox.
        /// </summary>
        /// <param name="item">An object representing the item to remove.</param>
        public void RemoveItem(object item)
        {
            RemoveItemAt(Items.IndexOf(item));
        }

        /// <summary>
        /// Removes an item from the DisableListBox at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index location of the item to remove.</param>
        public void RemoveItemAt(int index)
        {
            Items.RemoveAt(index);
            ItemEnables.RemoveAt(index);
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void ClearItems()
        {
            Items.Clear();
            ItemEnables.Clear();
        }

        #endregion

        #region Enable/Disable

        /// <summary>
        /// Enables an item in the DisableListbox.
        /// </summary>
        /// <param name="item">An object representing the item to enable.</param>
        public void EnableItem(object item)
        {
            EnableItemAt(Items.IndexOf(item));
        }

        /// <summary>
        /// Enables an item in the DisableListbox at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index location of the item to enable.</param>
        public void EnableItemAt(int index)
        {
            SetEnabledAt(index, true);
        }

        /// <summary>
        /// Disables an item in the DisableListbox.
        /// </summary>
        /// <param name="item">An object representing the item to disable.</param>
        public void DisableItem(object item)
        {
            DisableItemAt(Items.IndexOf(item));
        }

        /// <summary>
        /// Disables an item in the DisableListbox at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index location of the item to disable.</param>
        public void DisableItemAt(int index)
        {
            if (SelectedIndex == index)
                SelectedIndex = -1;

            SetEnabledAt(index, false);
        }

        private void SetEnabledAt(int index, bool enabled)
        {
            ItemEnables[index] = enabled;

            // Ensure disabled items are not selected
            if (!enabled && SelectedIndices.Contains(index))
                SelectedItems.Remove(SelectedItems[index]);
        }

        #endregion

        #region WndProc
        
        /// <summary>
        /// The DisableListBox's window procedure.
        /// </summary>
        /// <param name="m">A Windows Message Object.</param>
        protected override void WndProc(ref Message m)
        {
            // Get params as ints
            
            int wParam = m.WParam.ToInt32();

            // Intercept mouse selection
            if (m.Msg == WM_MOUSEMOVE || m.Msg == WM_LBUTTONDOWN)
            {
                int lParam = m.LParam.ToInt32();
                // Get mouse location
                Point clickedPt = new Point();
                clickedPt.X = lParam & 0x0000FFFF;
                clickedPt.Y = lParam >> 16;

                // If point is on a disabled item, ignore mouse
                for (int i = 0; i < Items.Count; i++)
                    if (!ItemEnables[i] && GetItemRectangle(i).Contains(clickedPt))
                        return;
            }

            // Intercept keyboard selection
            if (m.Msg == WM_KEYDOWN)
                // Handle single down
                if (wParam == VK_DOWN || wParam == VK_RIGHT)
                {
                    // Select next enabled item
                    for (int i = SelectedIndex + 1; i < Items.Count; i++)
                        if (ItemEnables[i])
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
                        if (ItemEnables[i])
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
                    if (ItemEnables.Count == 0)
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
                            if (ItemEnables[i])
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
                        if (ItemEnables[i])
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
                    if (ItemEnables.Count == 0)
                        return;

                    // Get current selected index
                    int currentIndex = Math.Max(0, SelectedIndex);

                    // Get number of items to jump
                    int toJump = NumVisibleItems() - 1;

                    // Check if there are enough items to jump a full page
                    if (currentIndex + toJump < ItemEnables.Count)
                    {
                        // Jmup at least a full page if possible
                        for (int i = currentIndex + toJump; i < ItemEnables.Count; i++)
                            if (ItemEnables[i])
                            {
                                SelectedIndex = i;
                                return;
                            }
                    }
                    // If there aren't enough items, try to jump as far as possible
                    else
                        toJump = ItemEnables.Count - currentIndex - 1;

                    // Jump as far as possible without ending on a disabled item
                    for (int i = currentIndex + toJump; i >= currentIndex; i--)
                        if (ItemEnables[i])
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
                    for (int i = ItemEnables.Count - 1; i >= 0; i--)
                        if (ItemEnables[i])
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
                    for (int i = 0; i < ItemEnables.Count; i++)
                        if (ItemEnables[i])
                        {
                            SelectedIndex = i;
                            break;
                        }
                    return;
                }

            base.WndProc(ref m);
        }

        // Gets the maximum number of items visible in the DisableListBox
        private int NumVisibleItems()
        {
            return this.Height / this.ItemHeight;
        }
        
        #endregion

        #region Item Drawing

        /// <summary>
        /// Raises the System.Windows.Forms.ListBox.DrawItem event.
        /// </summary>
        /// <param name="e">A System.Windows.Forms.ListBox.DrawItemEventArgs that contains the event data.</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // Stops control from throwing errors if empty or in design mode
            if (e.Index > -1 && !suspendDraw && !IsDesignMode())
            {
                // Draw the background
                e.DrawBackground();

                // Select color to use
                Color color;
                if (Enabled && ItemEnables[e.Index])
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        color = Color.White;
                    else
                        color = EnabledItemColor;
                else
                    color = DisabledItemColor;

                // Align text
                Rectangle shiftedBounds;
                TextFormatFlags alignment;
                if (base.RightToLeft == RightToLeft.No)
                {
                    // To look the same as ListBox, the bounds have to be shifted
                    shiftedBounds = new Rectangle(e.Bounds.X - 1, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                    alignment = TextFormatFlags.Left;
                }
                else
                {
                    // To look the same as ListBox, the bounds have to be shifted
                    shiftedBounds = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                    alignment = TextFormatFlags.Right;
                }

                // Get string to display
                string displayString = GetItemText(Items[e.Index]);

                // Draw the string
                TextRenderer.DrawText(e.Graphics, displayString, e.Font, shiftedBounds, color, alignment);

                // Draw the focus rectangle
                e.DrawFocusRectangle();
            }

            // Call base OnDrawItem
            base.OnDrawItem(e);
        }

        #endregion

        #region Refresh Item Enables

        private void RefreshItemEnables()
        {
            // Get enable property
            GetEnableProperty();

            // Clear enable list
            ItemEnables.Clear();

            // Fill enable list
            for (int i = 0; i < Items.Count; i++)
                ItemEnables.Add(ProduceEnable(i));

            // Ensure disabled items are not selected
            for (int i = SelectedItems.Count - 1; i >= 0; i--)
                if (!ItemEnables[SelectedIndices[i]])
                    SelectedItems.Remove(SelectedItems[i]);
        }

        private void GetEnableProperty()
        {
            // If it should be bound to a property
            if (DataSource != null && EnableMember != string.Empty)
            {
                // Clear property
                enableProperty = null;

                // Find property
                foreach (PropertyDescriptor property in DataManager.GetItemProperties())
                    if (property.Name == enableMember)
                        enableProperty = property;
            }
        }

        #endregion

        #region Produce Enable

        private bool ProduceEnable(int i)
        {
            // If databound and enable property is set
            if (DataSource != null && enableProperty != null)
                try
                {
                    // Convert property to boolean
                    return Convert.ToBoolean(enableProperty.GetValue(Items[i]));
                }
                // Object couldn't be converted to boolean
                catch (InvalidCastException ex)
                {
                    OnEnableMemberError(new EnableMemberErrorEventArgs(ex, i));
                    return false;
                }
            else
                return true;
        }

        #endregion

        #region IsDesignMode

        private bool IsDesignMode()
        {
            return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }

        #endregion
    }
}
