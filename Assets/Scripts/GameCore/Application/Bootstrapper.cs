using GameCore.Application.DI.LifetimeScoupes;
using UnityEngine;

namespace GameCore.Application
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameLifetimeScope _lifetimeScope;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            _lifetimeScope.Build();
        }
    }
}