using System;
using UnityEngine;

namespace MyZigzag.Scripts.Core.Loot.Entity
{
    public interface ILootEntity
    {
        #region ILootEntity

        event EventHandler<ILootEntity> OnPickUp;

        Vector3 StartPosition { get; }

        void PickUp();

        void Clear();

        #endregion
    }
}