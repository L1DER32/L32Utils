using UnityEngine;
using UnityEngine.Events;

namespace L32Utils.Notifiers
{
    public class TransformNotifierListener : MonoBehaviour, INotifierListener<Transform>
    {
        public TransformNotifier notifierEvent = null;

        [Space(10)]
        public UnityEvent<Transform> notifierEventResonse;

        public void OnNotified(Transform value) =>
            notifierEventResonse?.Invoke(value);

        void OnEnable() =>
            notifierEvent.RegisterListener(this);

        void OnDisable() =>
            notifierEvent.UnregisterListener(this);
    }
}
