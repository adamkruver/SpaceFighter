using System;
using System.Collections.Generic;
using Sources.BoundedContexts.Overlaps.Interfaces.Services;
using UnityEngine;

namespace Sources.BoundedContexts.Overlaps.Implementation.Services.Decorators
{
    public class MaskedOverlapServices : IOverlapService
    {
        private readonly IOverlapService _overlapService;
        private readonly int _layerMask;

        public MaskedOverlapServices(IOverlapService overlapService, int layerMask)
        {
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
            _layerMask = layerMask;
        }

        public IEnumerable<T> SphereOverlap<T>(Vector3 position, float radius, int layerMask) => 
            _overlapService.SphereOverlap<T>(position, radius, _layerMask);

        public IEnumerable<T> SphereOverlap<T>(Vector3 position, float radius) =>
            SphereOverlap<T>(position, radius, Physics.DefaultRaycastLayers);
    }
}