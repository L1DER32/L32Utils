using UnityEngine;
using UnityEngine.Events;

namespace L32Utils.Notifiers
{
    public class IntegerNotifierListener : MonoBehaviour, INotifierListener<int>
    {
        public IntegerNotifier notifierEvent = null;

        [Space(10)]
        public UnityEvent<int> notifierEventResonse;

        public void OnNotified(int value) =>
            notifierEventResonse?.Invoke(value);

        void OnEnable() =>
            notifierEvent.RegisterListener(this);

        void OnDisable() =>
            notifierEvent.UnregisterListener(this);
    }
}
