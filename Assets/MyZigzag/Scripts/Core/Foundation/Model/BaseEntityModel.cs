using System;
using System.Collections.Generic;
using MyZigzag.Scripts.Utility.Common;

namespace MyZigzag.Scripts.Core.Foundation.Model
{
    public abstract class BaseEntityModel<T> : IEntityModel<T>
    {
        #region BaseEntityModel

        private List<T> EntitiesList { get; } = new List<T>();

        public override string ToString() => $"{nameof(T)} entities:\n{EntitiesList.ToString(",\n")}";

        #endregion

        #region IEntityModel

        public event EventHandler<T> OnAddedEntity;

        public IList<T> Entities => EntitiesList;

        public virtual void AddEntity(T entity)
        {
            EntitiesList.Add(entity);

            OnAddedEntity?.Invoke(this, entity);
        }

        public virtual void RemoveEntity(T entity) => EntitiesList.Remove(entity);

        #endregion
    }
}