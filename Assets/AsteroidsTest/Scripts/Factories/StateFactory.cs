using AsteroidsTest.States;
using Zenject;

namespace AsteroidsTest.Factories
{
    public class StateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container) =>
          _container = container;

        public T CreateState<T>() where T : IExitableState
        {
            return _container.Resolve<T>();
        }
    }
}
