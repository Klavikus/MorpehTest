using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.InputFeature.Systems;

namespace GameCore.Gameplay.Features.InputFeature
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