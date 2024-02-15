using System;
using Sources.BoundedContexts.Overlaps.Interfaces;
using Sources.BoundedContexts.Overlaps.Interfaces.Services;
using Sources.BoundedContexts.Radars.Implementation.Domain.Models;
using Sources.BoundedContexts.Radars.Interfaces;
using Sources.Common.Mvp.Implememntation.Presenters;

namespace Sources.BoundedContexts.Radars.Implementation.Presenter
{
    public class RadarPresenter : PresenterBase
    {
        private readonly IRadarView _view;
        private readonly IOverlapService _overlapService;
        private readonly Radar _model;

        public RadarPresenter(Radar model, IRadarView view, IOverlapService overlapService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
            _model = model ?? throw new ArgumentNullException(nameof(model));
        }
        
        
    }
}