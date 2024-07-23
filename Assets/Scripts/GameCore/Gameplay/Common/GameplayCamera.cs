using Cinemachine;
using UnityEngine;

namespace GameCore.Gameplay.Common
{
    public class GameplayCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera;

        public void FocusTo(Transform targetTransform)
        {
            _camera.Follow = targetTransform;
            _camera.LookAt = targetTransform;
        }
    }
}