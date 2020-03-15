using MyZigzag.Scripts.Core.BoardTile.Generator;

namespace MyZigzag.Scripts.Core.Loot.Generator
{
    public interface ILootGenerator
    {
        #region ILootGenerator

        void Activate(IBoardTileGenerator boardTileGenerator);
        void Deactivate();

        #endregion
    }
}