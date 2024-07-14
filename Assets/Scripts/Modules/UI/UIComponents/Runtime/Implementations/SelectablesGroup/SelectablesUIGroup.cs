using System.Collections.Generic;
using Modules.UI.UIComponents.Runtime.Interfaces;
using UnityEngine;

namespace Modules.UI.UIComponents.Runtime.Implementations.SelectablesGroup
{
    public class SelectablesUiGroup : MonoBehaviour
    {
        private IEnumerable<ISelectable> _selectables;

        public void Initialize(IEnumerable<ISelectable> selectables)
        {
            _selectables = selectables;
        }

        public void Select(ISelectable targetSelectable)
        {
            foreach (ISelectable selectable in _selectables)
            {
                if (selectable == targetSelectable)
                    selectable.Focus();
                else
                    selectable.Unfocus();
            }
        }
    }
}