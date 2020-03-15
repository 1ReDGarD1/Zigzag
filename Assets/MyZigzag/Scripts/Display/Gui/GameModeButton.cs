using MyZigzag.Scripts.Core.Game.Def;
using MyZigzag.Scripts.Core.Game.Observer;
using MyZigzag.Scripts.Core.Game.Observer.Configurator;
using MyZigzag.Scripts.Core.Player.Def;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MyZigzag.Scripts.Display.Gui
{
    [DisallowMultipleComponent]
    public sealed class GameModeButton : MonoBehaviour
    {
        #region GameModeButton

        [SerializeField]
        private Button _button;

        [SerializeField]
        private GameDefSO _gameDef;

        private IGameStatusObserver GameStatusObserver;
        private IPlayerBallDef PlayerBallDef;

        private void Awake()
        {
            _button.CheckNull();
            _gameDef.CheckNull();

            _button.onClick.AddListener(OnButtonClickHandler);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnButtonClickHandler);
        }

        [Inject]
        private void Construct(IGameStatusObserver gameStatusObserver, IPlayerBallDef playerBallDef)
        {
            GameStatusObserver = gameStatusObserver.CheckNull();
            PlayerBallDef = playerBallDef.CheckNull();
        }

        private void OnButtonClickHandler()
        {
            var gameConfigurator = new GameConfigurator(_gameDef, PlayerBallDef);
            GameStatusObserver.StartGame(gameConfigurator);
        }

        #endregion
    }
}