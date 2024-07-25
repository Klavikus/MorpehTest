using GameCore.Domain.Enums;
using GameCore.Presentation.Abstract.Panels;

namespace GameCore.Controllers.Implementation.Presenters.Panels
{
    public sealed class TalentsPanelPresenter : PanelPresenterBase
    {
        private readonly ITalentsPanelView _view;

        public TalentsPanelPresenter(
            ITalentsPanelView view,
            IWindowFsm<PanelType> windowFsm)
            : base(windowFsm, PanelType.TalentsPanel, view.Show, view.Hide)
        {
            _view = view;
        }
    }
}