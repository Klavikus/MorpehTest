using System;
using System.Collections.Generic;
using GameCore.Controllers.Presenters;
using GameCore.Domain.Windows.Panels;
using GameCore.Extensions;
using GameCore.Presentation.Abstract;
using GameCore.Presentation.Implementation;
using GameCore.Presentation.Implementation.MainMenu;
using Modules.Infrastructure.Implementation;
using Modules.UI.WindowFsm.Runtime.Abstract;
using Modules.UI.WindowFsm.Runtime.Implementation;
using UnityEngine;
using VContainer;

namespace GameCore.Application.DI.Composition
{
    public class MainMenuCompositionRoot : SceneCompositionRoot
    {
        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private PanelSwitchView _panelSwitchView;

        public override void OnRegister(IContainerBuilder containerBuilder)
        {
            RegisterWindowFsm(containerBuilder);

            containerBuilder.BindViewWithPresenter<IMainMenuView, MainMenuPresenter>(_mainMenuView);
            containerBuilder.BindViewWithPresenter<IPanelSwitchView, PanelSwitchPresenter>(_panelSwitchView);
        }

        public override void OnResolve(IObjectResolver sceneResolver)
        {
            sceneResolver.ConstructView<IMainMenuView, MainMenuPresenter>();
            sceneResolver.ConstructView<IPanelSwitchView, PanelSwitchPresenter>();
        }

        private void RegisterWindowFsm(IContainerBuilder builder)
        {
            builder.Register<IWindowFsm>(
                _ =>
                {
                    Dictionary<Type, IWindow> windows = new Dictionary<Type, IWindow>()
                    {
                        [typeof(ShopPanel)] = new ShopPanel(),
                        [typeof(InventoryPanel)] = new InventoryPanel(),
                        [typeof(FightPanel)] = new FightPanel(),
                        [typeof(TalentsPanel)] = new TalentsPanel(),
                        [typeof(TowerPanel)] = new TowerPanel(),
                    };

                    return new WindowFsm<FightPanel>(windows);
                },
                Lifetime.Singleton);
        }
    }
}