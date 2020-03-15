using System.Collections.Generic;
using MyZigzag.Scripts.Core.Game.Def;
using MyZigzag.Scripts.Core.Player.Def;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;
using Zenject;

namespace MyZigzag.Scripts.Composition.Installer
{
    [CreateAssetMenu(menuName = "MyZigzag/ConfigInstaller")]
    public sealed class ConfigInstallerSO : ScriptableObjectInstaller<ConfigInstallerSO>
    {
        #region ConfigInstallerSO

        [SerializeField]
        private List<GameDefSO> _gameDefs;

        [SerializeField]
        private PlayerBallDefSO _playerBallDef;

        private void Awake()
        {
            _gameDefs.CheckNull();
            _playerBallDef.CheckNull();
        }

        private void InstallGameDefs()
        {
            foreach (var gameDef in _gameDefs)
            {
                Container.Bind<IGameDef>().FromInstance(gameDef).AsCached().NonLazy();
                Container.QueueForInject(gameDef.BoardTileGenerator);
                Container.QueueForInject(gameDef.LootGenerator);
            }
        }

        #endregion

        #region ScriptableObjectInstallerBase

        public override void InstallBindings()
        {
            InstallGameDefs();
            
            Container.Bind<IPlayerBallDef>().FromInstance(_playerBallDef).AsSingle().NonLazy();
        }

        #endregion
    }
}