using MyZigzag.Scripts.Core.Loot.Storage;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;
using UnityEngine.Assertions;

namespace MyZigzag.Scripts.Core.Loot.Def
{
    [CreateAssetMenu(menuName = "MyZigzag/CrystalLootDef")]
    public sealed class CrystalLootDefSO : ScriptableObject, ILootDef
    {
        #region CrystalLootDefSO

        [SerializeField]
        private int _amount = 1;

        private ICrystalLootStorage _crystalLootStorage;

        private void Awake()
        {
            Assert.IsTrue(_amount >= 1);
        }

        public void Construct(ICrystalLootStorage crystalLootStorage)
        {
            _crystalLootStorage = crystalLootStorage.CheckNull();
        }

        #endregion

        #region ILootDef

        public void PickUp()
        {
            _crystalLootStorage.IncrementCrystal(_amount);
        }

        #endregion
    }
}