using AsteroidsTest.Enemies.Asteroids;
using AsteroidsTest.UI;
using UnityEngine;
using Zenject;

namespace AsteroidsTest.Ship
{
    public class ShipCollision : MonoBehaviour, IDamageable
    {
        private GameOverModel _gameOverModel;
    
        [Inject]
        private void PseudoConstruct(GameOverModel gameOverModel)
        {
            _gameOverModel = gameOverModel;
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
            _gameOverModel.GameOver();
        }
    }
}
