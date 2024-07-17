using System;
using GameCore.Presentation.Implementation.MainMenu;
using Modules.UI.MVPPassiveView.Runtime.Presenters;

namespace GameCore.Controllers.Presenters
{
    public class MetaMainHeaderPresenter : IPresenter
    {
        private readonly MetaMainHeaderView _view;

        public MetaMainHeaderPresenter(MetaMainHeaderView view)
        {
            _view = view ? view : throw new ArgumentNullException(nameof(view));
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}