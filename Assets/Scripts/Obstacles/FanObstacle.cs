using UnityEngine;
using Utilities;

namespace Obstacles
{
    public class FanObstacle : MonoBehaviour
    {
        private void Update()
        {
            BehaviorUtilities.RotateContinuously(transform, 15f);
        }
    }
}