using MyZigzag.Scripts.Core.Player.Def;
using UnityEngine;

namespace MyZigzag.Scripts.Core.Player.Entity
{
    public interface IPlayerBallEntity
    {
        #region IPlayerBallEntity

        Vector3 Velocity { get; }

        void Initializable(IPlayerBallDef playerBallDef);

        void SwitchMoveDirection();

        #endregion
    }
}