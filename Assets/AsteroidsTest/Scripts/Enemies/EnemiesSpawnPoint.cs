using UnityEngine;

public class EnemiesSpawnPoint : MonoBehaviour
{
    private void Awake()
    {
        this.transform.SetParent(null);
        DontDestroyOnLoad(this.gameObject);
    }
}
