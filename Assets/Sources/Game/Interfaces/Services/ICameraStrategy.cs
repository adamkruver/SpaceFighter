using System;
using Sources.Interfaces.Domain;

namespace Sources.Interfaces.Services.TargetFollowers
{
    public interface ICameraFollower
    {
        event Action<ITarget> TargetChanged; 
        void Follow(ITarget target);
    }
}