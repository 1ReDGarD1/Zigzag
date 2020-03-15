using MyZigzag.Scripts.Core.Player.Entity;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;
using Zenject;

namespace MyZigzag.Scripts.Core.Game
{
    public sealed class KeyboardControl : ITickable
    {
        #region KeyboardControl

        private readonly IPlayerBallEntity PlayerBallEntity;

        public KeyboardControl(IPlayerBallEntity playerBallEntity)
        {
            PlayerBallEntity = playerBallEntity.CheckNull();
        }

        #endregion

        #region ITickable

        public void Tick()
        {
            if (!(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
            {
                return;
            }

            PlayerBallEntity.SwitchMoveDirection();
        }

        #endregion
    }
}