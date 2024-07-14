using GameCore.Domain.Entities;

namespace GameCore.Domain.Models
{
    public class SettingsModel : ISerializable<SettingsProgress>
    {
        public int MasterVolume { get; private set; }
        public int MusicVolume { get; private set; }
        public int EffectsVolume { get; private set; }
        public bool IsMuted { get; private set; }

        public SettingsProgress Serialize()
        {
            return new SettingsProgress(nameof(SettingsProgress))
            {
                MasterVolume = MasterVolume,
                MusicVolume = MusicVolume,
                EffectsVolume = EffectsVolume,
                IsMuted = IsMuted,
            };
        }

        public void Deserialize(SettingsProgress dto)
        {
            MasterVolume = dto.MasterVolume;
            MusicVolume = dto.MusicVolume;
            EffectsVolume = dto.EffectsVolume;
            IsMuted = dto.IsMuted;
        }
    }
}