using MyZigzag.Scripts.Core.BoardTile.Entity;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;

namespace MyZigzag.Scripts.Core.Loot.Generator
{
    [CreateAssetMenu(menuName = "MyZigzag/RandomCrystalLootGenerator")]
    public sealed class RandomCrystalLootGeneratorSO : BaseCrystalLootGeneratorSO
    {
        #region RandomCrystalLootGeneratorSO

        private int _countTilesBlock;
        private bool _pickUOnGeneration;

        #endregion

        #region BaseCrystalLootGeneratorSO

        protected override void ResetGeneration()
        {
            _countTilesBlock = 0;
            _pickUOnGeneration = false;
        }

        protected override void OnBuildTileHandler(object sender, IBoardTileEntity boardTileEntity)
        {
            if (!_pickUOnGeneration)
            {
                var rndBool = RandomUtils.RandomBool();
                if (rndBool || _countTilesBlock == TilesBlockIndex)
                {
                    GenerationLoot(boardTileEntity.Position);
                    _pickUOnGeneration = true;
                }
            }

            if (++_countTilesBlock > TilesBlockIndex)
            {
                ResetGeneration();
            }
        }

        #endregion
    }
}