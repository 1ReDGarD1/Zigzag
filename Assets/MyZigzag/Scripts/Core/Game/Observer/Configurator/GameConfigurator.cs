using MyZigzag.Scripts.Core.Game.Def;
using MyZigzag.Scripts.Core.Player.Def;
using MyZigzag.Scripts.Utility.Common;

namespace MyZigzag.Scripts.Core.Game.Observer.Configurator
{
    public struct GameConfigurator : IGameConfigurator
    {
        #region GameConfigurator

        public GameConfigurator(IGameDef gameDef, IPlayerBallDef playerBallDef)
        {
            GameDef = gameDef.CheckNull();
            PlayerBallDef = playerBallDef.CheckNull();
        }

        #endregion

        #region IGameConfigurator

        public IGameDef GameDef { get; }
        public IPlayerBallDef PlayerBallDef { get; }

        #endregion
    }
}