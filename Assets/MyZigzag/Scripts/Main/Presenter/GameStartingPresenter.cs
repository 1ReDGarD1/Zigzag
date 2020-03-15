using MyZigzag.Scripts.Core.Game.Model;
using MyZigzag.Scripts.Core.Game.Observer.Components;
using MyZigzag.Scripts.Core.Player.Entity;
using MyZigzag.Scripts.Display.Player;
using MyZigzag.Scripts.Utility.Common;

namespace MyZigzag.Scripts.Main.Presenter
{
    public class GameStartingPresenter : IGameComponentStarting
    {
        #region GameStartingPresenter

        private const int TileSize = 1;
        private const float TileY = -2f;

        private readonly IPlayerBallEntity PlayerBallEntity;
        private readonly IPlayerBallView PlayerBallView;
        private readonly IGameModel GameModel;

        public GameStartingPresenter(IPlayerBallEntity playerBallEntity, 
            IPlayerBallView playerBallView, 
            IGameModel gameModel)
        {
            PlayerBallEntity = playerBallEntity.CheckNull();
            PlayerBallView = playerBallView.CheckNull();
            GameModel = gameModel.CheckNull();
        }

        #endregion

        #region IGameComponentStarting

        public void GameStarting()
        {
            var boardTileGenerator = GameModel.BoardTileGenerator;

            var lootGenerator = GameModel.LootGenerator;
            lootGenerator.Activate(boardTileGenerator);

            boardTileGenerator.InitialBuild(TileSize, TileY);

            PlayerBallEntity.Initializable(GameModel.PlayerBallDef);
            PlayerBallView.Initializable(PlayerBallEntity, -TileSize);
        }
        
        #endregion
    }
}