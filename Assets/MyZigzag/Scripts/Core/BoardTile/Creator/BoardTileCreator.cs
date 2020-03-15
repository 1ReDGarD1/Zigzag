using System;
using MyZigzag.Scripts.Core.BoardTile.Entity;
using MyZigzag.Scripts.Core.BoardTile.Model;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;

namespace MyZigzag.Scripts.Core.BoardTile.Creator
{
    public sealed class BoardTileCreator : IBoardTileCreator
    {
        #region BoardTileCreator

        private readonly IBoardTileModel BoardTileModel;

        public BoardTileCreator(IBoardTileModel boardTileModel)
        {
            BoardTileModel = boardTileModel.CheckNull();
        }

        #endregion

        #region IBoardTileCreator

        public event EventHandler<IBoardTileEntity> OnCreated;

        public IBoardTileEntity Create(Vector3 startPosition)
        {
            var boardTileEntity = new BoardTileEntity(startPosition);
            BoardTileModel.AddEntity(boardTileEntity);
            
            OnCreated?.Invoke(this, boardTileEntity);

            return boardTileEntity;
        }

        #endregion
    }
}