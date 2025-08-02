using UnityEngine;

namespace AsteroidsTest.Pause
{
    public class PausableRegistrator : MonoBehaviour
    {
        private Pauser _pauser;


        public void Initialize(Pauser pauser)
        {
            _pauser = pauser;

            foreach (var pausable in GetComponentsInChildren<IPausable>())
            {
                pauser.Register(pausable);
            }
        }

        public void Disable(Pauser pauser)
        {
            foreach (var pausable in GetComponentsInChildren<IPausable>())
            {
                pauser.Unregister(pausable);
            }
        }

        private void OnDestroy()
        {
            if( _pauser == null ) return;

            foreach (var pausable in GetComponentsInChildren<IPausable>())
            {
                _pauser.Unregister(pausable);
            }
        }
    }
}
