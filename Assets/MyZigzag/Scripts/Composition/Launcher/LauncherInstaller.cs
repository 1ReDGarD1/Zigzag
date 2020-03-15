using MyZigzag.Scripts.Composition.Installer;
using MyZigzag.Scripts.Core.Game.Observer;
using MyZigzag.Scripts.Main.Decorator;
using UnityEngine;
using Zenject;

namespace MyZigzag.Scripts.Composition.Launcher
{
    [DisallowMultipleComponent]
    public sealed class LauncherInstaller : MonoInstaller
    {
        #region MonoInstallerBase

        public override void InstallBindings()
        {
            CoreInstaller.Install(Container);

            Container.Decorate<IGameStatusObserver>().With<GameStatusObserverDecorator>().AsSingle().NonLazy();

            Container.Bind<IInitializable>().To<LauncherInitializable>().AsSingle().NonLazy();
        }

        #endregion
    }
}