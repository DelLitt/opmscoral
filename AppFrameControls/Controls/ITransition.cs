using System.Windows;

namespace AppFrameControls.Controls
{
    public interface ITransition
    {
        bool RequiresNewContentTopmost { get; }
        void BeginTransition(TransitionPresenter transitionElement, UIElement oldContent, UIElement newContent);
    }
}