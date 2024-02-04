using Sources.BoundedContexts.PhysicsTorque.Interfaces.Domain;

namespace Sources.BoundedContexts.PhysicsTorque.Interfaces.Services
{
    public interface ITorqueService
    {
        void UpdateTorque(IPhysicsTorque torque, float deltaTime);
    }
}