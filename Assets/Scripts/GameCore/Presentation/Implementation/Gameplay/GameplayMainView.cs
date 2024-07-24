using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Presentation.Implementation.Gameplay
{
    public class GameplayMainView : ViewBase
    {
        [field: SerializeField] public Button BackToMenuButton { get; private set; }
    }
}