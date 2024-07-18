using GameCore.Controllers.Enums;
using GameCore.Presentation.Abstract.Panels;
using GameCore.UseCases;

namespace GameCore.Controllers.Presenters.Panels
{
    public sealed class ShopPanelPresenter : PanelPresenterBase
    {
        private readonly AddPlayerExpUseCase _addPlayerExpUseCase;
        private readonly IShopPanelView _view;

        public ShopPanelPresenter(
            AddPlayerExpUseCase addPlayerExpUseCase,
            IShopPanelView view,
            IWindowFsm<PanelType> windowFsm)
            : base(windowFsm, PanelType.ShopPanel, view.Show, view.Hide)
        {
            _addPlayerExpUseCase = addPlayerExpUseCase;
            _view = view;
        }

        protected override void OnAfterEnable()
        {
            _view.AddExpButton.onClick.AddListener(_addPlayerExpUseCase.Execute);
        }

        protected override void OnAfterDisable()
        {
            _view.AddExpButton.onClick.RemoveListener(_addPlayerExpUseCase.Execute);
        }
    }
}