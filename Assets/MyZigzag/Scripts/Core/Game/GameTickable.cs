using MyZigzag.Scripts.Core.BoardTile.Generator;
using MyZigzag.Scripts.Core.Game.Observer.Components;
using MyZigzag.Scripts.Core.Game.Observer.Configurator;
using Zenject;

namespace MyZigzag.Scripts.Core.Game
{
    public sealed class GameTickable : ITickable, IGameComponentInitializable, IGameComponentStarting,
        IGameComponentCompleted
    {
        #region GameTickable

        private bool _isPause = true;
        private IBoardTileGenerator _boardTileGenerator;

        #endregion

        #region ITickable

        public void Tick()
        {
            if (_isPause)
            {
                return;
            }

            _boardTileGenerator.Tick();
        }

        #endregion

        #region IGameComponentInitializable

        public void GameInitialize(IGameConfigurator configurator)
        {
            _isPause = true;
            _boardTileGenerator = configurator.GameDef.BoardTileGenerator;
        }

        #endregion

        #region IGameComponentStarting

        public void GameStarting()
        {
            _isPause = false;
        }

        #endregion

        #region IGameComponentCompleted

        public void GameComplete()
        {
            _isPause = true;
        }

        #endregion
    }
}