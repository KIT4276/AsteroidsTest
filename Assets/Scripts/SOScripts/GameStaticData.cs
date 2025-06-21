using UnityEngine;

[CreateAssetMenu(fileName = "GameStaticData", menuName = "ScriptableObjects/GameStaticData", order = 1)]
public class GameStaticData : ScriptableObject
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _asteroidPrefab;
    [SerializeField] private GameObject _fragmentPrefab;
    [SerializeField] private GameObject _ufoPrefab;
    [SerializeField] private GameObject _bulletPrefab;

    [Header("Asteroids Data")]
    [SerializeField] private float _spawnPosLimit = 35;
    [SerializeField] private Vector2 _screenLimits = new Vector2(11.2f, 5.25f);
    [SerializeField] private float _spawnTime = 1;
    [SerializeField] private int _startCount = 15;
    [Header("Fragments Data")]
    [SerializeField] private int _fragmentsCount = 5;


    public GameObject AsteroidPrefab => _asteroidPrefab;
    public GameObject FragmentPrefab => _fragmentPrefab;
    public GameObject UFOPrefab => _ufoPrefab;
    public GameObject BulletPrefab => _bulletPrefab;

    public float AsteroidsSpawnPosLimit => _spawnPosLimit;
    public Vector2 AsteroidsScreenLimits => _screenLimits;
    public float AsteroidsSpawnTime => _spawnTime;
    public int AsteroidsStartCount => _startCount;

    public int FragmentsCount => _fragmentsCount;



}
