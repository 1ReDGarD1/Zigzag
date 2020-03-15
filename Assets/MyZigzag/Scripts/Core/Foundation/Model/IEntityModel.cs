using System;
using System.Collections.Generic;

namespace MyZigzag.Scripts.Core.Foundation.Model
{
    public interface IEntityModel<T>
    {
        #region IEntityModel

        event EventHandler<T> OnAddedEntity;

        IList<T> Entities { get; }

        void AddEntity(T entity);
        void RemoveEntity(T entity);

        #endregion
    }
}