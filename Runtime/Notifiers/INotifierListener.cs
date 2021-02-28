
namespace L32Utils.Notifiers
{
    public interface INotifierListener
    {
        void OnNotified();
    }

    public interface INotifierListener<T>
    {
        void OnNotified(T value);
    }
}

