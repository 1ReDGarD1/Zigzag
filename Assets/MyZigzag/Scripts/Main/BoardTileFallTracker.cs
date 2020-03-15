using MyZigzag.Scripts.Core.BoardTile.Creator;
using MyZigzag.Scripts.Core.BoardTile.Entity;
using MyZigzag.Scripts.Core.BoardTile.Model;
using MyZigzag.Scripts.Core.BoardTile.Remover;
using MyZigzag.Scripts.Core.Game.Observer.Components;
using MyZigzag.Scripts.Core.Game.Observer.Configurator;
using MyZigzag.Scripts.Display.Player;
using MyZigzag.Scripts.Utility.Common;
using Zenject;

namespace MyZigzag.Scripts.Main
{
    public sealed class BoardTileFallTracker : IFixedTickable, IGameComponentInitializable, IGameComponentCompleted
    {
        #region BoardTileFallTracker

        private readonly IBoardTileModel BoardTileModel;
        private readonly IPlayerBallView PlayerBallView;
        private readonly IBoardTileRemover BoardTileRemover;
        private readonly IBoardTileCreator BoardTileCreator;

        public BoardTileFallTracker(IBoardTileModel boardTileModel, 
            IPlayerBallView playerBallView,
            IBoardTileRemover boardTileRemover, 
            IBoardTileCreator boardTileCreator)
        {
            BoardTileModel = boardTileModel.CheckNull();
            PlayerBallView = playerBallView.CheckNull();
            BoardTileRemover = boardTileRemover.CheckNull();
            BoardTileCreator = boardTileCreator.CheckNull();
        }

        private void OnEndFallingHandler(object sender, IBoardTileEntity boardTile)
        {
            boardTile.OnEndFalling -= OnEndFallingHandler;
            BoardTileRemover.RemoveEntity(boardTile);
        }

        private void OnCreatedHandler(object sender, IBoardTileEntity boardTile)
        {
            boardTile.OnEndFalling += OnEndFallingHandler;
        }

        #endregion

        #region IFixedTickable

        public void FixedTick()
        {
            var playerPositionZ = PlayerBallView.Position.z;
            foreach (var boardTile in BoardTileModel.Entities)
            {
                if (boardTile.IsFalling)
                {
                    continue;
                }

                if (playerPositionZ > boardTile.Position.z + 1f)
                {
                    boardTile.StartFall();
                }
            }
        }

        #endregion

        #region IGameComponentInitializable

        public void GameInitialize(IGameConfigurator configurator)
        {
            BoardTileCreator.OnCreated += OnCreatedHandler;
        }

        #endregion

        #region IGameComponentCompleted

        public void GameComplete()
        {
            BoardTileCreator.OnCreated -= OnCreatedHandler;
        }

        #endregion
    }
}