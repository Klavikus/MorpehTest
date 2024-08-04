using Cysharp.Threading.Tasks;
using Modules.DAL.Runtime.Abstract.Repositories;

namespace GameCore.Controllers.Implementation.UseCases.Progress
{
    public class LoadProgressUseCase
    {
        private readonly ICompositeRepository _compositeRepository;

        public LoadProgressUseCase(ICompositeRepository compositeRepository)
        {
            _compositeRepository = compositeRepository;
        }

        public UniTask Execute() =>
            _compositeRepository.Load();
    }
}