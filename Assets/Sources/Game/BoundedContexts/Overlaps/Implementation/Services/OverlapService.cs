using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sources.BoundedContexts.Overlaps.Interfaces.Services;
using UnityEngine;

namespace Sources.BoundedContexts.Overlaps.Implementation.Services
{
    public class OverlapService : IOverlapService
    {
        private readonly Collider[] _colliders = new Collider[100];
        
        public IEnumerable<T> SphereOverlap<T>(Vector3 position, float radius, int layerMask)
        {
          int count =  Physics.OverlapSphereNonAlloc(position, radius, _colliders, layerMask);
         
          return Filter<T>(_colliders, count);
        }

        public IEnumerable<T> SphereOverlap<T>(Vector3 position, float radius) =>
            SphereOverlap<T>(position, radius, Physics.DefaultRaycastLayers);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static IEnumerable<T> Filter<T>(Collider[] colliders,int count)
        {
            List<T> components = new List<T>(count);

            for (int i = 0; i < count; i++)
            {
                if(colliders[i].TryGetComponent(out T component))
                    components.Add(component);
            }

            return components;
        }
    }
}