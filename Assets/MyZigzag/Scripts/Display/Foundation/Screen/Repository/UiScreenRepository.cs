using System.Collections.Generic;
using MyZigzag.Scripts.Utility.Dao.Repository;

namespace MyZigzag.Scripts.Display.Foundation.Screen.Repository
{
    public sealed class UiScreenRepository : DefRepository<IUiScreen, UiScreenKind>, IUiScreenRepository
    {
        #region UiScreenRepository

        public UiScreenRepository(IEnumerable<IUiScreen> defs) : base(defs)
        {
        }

        protected override void AddDef(IUiScreen def)
        {
            base.AddDef(def);

            def.Hide();
        }

        #endregion
    }
}