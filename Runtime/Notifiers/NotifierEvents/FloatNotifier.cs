using System;
using System.Collections.Generic;
using UnityEngine;

namespace L32Utils.Notifiers
{
    [CreateAssetMenu(fileName = "New Float Notifier", menuName = "Notifiers/Float Notifier", order = 171)]
    public class FloatNotifier : ScriptableObject, INotifier<float>
    {
        List<INotifierListener<float>> listeners = new List<INotifierListener<float>>();

        public event Action<float> onNotified;

        public void InvokeNotifier(float value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnNotified(value);

            onNotified?.Invoke(value);
        }

        public void RegisterListener(INotifierListener<float> listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void UnregisterListener(INotifierListener<float> listener) =>
            listeners.Remove(listener);
    }
}


