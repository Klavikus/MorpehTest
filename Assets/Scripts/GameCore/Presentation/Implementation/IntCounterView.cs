using GameCore.Presentation.Abstract;
using Modules.UI.MVPPassiveView.Runtime.Views;
using TMPro;
using UnityEngine;

namespace GameCore.Presentation.Implementation
{
    public class IntCounterView : ViewBase, ICountView<int>
    {
        [SerializeField] private TMP_Text _label;

        public void Fill(int value) =>
            _label.text = value.ToString();
    }
}