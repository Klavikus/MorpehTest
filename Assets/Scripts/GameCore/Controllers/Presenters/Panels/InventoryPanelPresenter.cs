using GameCore.Presentation.Abstract;

namespace GameCore.Controllers.Presenters.Panels
{
    public sealed class InventoryPanelPresenter : PanelPresenterBase
    {
        private readonly IInventoryPanelView _view;

        public InventoryPanelPresenter(
            IInventoryPanelView view,
            IWindowFsm<WindowType> windowFsm,
            WindowType windowType)
            : base(windowFsm, windowType, view.Show, view.Hide)
        {
            _view = view;
        }
    }
}