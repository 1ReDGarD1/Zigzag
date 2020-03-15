using MyZigzag.Scripts.Core.Loot.Storage;
using MyZigzag.Scripts.Display.Foundation.View;
using MyZigzag.Scripts.Utility.Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MyZigzag.Scripts.Display.Gui
{
    [DisallowMultipleComponent]
    public sealed class HudScreen : BaseViewElement
    {
        #region HudScreen

        [SerializeField]
        private Text _crystalCountText;

        private ICrystalLootStorage _crystalLootStorage;

        private void Awake()
        {
            _crystalCountText.CheckNull();

            SetCrystalCountText(0);
        }

        private void OnDestroy()
        {
            _crystalLootStorage.OnChangeTotalCrystals -= OnChangeTotalCrystalsHandler;
        }

        [Inject]
        private void Construct(ICrystalLootStorage crystalLootStorage)
        {
            _crystalLootStorage = crystalLootStorage.CheckNull();
            _crystalLootStorage.OnChangeTotalCrystals += OnChangeTotalCrystalsHandler;
        }

        private void OnChangeTotalCrystalsHandler(object sender, int totalCrystals)
        {
            SetCrystalCountText(totalCrystals);
        }

        private void SetCrystalCountText(int totalCrystals)
        {
            _crystalCountText.text = $"Crystal:{totalCrystals}";
        }

        #endregion
    }
}