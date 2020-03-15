using System;
using MyZigzag.Scripts.Core.Game.Observer.Components;
using MyZigzag.Scripts.Core.Game.Observer.Configurator;
using MyZigzag.Scripts.Utility.Common;

namespace MyZigzag.Scripts.Core.Game.Observer
{
    public sealed class GameStatusObserver : IGameStatusObserver
    {
        #region GameStatusObserver

        private readonly IGameComponentInitializable[] ComponentsInitializable;
        private readonly IGameComponentStarting[] ComponentsStarting;
        private readonly IGameComponentCompleted[] ComponentsCompleted;

        public GameStatusObserver(IGameComponentInitializable[] componentsInitializable,
            IGameComponentStarting[] componentsStarting,
            IGameComponentCompleted[] componentsCompleted)
        {
            CheckComponents(out ComponentsInitializable, componentsInitializable);
            CheckComponents(out ComponentsStarting, componentsStarting);
            CheckComponents(out ComponentsCompleted, componentsCompleted);
        }

        private void CheckComponents<T>(out T[] components, T[] sourceComponents)
        {
            components = !sourceComponents.IsEmpty() ? sourceComponents : Array.Empty<T>();
        }

        #endregion

        #region IGameStatusObserver

        public void StartGame(IGameConfigurator gameConfigurator)
        {
            Array.ForEach(ComponentsInitializable, component => component.GameInitialize(gameConfigurator));
            Array.ForEach(ComponentsStarting, component => component.GameStarting());
        }

        public void CompleteGame()
        {
            Array.ForEach(ComponentsCompleted, component => component.GameComplete());
        }

        #endregion
    }
}