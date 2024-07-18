using GameCore.Controllers.Enums;
using GameCore.Presentation.Abstract.Panels;

namespace GameCore.Controllers.Presenters.Panels
{
    public sealed class TowerPanelPresenter : PanelPresenterBase
    {
        private readonly ITowerPanelView _view;

        public TowerPanelPresenter(
            ITowerPanelView view,
            IWindowFsm<PanelType> windowFsm)
            : base(windowFsm, PanelType.TowerPanel, view.Show, view.Hide)
        {
            _view = view;
        }
    }
}