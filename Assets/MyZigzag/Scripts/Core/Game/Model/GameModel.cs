using MyZigzag.Scripts.Core.BoardTile.Generator;
using MyZigzag.Scripts.Core.Game.Def;
using MyZigzag.Scripts.Core.Game.Observer.Components;
using MyZigzag.Scripts.Core.Game.Observer.Configurator;
using MyZigzag.Scripts.Core.Loot.Generator;
using MyZigzag.Scripts.Core.Player.Def;

namespace MyZigzag.Scripts.Core.Game.Model
{
    public sealed class GameModel : IGameModel, IGameComponentInitializable
    {
        #region GameModel

        private IGameDef _gameDef;

        #endregion

        #region IGameModel

        public IPlayerBallDef PlayerBallDef { get; private set; }

        public ILootGenerator LootGenerator => _gameDef.LootGenerator;
        public IBoardTileGenerator BoardTileGenerator => _gameDef.BoardTileGenerator;

        #endregion

        #region IGameComponentInitializable

        public void GameInitialize(IGameConfigurator configurator)
        {
            _gameDef = configurator.GameDef;
            PlayerBallDef = configurator.PlayerBallDef;
        }

        #endregion
    }
}