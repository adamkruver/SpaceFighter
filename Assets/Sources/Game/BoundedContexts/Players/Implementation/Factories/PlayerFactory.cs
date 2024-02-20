using Sources.BoundedContexts.Players.Implementation.Models;
using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using Sources.BoundedContexts.Weapons.Implementation.Domain.Models;

namespace Sources.BoundedContexts.Players.Implementation.Factories
{
    public class PlayerFactory
    {
        public Player Create()
        {
            Player player = new Player();
            player.Spaceship = new Spaceship();
            player.Spaceship.Weapon = new Weapon();
            
            return player;
        }
    }
}