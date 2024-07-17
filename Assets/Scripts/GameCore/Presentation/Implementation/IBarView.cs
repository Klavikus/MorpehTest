using Modules.UI.MVPPassiveView.Runtime.Views;

namespace GameCore.Presentation.Implementation
{
    public interface IBarView : IView
    {
        void Fill(int currentValue, int maxValue);
    }
}