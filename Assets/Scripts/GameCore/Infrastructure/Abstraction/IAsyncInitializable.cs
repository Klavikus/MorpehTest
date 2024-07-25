using Cysharp.Threading.Tasks;

namespace GameCore.Infrastructure.Abstraction
{
    public interface IAsyncInitializable
    {
        UniTask Initialize();
    }
}