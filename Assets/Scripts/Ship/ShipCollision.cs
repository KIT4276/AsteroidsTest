using AsteroidsTest.Enemies.Asteroids;
using UnityEngine;
using Zenject;

namespace AsteroidsTest.Ship
{
    public class ShipCollision : MonoBehaviour, IDamageable
    {
        private GameOver _gameOver;
    
        [Inject]
        private void PseudoConstruct(GameOver gameOver)
        {
            _gameOver = gameOver;
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<BaseEnemyCollision>(out var enemy))
            {
                TakeDamage();
            }
        }
    
        public void TakeDamage()
        {
            _gameOver.OnGameOver();
        }
    }
}
