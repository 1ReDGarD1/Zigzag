using MyZigzag.Scripts.Core.Loot.Entity;
using MyZigzag.Scripts.Display.Loot.View;
using Zenject;

namespace MyZigzag.Scripts.Display.Loot.Pool
{
    public sealed class LootViewPool : MonoMemoryPool<ILootEntity, LootView>, ILootViewPool
    {
        #region MonoMemoryPool

        protected override void Reinitialize(ILootEntity entity, LootView view)
        {
            base.Reinitialize(entity, view);

            view.Initialization(entity);
        }

        #endregion

        #region IMemoryPool

        public void Despawn(ILootView view)
        {
            base.Despawn(view as LootView);
        }

        public ILootView Spawn(ILootEntity entity)
        {
            return base.Spawn(entity);
        }

        #endregion
    }
}