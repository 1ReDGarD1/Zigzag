using System;
using MyZigzag.Scripts.Core.Loot.Def;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;

namespace MyZigzag.Scripts.Core.Loot.Entity
{
    public sealed class LootEntity : ILootEntity
    {
        #region LootEntity

        private ILootDef Def { get; }

        public LootEntity(ILootDef lootDef, Vector3 startPosition)
        {
            Def = lootDef.CheckNull();
            StartPosition = startPosition;
        }

        #endregion

        #region ILootEntity

        public event EventHandler<ILootEntity> OnPickUp;

        public Vector3 StartPosition { get; }

        public void PickUp()
        {
            Def.PickUp();
            OnPickUp?.Invoke(this, this);
        }

        public void Clear()
        {
            OnPickUp = null;
        }

        #endregion
    }
}