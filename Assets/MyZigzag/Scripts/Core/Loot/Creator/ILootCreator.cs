using MyZigzag.Scripts.Core.Loot.Def;
using MyZigzag.Scripts.Core.Loot.Entity;
using UnityEngine;

namespace MyZigzag.Scripts.Core.Loot.Creator
{
    public interface ILootCreator
    {
        #region ILootCreator

        ILootEntity Create(ILootDef lootDef, Vector3 position);

        #endregion
    }
}