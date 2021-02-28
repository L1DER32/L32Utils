
namespace L32Utils.Notifiers
{
    public interface INotifier
    {
        void InvokeNotifier();

        void RegisterListener(INotifierListener listener);

        void UnregisterListener(INotifierListener listener);
    }

    public interface INotifier<T>
    {
        void InvokeNotifier(T value);

        void RegisterListener(INotifierListener<T> listener);

        void UnregisterListener(INotifierListener<T> listener);
    }
}