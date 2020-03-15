using MyZigzag.Scripts.Core.Game.Observer;
using MyZigzag.Scripts.Display.Player;
using MyZigzag.Scripts.Utility.Common;
using Zenject;

namespace MyZigzag.Scripts.Main
{
    public sealed class PlayerBallFallTracker : ITickable
    {
        #region PlayerBallFallTracker

        private readonly IPlayerBallView PlayerBallView;
        private readonly IGameStatusObserver GameStatusObserver;

        public PlayerBallFallTracker(IPlayerBallView playerBallView, IGameStatusObserver gameStatusObserver)
        {
            PlayerBallView = playerBallView.CheckNull();
            GameStatusObserver = gameStatusObserver.CheckNull();
        }

        #endregion

        #region ITickable

        public void Tick()
        {
            if (PlayerBallView.Position.y > -3f)
            {
                return;
            }

            GameStatusObserver.CompleteGame();
        }

        #endregion
    }
}