using Modules.DAL.Runtime.Abstract.Repositories;

namespace GameCore.Controllers.Implementation.UseCases.Progress
{
    public class SaveProgressToLocalUseCase
    {
        private readonly ICompositeRepository _compositeRepository;

        public SaveProgressToLocalUseCase(ICompositeRepository compositeRepository)
        {
            _compositeRepository = compositeRepository;
        }

        // TODO: Fix async
        public async void Execute() =>
            await _compositeRepository.Save();
    }
}