using UnityEngine;

namespace AsteroidsTest.Pause
{
    public class PausableRegistrator : MonoBehaviour
    {
        public void Initialize(Pauser pauser)
        {
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
    }
}
