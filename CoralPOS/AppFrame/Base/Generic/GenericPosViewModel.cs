using Caliburn.Micro;

namespace AppFrame.Base.Generic
{
    public class GenericPosViewModel<T> : Screen, IScreenNode<T>
    {
        public string Name { get; set; }
        public IFlow Flow { get; set; }
        public void GoToNextNode()
        {
            Flow.Next();
        }


        public IScreen AttachedMenu
        {
            get; set;
        }
    }
}
