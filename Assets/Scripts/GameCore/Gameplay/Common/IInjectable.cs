using VContainer;

namespace GameCore.Gameplay.Common
{
    public interface IInjectable
    {
        void Inject(IObjectResolver objectResolver);
    }
}