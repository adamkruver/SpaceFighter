using System.Collections.Generic;
using UnityEngine;

namespace Sources.BoundedContexts.Overlaps.Interfaces.Services
{
    public interface IOverlapService
    {
        IEnumerable<T> SphereOverlap<T>(Vector3 position, float radius, int layerMask);
        IEnumerable<T> SphereOverlap<T>(Vector3 position, float radius);
        
    }
}