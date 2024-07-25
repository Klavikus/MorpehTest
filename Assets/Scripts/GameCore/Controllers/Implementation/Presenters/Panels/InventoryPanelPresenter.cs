using GameCore.Domain.Enums;
using GameCore.Presentation.Abstract.Panels;

namespace GameCore.Controllers.Implementation.Presenters.Panels
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