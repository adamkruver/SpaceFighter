using System;
using Sources.Game.Interfaces.Domain;

namespace Sources.Game.Interfaces.Services.TargetFollowers
{
    public interface ICameraFollower
    {
        event Action<ITarget> TargetChanged; 
        void Follow(ITarget target);
    }
}