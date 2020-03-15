using MyZigzag.Scripts.Core.BoardTile.Entity;
using MyZigzag.Scripts.Display.BoardTile.View;
using Zenject;

namespace MyZigzag.Scripts.Display.BoardTile.Pool
{
    public sealed class BoardTileViewPool : MonoMemoryPool<IBoardTileEntity, BoardTileView>, IBoardTileViewPool
    {
        #region MonoMemoryPool

        protected override void Reinitialize(IBoardTileEntity entity, BoardTileView view)
        {
            base.Reinitialize(entity, view);

            view.Initialization(entity);
        }

        #endregion

        #region IMemoryPool

        public void Despawn(IBoardTileView view)
        {
            base.Despawn(view as BoardTileView);
        }

        public IBoardTileView Spawn(IBoardTileEntity entity)
        {
            return base.Spawn(entity);
        }

        #endregion
    }
}