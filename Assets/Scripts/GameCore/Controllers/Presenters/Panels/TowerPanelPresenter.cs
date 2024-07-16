using GameCore.Presentation.Abstract;

namespace GameCore.Controllers.Presenters.Panels
{
    public sealed class TowerPanelPresenter : PanelPresenterBase
    {
        private readonly ITowerPanelView _view;

        public TowerPanelPresenter(
            ITowerPanelView view,
            IWindowFsm<WindowType> windowFsm,
            WindowType windowType)
            : base(windowFsm, windowType, view.Show, view.Hide)
        {
            _view = view;
        }
    }
}