using AsteroidsTest.Services;
using UnityEngine;

namespace AsteroidsTest.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly StateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        private GameObject _playerObj;

        public LoadLevelState(StateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            //_curtain = curtain;
            //_gameFactory = gameFactory;
            //_input = input;
            //_progressService = progressService;
            //_addresses = addresses;
            //_parcelGenerator = parcelGenerator;
            //_counter = counter;
            //_maintenanceEC = maintenanceEC;
            //_maintenanceAC = maintenanceAC;
            //_salary = salary;
        }

        public void Enter(string sceneName)
        {
            //_curtain.Show();
            //TODO _gameFactory.CleanUp();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() { }

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {
            //foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
            //    progressReader.LoadProgress(_progressService.Progress);

            //TODO
        }

        private void InitGameWorld()
        {
            _playerObj = InitPlayer();
            InitSpawners();
        }

       

        private void InitSpawners()
        {
           //todo
        }

        private void Init(string tag)
        {
            foreach (GameObject spawnerObject in GameObject.FindGameObjectsWithTag(tag))
            {
                //var spawner = spawnerObject.GetComponent<Spawner>();
                //_gameFactory.Register(spawner);
            }
        }

        private GameObject InitPlayer()
        {
            //TODO
            return null;
        }
    }
}
