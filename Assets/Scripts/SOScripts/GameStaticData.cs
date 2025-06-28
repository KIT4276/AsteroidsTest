using UnityEngine;

[CreateAssetMenu(fileName = "GameStaticData", menuName = "ScriptableObjects/GameStaticData", order = 1)]
public class GameStaticData : ScriptableObject
{
    [Header("Prefabs")]
    [SerializeField] private readonly GameObject _asteroidPrefab;
    [SerializeField] private readonly GameObject _fragmentPrefab;
    [SerializeField] private readonly GameObject _ufoPrefab;
    [SerializeField] private readonly GameObject _bulletPrefab;

    [Header("Asteroids and UFO Data")]
    [SerializeField] private float _spawnPosLimit = 18;
    [SerializeField] private Vector2 _screenLimits = new Vector2(11.2f, 5.25f);
    [Header("Asteroids Data")]
    [SerializeField] private float _spawnTimeAster = 1;
    [SerializeField] private int _startCountAster = 15;
    [Header("UFO Data")]
    [SerializeField] private float _spawnTimeUFO = 3;
    [Header("Fragments Data")]
    [SerializeField] private int _fragmentsCount = 5;
    [Header("For all IMove")]
    [SerializeField] private float _moveLimits = 35;


    public GameObject AsteroidPrefab => _asteroidPrefab;
    public GameObject FragmentPrefab => _fragmentPrefab;
    public GameObject UFOPrefab => _ufoPrefab;
    public GameObject BulletPrefab => _bulletPrefab;

    public float SpawnPosLimit => _spawnPosLimit;
    public Vector2 ScreenLimits => _screenLimits;

    public float AsteroidsSpawnTime => _spawnTimeAster;
    public int AsteroidsStartCount => _startCountAster;

    public float UFOSpawnTime => _spawnTimeUFO;
    public int FragmentsCount => _fragmentsCount;
    public float MoveLimits => _moveLimits;

}

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