using MyZigzag.Scripts.Core.Player.Entity;
using MyZigzag.Scripts.Display.CameraWatcher;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;

namespace MyZigzag.Scripts.Display.Player
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerBallView : MonoBehaviour, IPlayerBallView, ICameraWatcherTarget
    {
        #region PlayerBallView

        private Rigidbody _rigidbody;

        private Vector3 _startPosition;
        private IPlayerBallEntity _playerBallEntity;

        private bool IsPause => _playerBallEntity == null;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

            _startPosition = transform.position;
            
            Reset();
        }

        private void FixedUpdate()
        {
            if (IsPause)
            {
                return;
            }
            
            UpdateVelocity();
        }

        private void UpdateVelocity()
        {
            var velocity = _playerBallEntity.Velocity;
            velocity.y = _rigidbody.velocity.y;

            _rigidbody.velocity = velocity;
        }

        #endregion

        #region IPlayerBallView

        public void Initializable(IPlayerBallEntity playerBallEntity, float startZ)
        {
            _playerBallEntity = playerBallEntity.CheckNull();
            Position = new Vector3(0, 0, startZ);
            _rigidbody.useGravity = true;
        }

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public void Reset()
        {
            transform.SetPositionAndRotation(_startPosition, Quaternion.identity);
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.useGravity = false;
            _playerBallEntity = null;
        }

        #endregion

        #region ICameraWatcherTarget

        Vector3 ICameraWatcherTarget.Position => Position;

        #endregion
    }
}