using GameCore.Presentation.Abstract;

namespace GameCore.Controllers.Presenters.Panels
{
    public sealed class InventoryPanelPresenter : PanelPresenterBase
    {
        private readonly IInventoryPanelView _view;

        public InventoryPanelPresenter(
            IInventoryPanelView view,
            IWindowFsm<PanelType> windowFsm,
            PanelType panelType)
            : base(windowFsm, panelType, view.Show, view.Hide)
        {
            _view = view;
        }
    }
}