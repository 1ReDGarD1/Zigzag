using MyZigzag.Scripts.Core.Player.Entity;
using UnityEngine;

namespace MyZigzag.Scripts.Display.Player
{
    public interface IPlayerBallView
    {
        #region IPlayerBallView

        void Initializable(IPlayerBallEntity playerBallEntity, float startZ);

        Vector3 Position { get; }

        void Reset();

        #endregion
    }
}