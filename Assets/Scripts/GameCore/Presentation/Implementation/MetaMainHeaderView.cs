using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;

namespace GameCore.Presentation.Implementation.MainMenu
{
    public class MetaMainHeaderView : ViewBase
    {
        [field: SerializeField] public BarView LevelBar { get; private set; }
        [field: SerializeField] public IntCounterView LevelCounter { get; private set; }
        [field: SerializeField] public IntCounterView SoftCurrency { get; private set; }
        [field: SerializeField] public IntCounterView HardCurrency { get; private set; }
    }
}