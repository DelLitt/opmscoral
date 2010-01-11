using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Actions;
using Caliburn.PresentationFramework.Screens;

namespace AppFrame.Base
{
    public class DefaultFlow : IFlow
    {
        private ShellNavigator<IScreen,INode> _rootNavigator;
        private readonly Stack<INode> _next = new Stack<INode>();
        private readonly Stack<INode> _previous = new Stack<INode>();

        private INode _current;
        private bool _isNavigating;



        public DefaultFlow(ShellNavigator<IScreen,INode> rootNavigator)
        {
            _rootNavigator = rootNavigator;
        }

        
        public INode CurrentNode
        {
            get
            {
                return _current;
            }
            set
            {
                _current = value;
            }
        }

        public INode StartNode
        {
            get
            {
                return FlowSteps[0];
            }
        }

        public bool IsEndFlow
        {
            get
            {
                int currentPos = FlowSteps.IndexOf(CurrentNode);
                return (currentPos == (FlowSteps.Count - 1));
            }
            
        }

        /// <summary>
        /// Gets a value indicating whether this instance can navigate back.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance can go back; otherwise, <c>false</c>.
        /// </value>
        public bool CanGoBack
        {
            get { return _previous.Count > 0; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance can navigate next.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance can go next; otherwise,<c>false</c>
        /// </value>
        public bool CanGoForward
        {
            get { return _next.Count > 0; }
        }

        
        /// <summary>
        /// Navigates forward.
        /// </summary>
        public virtual void Forward()
        {
            if (!CanGoForward)
            {
                return;
            }

            _isNavigating = true;

            if (_current != null)
                _previous.Push(_current);

            _current = _next.Pop();

            ProcessingNode();
            _isNavigating = false;
        }

        private void ProcessingNode()
        {
            if (_current == null) return;
            if (_current is IScreen)
            {
                var screen = _current as IScreen;
                _rootNavigator.OpenScreen(screen);
            }
            else if(_current is IActionNode)
            {
                var _action = _current as IActionNode;
                _action.DoExecute();
            }
        }

        /// <summary>
        /// Navigates back.
        /// </summary>
        public virtual void Back()
        {
            if (!CanGoBack)
            {
                return;
            }

            _isNavigating = true;

            if (_current != null)
                _next.Push(_current);

            _current = _previous.Pop();
            ProcessingNode();

        }

        public virtual void Next()
        {
            _isNavigating = true;

            if (IsEndFlow) 
            {
                End(); 
            }
            if(CanGoForward)
            {
                Forward();
            }
            else
            {
                
                int currentPos = FlowSteps.IndexOf(CurrentNode);
                if (_current != null)
                    _previous.Push(_current);

                INode nextNode = FlowSteps[currentPos + 1];
                _current = nextNode;
                ProcessingNode();
                
            }
            _isNavigating = false;
        }

        public virtual void Start()
        {
            _current = StartNode;
            ProcessingNode();
        }

        public virtual void Resume()
        {
            ProcessingNode();
        }

        public virtual void End()
        {
            
        }

        public bool IsNavigating
        {
            get
            {
                return _isNavigating;
            }
        }
        public IList<INode> FlowSteps
        {
            get; set;
        }

        public ISession Session
        {
            get; set;
        }
    }
}

