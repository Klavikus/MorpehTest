using GameCore.Controllers.Implementation.UseCases;
using GameCore.Domain.Enums;
using GameCore.Presentation.Abstract.Panels;

namespace GameCore.Controllers.Implementation.Presenters.Panels
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