using System.Collections.Generic;
using MyZigzag.Scripts.Utility.Dao.Def;

namespace MyZigzag.Scripts.Utility.Dao.Repository
{
    public abstract class BaseDefRepository<TDef> : DefRepository<TDef, string>, IBaseDefRepository<TDef>
        where TDef : IBaseDef
    {
        #region BaseDefRepository

        protected BaseDefRepository(IEnumerable<TDef> defs) : base(defs)
        {
        }

        #endregion
    }
}