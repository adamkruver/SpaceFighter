using System;
using Sources.BoundedContexts.Assets.Implementation;
using Sources.BoundedContexts.Radars.Implementation.Domain.Models;
using Sources.BoundedContexts.Radars.Interfaces;
using Object = UnityEngine.Object;

namespace Sources.BoundedContexts.Radars.Implementation.Factories
{
    public class RadarViewFactory
    {
        private readonly UiAssetProvider _provider;
        private readonly RadarPresenterFactory _radarPresenterFactory;

        public RadarViewFactory(UiAssetProvider provider, RadarPresenterFactory radarPresenterFactory)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _radarPresenterFactory = radarPresenterFactory ?? throw new ArgumentNullException(nameof(radarPresenterFactory));
        }

        public IRadarView Create(Radar model)
        {
            var view = Object.Instantiate(_provider.Radar);
            var presenter = _radarPresenterFactory.Create(model, view, view.LayerMask);
            view.Construct(presenter);
            
            return view;
        }
    }
}