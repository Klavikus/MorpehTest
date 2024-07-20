using Code.Infrastructure.Systems;
using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.InputFeature.Systems;

namespace GameCore.Gameplay.Features.InputFeature
{
    public class InputFeature : Feature
    {
        public InputFeature(ISystemFactory systemFactory)
        {
            AddSystem(systemFactory.Create<InputSystem>());
            AddCleanupSystem(systemFactory.Create<CleanupInputSystem>());
        }
    }
}