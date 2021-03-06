﻿using System.Collections.Generic;
using UnityEngine;
using System;

namespace L32Utils.Notifiers
{
    [CreateAssetMenu(fileName = "New Boolean Notifier", menuName = "Notifiers/Boolean Notifier", order = 171)]
    public class BooleanNotifier : ScriptableObject, INotifier<bool>
    {
        List<INotifierListener<bool>> listeners = new List<INotifierListener<bool>>();

        public event Action<bool> onNotified;

        public void InvokeNotifier(bool value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnNotified(value);

            onNotified?.Invoke(value);
        }

        public void RegisterListener(INotifierListener<bool> listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void UnregisterListener(INotifierListener<bool> listener) =>
            listeners.Remove(listener);
    }
}
