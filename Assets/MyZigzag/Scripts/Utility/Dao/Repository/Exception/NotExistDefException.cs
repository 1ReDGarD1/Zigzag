using MyZigzag.Scripts.Utility.Dao.Def;

namespace MyZigzag.Scripts.Utility.Dao.Repository.Exception
{
    public sealed class NotExistDefException<TDef, TKey> : System.Exception
        where TDef : IDef<TKey>
    {
        public NotExistDefException(TKey id) : base($"Not existing id:{id} for repository:{typeof(TDef)}")
        {
        }
    }
}