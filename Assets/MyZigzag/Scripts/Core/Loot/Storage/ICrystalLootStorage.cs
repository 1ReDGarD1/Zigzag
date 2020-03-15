using System;

namespace MyZigzag.Scripts.Core.Loot.Storage
{
    public interface ICrystalLootStorage
    {
        #region ICrystalLootStorage

        event EventHandler<int> OnChangeTotalCrystals;
            
        int TotalCrystals { get; }

        void IncrementCrystal(int amount);

        #endregion
    }
}