using UnityEngine;

namespace GameCore.Application
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private Bootstrapper _bootstrapper;

        private void Start()
        {
            UnityEngine.Application.targetFrameRate = 120;

            if (FindObjectOfType<Bootstrapper>() != null)
                return;

            Instantiate(_bootstrapper);
        }
    }
}