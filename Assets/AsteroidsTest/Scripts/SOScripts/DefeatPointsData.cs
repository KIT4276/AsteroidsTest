using UnityEngine;

namespace AsteroidsTest.SOScripts
{
    [CreateAssetMenu(fileName = "DefeatPointsData", menuName = "ScriptableObjects/DefeatPointsData", order = 2)]
    
    public class DefeatPointsData : ScriptableObject
    {
        [SerializeField] private int _asteroidPoints = 3;
        [SerializeField] private int _fragmentPoints = 1;
        [SerializeField] private int _ufoPoints = 5;
    
        public int AsteroidPoints => _asteroidPoints;
        public int FragmentPoints => _fragmentPoints;
        public int UFOPoints => _ufoPoints;
    
    }
}
