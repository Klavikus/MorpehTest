using System;
using GameCore.Domain.Dto;
using UnityEngine;

namespace GameCore.Controllers.Implementation.Services
{
    public class HeroSelectionService : IHeroSelectionService
    {
        private HeroDto _currentFocused;

        public event Action<HeroDto> Focused;

        public void FocusOn(HeroDto heroDto)
        {
            Debug.Log($"Selected {heroDto.Id}");
            _currentFocused = heroDto;
            Focused?.Invoke(heroDto);
        }
    }
}