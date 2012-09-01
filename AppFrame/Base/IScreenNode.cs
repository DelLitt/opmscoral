namespace AppFrame.Base
{
    public interface IScreenNode : IPosScreen,INode
    {
        
    }

    public interface  IScreenNode<T> : IPosScreen<T>, INode
    {
        
    }
}
