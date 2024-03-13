using UnityEngine;

namespace Utilities
{
    public static class BehaviorUtilities
    {
        public static void RotateContinuously(Transform transform, float rotationSpeed)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}