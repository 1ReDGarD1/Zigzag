using MyZigzag.Scripts.Core.Game.Observer.Configurator;

namespace MyZigzag.Scripts.Core.Game.Observer.Components
{
    public interface IGameComponentInitializable
    {
        #region IGameComponentInitializable

        void GameInitialize(IGameConfigurator configurator);

        #endregion
    }
}