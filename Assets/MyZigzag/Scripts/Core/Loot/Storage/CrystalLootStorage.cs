using System;
using UnityEngine;

namespace MyZigzag.Scripts.Core.Loot.Storage
{
    public sealed class CrystalLootStorage : ICrystalLootStorage
    {
        #region ICrystalLootStorage

        public event EventHandler<int> OnChangeTotalCrystals;

        public int TotalCrystals { get; private set; }

        public void IncrementCrystal(int amount)
        {
            TotalCrystals += amount;
            OnChangeTotalCrystals?.Invoke(this, TotalCrystals);
        }

        #endregion
    }
}