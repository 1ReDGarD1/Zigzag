using UnityEngine;

namespace MyZigzag.Scripts.Display.Foundation.View
{
    public abstract class BaseViewElement : MonoBehaviour, IViewElement
    {
        #region BaseViewElement

        private bool IsVisible => gameObject.activeSelf;

        #endregion
        
        #region IViewElement
        
        public virtual void Show()
        {
            if (IsVisible)
            {
                return;
            }

            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            if (!IsVisible)
            {
                return;
            }

            gameObject.SetActive(false);
        }

        #endregion
    }
}