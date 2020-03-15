using MyZigzag.Scripts.Display.Foundation.View;
using UnityEngine;

namespace MyZigzag.Scripts.Display.Foundation.Screen
{
    [DisallowMultipleComponent]
    public sealed class ViewScreen : BaseViewElement, IUiScreen
    {
        #region ViewScreen

        [SerializeField]
        private UiScreenKind _uiScreenKind;

        #endregion

        #region IDef

        public UiScreenKind Id => _uiScreenKind;

        #endregion
    }
}