using System;

namespace GameCore.Domain.Dto
{
    [Serializable]
    public struct SettingsDto
    {
        public int Volume;
        public bool IsMuted;
    }
}