using GameCore.Domain.Dto;
using UnityEngine;

namespace GameCore.Infrastructure.Implementation.Factories
{
    public interface IViewFactory
    {
        void CreateHeroButtons(Transform parent);
        void CreateHeroModelView(HeroDto heroDto, Transform parent);
    }
}