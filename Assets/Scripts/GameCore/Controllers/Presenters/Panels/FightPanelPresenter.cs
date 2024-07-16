using GameCore.Presentation.Abstract;

namespace GameCore.Controllers.Presenters.Panels
{
    public sealed class FightPanelPresenter : PanelPresenterBase
    {
        private readonly IFightPanelView _view;

        public FightPanelPresenter(
            IFightPanelView view,
            IWindowFsm<PanelType> windowFsm,
            PanelType panelType)
            : base(windowFsm, panelType, view.Show, view.Hide)
        {
            _view = view;
        }
    }
}