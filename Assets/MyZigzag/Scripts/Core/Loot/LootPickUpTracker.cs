using MyZigzag.Scripts.Core.Game.Observer.Components;
using MyZigzag.Scripts.Core.Game.Observer.Configurator;
using MyZigzag.Scripts.Core.Loot.Entity;
using MyZigzag.Scripts.Core.Loot.Model;
using MyZigzag.Scripts.Core.Loot.Remover;
using MyZigzag.Scripts.Utility.Common;

namespace MyZigzag.Scripts.Core.Loot
{
    public sealed class LootPickUpTracker : IGameComponentInitializable, IGameComponentCompleted
    {
        #region LootPickUpTracker

        private readonly ILootModel LootModel;
        private readonly ILootRemover LootRemover;

        public LootPickUpTracker(ILootModel lootModel, ILootRemover lootRemover)
        {
            LootModel = lootModel.CheckNull();
            LootRemover = lootRemover.CheckNull();
        }

        private void OnAddedEntityHandler(object sender, ILootEntity loot)
        {
            loot.OnPickUp += OnPickUpHandler;
        }

        private void OnPickUpHandler(object sender, ILootEntity loot)
        {
            loot.OnPickUp -= OnPickUpHandler;
            LootRemover.RemoveEntity(loot);
        }

        #endregion

        #region IGameComponentInitializable

        public void GameInitialize(IGameConfigurator configurator)
        {
            LootModel.OnAddedEntity += OnAddedEntityHandler;
        }

        #endregion

        #region IGameComponentCompleted

        public void GameComplete()
        {
            LootModel.OnAddedEntity -= OnAddedEntityHandler;
        }

        #endregion
    }
}