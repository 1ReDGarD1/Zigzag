using MyZigzag.Scripts.Core.Game.Observer;
using MyZigzag.Scripts.Core.Game.Observer.Configurator;
using MyZigzag.Scripts.Display.Foundation.Manager;
using MyZigzag.Scripts.Display.Foundation.Screen;
using MyZigzag.Scripts.Display.Game;
using MyZigzag.Scripts.Utility.Common;

namespace MyZigzag.Scripts.Main.Decorator
{
    public sealed class GameStatusObserverDecorator : IGameStatusObserver
    {
        #region GameStatusObserverDecorator

        private readonly IGameStatusObserver GameStatusObserver;
        private readonly IGameView GameView;
        private readonly IGuiManager GuiManager;

        public GameStatusObserverDecorator(IGameStatusObserver gameStatusObserver, 
            IGameView gameView,
            IGuiManager guiManager)
        {
            GameStatusObserver = gameStatusObserver.CheckNull();
            GameView = gameView.CheckNull();
            GuiManager = guiManager.CheckNull();
        }

        #endregion

        #region IGameStatusObserver

        public void StartGame(IGameConfigurator gameConfigurator)
        {
            GameStatusObserver.StartGame(gameConfigurator);

            GameView.Show();
            GuiManager.ShowScreen(UiScreenKind.Hud);
        }

        public void CompleteGame()
        {
            GameStatusObserver.CompleteGame();

            GameView.Hide();
            GuiManager.ShowScreen(UiScreenKind.GameOver);
        }

        #endregion
    }
}