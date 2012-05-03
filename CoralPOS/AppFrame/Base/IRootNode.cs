namespace AppFrame.Base
{
    public interface IRootNode<T> where T:class,INode
    {
        void Open(T node);
        T CreateNode(string typeName);
        //IScreen MainScreen { get; set; }
    }
}
