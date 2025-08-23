using AsteroidsTest.Input;
using AsteroidsTest.States;
using System;
using UnityEngine;
using Zenject;

namespace AsteroidsTest.Weapon.Bullet
{
    public class ShootingBullets : MonoBehaviour
    {
        [SerializeField] private Transform _gunBarrel;

        private BulletsFactory _bulletsFactory;
        private BaseInputHandler _inputHandler;
        private StateMachine _stateMachine;
        private bool _isGameLoop;
        private bool _initialized = false;

        [Inject]
        private void Construct(BaseInputHandler inputHandler, BulletsFactory bulletsFactory, StateMachine stateMachine)
        {
            if (_initialized) return;

            _bulletsFactory = bulletsFactory;
            _inputHandler = inputHandler;
            _stateMachine = stateMachine;

            if (_inputHandler != null)
            {
                _inputHandler.BulletFireAction += BulletFire;
            }

            _stateMachine.StateChanged += OnStateChange;
            _initialized = true;
        }

        private void OnStateChange(IExitableState state)
        {
            if(state is GameLoopState)
            {
                _isGameLoop = true; 
            }
            else
            {
                _isGameLoop = false;    
            }
        }

        private void BulletFire()
        {

            if (!_initialized || _gunBarrel == null || !_isGameLoop) return;

            _bulletsFactory?.Spawn(_gunBarrel);
        }

        private void OnDestroy()
        {
            if (!_initialized) return;

            if (_inputHandler != null && !ReferenceEquals(_inputHandler, null))
            {
                _inputHandler.BulletFireAction -= BulletFire;
                _stateMachine.StateChanged -= OnStateChange;
            }
        }
    }
}
