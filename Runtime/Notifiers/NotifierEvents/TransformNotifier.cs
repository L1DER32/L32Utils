﻿using System.Collections.Generic;
using UnityEngine;

namespace L32Utils.Notifiers
{
    [CreateAssetMenu(fileName = "New Transform Notifier", menuName = "Notifiers/Transform Notifier", order = 151)]
    public class TransformNotifier : ScriptableObject, INotifier<Transform>
    {
        List<INotifierListener<Transform>> listeners = new List<INotifierListener<Transform>>();

        public void InvokeNotifier(Transform value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnNotified(value);
        }

        public void RegisterListener(INotifierListener<Transform> listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void UnregisterListener(INotifierListener<Transform> listener) =>
            listeners.Remove(listener);
    }
}