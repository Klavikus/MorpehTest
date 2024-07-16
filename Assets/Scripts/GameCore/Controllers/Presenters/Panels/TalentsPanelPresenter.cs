using GameCore.Presentation.Abstract;

namespace GameCore.Controllers.Presenters.Panels
{
    public sealed class TalentsPanelPresenter : PanelPresenterBase
    {
        private readonly ITalentsPanelView _view;

        public TalentsPanelPresenter(
            ITalentsPanelView view,
            IWindowFsm<PanelType> windowFsm,
            PanelType panelType)
            : base(windowFsm, panelType, view.Show, view.Hide)
        {
            _view = view;
        }
    }
}