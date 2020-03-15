using MyZigzag.Scripts.Core.Player.Def;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;

namespace MyZigzag.Scripts.Core.Player.Entity
{
    public sealed class PlayerBallEntity : IPlayerBallEntity
    {
        #region PlayerBallEntity

        private Vector3 ForwardVelocity;
        private Vector3 RightVelocity;

        private bool _currentDirectionFlag;

        #endregion

        #region IPlayerBallEntity

        public Vector3 Velocity => _currentDirectionFlag ? ForwardVelocity : RightVelocity;

        public void Initializable(IPlayerBallDef playerBallDef)
        {
            var modeSpeed = playerBallDef.CheckNull().MoveSpeed;
            ForwardVelocity = new Vector3(-modeSpeed, 0, 0);
            RightVelocity = new Vector3(0, 0, modeSpeed);
        }

        public void SwitchMoveDirection() => _currentDirectionFlag = !_currentDirectionFlag;

        #endregion
    }
}