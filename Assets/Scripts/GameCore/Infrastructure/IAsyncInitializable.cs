using Cysharp.Threading.Tasks;

namespace GameCore.Infrastructure
{
    public interface IAsyncInitializable
    {
        UniTask Initialize();
    }
}