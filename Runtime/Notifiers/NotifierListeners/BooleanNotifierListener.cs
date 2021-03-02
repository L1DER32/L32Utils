using UnityEngine;
using UnityEngine.Events;

namespace L32Utils.Notifiers
{
    public class BooleanNotifierListener : MonoBehaviour, INotifierListener<bool>
    {
        public BooleanNotifier notifier = null;

        [Space(10)]
        public UnityEvent<bool> notifierEventResonse;

        public void OnNotified(bool value) =>
            notifierEventResonse?.Invoke(value);

        void OnEnable() =>
            notifier.RegisterListener(this);

        void OnDisable() =>
            notifier.UnregisterListener(this);

        void OnDestroy() =>
            notifier.UnregisterListener(this);
    }
}
