using AsteroidsTest.SOScripts;
using UnityEngine;

namespace AsteroidsTest
{
    public interface IMove
    {
    
        public void Initialize(Transform transform, BaseFactory factory, GameStaticData gameStaticData);
    
    
        public void StopMove();
    }
}
