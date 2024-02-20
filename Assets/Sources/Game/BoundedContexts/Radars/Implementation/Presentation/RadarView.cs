using Sources.BoundedContexts.Radars.Implementation.Presenter;
using Sources.BoundedContexts.Radars.Interfaces;
using Sources.Common.Mvp.Implementation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.Radars.Implementation.Presentation
{
    public class RadarView : PresentableView<RadarPresenter>, IRadarView
    {
        [SerializeField] private LayerMask _layerMask;
        
        public int LayerMask => _layerMask.value;
        
    }
}