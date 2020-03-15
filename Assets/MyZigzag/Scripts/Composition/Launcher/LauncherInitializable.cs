using MyZigzag.Scripts.Display.Foundation.Manager;
using MyZigzag.Scripts.Display.Foundation.Screen;
using MyZigzag.Scripts.Display.Game;
using MyZigzag.Scripts.Utility.Common;
using Zenject;

namespace MyZigzag.Scripts.Composition.Launcher
{
    public sealed class LauncherInitializable : IInitializable
    {
        #region LauncherInitializable

        private readonly IGuiManager GuiManager;
        private readonly IGameView GameView;

        public LauncherInitializable(IGuiManager guiManager, IGameView gameView)
        {
            GuiManager = guiManager.CheckNull();
            GameView = gameView.CheckNull();
        }

        #endregion

        #region IInitializable

        public void Initialize()
        {
            GameView.Hide();

            GuiManager.ShowScreen(UiScreenKind.MainMenu);
        }

        #endregion
    }
}