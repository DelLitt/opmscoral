using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        private IFlowSession _flowSession;
        private readonly IList<string> _nodeList = new List<string>();
        private INode _current;
        private bool _isNavigating;

        public DefaultFlow()
        {
             
        }

        public DefaultFlow(ShellNavigator<IScreen,INode> rootNavigator) 
        {
            _rootNavigator = rootNavigator;
            foreach (string key in FlowSteps.Keys)
            {
                _nodeList.Add(key);
            }
        }

        public virtual void InitFlow()
        {
            foreach (string key in FlowSteps.Keys)
            {
                _nodeList.Add(key);
            }
        }

        public ShellNavigator<IScreen, INode> Navigator
        {
            get
            {
                return _rootNavigator; 
            }
            set
            {
                _rootNavigator = value;
            }
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
                _current.Flow = this;
            }
        }

        public string StartNodeName
        {
            get
            {
                return (string)FlowSteps[_nodeList[0]];
            }
        }

        public string Name
        {
            get; set;
        }

        public bool IsEndFlow
        {
            get
            {
                int currentPos = IndexOfNode(FlowSteps,_current);
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
                _previous.Push(CurrentNode);

            CurrentNode = _next.Pop();

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
                var action = _current as IActionNode;
                action.DoExecute();
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
                _next.Push(CurrentNode);

            CurrentNode = _previous.Pop();
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
                int currentPos = 0;
                if (_current != null)
                {
                    currentPos = IndexOfNode(FlowSteps, _current);
                    _previous.Push(CurrentNode);

                }
                int nextPos = currentPos + 1;
                if(nextPos >= FlowSteps.Count)
                {
                    End();
                }
                else
                {
                    INode nextNode = EnsureNode((string)FlowSteps[_nodeList[nextPos]],nextPos);
                    CurrentNode = nextNode;
                    ProcessingNode();    
                }
            }
            _isNavigating = false;
        }

        private INode EnsureNode(string nodeTypeName,int position)
        {
            INode node = _rootNavigator.CreateNode(nodeTypeName);
            node.Name = _nodeList[position];
            return node;
        }

        private int IndexOfNode(IDictionary dictionary, INode current)
        {
            int result = -1;
            int i = 0;
            foreach (string key in dictionary.Keys)
            {
                if (key.Equals(current.Name))
                {
                    result = i;
                    break;
                }
                i += 1;
            }
            return result;
        }

        public virtual void Start()
        {
            INode startNode = EnsureNode((string)StartNodeName, 0);
            CurrentNode = startNode;
            ProcessingNode();
        }

        public virtual void Resume()
        {
            ProcessingNode();
        }

        public virtual void End()
        {
            _rootNavigator.LeaveFlow(); 
        }
        public int CurrentPosition
        {
            get
            {
                return IndexOfNode(FlowSteps, CurrentNode);
            }
        }
        public bool IsNavigating
        {
            get
            {
                return _isNavigating;
            }
        }
        public IDictionary FlowSteps
        {
            get; set;
        }

        public IFlowSession Session
        {
            get
            {
                return _flowSession;
            }
            set
            {
                _flowSession = value;
                _flowSession.Flow = this;
            }
        }
        public int Count
        {
            get
            {
                return FlowSteps.Count;
            }
        }
    }
}

