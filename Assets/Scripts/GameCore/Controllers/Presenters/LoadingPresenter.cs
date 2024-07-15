using GameCore.Controllers.Services.Loading;
using GameCore.Presentation.Implementation;
using Modules.UI.MVPPassiveView.Runtime.Presenters;

namespace GameCore.Controllers.Presenters
{
    public class LoadingPresenter : IPresenter
    {
        private readonly LoadingScreenView _loadingScreenView;
        private readonly ILoadingService _loadingService;

        public LoadingPresenter(LoadingScreenView loadingScreenView, ILoadingService loadingService)
        {
            _loadingScreenView = loadingScreenView;
            _loadingService = loadingService;
        }

        public void Enable()
        {
            _loadingScreenView.Initialize();

            _loadingService.Started += ShowScreen;
            _loadingService.Completed += HideScreen;
            _loadingService.ProgressUpdated += _loadingScreenView.Fill;

            if (_loadingService.InProgress)
            {
                _loadingScreenView.Fill(_loadingService.Progress, _loadingService.Description);
                ShowScreen();
            }
        }

        public void Disable()
        {
        }

        private void ShowScreen()
        {
            _loadingScreenView.Show();
        }

        private void HideScreen()
        {
            _loadingScreenView.Hide();
        }
    }
}