using Sources.Game.Implementation.Domain;

namespace Sources.Game.Interfaces.Services.Cameras
{
    public interface ITargetFollowerService
    {
        void Follow(Spaceship spaceship);
    }
}