using MyZigzag.Scripts.Core.BoardTile.Entity;
using MyZigzag.Scripts.Core.BoardTile.Model;
using MyZigzag.Scripts.Core.Foundation.Remover;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;

namespace MyZigzag.Scripts.Core.BoardTile.Remover
{
    public sealed class BoardTileRemover : BaseEntityRemover<IBoardTileEntity, IBoardTileModel>, IBoardTileRemover
    {
        #region BoardTileRemover

        public BoardTileRemover(IBoardTileModel model) : base(model)
        {
        }

        public override void RemoveEntity(IBoardTileEntity entity)
        {
            base.RemoveEntity(entity);
            
            entity.Clear();
        }

        #endregion
    }
}