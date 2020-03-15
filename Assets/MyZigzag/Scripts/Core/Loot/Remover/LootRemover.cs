using MyZigzag.Scripts.Core.Foundation.Remover;
using MyZigzag.Scripts.Core.Loot.Entity;
using MyZigzag.Scripts.Core.Loot.Model;

namespace MyZigzag.Scripts.Core.Loot.Remover
{
    public sealed class LootRemover : BaseEntityRemover<ILootEntity, ILootModel>, ILootRemover
    {
        #region LootRemover

        public LootRemover(ILootModel model) : base(model)
        {
        }

        #endregion

        public override void RemoveEntity(ILootEntity entity)
        {
            base.RemoveEntity(entity);
            
            entity.Clear();
        }
    }
}