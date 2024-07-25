using Cysharp.Threading.Tasks;
using GameCore.Presentation.Abstract;

namespace GameCore.Infrastructure.Abstraction.Factories
{
    public interface ILoadingScreenFactory
    {
        UniTask<ILoadingScreenView> Create();
    }
}