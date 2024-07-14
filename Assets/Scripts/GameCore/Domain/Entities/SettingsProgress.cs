using System;
using Modules.DAL.Runtime.Abstract.Data;

namespace GameCore.Domain.Entities
{
    [Serializable]
    public class SettingsProgress : IEntity
    {
        public int MasterVolume;
        public int MusicVolume;
        public int EffectsVolume;
        public bool IsMuted;

        public SettingsProgress(string id) =>
            Id = id;

        public string Id { get; }

        public object Clone()
        {
            return new SettingsProgress(Id)
            {
                MasterVolume = MasterVolume,
                MusicVolume = MusicVolume,
                EffectsVolume = EffectsVolume,
                IsMuted = IsMuted,
            };
        }

        public bool Equals(IEntity other) =>
            Id == other?.Id;
    }
}