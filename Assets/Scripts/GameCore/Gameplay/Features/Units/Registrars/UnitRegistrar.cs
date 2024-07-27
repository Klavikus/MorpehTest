using GameCore.Gameplay.Features.UnitFeature.Components;
using GameCore.Gameplay.Features.ViewFeature.Registrars;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.UnitFeature.Registrars
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