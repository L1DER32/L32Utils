﻿using UnityEngine;

namespace L32Utils
{
    public class Rotator : MonoBehaviour
    {
        public Vector3 degreesPerSecond = Vector3.zero;
        public Space relativeSpace = Space.Self;
        public bool rotate = true;

        [Space(10)]
        public bool preferLateUpdate = false;

        void Update()
        {
            if (!preferLateUpdate && rotate)
                transform.Rotate(degreesPerSecond * Time.deltaTime, relativeSpace);
        }

        private void LateUpdate()
        {
            if (preferLateUpdate && rotate)
                transform.Rotate(degreesPerSecond * Time.deltaTime, relativeSpace);
        }
    }
}