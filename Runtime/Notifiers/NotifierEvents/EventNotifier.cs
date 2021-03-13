using System;
using System.Collections.Generic;
using UnityEngine;

namespace L32Utils.Notifiers
{
    [CreateAssetMenu(fileName = "New Event Notifier", menuName = "Notifiers/Event Notifier", order = 151)]
    public class EventNotifier : ScriptableObject, INotifier
    {
        List<INotifierListener> listeners = new List<INotifierListener>();

        public event Action onNotified;

        public void InvokeNotifier()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnNotified();

            onNotified?.Invoke();
        }

        public void RegisterListener(INotifierListener listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void UnregisterListener(INotifierListener listener) =>
            listeners.Remove(listener);
    }
}
