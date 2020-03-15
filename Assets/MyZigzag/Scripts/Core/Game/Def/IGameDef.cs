using MyZigzag.Scripts.Core.BoardTile.Generator;
using MyZigzag.Scripts.Core.Loot.Generator;

namespace MyZigzag.Scripts.Core.Game.Def
{
    public interface IGameDef
    {
        #region IGameDef

        IBoardTileGenerator BoardTileGenerator { get; }

        ILootGenerator LootGenerator { get; }

        #endregion
    }
}