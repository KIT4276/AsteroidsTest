using UnityEngine;

namespace AsteroidsTest.Pause
{
    public class PausableRegistrator : MonoBehaviour
    {
        public void Initialize(Pauser pauser)
        {
    
            foreach( var monoMeh in GetComponentsInChildren<MonoBehaviour>() )
            {
                if( monoMeh is IPausable pausable)
                {
                    pauser.Register(pausable);
                }
            }
        }
    }
}
