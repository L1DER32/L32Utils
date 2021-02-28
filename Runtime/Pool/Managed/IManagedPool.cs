using UnityEngine;

namespace L32Utils.Pooling
{
    public interface IManagedPool<T> : IGamePool<T> where T : Component
    {
        T GetAutoReturingFromPool();

        void ReturnAllToPool();
    }
}
