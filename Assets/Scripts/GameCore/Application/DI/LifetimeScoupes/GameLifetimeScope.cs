﻿using System;
using GameCore.Controllers.Abstracion.Services.Loading;
using GameCore.Controllers.Implementation.GameFSM;
using GameCore.Controllers.Implementation.GameFSM.States;
using GameCore.Controllers.Implementation.Services;
using GameCore.Controllers.Implementation.Services.Loading;
using GameCore.Controllers.Implementation.UseCases;
using GameCore.Controllers.Implementation.UseCases.HeroSelection;
using GameCore.Domain.Models;
using GameCore.Infrastructure.Abstraction;
using GameCore.Infrastructure.Abstraction.AssetManagement;
using GameCore.Infrastructure.Abstraction.Factories;
using GameCore.Infrastructure.Implementation;
using GameCore.Infrastructure.Implementation.AssetManagement;
using GameCore.Infrastructure.Implementation.Factories;
using Modules.DAL.Runtime.Abstract.Data;
using Modules.DAL.Runtime.Abstract.DataContexts;
using Modules.DAL.Runtime.Abstract.Repositories;
using Modules.DAL.Runtime.Implementation.Data;
using Modules.DAL.Runtime.Implementation.Data.Entities;
using Modules.DAL.Runtime.Implementation.DataContexts;
using Modules.DAL.Runtime.Implementation.Repositories;
using Modules.Infrastructure.Implementation.DI;
using Modules.Infrastructure.Interfaces.GameFsm;
using Qw1nt.Runtime.AddressablesContentController.Common;
using Qw1nt.Runtime.AddressablesContentController.Core;
using Qw1nt.Runtime.Shared.AddressablesContentController.Interfaces;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace GameCore.Application.DI.LifetimeScoupes
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IOperationsTracker, OperationsTracker>(Lifetime.Transient);
            builder.Register<SceneManipulator>(Lifetime.Singleton);

            builder.Register<ILoadingService, LoadingService>(Lifetime.Singleton);
            builder.Register<ILoadingScreenFactory, LoadingScreenFactory>(Lifetime.Singleton);
            builder.Register<LevelLoadingService>(Lifetime.Singleton);

            RegisterAssetManagementServices(builder);
            RegisterGameStateMachine(builder);

            builder.Register<ContentController>(Lifetime.Singleton);

            builder.Register<IConfigurationProvider, ConfigurationProvider>(Lifetime.Singleton);

            builder.Register<SceneInitializer>(Lifetime.Singleton);

            builder.Register<GetPlayerLevelUseCase>(Lifetime.Singleton);
            builder.Register<GetPlayerCurrencyUseCase>(Lifetime.Singleton);
            builder.Register<AddPlayerExpUseCase>(Lifetime.Singleton);
            builder.Register<GetLevelSelectionUseCase>(Lifetime.Singleton);
            builder.Register<GetSelectedHeroUseCase>(Lifetime.Singleton);
            builder.Register<GetSelectedHeroIdUseCase>(Lifetime.Singleton);
            builder.Register<SetSelectedHeroIdUseCase>(Lifetime.Singleton);

            RegisterProgressRepository(builder);

            builder.RegisterEntryPoint<Game>();
        }

        private void RegisterGameStateMachine(IContainerBuilder builder)
        {
            builder.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);
            builder.Register<BootstrapState>(Lifetime.Singleton);
            builder.Register<GameLoopState>(Lifetime.Singleton);
            builder.Register<LoadDataState>(Lifetime.Singleton);
            builder.Register<MainMenuState>(Lifetime.Singleton);
        }

        private void RegisterAssetManagementServices(IContainerBuilder builder)
        {
            builder.Register<IAssetProvider, AssetProvider>(Lifetime.Singleton);
            builder.Register<IResourceService, ResourceService>(Lifetime.Singleton);
        }

        private void RegisterProgressRepository(IContainerBuilder builder)
        {
            builder.Register<ICompositeRepository>(_ =>
                {
                    Type[] dataTypes =
                    {
                        typeof(SyncData),
                        typeof(PlayerLevel),
                        typeof(PlayerCurrency),
                        typeof(LevelSelection),
                        typeof(HeroSelection),
                    };
                    IData gameData = new GameData(dataTypes);
                    IDataContext dataContext = new SimpleRuntimeDataContext(gameData);

                    return new CompositeRepository(dataContext, dataTypes);
                },
                Lifetime.Singleton);
        }
    }
}