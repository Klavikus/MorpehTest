using System;

namespace GameCore.Domain.Dto
{
    [Serializable]
    public struct PlayerLevelDto
    {
        public int CurrentLevel;
        public int MaxLevel;
        public int CurrentExp;
        public int ExpToLevelup;
    }
}