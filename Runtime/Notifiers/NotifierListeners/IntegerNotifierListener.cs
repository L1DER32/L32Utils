using UnityEngine;
using UnityEngine.Events;

namespace L32Utils.Notifiers
{
    public class IntegerNotifierListener : MonoBehaviour, INotifierListener<int>
    {
        public IntegerNotifier notifier = null;

        [Space(10)]
        public UnityEvent<int> notifierEventResonse;

        public void OnNotified(int value) =>
            notifierEventResonse?.Invoke(value);

        void OnEnable() =>
            notifier.RegisterListener(this);

        void OnDisable() =>
            notifier.UnregisterListener(this);

        void OnDestroy() =>
            notifier.UnregisterListener(this);
    }
}
