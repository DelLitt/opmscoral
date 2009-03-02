using AppFrame.Model;
using AppFrame.Presenter;

namespace AppFrame.Common
{
    public interface IBaseController<T> where T: BaseEventArgs
    {
        T ResultEventArgs { get; set; }
    }
    
}