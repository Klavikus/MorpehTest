using GameCore.Gameplay.Features.UnitFeature.Components;
using GameCore.Gameplay.Features.ViewFeature.Registrars;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.UnitFeature.Registrars
{
    public class UnitRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents(Entity gameEntity)
        {
            gameEntity.AddComponent<UnitTag>();
        }

        public override void UnregisterComponents(Entity gameEntity)
        {
            if (gameEntity.Has<UnitTag>())
                gameEntity.RemoveComponent<UnitTag>();
        }
    }
}