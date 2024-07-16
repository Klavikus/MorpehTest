using GameCore.Presentation.Abstract;

namespace GameCore.Controllers.Presenters.Panels
{
    public sealed class TowerPanelPresenter : PanelPresenterBase
    {
        private readonly ITowerPanelView _view;

        public TowerPanelPresenter(
            ITowerPanelView view,
            IWindowFsm<PanelType> windowFsm,
            PanelType panelType)
            : base(windowFsm, panelType, view.Show, view.Hide)
        {
            _view = view;
        }
    }
}