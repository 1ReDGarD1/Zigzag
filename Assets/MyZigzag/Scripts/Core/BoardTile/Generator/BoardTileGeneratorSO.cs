using System;
using MyZigzag.Scripts.Core.BoardTile.Creator;
using MyZigzag.Scripts.Core.BoardTile.Entity;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;
using Zenject;

namespace MyZigzag.Scripts.Core.BoardTile.Generator
{
    [CreateAssetMenu(menuName = "MyZigzag/BoardTileGenerator")]
    public sealed class BoardTileGeneratorSO : ScriptableObject, IBoardTileGenerator
    {
        #region BoardTileGeneratorSO

        [SerializeField]
        private int InitialMaxTiles = 5;

        [SerializeField]
        private int ThicknessTileSet = 1;

        [SerializeField]
        private float TimerInterval = 0.5f;

        private IBoardTileCreator BoardTileCreator;

        private bool IsMultiThicknessTileSet => ThicknessTileSet > 1;

        private Vector3 _currentTilePosition;
        private float _timer;
        private float _tileY;
        private int _tileSize;

        [Inject]
        public void Construct(IBoardTileCreator boardTileCreator)
        {
            BoardTileCreator = boardTileCreator.CheckNull();
        }

        private void InitialBuildStartingField()
        {
            var z = 0;
            for (var i = 0; i < 3; i++)
            {
                var x = -_tileSize;
                for (var j = 0; j < 3; j++)
                {
                    var position = new Vector3(x, _tileY, z);
                    BoardTileCreator.Create(position);

                    x += _tileSize;
                }

                z -= _tileSize;
            }
        }

        private void InitialBuildTileSets()
        {
            _currentTilePosition = new Vector3(-_tileSize, _tileY, _tileSize);

            BuildTileSet(_currentTilePosition);

            for (var i = 0; i < InitialMaxTiles; i++)
            {
                BuildTileSet(NextRandomTilePosition());
            }
        }

        private void BuildTileSet(Vector3 position)
        {
            _currentTilePosition = position;

            var centralBoardTile = BoardTileCreator.Create(_currentTilePosition);
            OnBuildTile?.Invoke(this, centralBoardTile);

            var deltaX = 0;
            for (var i = 1; i <= ThicknessTileSet - 1; i++)
            {
                var isEven = (i & 1) == 0;
                if (!isEven) deltaX += _tileSize;

                var newPosition = new Vector3(isEven ? _tileSize : -_tileSize * deltaX, 0);

                BoardTileCreator.Create(newPosition + _currentTilePosition);
            }
        }

        private Vector3 NextRandomTilePosition()
        {
            var nextPosition = _currentTilePosition;
            var rndDirection = RandomUtils.RandomBool();

            if (rndDirection)
            {
                nextPosition.x -= _tileSize;
            }

            if (IsMultiThicknessTileSet || !rndDirection)
            {
                nextPosition.z += _tileSize;
            }

            nextPosition.y = _tileY;

            return nextPosition;
        }

        #endregion

        #region IBoardTileGenerator

        public event EventHandler<IBoardTileEntity> OnBuildTile;

        public void InitialBuild(int tileSize, float tileY)
        {
            _tileSize = tileSize;
            _tileY = tileY;

            InitialBuildStartingField();
            InitialBuildTileSets();
        }

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer < TimerInterval)
            {
                return;
            }

            _timer -= TimerInterval;

            BuildTileSet(NextRandomTilePosition());
        }

        #endregion
    }
}