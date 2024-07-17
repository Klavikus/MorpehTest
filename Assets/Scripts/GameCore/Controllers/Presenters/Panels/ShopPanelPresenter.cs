using GameCore.Presentation.Abstract;

namespace GameCore.Controllers.Presenters.Panels
{
    public sealed class ShopPanelPresenter : PanelPresenterBase
    {
        private readonly IShopPanelView _view;

        public ShopPanelPresenter(
            IShopPanelView view,
            IWindowFsm<PanelType> windowFsm)
            : base(windowFsm, PanelType.ShopPanel, view.Show, view.Hide)
        {
            _view = view;
        }
    }
}