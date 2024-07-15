using Cysharp.Threading.Tasks;
using GameCore.Presentation.Abstract;

namespace GameCore.Infrastructure.Factories
{
    public interface ILoadingScreenFactory
    {
        UniTask<ILoadingScreenView> Create();
    }
}