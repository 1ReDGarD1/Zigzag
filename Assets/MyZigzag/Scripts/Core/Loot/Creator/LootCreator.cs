using MyZigzag.Scripts.Core.Loot.Def;
using MyZigzag.Scripts.Core.Loot.Entity;
using MyZigzag.Scripts.Core.Loot.Model;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;

namespace MyZigzag.Scripts.Core.Loot.Creator
{
    public sealed class LootCreator : ILootCreator
    {
        #region LootCreator

        private readonly ILootModel LootModel;

        public LootCreator(ILootModel lootModel)
        {
            LootModel = lootModel.CheckNull();
        }

        #endregion

        #region ILootCreator

        public ILootEntity Create(ILootDef lootDef, Vector3 position)
        {
            var loot = new LootEntity(lootDef, position);
            LootModel.AddEntity(loot);

            return loot;
        }

        #endregion
    }
}