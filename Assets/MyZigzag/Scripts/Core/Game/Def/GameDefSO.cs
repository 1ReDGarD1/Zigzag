using MyZigzag.Scripts.Core.BoardTile.Generator;
using MyZigzag.Scripts.Core.Loot.Generator;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;

namespace MyZigzag.Scripts.Core.Game.Def
{
    [CreateAssetMenu(menuName = "MyZigzag/GameDef")]
    public sealed class GameDefSO : ScriptableObject, IGameDef
    {
        #region GameDefSO

        [SerializeField]
        private BoardTileGeneratorSO _boardTileGenerator;

        [SerializeField]
        private BaseCrystalLootGeneratorSO _crystalLootGenerator;

        private void Awake()
        {
            _boardTileGenerator.CheckNull();
            _crystalLootGenerator.CheckNull();
        }

        #endregion

        #region IGameDef

        public IBoardTileGenerator BoardTileGenerator => _boardTileGenerator;
        public ILootGenerator LootGenerator => _crystalLootGenerator;

        #endregion
    }
}