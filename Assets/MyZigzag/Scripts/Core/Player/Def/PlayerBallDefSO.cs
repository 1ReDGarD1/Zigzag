using MyZigzag.Scripts.Utility.Dao.Def;
using UnityEngine;

namespace MyZigzag.Scripts.Core.Player.Def
{
    [CreateAssetMenu(menuName = "MyZigzag/PlayerBallDef")]
    public sealed class PlayerBallDefSO : BaseDefSO, IPlayerBallDef
    {
        #region PlayerBallDefSO

        [SerializeField]
        private float _moveSpeed = 1f;

        public override string ToString() => $"{base.ToString()}, moveSpeed:{MoveSpeed}";

        #endregion

        #region IPlayerBallDef

        public float MoveSpeed => _moveSpeed;

        #endregion
    }
}