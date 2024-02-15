using System;
using System.ComponentModel;
using Sources.BoundedContexts.Players.Implementation.Models;
using Sources.BoundedContexts.Players.Interfaces.Views;
using Sources.Common.Mvp.Implememntation.Presenters;
using Sources.Common.StateMachines.Implementation.Contexts;
using Sources.Common.StateMachines.Interfaces.Contexts;
using Sources.Common.StateMachines.Interfaces.Handlers;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Players.Implementation.Presenters
{
    public class PlayerPresenter : PresenterBase
    {
        private readonly Player _player;
        private readonly IPlayerView _view;
        private readonly IUpdateService _updateService;
        private readonly IContextStateMachine _stateMachine;
        private readonly IUpdateHandler _updateHandler;

        public PlayerPresenter(
            Player player,
            IPlayerView view,
            IUpdateService updateService,
            IContextStateMachine stateMachine,
            IUpdateHandler updateHandler
        )
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));
            _updateHandler = updateHandler ?? throw new ArgumentNullException(nameof(updateHandler));
        }

        public override void Enable()
        {
            _player.PropertyChanged += OnModelPropertyChanged;
            _stateMachine.Run();
            _updateService.Updated += _updateHandler.Update;
        }

        public override void Disable()
        {
            _updateService.Updated -= _updateHandler.Update;
            _stateMachine.Stop();
            _player.PropertyChanged -= OnModelPropertyChanged;
        }

        private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is not Player)
                return;

            Action action = e.PropertyName switch
            {
                nameof(Player.State) => OnPlayerStateChanged,
                _ => null
            };

            action?.Invoke();
        }

        private void OnPlayerStateChanged() =>
            _stateMachine.Apply(Context.Create(_player.State));
    }
}