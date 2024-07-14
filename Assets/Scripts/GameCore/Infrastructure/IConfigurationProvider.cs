
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;

namespace Sources.Infrastructure.Api.Services.Providers
{
    public interface IConfigurationProvider : IAsyncInitializable
    {
        SceneData BootstrapSceneData { get; }
        SceneData MainMenuSceneData { get; }
        SceneData GameloopSceneData { get; }
        string LocalizationTablePath { get; }
    }
}