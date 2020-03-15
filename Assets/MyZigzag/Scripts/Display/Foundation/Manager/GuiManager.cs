using MyZigzag.Scripts.Display.Foundation.Screen;
using MyZigzag.Scripts.Display.Foundation.Screen.Repository;
using MyZigzag.Scripts.Utility.Common;

namespace MyZigzag.Scripts.Display.Foundation.Manager
{
    public sealed class GuiManager : IGuiManager
    {
        #region GuiManager

        private readonly IUiScreenRepository UiScreenRepository;

        private IUiScreen _curScreen;

        public GuiManager(IUiScreenRepository uiScreenRepository)
        {
            UiScreenRepository = uiScreenRepository.CheckNull();
        }

        private IUiScreen GetScreen(UiScreenKind screenKind)
        {
            return UiScreenRepository.GetDef(screenKind);
        }

        #endregion

        #region IGuiManager

        public void ShowScreen(UiScreenKind screenKind)
        {
            _curScreen?.Hide();

            _curScreen = GetScreen(screenKind);
            _curScreen.Show();
        }

        public void HideScreen(UiScreenKind screenKind) => GetScreen(screenKind).Hide();

        #endregion
    }
}