using UnityEngine;

namespace AsteroidsTest.Pause
{
    public class PausableRegistrator : MonoBehaviour
    {
        public void Initialize(Pauser pauser)
        {
            foreach( var pausable in GetComponentsInChildren<IPausable>() )
            {
                //if( monoBeh is IPausable pausable)
                //{
                    pauser.Register(pausable);
                //}
            }
        }
    }
}
