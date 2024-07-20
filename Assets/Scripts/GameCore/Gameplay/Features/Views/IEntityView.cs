using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Features.Views
{
    public interface IEntityView
    {
        Entity Entity { get; }
        GameObject GameObject { get; }
        void SetEntity(Entity gameEntity);
        void Release();
    }
}