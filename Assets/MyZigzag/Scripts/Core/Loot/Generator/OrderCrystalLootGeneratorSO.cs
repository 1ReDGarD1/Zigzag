using MyZigzag.Scripts.Core.BoardTile.Entity;
using UnityEngine;

namespace MyZigzag.Scripts.Core.Loot.Generator
{
    [CreateAssetMenu(menuName = "MyZigzag/OrderCrystalLootGeneratorSO")]
    public sealed class OrderCrystalLootGeneratorSO : BaseCrystalLootGeneratorSO
    {
        #region OrderCrystalLootGeneratorSO

        private int _countTilesBlock;
        private int _orderTile;

        #endregion

        #region BaseCrystalLootGeneratorSO

        protected override void ResetGeneration()
        {
            _countTilesBlock = 0;
            _orderTile = 0;
        }
        
        protected override void OnBuildTileHandler(object sender, IBoardTileEntity boardTileEntity)
        {
            if (_orderTile == _countTilesBlock)
            {
                GenerationLoot(boardTileEntity.Position);
            }
            
            if (++_countTilesBlock > TilesBlockIndex)
            {
                _countTilesBlock = 0;
                _orderTile += 1;
                if (_orderTile > TilesBlockIndex)
                {
                    _orderTile = 0;
                }
            }
        }

        #endregion
    }
}