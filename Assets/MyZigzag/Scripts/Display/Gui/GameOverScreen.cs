using MyZigzag.Scripts.Display.Foundation.Manager;
using MyZigzag.Scripts.Display.Foundation.Screen;
using MyZigzag.Scripts.Display.Foundation.View;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MyZigzag.Scripts.Display.Gui
{
    [DisallowMultipleComponent]
    public sealed class GameOverScreen : BaseViewElement
    {
        #region GameOverScreen

        [SerializeField]
        private Button _exitButton;

        private IGuiManager _guiManager;

        private void Awake()
        {
            _exitButton.CheckNull();

            _exitButton.onClick.AddListener(OnExitButtonClickHandler);
        }

        private void OnDestroy()
        {
            _exitButton.onClick.RemoveListener(OnExitButtonClickHandler);
        }

        [Inject]
        private void Construct(IGuiManager guiManager)
        {
            _guiManager = guiManager.CheckNull();
        }

        private void OnExitButtonClickHandler()
        {
            _guiManager.ShowScreen(UiScreenKind.MainMenu);
        }

        #endregion
    }
}