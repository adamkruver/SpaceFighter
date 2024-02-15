using System;
using Sources.BoundedContexts.Overlaps.Implementation.Services.Decorators;
using Sources.BoundedContexts.Overlaps.Interfaces.Services;
using Sources.BoundedContexts.Radars.Implementation.Domain.Models;
using Sources.BoundedContexts.Radars.Implementation.Presenter;
using Sources.BoundedContexts.Radars.Interfaces;

namespace Sources.BoundedContexts.Radars.Implementation.Factories
{
    public class RadarPresenterFactory
    {
        private readonly IOverlapService _overlapService;

        public RadarPresenterFactory(IOverlapService overlapService)
        {
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
        }

        public RadarPresenter Create(Radar model,  IRadarView view, int layerMask) =>
            new RadarPresenter(model,view, new MaskedOverlapServices(_overlapService, layerMask));
    }
}