using GameCore.Presentation.Abstract;

namespace GameCore.Controllers.Presenters.Panels
{
    public sealed class InventoryPanelPresenter : PanelPresenterBase
    {
        private readonly IInventoryPanelView _view;

        public InventoryPanelPresenter(
            IInventoryPanelView view,
            IWindowFsm<PanelType> windowFsm)
            : base(windowFsm, PanelType.InventoryPanel, view.Show, view.Hide)
        {
            _view = view;
        }
    }
}