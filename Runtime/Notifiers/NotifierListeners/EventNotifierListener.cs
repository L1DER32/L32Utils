using UnityEngine;
using UnityEngine.Events;

namespace L32Utils.Notifiers
{
    public class EventNotifierListener : MonoBehaviour, INotifierListener
    {
        public EventNotifier notifierEvent = null;

        [Space(10)]
        public UnityEvent notifierEventResonse;

        public void OnNotified() =>
            notifierEventResonse?.Invoke();

        void OnEnable() =>
            notifierEvent.RegisterListener(this);

        void OnDisable() =>
            notifierEvent.UnregisterListener(this);
    }
}
