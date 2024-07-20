using System.Collections.Generic;
using GameCore.Gameplay.Common.Collisions;
using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Common.Physic
{
    public class PhysicsService : IPhysicsService
    {
        private static readonly RaycastHit[] Hits = new RaycastHit[128];
        private static readonly Collider[] OverlapHits = new Collider[128];

        private readonly ICollisionRegistry _collisionRegistry;

        public PhysicsService(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public IEnumerable<Entity> RaycastAll(
            Vector3 worldPosition,
            Vector3 direction,
            float maxDistance,
            int layerMask)
        {
            int hitCount = Physics.RaycastNonAlloc(worldPosition, direction, Hits, maxDistance, layerMask);

            for (int i = 0; i < hitCount; i++)
            {
                RaycastHit hit = Hits[i];

                if (hit.collider == null)
                    continue;

                Entity entity = _collisionRegistry.Get<Entity>(hit.collider.GetInstanceID());

                if (entity == null)
                    continue;

                yield return entity;
            }
        }

        public Entity Raycast(Vector3 worldPosition, Vector3 direction, float maxDistance, int layerMask)
        {
            int hitCount = Physics.RaycastNonAlloc(worldPosition, direction, Hits, maxDistance, layerMask);

            for (int i = 0; i < hitCount; i++)
            {
                RaycastHit hit = Hits[i];

                if (hit.collider == null)
                    continue;

                Entity entity = _collisionRegistry.Get<Entity>(hit.collider.GetInstanceID());

                if (entity == null)
                    continue;

                return entity;
            }

            return null;
        }

        public Entity LineCast(Vector3 start, Vector3 end, float maxDistance, int layerMask)
        {
            int hitCount = Physics.RaycastNonAlloc(start, end - start, Hits, maxDistance, layerMask);

            for (int i = 0; i < hitCount; i++)
            {
                RaycastHit hit = Hits[i];

                if (hit.collider == null)
                    continue;

                Entity entity = _collisionRegistry.Get<Entity>(hit.collider.GetInstanceID());

                if (entity == null)
                    continue;

                return entity;
            }

            return null;
        }

        public IEnumerable<Entity> CircleCast(Vector3 position, float radius, int layerMask)
        {
            int hitCount = OverlapSphere(position, radius, OverlapHits, layerMask);
        
            DrawDebug(position, radius, 1f, Color.red);
        
            for (int i = 0; i < hitCount; i++)
            {
                Entity entity = _collisionRegistry.Get<Entity>(OverlapHits[i].GetInstanceID());
        
                if (entity == null)
                    continue;
        
                yield return entity;
            }
        }
        
        public int CircleCastNonAlloc(Vector3 position, float radius, int layerMask, Entity[] hitBuffer)
        {
            int hitCount = OverlapSphere(position, radius, OverlapHits, layerMask);
        
            DrawDebug(position, radius, 1f, Color.green);
        
            for (int i = 0; i < hitCount; i++)
            {
                Entity entity = _collisionRegistry.Get<Entity>(OverlapHits[i].GetInstanceID());
        
                if (entity == null)
                    continue;
        
                if (i < hitBuffer.Length)
                    hitBuffer[i] = entity;
            }
        
            return hitCount;
        }
        
        public int OverlapSphere(Vector3 worldPos, float radius, Collider[] hits, int layerMask) =>
            Physics.OverlapSphereNonAlloc(worldPos, radius, hits, layerMask);
        
        private static void DrawDebug(Vector3 worldPos, float radius, float seconds, Color color)
        {
            Debug.DrawRay(worldPos, radius * Vector3.up, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.down, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.left, color, seconds);
            Debug.DrawRay(worldPos, radius * Vector3.right, color, seconds);
        }
    }
}