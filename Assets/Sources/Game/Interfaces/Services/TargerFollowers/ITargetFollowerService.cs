using Sources.Game.Implementation.Domain;

namespace Sources.Game.Interfaces.Services.TargerFollowers
{
    public interface ITargetFollowerService
    {
        void Follow(Spaceship spaceship);
    }
}