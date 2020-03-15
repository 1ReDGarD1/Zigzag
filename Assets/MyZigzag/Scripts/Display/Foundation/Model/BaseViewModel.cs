using System.Collections.Generic;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;

namespace MyZigzag.Scripts.Display.Foundation.Model
{
    public abstract class BaseViewModel<TEntity, TEntityView> : IViewModel<TEntity, TEntityView>
    {
        #region BaseViewModel

        private IDictionary<TEntity, TEntityView> ViewsByEntity { get; } = new Dictionary<TEntity, TEntityView>();
        
        public override string ToString() => $"Views:\n{ViewsByEntity.ToString(",\n")}";

        #endregion

        #region IViewModel

        public void AddView(TEntity entity, TEntityView entityView)
        {
            if (ViewsByEntity.ContainsKey(entity))
            {
                Debug.LogError($"Attempt to re-added {entity}, {entityView}");
                return;
            }

            ViewsByEntity.Add(entity, entityView);
        }

        public void RemoveView(TEntity entity)
        {
            ViewsByEntity.Remove(entity);
        }

        public TEntityView GetView(TEntity entity)
        {
            ViewsByEntity.TryGetValue(entity, out var entityView);

            if (entityView == null)
            {
                Debug.LogError($"Can't find view for {entity}");
                return default;
            }

            return entityView;
        }

        #endregion
    }
}