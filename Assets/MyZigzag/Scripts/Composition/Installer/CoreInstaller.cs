using MyZigzag.Scripts.Core.BoardTile.Creator;
using MyZigzag.Scripts.Core.BoardTile.Model;
using MyZigzag.Scripts.Core.BoardTile.Remover;
using MyZigzag.Scripts.Core.Game;
using MyZigzag.Scripts.Core.Game.Model;
using MyZigzag.Scripts.Core.Game.Observer;
using MyZigzag.Scripts.Core.Game.Observer.Components;
using MyZigzag.Scripts.Core.Loot;
using MyZigzag.Scripts.Core.Loot.Creator;
using MyZigzag.Scripts.Core.Loot.Model;
using MyZigzag.Scripts.Core.Loot.Remover;
using MyZigzag.Scripts.Core.Loot.Storage;
using MyZigzag.Scripts.Core.Player.Entity;
using MyZigzag.Scripts.Main;
using MyZigzag.Scripts.Main.Presenter;
using Zenject;

namespace MyZigzag.Scripts.Composition.Installer
{
    public sealed class CoreInstaller : Installer<CoreInstaller>
    {
        #region CoreInstaller

        private void InstallModels()
        {
            Container.Bind<IBoardTileModel>().To<BoardTileModel>().AsSingle().NonLazy();
            Container.Bind<ILootModel>().To<LootModel>().AsSingle().NonLazy();
            Container.Bind(typeof(IGameModel), typeof(IGameComponentInitializable)).To<GameModel>().AsSingle()
                .NonLazy();
        }

        private void InstallCreators()
        {
            Container.Bind<IBoardTileCreator>().To<BoardTileCreator>().AsSingle().NonLazy();
            Container.Bind<ILootCreator>().To<LootCreator>().AsSingle().NonLazy();
        }

        private void InstallGameEntities()
        {
            Container.Bind<IGameStatusObserver>().To<GameStatusObserver>().AsSingle().NonLazy();
            Container.Bind(typeof(ITickable)).To<PlayerBallFallTracker>().AsSingle().NonLazy();
            Container.Bind(typeof(IFixedTickable), typeof(IGameComponentInitializable), typeof(IGameComponentCompleted))
                .To<BoardTileFallTracker>().AsSingle().NonLazy();
            Container.Bind(typeof(ITickable)).To<KeyboardControl>().AsSingle().NonLazy();

            Container.Bind<IPlayerBallEntity>().To<PlayerBallEntity>().AsSingle().NonLazy();

            Container.Bind(typeof(ITickable), typeof(IGameComponentInitializable), typeof(IGameComponentStarting),
                typeof(IGameComponentCompleted)).To<GameTickable>().AsSingle().NonLazy();

            Container.Bind<ICrystalLootStorage>().To<CrystalLootStorage>().AsSingle().NonLazy();

            Container.Bind<IBoardTileRemover>().To<BoardTileRemover>().AsSingle().NonLazy();
            Container.Bind<ILootRemover>().To<LootRemover>().AsSingle().NonLazy();

            Container.Bind(typeof(IGameComponentInitializable), typeof(IGameComponentCompleted)).To<LootPickUpTracker>()
                .AsSingle().NonLazy();
        }

        private void InstallPresenters()
        {
            Container.Bind<IGameComponentStarting>().To<GameStartingPresenter>().AsSingle().NonLazy();
            Container.Bind<IGameComponentCompleted>().To<GameCompletedPresenter>().AsSingle().NonLazy();
        }

        #endregion

        #region MonoInstaller

        public override void InstallBindings()
        {
            InstallModels();
            InstallCreators();
            InstallGameEntities();
            InstallPresenters();
        }

        #endregion
    }
}