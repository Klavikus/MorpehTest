using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Views.Registrars
{
    public interface IEntityComponentRegistrar
    {
        void RegisterComponents(Entity gameEntity);
        void UnregisterComponents(Entity gameEntity);
    }
}