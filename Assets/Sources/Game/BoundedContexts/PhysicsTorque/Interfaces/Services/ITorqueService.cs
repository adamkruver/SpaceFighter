using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Domain;

namespace Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Services
{
    public interface ITorqueService
    {
        void UpdateTorque(IPhysicsTorque torque, float deltaTime);
    }
}