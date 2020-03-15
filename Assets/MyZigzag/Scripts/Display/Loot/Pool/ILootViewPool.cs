using MyZigzag.Scripts.Core.Loot.Entity;
using MyZigzag.Scripts.Display.Loot.View;
using Zenject;

namespace MyZigzag.Scripts.Display.Loot.Pool
{
    public interface ILootViewPool : IMemoryPool<ILootEntity, ILootView>
    {
    }
}