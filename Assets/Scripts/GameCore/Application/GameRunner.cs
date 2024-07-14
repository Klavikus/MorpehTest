using UnityEngine;

namespace GameCore.Application
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private Bootstrapper _bootstrapper;

        private void Start()
        {
            if (FindObjectOfType<Bootstrapper>() != null)
                return;

            Instantiate(_bootstrapper);
        }
    }
}