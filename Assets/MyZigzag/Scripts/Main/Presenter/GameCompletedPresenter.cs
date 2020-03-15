using System.Collections.Generic;
using MyZigzag.Scripts.Core.BoardTile.Model;
using MyZigzag.Scripts.Core.BoardTile.Remover;
using MyZigzag.Scripts.Core.Foundation.Remover;
using MyZigzag.Scripts.Core.Game.Model;
using MyZigzag.Scripts.Core.Game.Observer.Components;
using MyZigzag.Scripts.Core.Loot.Model;
using MyZigzag.Scripts.Core.Loot.Remover;
using MyZigzag.Scripts.Display.Player;
using MyZigzag.Scripts.Utility.Common;

namespace MyZigzag.Scripts.Main.Presenter
{
    public sealed class GameCompletedPresenter : IGameComponentCompleted
    {
        #region GameCompletedPresenter

        private readonly IBoardTileModel BoardTileModel;
        private readonly IBoardTileRemover BoardTileRemover;

        private readonly ILootModel LootModel;
        private readonly ILootRemover LootRemover;

        private readonly IGameModel GameModel;
        private readonly IPlayerBallView PlayerBallView;

        public GameCompletedPresenter(IBoardTileModel boardTileModel,
            IBoardTileRemover boardTileRemover,
            ILootModel lootModel,
            ILootRemover lootRemover, 
            IGameModel gameModel,
            IPlayerBallView playerBallView)
        {
            BoardTileModel = boardTileModel.CheckNull();
            BoardTileRemover = boardTileRemover.CheckNull();
            LootModel = lootModel.CheckNull();
            LootRemover = lootRemover.CheckNull();
            GameModel = gameModel.CheckNull();
            PlayerBallView = playerBallView.CheckNull();
        }

        private void RemovedEntities<T>(IList<T> entities, IEntityRemover<T> entityRemover)
        {
            for (var i = entities.Count - 1; i >= 0; i--)
            {
                var entity = entities[i];
                entityRemover.RemoveEntity(entity);
            }
        }

        #endregion

        #region IGameComponentCompleted

        public void GameComplete()
        {
            RemovedEntities(BoardTileModel.Entities, BoardTileRemover);
            RemovedEntities(LootModel.Entities, LootRemover);
            
            GameModel.LootGenerator.Deactivate();
            
            PlayerBallView.Reset();
        }

        #endregion
    }
}