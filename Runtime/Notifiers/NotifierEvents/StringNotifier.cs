using System.Collections.Generic;
using UnityEngine;

namespace L32Utils.Notifiers
{
    [CreateAssetMenu(fileName = "New String Notifier", menuName = "Notifiers/String Notifier", order = 151)]
    public class StringNotifier : ScriptableObject
    {
        List<StringNotifierListener> listeners = new List<StringNotifierListener>();

        public void InvokeNotifier(string value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnNotified(value);
        }

        public void RegisterListener(StringNotifierListener listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void UnregisterListener(StringNotifierListener listener) =>
            listeners.Remove(listener);
    }
}