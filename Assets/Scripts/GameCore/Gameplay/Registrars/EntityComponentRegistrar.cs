using Scellecs.Morpeh;
using UnityEngine;

namespace Code.Infrastructure.Views.Registrars
{
    public abstract class EntityComponentRegistrar : MonoBehaviour, IEntityComponentRegistrar
    {
        public abstract void RegisterComponents(Entity gameEntity);
        public abstract void UnregisterComponents(Entity gameEntity);
    }
}