using MyZigzag.Scripts.Core.BoardTile.Entity;
using MyZigzag.Scripts.Core.BoardTile.Remover;
using MyZigzag.Scripts.Core.Foundation.Remover;
using MyZigzag.Scripts.Display.BoardTile.Model;
using MyZigzag.Scripts.Display.BoardTile.Pool;
using MyZigzag.Scripts.Display.BoardTile.View;

namespace MyZigzag.Scripts.Main.Decorator.Remover
{
    public sealed class BoardTileRemoverDecorator : BaseEntityRemoverDecorator<IBoardTileEntity, IBoardTileView, 
            IBoardTileViewModel, IBoardTileViewPool>, IBoardTileRemover
    {
        #region BoardTileRemoverDecorator

        public BoardTileRemoverDecorator(IEntityRemover<IBoardTileEntity> boardTileRemover,
            IBoardTileViewModel boardTileViewModel,
            IBoardTileViewPool boardTileViewPool) : base(boardTileRemover, boardTileViewModel, boardTileViewPool)
        {
        }

        #endregion
    }
}