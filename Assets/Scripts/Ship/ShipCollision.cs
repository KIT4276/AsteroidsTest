using UnityEngine;
using Zenject;

public class ShipCollision : MonoBehaviour
{
    private GameOver _gameOver;

    [Inject]
    private void PseudoConstruct(GameOver gameOver)
    {
        _gameOver = gameOver;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<BaseEnemyCollision>(out var enemy))
        {
            _gameOver.OnGameOver();
        }
    }
}
