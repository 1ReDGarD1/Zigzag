namespace MyZigzag.Scripts.Display.Foundation.Model
{
    public interface IViewModel<TEntity, TEntityView>
    {
        #region IViewModel

        void AddView(TEntity entity, TEntityView entityView);
        void RemoveView(TEntity entity);

        TEntityView GetView(TEntity entity);

        #endregion
    }
}