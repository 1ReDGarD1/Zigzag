using System;
using UnityEngine;

namespace MyZigzag.Scripts.Core.BoardTile.Entity
{
    public sealed class BoardTileEntity : IBoardTileEntity
    {
        #region BoardTileEntity

        public BoardTileEntity(Vector3 position)
        {
            Position = position;
        }

        #endregion

        #region IBoardTileEntity

        public event EventHandler OnStartFalling;
        public event EventHandler<IBoardTileEntity> OnEndFalling;

        public Vector3 Position { get; }
        public bool IsFalling { get; private set; }

        public void StartFall()
        {
            if (IsFalling)
            {
                return;
            }

            IsFalling = true;
            OnStartFalling?.Invoke(this, EventArgs.Empty);
        }

        public void EndFall()
        {
            IsFalling = false;
            OnEndFalling?.Invoke(this, this);
        }

        public void Clear()
        {
            IsFalling = false;
            OnStartFalling = null;
            OnEndFalling = null;
        }

        #endregion
    }
}