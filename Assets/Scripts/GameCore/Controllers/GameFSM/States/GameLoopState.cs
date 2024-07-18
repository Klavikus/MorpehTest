using GameCore.Controllers.Services.Loading;
using Modules.Infrastructure.Interfaces.GameFsm;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using VContainer;

namespace GameCore.Controllers.GameFSM.States
{
    public class GameLoopState : IPayloadState<SceneData>
    {
        private readonly ILoadingService _loadingService;
        private readonly IObjectResolver _objectResolver;

        public GameLoopState(ILoadingService loadingService, IObjectResolver objectResolver)
        {
            _loadingService = loadingService;
            _objectResolver = objectResolver;
        }

        public void Enter(SceneData sceneData)
        {
            _loadingService.LoadScene(sceneData, _objectResolver);
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }
    }
}