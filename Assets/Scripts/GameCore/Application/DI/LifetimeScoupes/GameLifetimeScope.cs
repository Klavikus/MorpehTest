using GameCore.Controllers.GameFSM;
using GameCore.Controllers.GameFSM.States;
using GameCore.Controllers.Services;
using GameCore.Infrastructure.AssetManagement;
using Modules.Infrastructure.Implementation.DI;
using Modules.Infrastructure.Interfaces.GameFsm;
using Qw1nt.Runtime.AddressablesContentController.Common;
using Qw1nt.Runtime.AddressablesContentController.Core;
using Qw1nt.Runtime.Shared.AddressablesContentController.Interfaces;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using Sources.Infrastructure.Api.Services.Providers;
using Sources.Infrastructure.Core.Services.Providers;
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

            RegisterAssetManagementServices(builder);
            RegisterGameStateMachine(builder);

            builder.Register<ICurtainService, CurtainService>(Lifetime.Scoped);
            builder.Register<ContentController>(Lifetime.Singleton);
            
            builder.Register<IConfigurationProvider, ConfigurationProvider>(Lifetime.Scoped);

            builder.Register<SceneInitializer>(Lifetime.Singleton);

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
    }
}