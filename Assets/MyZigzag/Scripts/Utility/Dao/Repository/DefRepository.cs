using System.Collections.Generic;
using MyZigzag.Scripts.Utility.Common;
using MyZigzag.Scripts.Utility.Dao.Def;
using MyZigzag.Scripts.Utility.Dao.Repository.Exception;

namespace MyZigzag.Scripts.Utility.Dao.Repository
{
    public abstract class DefRepository<TDef, TKey> : IDefRepository<TDef, TKey>
        where TDef : IDef<TKey>
    {
        #region DefRepository

        private readonly Dictionary<TKey, TDef> Defs = new Dictionary<TKey, TDef>();

        protected DefRepository(IEnumerable<TDef> defs)
        {
            Initialization(defs.CheckNull());
        }

        private void Initialization(IEnumerable<TDef> defs)
        {
            foreach (var def in defs)
            {
                AddDef(def);
            }
        }

        protected virtual void AddDef(TDef def) => Defs.Add(def.Id, def);

        public override string ToString() => $"Defs:\n{Defs.ToString(",\n")}";

        #endregion

        #region IDefRepository

        public TDef GetDef(TKey id)
        {
            if (!Defs.ContainsKey(id))
            {
                throw new NotExistDefException<TDef, TKey>(id);
            }

            return Defs[id];
        }

        #endregion
    }
}