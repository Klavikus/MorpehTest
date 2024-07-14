using Cysharp.Threading.Tasks;

namespace Sources.Infrastructure.Api.Services.Providers
{
    public interface IAsyncInitializable
    {
        UniTask Initialize();
    }
}