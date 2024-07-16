using GameCore.Presentation.Abstract;

namespace GameCore.Controllers.Presenters.Panels
{
    public sealed class TalentsPanelPresenter : PanelPresenterBase
    {
        private readonly ITalentsPanelView _view;

        public TalentsPanelPresenter(
            ITalentsPanelView view,
            IWindowFsm<WindowType> windowFsm,
            WindowType windowType)
            : base(windowFsm, windowType, view.Show, view.Hide)
        {
            _view = view;
        }
    }
}