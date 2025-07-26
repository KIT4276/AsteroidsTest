using AsteroidsTest.States;
using System.Collections;
using UnityEngine;
using Zenject;

namespace AsteroidsTest.Services
{
    public class EntryPoint : MonoBehaviour
    {
        [Inject] private readonly DiContainer _container;

        private void Start() =>
            StartCoroutine(WaitForStateMachine());

        private IEnumerator WaitForStateMachine()
        {
            while (_container.Resolve<StateMachine>() == null)
                Debug.Log("wait for StateMachine");

            _container.Resolve<StateMachine>().Initialize();

            yield return null;
        }
    }
}
