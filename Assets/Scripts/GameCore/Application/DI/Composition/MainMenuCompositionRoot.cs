using System;
using System.Collections.Generic;
using GameCore.Controllers.Presenters;
using GameCore.Domain.Windows;
using GameCore.Extensions;
using GameCore.Presentation.Abstract;
using GameCore.Presentation.Implementation;
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

        public override void OnRegister(IContainerBuilder containerBuilder)
        {
            RegisterWindowFsm(containerBuilder);

            containerBuilder.BindViewWithPresenter<IMainMenuView, MainMenuPresenter>(_mainMenuView);
        }

        public override void OnResolve(IObjectResolver sceneResolver)
        {
            sceneResolver.ConstructView<IMainMenuView, MainMenuPresenter>();
        }

        private void RegisterWindowFsm(IContainerBuilder builder)
        {
            builder.Register<IWindowFsm>(
                _ =>
                {
                    Dictionary<Type, IWindow> windows = new Dictionary<Type, IWindow>()
                    {
                        [typeof(MainMenuWindow)] = new MainMenuWindow(),
                    };

                    return new WindowFsm<MainMenuWindow>(windows);
                },
                Lifetime.Singleton);
        }
    }
}