using UnityEngine;
using UnityEngine.Events;

namespace L32Utils.Notifiers
{
    public class TransformNotifierListener : MonoBehaviour, INotifierListener<Transform>
    {
        public TransformNotifier notifier = null;

        [Space(10)]
        public UnityEvent<Transform> notifierEventResonse;

        public void OnNotified(Transform value) =>
            notifierEventResonse?.Invoke(value);

        void OnEnable() =>
            notifier.RegisterListener(this);

        void OnDisable() =>
            notifier.UnregisterListener(this);

        void OnDestroy() =>
            notifier.UnregisterListener(this);
    }
}
