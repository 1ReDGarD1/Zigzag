using UnityEngine;

namespace MyZigzag.Scripts.Display.CameraWatcher
{
    public interface ICameraWatcherTarget
    {
        #region ICameraWatcherTarget

        Vector3 Position { get; }

        #endregion
    }
}