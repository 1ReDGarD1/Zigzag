using System;
using MyZigzag.Scripts.Core.BoardTile.Entity;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;

namespace MyZigzag.Scripts.Display.BoardTile.View
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public sealed class BoardTileView : MonoBehaviour, IBoardTileView
    {
        #region BoardTileView

        [SerializeField]
        private Rigidbody _rigidbody;
        
        private const float TimerInterval = 1.5f;

        private IBoardTileEntity _boardTile;

        private float _timer;

        private void Awake()
        {
            _rigidbody.CheckNull();
        }

        private void OnStartFallingHandler(object sender, EventArgs eventArgs)
        {
            SetRigidbodySettings(false);
        }

        private void FixedUpdate()
        {
            if (!_boardTile.IsFalling)
            {
                return;
            }
            
            _timer += Time.deltaTime;
            if (_timer < TimerInterval)
            {
                return;
            }

            _boardTile.OnStartFalling -= OnStartFallingHandler;
            _boardTile.EndFall();
        }

        private void SetRigidbodySettings(bool flag)
        {
            _rigidbody.useGravity = !flag;
            _rigidbody.isKinematic = flag;
        }

        #endregion

        #region IBoardTileView

        public Vector3 Position
        {
            set => transform.position = value;
        }

        public void Initialization(IBoardTileEntity boardTile)
        {
            _boardTile = boardTile.CheckNull();

            _timer = 0;
            SetRigidbodySettings(true);
            Position = boardTile.Position;
            boardTile.OnStartFalling += OnStartFallingHandler;
        }

        #endregion
    }
}