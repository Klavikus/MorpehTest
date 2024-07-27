using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Input.Systems;

namespace GameCore.Gameplay.Features.Input
{
    public class InputFeature : Feature
    {
        public InputFeature()
        {
            AddSystem<InputSystem>();
            AddCleanupSystem<CleanupInputSystem>();
        }
    }
}