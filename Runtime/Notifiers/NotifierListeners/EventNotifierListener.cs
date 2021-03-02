using UnityEngine;
using UnityEngine.Events;

namespace L32Utils.Notifiers
{
    public class EventNotifierListener : MonoBehaviour, INotifierListener
    {
        public EventNotifier notifier = null;

        [Space(10)]
        public UnityEvent notifierEventResonse;

        public void OnNotified() =>
            notifierEventResonse?.Invoke();

        void OnEnable() =>
            notifier.RegisterListener(this);

        void OnDisable() =>
            notifier.UnregisterListener(this);

        void OnDestroy() =>
            notifier.UnregisterListener(this);
    }
}
