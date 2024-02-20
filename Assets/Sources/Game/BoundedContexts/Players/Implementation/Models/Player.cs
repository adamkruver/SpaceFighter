using Sources.BoundedContexts.Players.Interfaces.Models;
using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using Sources.Common.Mvp.Implementation.Models;

namespace Sources.BoundedContexts.Players.Implementation.Models
{
	public class Player : ObservableModel
	{
		private Spaceship _spaceship;
		private IPlayerState _state;

		public Spaceship Spaceship 
		{
			get => _spaceship;
			set => TrySetField(ref _spaceship, value);
		}
		
		public IPlayerState State
		{
			get => _state;
			set => TrySetField(ref _state, value);
		}
	}
}