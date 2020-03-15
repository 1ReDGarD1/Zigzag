using System;
using MyZigzag.Scripts.Core.BoardTile.Entity;
using UnityEngine;

namespace MyZigzag.Scripts.Core.BoardTile.Creator
{
    public interface IBoardTileCreator
    {
        #region IBoardTileCreator

        event EventHandler<IBoardTileEntity> OnCreated;
        
        IBoardTileEntity Create(Vector3 startPosition);

        #endregion
    }
}