using MyZigzag.Scripts.Core.Game.Def;
using MyZigzag.Scripts.Core.Player.Def;

namespace MyZigzag.Scripts.Core.Game.Observer.Configurator
{
    public interface IGameConfigurator
    {
        #region IGameConfigurator

        IGameDef GameDef { get; }

        IPlayerBallDef PlayerBallDef { get; }

        #endregion
    }
}