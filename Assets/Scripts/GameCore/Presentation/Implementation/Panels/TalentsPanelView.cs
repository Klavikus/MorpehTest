using GameCore.Presentation.Abstract.Panels;
using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;

namespace GameCore.Presentation.Implementation.Panels
{
    public class TalentsPanelView : ViewBase, ITalentsPanelView
    {
        [SerializeField] private Canvas _canvas;

        public void Show()
        {
            _canvas.enabled = true;
        }

        public void Hide()
        {
            _canvas.enabled = false;
        }
    }
}