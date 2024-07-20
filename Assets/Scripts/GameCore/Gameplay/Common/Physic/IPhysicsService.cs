using System.Collections.Generic;
using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Common.Physic
{
    public interface IPhysicsService
    {
        Entity Raycast(Vector3 worldPosition, Vector3 direction, float maxDistance, int layerMask);
        Entity LineCast(Vector3 start, Vector3 end, float maxDistance, int layerMask);
        IEnumerable<Entity> RaycastAll(Vector3 worldPosition, Vector3 direction, float maxDistance, int layerMask);
        IEnumerable<Entity> CircleCast(Vector3 position, float radius, int layerMask);
        int OverlapSphere(Vector3 worldPos, float radius, Collider[] hits, int layerMask);
        int CircleCastNonAlloc(Vector3 position, float radius, int layerMask, Entity[] hitBuffer);
    }
}