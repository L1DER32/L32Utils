using UnityEngine;
using UnityEngine.Events;

namespace L32Utils.Notifiers
{
    public class FloatNotifierListener : MonoBehaviour, INotifierListener<float>
    {
        public FloatNotifier notifier = null;

        [Space(10)]
        public UnityEvent<float> notifierEventResonse;

        public void OnNotified(float value) =>
            notifierEventResonse?.Invoke(value);

        void OnEnable() =>
            notifier.RegisterListener(this);

        void OnDisable() =>
            notifier.UnregisterListener(this);

        void OnDestroy() =>
            notifier.UnregisterListener(this);
    }
}


