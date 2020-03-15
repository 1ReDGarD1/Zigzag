using MyZigzag.Scripts.Core.Foundation.Remover;
using MyZigzag.Scripts.Core.Loot.Entity;
using MyZigzag.Scripts.Core.Loot.Remover;
using MyZigzag.Scripts.Display.Loot.Model;
using MyZigzag.Scripts.Display.Loot.Pool;
using MyZigzag.Scripts.Display.Loot.View;

namespace MyZigzag.Scripts.Main.Decorator.Remover
{
    public sealed class LootRemoverDecorator : BaseEntityRemoverDecorator<ILootEntity, ILootView, ILootViewModel,
        ILootViewPool>, ILootRemover
    {
        #region LootRemoverDecorator

        public LootRemoverDecorator(IEntityRemover<ILootEntity> boardTileRemover,
            ILootViewModel boardTileViewModel,
            ILootViewPool boardTileViewPool) : base(boardTileRemover, boardTileViewModel, boardTileViewPool)
        {
        }

        #endregion
    }
}