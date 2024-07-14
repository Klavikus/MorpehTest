using UnityEngine;

namespace Sources.Infrastructure.Core
{
    [CreateAssetMenu(menuName = "Data/Create ConfigurationContainer", fileName = "ConfigurationContainer", order = 0)]
    public class ConfigurationContainer : ScriptableObject
    {
        [field: SerializeField] public string BootstrapSceneName { get; private set; }
        [field: SerializeField] public string MainMenuSceneName { get; private set; }
        [field: SerializeField] public string GameloopSceneName { get; private set; }
        [field: SerializeField] public string LocalizationTablePath { get; private set; }
    }
}