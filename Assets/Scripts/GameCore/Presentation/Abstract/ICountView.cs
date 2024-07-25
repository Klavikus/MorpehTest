using Modules.UI.MVPPassiveView.Runtime.Views;

namespace GameCore.Presentation.Implementation
{
    public interface ICountView<in T> : IView
        where T : struct
    {
        void Fill(T text);
    }
}