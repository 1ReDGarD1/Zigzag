using MyZigzag.Scripts.Core.BoardTile.Generator;
using MyZigzag.Scripts.Core.Loot.Generator;
using MyZigzag.Scripts.Core.Player.Def;

namespace MyZigzag.Scripts.Core.Game.Model
{
    public interface IGameModel
    {
        #region IGameModel

        IPlayerBallDef PlayerBallDef { get; }
        
        ILootGenerator LootGenerator { get; }

        IBoardTileGenerator BoardTileGenerator { get; }

        #endregion
    }
}