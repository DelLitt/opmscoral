using System;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Presenter;

namespace AppFrame.Utility
{
    public sealed class EventUtility
    {
        public static void fireEvent(EventHandler eventHandler, object sender, BaseEventArgs eventArgs)
        {
            eventHandler(sender, eventArgs);
        }
        public static void fireAsyncEvent<T>(EventHandler<T> eventHandler,object sender,T eventArgs,AsyncCallback callback) where T:BaseEventArgs
        {
            eventHandler.BeginInvoke(sender, eventArgs, callback,eventArgs);
        }
        public static void fireEvent<T>(EventHandler<T> eventHandler, object sender, T eventArgs) where T : BaseEventArgs
        {
            ProcessDelegate(eventHandler,sender, eventArgs);
        }

        private static void ProcessDelegate(Delegate del, params object[] args)
        {
            Delegate temp = del;
            if (temp == null)
            {
                return;
            }

            Delegate[] delegates = temp.GetInvocationList();
            foreach (Delegate handler in delegates)
            {
                InvokeDelegate(handler, args);
            }
        }
        /// <summary>
        ///     
        /// </summary>
        /// <param name="del" type="System.Delegate">
        ///     <para>
        ///         
        ///     </para>
        /// </param>
        /// <param name="args" type="object[]">
        ///     <para>
        ///         
        ///     </para>
        /// </param>
        private static void InvokeDelegate(Delegate del, object[] args)
        {
            System.ComponentModel.ISynchronizeInvoke synchronizer;
            synchronizer = del.Target as System.ComponentModel.ISynchronizeInvoke;
            try
            {
                if (synchronizer != null) //A Windows Forms object
                {
                    if (synchronizer.InvokeRequired == false)
                    {
                    del.DynamicInvoke(args);
                    return;
                    }
                    try
                    {
                        synchronizer.Invoke(del, args);
                    }
                    catch
                    {
                    
                    }
                }

                else //Not a Windows Forms object
                {       
                del.DynamicInvoke(args);
                }
            }
            catch (Exception exp)
            {
                //MessageBox.Show("Có lỗi khi thực hiện chương trình","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                if(exp.InnerException is BusinessException)
                {
                    MessageBox.Show(exp.InnerException.Message);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện chương trình. Chương trình vẫn tiếp tục bình thường, xin vui lòng kiểm tra lại dữ liệu");
                    //throw exp;
                }
                //throw exp;
            }
        }
    }
}