using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Caliburn.Core;
using Caliburn.Core.Invocation;
using Caliburn.PresentationFramework.Filters;
using Caliburn.PresentationFramework.RoutedMessaging;
using Microsoft.Practices.ServiceLocation;

namespace AppFrame.Security
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class InRoleAttribute : MethodCallFilterBase, IPreProcessor, IHandlerAware
    {
        private IList<Role> roleList;
        private MemberInfo _target;
        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewAttribute"/> class.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        public InRoleAttribute(string roles)
            : base(roles)
        {
            AffectsTriggers = true;
            roleList = ParseRole(roles);
        }

        private IList<Role> ParseRole(string roles)
        {
            IList<Role> parsedRoles = new List<Role>();
            string[] rolearr = roles.Split(',');
            foreach (string roleName in rolearr)
            {
                Role role = new Role { Name = roleName };
                parsedRoles.Add(role);
            }
            return parsedRoles;
        }

        public IList<Role> AcceptRoles
        {
            get
            {
                return roleList;
            }
            set
            {
                roleList = value;
            }
        }

        private IMethodFactory _methodFactory;

        

        /*/// <summary>
        /// Initializes a new instance of the <see cref="PreviewAttribute"/> class.
        /// </summary>
        /// <param name="method">The method.</param>
        public InRoleAttribute(IMethod method)
            : base(method)
        {
            AffectsTriggers = true;
        }*/

        /// <summary>
        /// Gets a value indicating whether this filter affects triggers.
        /// </summary>
        /// <value><c>true</c> if affects triggers; otherwise, <c>false</c>.</value>
        /// <remarks>True by default.</remarks>
        public bool AffectsTriggers { get; set; }

        /// <summary>
        /// Initializes the filter.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="member">The member.</param>
        /// <param name="serviceLocator">The serviceLocator.</param>
        public override void Initialize(Type targetType, MemberInfo member, IServiceLocator serviceLocator)
        {
            _target = member;
            _methodFactory = serviceLocator.GetInstance<IMethodFactory>();
        }

        /// <summary>
        /// Executes the filter.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="handlingNode">The handling node.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public bool Execute(IRoutedMessage message, IInteractionNode handlingNode, object[] parameters)
        {
            Role clientRole = new Role{ Name = ClientInfo.Instance.Role};
            foreach (Role acceptRole in AcceptRoles)
            {
                if (acceptRole.Equals(clientRole)) return true;
            }
            return false;
        }

        /// <summary>
        /// Makes the filter aware of the <see cref="IRoutedMessageHandler"/>.
        /// </summary>
        /// <param name="messageHandler">The message handler.</param>
        public void MakeAwareOf(IRoutedMessageHandler messageHandler)
        {
            if (!AffectsTriggers)
                return;

            var notifier = messageHandler.Unwrap() as INotifyPropertyChanged;
            if (notifier == null) return;

            var helper = messageHandler.Metadata.FirstOrDefaultOfType<DependencyObserver>();
            if (helper != null) return;

            helper = new DependencyObserver(messageHandler, _methodFactory, notifier);
            messageHandler.Metadata.Add(helper);
        }

        /// <summary>
        /// Makes the filter aware of the <see cref="IMessageTrigger"/>.
        /// </summary>
        /// <param name="messageHandler">The message handler.</param>
        /// <param name="trigger">The trigger.</param>
        public void MakeAwareOf(IRoutedMessageHandler messageHandler, IMessageTrigger trigger)
        {
            if (!AffectsTriggers)
                return;

            var helper = messageHandler.Metadata.FirstOrDefaultOfType<DependencyObserver>();
            if (helper == null) return;

            if (trigger.Message.RelatesTo(_target))
                helper.MakeAwareOf(trigger, new[] { _target.Name });
        }
    }
}
