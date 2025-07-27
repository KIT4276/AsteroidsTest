using AsteroidsTest.States;
using Zenject;

namespace AsteroidsTest.Installers
{

    public class StateMachinenstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BootstrapState>()
                .AsSingle();
            Container.Bind<LoadProgressState>()
                .AsSingle();
            Container.Bind<LoadLevelState>()
                .AsSingle();
            Container.Bind<GameLoopState>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<StateMachine>()
                .AsSingle();
        }
    }
}