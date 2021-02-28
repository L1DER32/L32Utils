using UnityEngine;

namespace L32Utils
{
    public class RotateTowards : MonoBehaviour
    {
        [Tooltip("Target to which this will be rotated.")]
        public Transform lookAtTransform;

        [Space(10)]
        public bool lockXAxis = false;
        public bool lockYAxis = false;
        public bool lockZAxis = false;

        [Space(10)]
        public bool autoRotate = true;
        public bool preferLateUpdate = false;


        void Update()
        {
            if (autoRotate && !preferLateUpdate)
                transform.rotation = GetRotation(transform,
                    lookAtTransform.position, lockXAxis, lockYAxis, lockZAxis);
        }

        private void LateUpdate()
        {
            if (autoRotate && preferLateUpdate)
                transform.rotation = GetRotation(transform,
                   lookAtTransform.position, lockXAxis, lockYAxis, lockZAxis);
        }

        public static Quaternion GetRotation(Transform objToRotate, Vector3 worldSpaceLookPoint,
            bool originalXRotation = false, bool originalYRotation = false, bool originalZRotation = false)
        {
            Quaternion nextRotation = Quaternion.LookRotation(worldSpaceLookPoint - objToRotate.position);

            nextRotation.eulerAngles = new Vector3(
                originalXRotation ? objToRotate.rotation.x : nextRotation.eulerAngles.x,
                originalYRotation ? objToRotate.rotation.y : nextRotation.eulerAngles.y,
                originalZRotation ? objToRotate.rotation.z : nextRotation.eulerAngles.z);
                
            return nextRotation;
        }
    }
}
