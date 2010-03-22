using System.Windows;
using System.Windows.Controls;
using Caliburn.PresentationFramework.Actions;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Caliburn.PresentationFramework.RoutedMessaging;

namespace AppFrame.WPF
{
    public static class MessageExtensions
    {

        public static void Send(this DependencyObject origin, IRoutedMessage message)
        {

            origin.Send(message, null);

        }



        public static void Send(this DependencyObject origin, IRoutedMessage message, object context)
        {
            var node = origin.GetValue(DefaultRoutedMessageController.NodeProperty) as IInteractionNode;

            if (node != null)

                node.ProcessMessage(message, context);

        }



        public static void Send(this DependencyObject origin, string actionName)
        {

            origin.Send(actionName, null);

        }



        public static void Send(this DependencyObject origin, string actionName, object context)
        {

            var node = origin.GetValue(DefaultRoutedMessageController.NodeProperty) as IInteractionNode;

            if (node == null) return;



            foreach (var trigger in node.Triggers)
            {

                var message = trigger.Message as ActionMessage;

                if (message == null || message.MethodName != actionName) continue;



                node.ProcessMessage(message, context);

                return;

            }

        }

    }
}