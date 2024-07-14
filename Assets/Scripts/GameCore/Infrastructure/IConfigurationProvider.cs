
namespace Sources.Infrastructure.Api.Services.Providers
{
    public interface IConfigurationProvider : IAsyncInitializable
    {
        string BootstrapSceneName { get; }
        string MainMenuSceneName { get; }
        string GameloopSceneName { get; }
        string LocalizationTablePath { get; }
    }
}