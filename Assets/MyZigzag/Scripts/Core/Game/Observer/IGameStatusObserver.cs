using MyZigzag.Scripts.Core.Game.Observer.Configurator;

namespace MyZigzag.Scripts.Core.Game.Observer
{
    public interface IGameStatusObserver
    {
        #region IGameStatusObserver

        void StartGame(IGameConfigurator gameConfigurator);

        void CompleteGame();

        #endregion
    }
}