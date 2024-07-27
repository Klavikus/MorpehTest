using UnityEngine;

namespace GameCore.Gameplay.Common
{
    public class SelfDestructor : MonoBehaviour
    {
        [SerializeField] private float _countdown = 3f;

        private void Update()
        {
            _countdown -= Time.deltaTime;
            if (_countdown <= 0)
                Destroy(gameObject);
        }
    }
}