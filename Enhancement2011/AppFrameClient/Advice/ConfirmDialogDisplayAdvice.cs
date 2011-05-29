using System.Windows.Forms;
using AopAlliance.Intercept;
using AppFrame.Utility;

namespace AppFrame.Advice
{
    public class ConfirmDialogDisplayAdvice : IMethodInterceptor
    {
        #region IMethodInterceptor Members

        /// <summary>
        /// Call before any click of Button create and will go next if it click OK.
        /// </summary>
        /// <param name="invocation"></param>
        /// <returns></returns>
        public object Invoke(IMethodInvocation invocation)
        {
            DialogResult dialogResult =
                MessageBox.Show(ResourceUtility.GetMessageString("confirmDialogText"), "Confirmation",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation
                    );
            if (dialogResult == DialogResult.OK)
            {
                return invocation.Proceed();
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}