using MyZigzag.Scripts.Core.Loot.Entity;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;

namespace MyZigzag.Scripts.Display.Loot.View
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SphereCollider))]
    public sealed class LootView : MonoBehaviour, ILootView
    {
        private ILootEntity _loot;

        private void OnCollisionEnter(Collision other)
        {
            _loot.PickUp();
        }

        #region ILootView

        public void Initialization(ILootEntity loot)
        {
            _loot = loot.CheckNull();

            transform.position = loot.StartPosition;
        }

        #endregion
    }
}