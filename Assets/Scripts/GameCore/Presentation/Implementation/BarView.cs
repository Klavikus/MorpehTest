using GameCore.Presentation.Abstract;
using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Presentation.Implementation
{
    public class BarView : ViewBase, IBarView
    {
        [SerializeField] private Image _filler;

        public void Fill(int currentValue, int maxValue) =>
            _filler.fillAmount = (float) currentValue / maxValue;
    }
}