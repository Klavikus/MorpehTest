using GameCore.Gameplay.Common.View.Registrars;
using GameCore.Gameplay.Features.Units.Components;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Units.Registrars
{
    public class UnitRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents(Entity gameEntity)
        {
            gameEntity.AddComponent<Unit>();
        }

        public override void UnregisterComponents(Entity gameEntity)
        {
            if (gameEntity.Has<Unit>())
                gameEntity.RemoveComponent<Unit>();
        }
    }
}