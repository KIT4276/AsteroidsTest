using UnityEngine;

namespace AsteroidsTest.Pause
{
    public class PausableRegistrator : MonoBehaviour
    {
        public void Initialize(Pauser pauser)
        {
    
            foreach( var monoBeh in GetComponentsInChildren<MonoBehaviour>() )
            {
                if( monoBeh is IPausable pausable)
                {
                    pauser.Register(pausable);
                }
            }
        }
    }
}
