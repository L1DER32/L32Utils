using System;

namespace L32Utils.Notifiers
{
    public interface INotifier
    {
        event Action onNotified;

        void InvokeNotifier();

        void RegisterListener(INotifierListener listener);

        void UnregisterListener(INotifierListener listener);
    }

    public interface INotifier<T>
    {
        event Action<T> onNotified;

        void InvokeNotifier(T value);

        void RegisterListener(INotifierListener<T> listener);

        void UnregisterListener(INotifierListener<T> listener);
    }
}