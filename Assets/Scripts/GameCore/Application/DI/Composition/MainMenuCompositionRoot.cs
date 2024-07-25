using GameCore.Controllers.Abstracion.Services;
using GameCore.Controllers.Implementation;
using GameCore.Controllers.Implementation.Presenters;
using GameCore.Controllers.Implementation.Presenters.Panels;
using GameCore.Controllers.Implementation.Services;
using GameCore.Domain.Enums;
using GameCore.Extensions;
using GameCore.Infrastructure.Abstraction.Factories;
using GameCore.Infrastructure.Implementation.Factories;
using GameCore.Presentation.Abstract.Panels;
using GameCore.Presentation.Implementation;
using GameCore.Presentation.Implementation.Panels;
using Modules.Infrastructure.Implementation;
using UnityEngine;
using VContainer;

namespace GameCore.Application.DI.Composition
{
    public class MainMenuCompositionRoot : SceneCompositionRoot
    {
        [SerializeField] private PanelSwitchView _panelSwitchView;
        [SerializeField] private ShopPanelView _shopPanelView;
        [SerializeField] private InventoryPanelView _inventoryPanelView;
        [SerializeField] private FightPanelView _fightPanelView;
        [SerializeField] private TalentsPanelView _talentsPanelView;
        [SerializeField] private TowerPanelView _towerPanelView;
        [SerializeField] private MetaMainHeaderView _metaMainHeaderView;
        [SerializeField] private BarView _levelBarView;

        public override void OnRegister(IContainerBuilder containerBuilder)
        {
            RegisterWindowFsm(containerBuilder);

            containerBuilder.Register<IPanelAccessService, PanelAccessService>(Lifetime.Singleton);
            containerBuilder.Register<IViewBuilder, ViewBuilder>(Lifetime.Singleton);

            containerBuilder.BindViewWithPresenter<IPanelSwitchView, EnumPanelSwitchPresenter>(_panelSwitchView);

            containerBuilder.BindViewWithPresenter<IShopPanelView, ShopPanelPresenter>(_shopPanelView);
            containerBuilder.BindViewWithPresenter<IInventoryPanelView, InventoryPanelPresenter>(_inventoryPanelView);
            containerBuilder.BindViewWithPresenter<IFightPanelView, FightPanelPresenter>(_fightPanelView);
            containerBuilder.BindViewWithPresenter<ITalentsPanelView, TalentsPanelPresenter>(_talentsPanelView);
            containerBuilder.BindViewWithPresenter<ITowerPanelView, TowerPanelPresenter>(_towerPanelView);
            containerBuilder.BindViewWithPresenter<MetaMainHeaderView, MetaMainHeaderPresenter>(_metaMainHeaderView);
        }

        public override void OnResolve(IObjectResolver sceneResolver)
        {
            sceneResolver.ConstructView<IPanelSwitchView, EnumPanelSwitchPresenter>();

            sceneResolver.ConstructView<IShopPanelView, ShopPanelPresenter>();
            sceneResolver.ConstructView<IInventoryPanelView, InventoryPanelPresenter>();
            sceneResolver.ConstructView<IFightPanelView, FightPanelPresenter>();
            sceneResolver.ConstructView<ITalentsPanelView, TalentsPanelPresenter>();
            sceneResolver.ConstructView<ITowerPanelView, TowerPanelPresenter>();
            sceneResolver.ConstructView<MetaMainHeaderView, MetaMainHeaderPresenter>();
        }

        private void RegisterWindowFsm(IContainerBuilder builder)
        {
            builder.Register<IWindowFsm<PanelType>>(
                _ => new EnumWindowFsm<PanelType>(PanelType.FightPanel),
                Lifetime.Singleton);
        }
    }
}