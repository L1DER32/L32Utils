using UnityEngine;
using UnityEngine.Events;

namespace L32Utils.Notifiers
{
    public class FloatNotifierListener : MonoBehaviour, INotifierListener<float>
    {
        public FloatNotifier notifierEvent = null;

        [Space(10)]
        public UnityEvent<float> notifierEventResonse;

        public void OnNotified(float value) =>
            notifierEventResonse?.Invoke(value);

        void OnEnable() =>
            notifierEvent.RegisterListener(this);

        void OnDisable() =>
            notifierEvent.UnregisterListener(this);
    }
}


