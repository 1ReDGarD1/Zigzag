using MyZigzag.Scripts.Core.Foundation.Model;
using MyZigzag.Scripts.Utility.Common;

namespace MyZigzag.Scripts.Core.Foundation.Remover
{
    public abstract class BaseEntityRemover<TEntity, TModel> : IEntityRemover<TEntity>
        where TModel : IEntityModel<TEntity>
    {
        #region BaseEntityRemover

        private readonly TModel Model;

        protected BaseEntityRemover(TModel model)
        {
            Model = model.CheckNull();
        }

        #endregion

        #region IEntityRemover

        public virtual void RemoveEntity(TEntity entity)
        {
            Model.RemoveEntity(entity);
        }

        #endregion
    }
}