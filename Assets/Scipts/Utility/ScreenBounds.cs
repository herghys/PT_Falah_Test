using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herghys
{
    public class ScreenBounds : MonoBehaviour
    {
        static Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        public static Vector2 BoundarySize { get { return screenBounds; } }
        public static float BoundaryWidth { get { return BoundarySize.x; } }

        public static float BoundaryHeight { get { return BoundarySize.y; } }
    }
}
