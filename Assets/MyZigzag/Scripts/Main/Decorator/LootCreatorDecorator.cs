using MyZigzag.Scripts.Core.Loot;
using MyZigzag.Scripts.Core.Loot.Creator;
using MyZigzag.Scripts.Core.Loot.Def;
using MyZigzag.Scripts.Core.Loot.Entity;
using MyZigzag.Scripts.Display.Loot.Model;
using MyZigzag.Scripts.Display.Loot.Pool;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;

namespace MyZigzag.Scripts.Main.Decorator
{
    public sealed class LootCreatorDecorator : ILootCreator
    {
        #region LootCreatorDecorator

        private readonly ILootCreator LootCreator;
        private readonly ILootViewModel LootViewModel;
        private readonly ILootViewPool LootViewPool;

        public LootCreatorDecorator(ILootCreator lootCreator, ILootViewModel lootViewModel, ILootViewPool lootViewPool)
        {
            LootCreator = lootCreator.CheckNull();
            LootViewModel = lootViewModel.CheckNull();
            LootViewPool = lootViewPool.CheckNull();
        }

        #endregion

        #region ILootCreator

        public ILootEntity Create(ILootDef lootDef, Vector3 position)
        {
            var loot = LootCreator.Create(lootDef, position);

            var lootView = LootViewPool.Spawn(loot);
            LootViewModel.AddView(loot, lootView);

            return loot;
        }

        #endregion
    }
}