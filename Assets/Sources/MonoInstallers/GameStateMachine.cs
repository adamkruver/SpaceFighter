using Sources.Game.Implementation.Infrastructure.StateMachines;
using Sources.Game.Interfaces.Infrastructure.Scenes;
using Sources.Game.Interfaces.Infrastructure.StateMachine;
using Zenject;

public class GameStateMachine : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IStateMachine<IScene>>().To<StateMachine<IScene>>().AsSingle();
    }
}
