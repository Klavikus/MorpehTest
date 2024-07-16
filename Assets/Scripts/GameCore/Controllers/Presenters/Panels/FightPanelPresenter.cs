using GameCore.Presentation.Abstract;

namespace GameCore.Controllers.Presenters.Panels
{
    public sealed class FightPanelPresenter : PanelPresenterBase
    {
        private readonly IFightPanelView _view;

        public FightPanelPresenter(
            IFightPanelView view,
            IWindowFsm<WindowType> windowFsm,
            WindowType windowType)
            : base(windowFsm, windowType, view.Show, view.Hide)
        {
            _view = view;
        }
    }
}