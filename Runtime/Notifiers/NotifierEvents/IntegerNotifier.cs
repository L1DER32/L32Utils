﻿using System.Collections.Generic;
using UnityEngine;

namespace L32Utils.Notifiers
{
    [CreateAssetMenu(fileName = "New Integer Notifier", menuName = "Notifiers/Integer Notifier", order = 151)]
    public class IntegerNotifier : ScriptableObject, INotifier<int>
    {
        List<INotifierListener<int>> listeners = new List<INotifierListener<int>>();

        public void InvokeNotifier(int value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnNotified(value);
        }

        public void RegisterListener(INotifierListener<int> listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void UnregisterListener(INotifierListener<int> listener) =>
            listeners.Remove(listener);
    }
}