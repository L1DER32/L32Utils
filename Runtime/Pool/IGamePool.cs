using System;
using UnityEngine;

namespace L32Utils.Pooling
{
    public interface IGamePool<T> where T : Component
    {
        T OriginalObject { get; set; }

        int StartCount { get; set; }

        bool IsInitialized { get; }

        event Action OnInitialized;

        void InitializePool();

        T GetFromPool(bool setActive = true);

        void ReturnToPool(T pooledObj);

        void DeinitializePool();
    }
}
