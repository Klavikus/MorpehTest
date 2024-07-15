namespace GameCore.Presentation.Abstract
{
    public interface ILoadingScreenView
    {
        void Initialize();
        void Show();
        void Hide();
        void Fill(float progress, string description);
    }
}