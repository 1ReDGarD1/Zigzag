using MyZigzag.Scripts.Core.BoardTile.Entity;
using MyZigzag.Scripts.Display.BoardTile.View;
using Zenject;

namespace MyZigzag.Scripts.Display.BoardTile.Pool
{
    public interface IBoardTileViewPool : IMemoryPool<IBoardTileEntity, IBoardTileView>
    {
    }
}