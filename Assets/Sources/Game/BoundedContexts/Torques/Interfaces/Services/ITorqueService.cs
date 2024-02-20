using Sources.BoundedContexts.Torques.Interfaces.Domain;

namespace Sources.BoundedContexts.Torques.Interfaces.Services
{
    public interface ITorqueService
    {
        void UpdateTorqueWithSlerp(IPhysicsTorque torque, float deltaTime);
    }
}