namespace MyZigzag.Scripts.Core.Foundation.Remover
{
    public interface IEntityRemover<T>
    {
        #region IEntityRemover

        void RemoveEntity(T entity);

        #endregion
    }
}