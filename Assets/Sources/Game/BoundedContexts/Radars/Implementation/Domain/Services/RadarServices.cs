using System;
using Sources.BoundedContexts.Overlaps.Interfaces.Services;
using Sources.BoundedContexts.Radars.Implementation.Domain.Models;

namespace Sources.BoundedContexts.Radars.Implementation.Domain.Services
{
    public class RadarServices
    {
        private readonly IOverlapService _overlapService;

        public RadarServices(IOverlapService overlapService)
        {
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
        }

        public object Scan(Radar model)
        {
            return _overlapService.SphereOverlap<object>(model.Position, model.Radius); // TODO: replace with the required type
        }
    }
}