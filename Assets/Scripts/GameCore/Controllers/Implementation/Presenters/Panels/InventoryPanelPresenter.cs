using GameCore.Domain.Enums;
using GameCore.Presentation.Abstract.Panels;

namespace GameCore.Controllers.Implementation.Presenters.Panels
{
    public sealed class InventoryPanelPresenter : PanelPresenterBase
    {
        private readonly IInventoryPanelView _view;
        private readonly IWindowFsm<PanelType> _windowFsm;

        public InventoryPanelPresenter(
            IInventoryPanelView view,
            IWindowFsm<PanelType> windowFsm)
            : base(windowFsm, PanelType.InventoryPanel, view.Show, view.Hide)
        {
            _windowFsm = windowFsm;
            _view = view;
        }

        protected override void OnAfterEnable()
        {
            _view.HeroListButton.onClick.AddListener(OnHeroListButtonClicked);
        }

        protected override void OnAfterDisable()
        {
            _view.HeroListButton.onClick.RemoveListener(OnHeroListButtonClicked);
        }

        private void OnHeroListButtonClicked()
        {
            _windowFsm.OpenWindow(PanelType.HeroListPanel);
        }
    }
}