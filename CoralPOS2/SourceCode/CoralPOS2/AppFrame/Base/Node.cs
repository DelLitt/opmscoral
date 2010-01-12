using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AppFrame.Base
{
    [Obsolete]
    public class Node : INode
    {
        public HybridDictionary ActionMap { get; set; }

        public Node()
            : base()
        {
        }

        public INode GetNextNode(string key)
        {
            INode node = null;

            if (ActionMap != null)
            {
                node = (INode) ActionMap[key];
            }
            return node;
        }

        public void ToNextNode(string nodeName)
        {
            object nextNode = GetNextNode(nodeName);
            if (nextNode != null)
            {
                if (typeof(INode) == nextNode.GetType())
                {
                    //((INode) nextNode).Execute();
                }
                else 
                {
                    //NavigationService.Navigate(nextNode.ToString());
                }
                
            }
            else
            {
                //throw new System.NotImplementedException();
            }
        }
        
        public void ToNextNode(string nodeName, object param)
        {
            object nextNode = GetNextNode(nodeName);
            if (nextNode != null)
            {
                if (typeof(INode) == nextNode.GetType())
                {
                    //((INode) nextNode).Execute(param);
                }
                else 
                {
                    //NavigationService.Navigate(nextNode.ToString(), param);
                }
                
            }
            else
            {
                throw new System.NotImplementedException();
            }
        }

        public virtual void Execute()
        {
            
        }

        public virtual void Execute(object param)
        {
            
        }

        public string Name
        {
            get; set;
        }
    }
}