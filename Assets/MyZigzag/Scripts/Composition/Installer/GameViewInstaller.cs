using MyZigzag.Scripts.Core.BoardTile.Creator;
using MyZigzag.Scripts.Core.BoardTile.Remover;
using MyZigzag.Scripts.Core.Loot.Creator;
using MyZigzag.Scripts.Core.Loot.Remover;
using MyZigzag.Scripts.Display.BoardTile.Model;
using MyZigzag.Scripts.Display.BoardTile.Pool;
using MyZigzag.Scripts.Display.BoardTile.View;
using MyZigzag.Scripts.Display.CameraWatcher;
using MyZigzag.Scripts.Display.Game;
using MyZigzag.Scripts.Display.Loot.Model;
using MyZigzag.Scripts.Display.Loot.Pool;
using MyZigzag.Scripts.Display.Loot.View;
using MyZigzag.Scripts.Display.Player;
using MyZigzag.Scripts.Main.Decorator;
using MyZigzag.Scripts.Main.Decorator.Remover;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;
using Zenject;

namespace MyZigzag.Scripts.Composition.Installer
{
    [DisallowMultipleComponent]
    public sealed class GameViewInstaller : MonoInstaller
    {
        #region GameViewInstaller

        [SerializeField]
        private GameView _gameView;

        [SerializeField]
        private PlayerBallView _playerBallView;

        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private GameObject _boardTilePrefab;

        [SerializeField]
        private GameObject _crystalLootPrefab;

        [SerializeField]
        private Transform _poolParent;

        private void Awake()
        {
            _gameView.CheckNull();
            _playerBallView.CheckNull();
            _camera.CheckNull();
            _boardTilePrefab.CheckNull();
            _crystalLootPrefab.CheckNull();
            _poolParent.CheckNull();
        }

        private void InstallPlayer()
        {
            Container.Bind<IPlayerBallView>().FromInstance(_playerBallView).AsSingle().NonLazy();
            Container.Bind<ILateTickable>().To<CameraWatcher>().AsSingle()
                .WithArguments(_camera, _playerBallView)
                .NonLazy();

            Container.Bind<IGameView>().FromInstance(_gameView).AsSingle().NonLazy();
        }

        private void InstallPools()
        {
            Container.BindMemoryPoolCustomInterface<BoardTileView, BoardTileViewPool, IBoardTileViewPool>()
                .WithInitialSize(20)
                .FromComponentInNewPrefab(_boardTilePrefab)
                .UnderTransform(_poolParent)
                .AsCached()
                .NonLazy();

            Container.BindMemoryPoolCustomInterface<LootView, LootViewPool, ILootViewPool>()
                .WithInitialSize(5)
                .FromComponentInNewPrefab(_crystalLootPrefab)
                .UnderTransform(_poolParent)
                .AsCached()
                .NonLazy();
        }

        private void InstallDecorators()
        {
            Container.Decorate<IBoardTileCreator>().With<BoardTileCreatorDecorator>().AsSingle().NonLazy();
            Container.Decorate<ILootCreator>().With<LootCreatorDecorator>().AsSingle().NonLazy();
            Container.Decorate<IBoardTileRemover>().With<BoardTileRemoverDecorator>().AsSingle().NonLazy();
            Container.Decorate<ILootRemover>().With<LootRemoverDecorator>().AsSingle().NonLazy();
        }

        private void InstallModels()
        {
            Container.Bind<IBoardTileViewModel>().To<BoardTileViewModel>().AsSingle().NonLazy();
            Container.Bind<ILootViewModel>().To<LootViewModel>().AsSingle().NonLazy();
        }

        #endregion

        #region MonoInstaller

        public override void InstallBindings()
        {
            InstallPlayer();
            InstallPools();
            InstallDecorators();
            InstallModels();
        }

        #endregion
    }
}