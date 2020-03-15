using MyZigzag.Scripts.Display.Foundation.Manager;
using MyZigzag.Scripts.Display.Foundation.Screen;
using MyZigzag.Scripts.Display.Foundation.Screen.Repository;
using UnityEngine;
using Zenject;

namespace MyZigzag.Scripts.Composition.Installer
{
    [DisallowMultipleComponent]
    public sealed class GuiInstaller : MonoInstaller
    {
        #region MonoInstaller

        public override void InstallBindings()
        {
            Container.Bind<IGuiManager>().To<GuiManager>().AsSingle().NonLazy();
            Container.Bind<IUiScreenRepository>().To<UiScreenRepository>().AsSingle().NonLazy();

            var screens = GetComponentsInChildren<IUiScreen>(true);
            foreach (var screen in screens)
            {
                Container.Bind<IUiScreen>().FromInstance(screen).AsCached().NonLazy();
                Container.QueueForInject(screen);
            }
        }

        #endregion
    }
}