using System;
using MyZigzag.Scripts.Core.BoardTile.Creator;
using MyZigzag.Scripts.Core.BoardTile.Entity;
using MyZigzag.Scripts.Display.BoardTile.Model;
using MyZigzag.Scripts.Display.BoardTile.Pool;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;

namespace MyZigzag.Scripts.Main.Decorator
{
    public sealed class BoardTileCreatorDecorator : IBoardTileCreator
    {
        #region BoardTileCreatorDecorator

        private readonly IBoardTileCreator BoardTileCreator;
        private readonly IBoardTileViewModel BoardTileViewModel;
        private readonly IBoardTileViewPool BoardTileViewPool;

        public BoardTileCreatorDecorator(IBoardTileCreator boardTileCreator,
            IBoardTileViewModel boardTileViewModel,
            IBoardTileViewPool boardTileViewPool)
        {
            BoardTileCreator = boardTileCreator.CheckNull();
            BoardTileViewModel = boardTileViewModel.CheckNull();
            BoardTileViewPool = boardTileViewPool.CheckNull();
        }

        #endregion

        #region IBoardTileCreator

        public event EventHandler<IBoardTileEntity> OnCreated;

        public IBoardTileEntity Create(Vector3 startPosition)
        {
            var boardTile = BoardTileCreator.Create(startPosition);

            var boardTileView = BoardTileViewPool.Spawn(boardTile);
            BoardTileViewModel.AddView(boardTile, boardTileView);
            
            OnCreated?.Invoke(this, boardTile);
            
            return boardTile;
        }

        #endregion
    }
}