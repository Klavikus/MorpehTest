using Cysharp.Threading.Tasks;
using GameCore.Controllers.Behaviours;
using GameCore.Infrastructure.AssetManagement;

namespace GameCore.Controllers.Services
{
    public class CurtainService : ICurtainService
    {
        private readonly IResourceService _resourceService;

        private ICurtain _curtain;

        public CurtainService(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public async UniTask Initialize()
        {
            _curtain = await _resourceService.CreateAsync<Curtain>(AssetKeys.KeyByType[typeof(Curtain)]);
            _curtain.Initialize();
        }

        public async UniTask Show() =>
            await _curtain.Show();

        public async UniTask Hide() =>
            await _curtain.Hide();
    }
}