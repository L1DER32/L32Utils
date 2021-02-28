using UnityEngine;
using UnityEngine.Events;

namespace L32Utils.Notifiers
{
    public class StringNotifierListener : MonoBehaviour, INotifierListener<string>
    {
        public StringNotifier notifierEvent = null;

        [Space(10)]
        public UnityEvent<string> notifierEventResonse;

        public void OnNotified(string value) =>
            notifierEventResonse?.Invoke(value);

        void OnEnable() =>
            notifierEvent.RegisterListener(this);

        void OnDisable() =>
            notifierEvent.UnregisterListener(this);
    }
}
