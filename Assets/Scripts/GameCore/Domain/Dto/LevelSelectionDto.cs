using System;

namespace GameCore.Domain.Dto
{
    [Serializable]
    public struct LevelSelectionDto
    {
        public int SelectedLevelId;
        public int SelectedId;
    }
}