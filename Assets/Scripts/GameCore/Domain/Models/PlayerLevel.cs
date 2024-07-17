using System;

namespace GameCore.Domain.Models
{
    [Serializable]
    public class PlayerLevel : BaseEntity
    {
        public static string DefaultId = nameof(PlayerLevel);
        
        public PlayerLevel() : base(DefaultId)
        {
        }

        public int LevelCurrency { get; private set; }
        public int WinCount { get; private set; }
        public int LevelId { get; private set; }
        public bool IsNudeToggled { get; private set; }
        public bool IsCompleted => WinCount > 0;
    }
}