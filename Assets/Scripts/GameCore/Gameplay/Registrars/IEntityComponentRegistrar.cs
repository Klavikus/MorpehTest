using Scellecs.Morpeh;

namespace Code.Infrastructure.Views.Registrars
{
    public interface IEntityComponentRegistrar
    {
        void RegisterComponents(Entity gameEntity);
        void UnregisterComponents(Entity gameEntity);
    }
}