using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.ViewFeature.Registrars
{
    public interface IEntityComponentRegistrar
    {
        void RegisterComponents(Entity gameEntity);
        void UnregisterComponents(Entity gameEntity);
    }
}