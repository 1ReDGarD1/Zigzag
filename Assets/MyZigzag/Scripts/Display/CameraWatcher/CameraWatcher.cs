using MyZigzag.Scripts.Utility.Common;
using UnityEngine;
using Zenject;

namespace MyZigzag.Scripts.Display.CameraWatcher
{
    public sealed class CameraWatcher : ILateTickable
    {
        #region CameraWatcher

        private readonly Camera Camera;
        private readonly ICameraWatcherTarget Target;

        private Vector3 _oldPosition;

        public CameraWatcher(Camera camera, ICameraWatcherTarget target)
        {
            Camera = camera.CheckNull();
            Target = target.CheckNull();

            _oldPosition = target.Position;
        }

        #endregion

        #region ILateTickable

        public void LateTick()
        {
            var delta = _oldPosition - Target.Position;
            delta.y = 0;

            Camera.transform.position -= delta;

            _oldPosition = Target.Position;
        }

        #endregion
    }
}