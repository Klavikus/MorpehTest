using Modules.UI.MVPPassiveView.Runtime.Views;

namespace GameCore.Presentation.Implementation.MainMenu
{
    public class MetaMainHeaderView : ViewBase
    {
    }

    public class LevelupUseCase : IUseCase<int>
    {
        
        public void Execute(int levelsAmount)
        {
        }
    }

    public interface IUseCase<in TRequest>
        where TRequest : struct
    {
        void Execute(TRequest request);
    }
}