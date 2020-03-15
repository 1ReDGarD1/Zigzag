using System;
using UnityEngine;

namespace MyZigzag.Scripts.Core.BoardTile.Entity
{
    public interface IBoardTileEntity
    {
        #region IBoardTileEntity

        event EventHandler OnStartFalling;
        event EventHandler<IBoardTileEntity> OnEndFalling;

        Vector3 Position { get; }
        bool IsFalling { get; }

        void StartFall();
        void EndFall();

        void Clear();

        #endregion
    }
}