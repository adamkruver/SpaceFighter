using System;
using Sources.Game.Implementation.Controllers;
using Sources.Game.Interfaces.Controllers;
using Sources.Game.Interfaces.Presentation.Views;
using UnityEngine;

namespace Sources.Game.Implementation.Presentation.Views
{
    public class SpaceshipView : MonoBehaviour, ISpaceshipView
    {
        [field: SerializeField] public PhysicsMovementSystem PhysicsMovementSystem { get; private set; }
        
        private SpaceshipPresenter _presenter;

        private void OnEnable() => 
            _presenter?.Enable();

        private void OnDisable() => 
            _presenter?.Disable();

        public void Construct(SpaceshipPresenter presenter)
        {
            if (presenter == null) 
                throw new ArgumentNullException(nameof(presenter));
            
            Hide();
            _presenter = presenter;
            Show();
        }

        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() => 
            gameObject.SetActive(false);
    }
}