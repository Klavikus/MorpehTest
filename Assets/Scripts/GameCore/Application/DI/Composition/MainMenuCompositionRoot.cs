using GameCore.Controllers;
using GameCore.Controllers.Presenters.Panels;
using GameCore.Controllers.Services;
using GameCore.Extensions;
using GameCore.Presentation.Abstract;
using GameCore.Presentation.Implementation.MainMenu;
using Modules.Infrastructure.Implementation;
using UnityEngine;
using VContainer;

namespace GameCore.Application.DI.Composition
{
    public class MainMenuCompositionRoot : SceneCompositionRoot
    {
        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private PanelSwitchView _panelSwitchView;
        [SerializeField] private ShopPanelView _shopPanelView;
        [SerializeField] private InventoryPanelView _inventoryPanelView;
        [SerializeField] private FightPanelView _fightPanelView;
        [SerializeField] private TalentsPanelView _talentsPanelView;
        [SerializeField] private TowerPanelView _towerPanelView;

        public override void OnRegister(IContainerBuilder containerBuilder)
        {
            RegisterWindowFsm(containerBuilder);

            containerBuilder.Register<IPanelAccessService, PanelAccessService>(Lifetime.Singleton);

            // containerBuilder.BindViewWithPresenter<IMainMenuView, MainMenuPresenter>(_mainMenuView);
            containerBuilder.BindViewWithPresenter<IPanelSwitchView, EnumPanelSwitchPresenter>(_panelSwitchView);
            // containerBuilder.BindViewWithPresenter<IShopPanelView, ShopPanelPresenter>(_shopPanelView);
            // containerBuilder.BindViewWithPresenter<IFightPanelView, FightPanelPresenter>(_fightPanelView);
        }

        public override void OnResolve(IObjectResolver sceneResolver)
        {
            // sceneResolver.ConstructView<IMainMenuView, MainMenuPresenter>();
            sceneResolver.ConstructView<IPanelSwitchView, EnumPanelSwitchPresenter>();
            // sceneResolver.ConstructView<IShopPanelView, ShopPanelPresenter>();
            // sceneResolver.ConstructView<IFightPanelView, FightPanelPresenter>();

            var panelFsm = sceneResolver.Resolve<IWindowFsm<PanelType>>();

            _shopPanelView.Construct(new ShopPanelPresenter(_shopPanelView, panelFsm, PanelType.ShopPanel));
            _inventoryPanelView.Construct(new InventoryPanelPresenter(_inventoryPanelView, panelFsm, PanelType.InventoryPanel));
            _fightPanelView.Construct(new FightPanelPresenter(_fightPanelView, panelFsm, PanelType.FightPanel));
            _talentsPanelView.Construct(new TalentsPanelPresenter(_talentsPanelView, panelFsm, PanelType.TalentsPanel));
            _towerPanelView.Construct(new TowerPanelPresenter(_towerPanelView, panelFsm, PanelType.TowerPanel));
        }

        private void RegisterWindowFsm(IContainerBuilder builder)
        {
            builder.Register<IWindowFsm<PanelType>>(
                _ => new EnumWindowFsm<PanelType>(PanelType.FightPanel),
                Lifetime.Singleton);
        }
    }
}