using Scellecs.Morpeh;

namespace GameCore.Gameplay.Common.View.Registrars
{
    public interface IEntityComponentRegistrar
    {
        void RegisterComponents(Entity gameEntity);
        void UnregisterComponents(Entity gameEntity);
    }
}