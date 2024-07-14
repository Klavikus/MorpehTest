using Modules.UI.MVPPassiveView.Runtime.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.UI.MVPPassiveView._Samples.Views
{
    public class SampleView : ViewBase, ISampleView
    {
        [SerializeField] public TMP_Text _clicksCountText;
        [field: SerializeField] public Button SampleButton { get; private set; }

        public void SetClicksCountText(string clicksCount)
        {
            _clicksCountText.text = clicksCount;
        }
    }
}