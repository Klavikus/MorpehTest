using System;
using GameCore.Domain.Dto;

namespace GameCore.Controllers.Implementation.Services
{
    public interface IHeroSelectionService
    {
        void FocusOn(HeroDto heroDto);
        event Action<HeroDto> Focused;
        HeroDto FocusedOn { get; }
    }
}