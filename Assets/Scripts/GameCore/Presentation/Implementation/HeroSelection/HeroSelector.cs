using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Presentation.Implementation.HeroSelection
{
    public class HeroSelector : ViewBase
    {
        [field: SerializeField] public Image Avatar { get; private set; }
        [field: SerializeField] public Image SelectionBorder { get; private set; }
        [field: SerializeField] public Button SelectButton { get; private set; }
    }
}