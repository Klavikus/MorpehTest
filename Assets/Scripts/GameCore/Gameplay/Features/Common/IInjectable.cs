using VContainer;

namespace GameCore.Gameplay.Features.Common
{
    public interface IInjectable
    {
        void Inject(IObjectResolver objectResolver);
    }
}