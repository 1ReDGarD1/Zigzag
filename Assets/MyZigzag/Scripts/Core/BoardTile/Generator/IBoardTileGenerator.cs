using System;
using MyZigzag.Scripts.Core.BoardTile.Entity;

namespace MyZigzag.Scripts.Core.BoardTile.Generator
{
    public interface IBoardTileGenerator
    {
        #region IBoardTileGenerator

        event EventHandler<IBoardTileEntity> OnBuildTile;

        void InitialBuild(int tileSize, float tileY);

        void Tick();

        #endregion
    }
}