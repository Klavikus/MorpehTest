using Qw1nt.Runtime.AddressablesContentController.Core;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using UnityEngine;

namespace Runtime
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private SceneData _sceneData;

        private ContentController _contentController;

        private async void Start()
        {
            _contentController = ContentController.Default;

            await _contentController.Scene.Load(_sceneData);
        }
    }
}