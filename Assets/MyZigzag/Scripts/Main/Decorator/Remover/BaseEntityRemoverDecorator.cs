using MyZigzag.Scripts.Core.Foundation.Remover;
using MyZigzag.Scripts.Display.Foundation.Model;
using MyZigzag.Scripts.Utility.Common;
using Zenject;

namespace MyZigzag.Scripts.Main.Decorator.Remover
{
    public abstract class BaseEntityRemoverDecorator<TEntity, TView, TViewModel, TEntityViewPool> :
        IEntityRemover<TEntity>
        where TViewModel : IViewModel<TEntity, TView>
        where TEntityViewPool : IMemoryPool<TEntity, TView>
    {
        #region BaseEntityRemoverDecorator

        private readonly IEntityRemover<TEntity> EntityRemover;
        private readonly TViewModel ViewModel;
        private readonly TEntityViewPool ViewPool;

        protected BaseEntityRemoverDecorator(IEntityRemover<TEntity> boardTileRemover,
            TViewModel boardTileViewModel,
            TEntityViewPool boardTileViewPool)
        {
            EntityRemover = boardTileRemover.CheckNull();
            ViewModel = boardTileViewModel.CheckNull();
            ViewPool = boardTileViewPool.CheckNull();
        }

        #endregion

        #region IEntityRemover

        public void RemoveEntity(TEntity entity)
        {
            EntityRemover.RemoveEntity(entity);

            var view = ViewModel.GetView(entity);
            ViewPool.Despawn(view);

            ViewModel.RemoveView(entity);
        }

        #endregion
    }
}