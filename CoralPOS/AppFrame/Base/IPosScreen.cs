using Caliburn.Micro;

namespace AppFrame.Base
{
    public interface IPosScreen : IScreen
    {
        //IScreen AttachedMenu { get; set; }
    }

    public interface IPosScreen<T> : IScreen, INode
    {
        //IScreen AttachedMenu { get; set; }
    }
}
