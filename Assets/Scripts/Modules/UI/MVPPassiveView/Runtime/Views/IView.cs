using Modules.UI.MVPPassiveView.Runtime.Presenters;

namespace Modules.UI.MVPPassiveView.Runtime.Views
{
    public interface IView
    {
        void Construct(IPresenter presenter);
    }
}