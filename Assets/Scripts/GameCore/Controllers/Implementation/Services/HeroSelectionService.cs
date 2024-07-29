using System;
using GameCore.Domain.Dto;
using UnityEngine;

namespace GameCore.Controllers.Implementation.Services
{
    public class HeroSelectionService : IHeroSelectionService
    {
        public event Action<HeroDto> Focused;
        public HeroDto FocusedOn { get; private set; }

        public void FocusOn(HeroDto heroDto)
        {
            if (FocusedOn == heroDto)
                return;

            Debug.Log($"Selected {heroDto.Id}");

            FocusedOn = heroDto;
            Focused?.Invoke(heroDto);
        }
    }
}