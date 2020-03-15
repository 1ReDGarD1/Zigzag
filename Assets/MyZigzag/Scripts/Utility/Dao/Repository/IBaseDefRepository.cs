using MyZigzag.Scripts.Utility.Dao.Def;

namespace MyZigzag.Scripts.Utility.Dao.Repository
{
    public interface IBaseDefRepository<out TDef> : IDefRepository<TDef, string>
        where TDef : IBaseDef
    {
    }
}