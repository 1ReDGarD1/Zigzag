using MyZigzag.Scripts.Core.BoardTile.Entity;
using MyZigzag.Scripts.Core.BoardTile.Generator;
using MyZigzag.Scripts.Core.Loot.Creator;
using MyZigzag.Scripts.Core.Loot.Def;
using MyZigzag.Scripts.Core.Loot.Storage;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace MyZigzag.Scripts.Core.Loot.Generator
{
    public abstract class BaseCrystalLootGeneratorSO : ScriptableObject, ILootGenerator
    {
        #region BaseCrystalLootGeneratorSO

        [SerializeField]
        private CrystalLootDefSO _crystalLootDef;

        [SerializeField]
        private int _tilesBlock = 1;

        protected int TilesBlockIndex => _tilesBlock - 1;

        private ILootCreator _lootCreator;
        
        private IBoardTileGenerator _boardTileGenerator;
        private float _tileSize;

        private void Awake()
        {
            _crystalLootDef.CheckNull();
            Assert.IsTrue(_tilesBlock > 0);
        }

        [Inject]
        private void Construct(ILootCreator lootCreator, ICrystalLootStorage crystalLootStorage)
        {
            _lootCreator = lootCreator.CheckNull();
            _crystalLootDef.Construct(crystalLootStorage.CheckNull());
        }

        protected void GenerationLoot(Vector3 position)
        {
            position.y = 0;
            _lootCreator.Create(_crystalLootDef, position);
        }

        protected abstract void OnBuildTileHandler(object sender, IBoardTileEntity boardTileEntity);

        protected abstract void ResetGeneration();

        #endregion

        #region ILootGenerator

        public void Activate(IBoardTileGenerator boardTileGenerator)
        {
            _boardTileGenerator = boardTileGenerator.CheckNull();
            _boardTileGenerator.OnBuildTile += OnBuildTileHandler;

            ResetGeneration();
        }

        public void Deactivate()
        {
            _boardTileGenerator.OnBuildTile -= OnBuildTileHandler;
        }

        #endregion
    }
}