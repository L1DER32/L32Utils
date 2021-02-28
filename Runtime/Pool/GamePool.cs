using System;
using System.Collections.Generic;
using UnityEngine;

namespace L32Utils.Pooling
{
    public abstract class GamePool<T> : MonoBehaviour, IGamePool<T> where T : Component
    {
        [SerializeField]
        [Tooltip("Object that Pool will instantate to create copies.")]
        protected T originalObject = null;

        public T OriginalObject
        {
            get => originalObject;
            set
            {
                if (!IsInitialized)
                    originalObject = value;
                else
                    Debug.LogError("Can't change original object of initialized Pool");
            }
        }

        [Tooltip("Number of elements Pool will start with.")]
        [SerializeField]
        protected int startCount = 4;

        public int StartCount
        {
            get => startCount;
            set
            {
                if (!IsInitialized)
                    startCount = value;
                else
                    Debug.LogError("Can't change Start object Count of initialized Pool");
            }
        }

        protected Queue<T> objectPool = new Queue<T>();

        public bool IsInitialized { get; protected set; }

        [Tooltip("If true Pool will not get destroyed on Scene change.")]
        public bool dontDestroyOnLoad = true;

        public event Action OnInitialized;

        protected virtual void Awake()
        {
            if (dontDestroyOnLoad)
                DontDestroyOnLoad(this.gameObject);
        }

        public virtual void InitializePool()
        {
            if (!IsInitialized)
            {
                if (originalObject != null)
                {
                    IsInitialized = true;
                    if (startCount > 0)
                        GrowPool(startCount);
                    OnInitialized?.Invoke();
                }
                else
                    Debug.LogError("Can't Initialize Pool of " + typeof(T) + ", original object is null!");
            }
            else
                Debug.LogError("Pool of " + typeof(T) + " is already initialized!");
        }

        protected virtual void GrowPool(int count = 1)
        {
            if (IsInitialized)
            {
                if (count > 0)
                {
                    GameObject instanceToAdd = GameObject.Instantiate(originalObject.gameObject, transform);
                    T pooled = instanceToAdd.GetComponent<T>();
                    ReturnToPool(pooled);
                }
                else
                    Debug.LogError("Can't grow Pool of " + typeof(T) + " for less than one!");
            }
            else
                Debug.LogError("Can't Grow Pool of " + typeof(T) + ", it has not initialized yet!");
        }

        public virtual void ReturnToPool(T pooledObj)
        {
            if (IsInitialized)
            {
                pooledObj.gameObject.SetActive(false);
                objectPool.Enqueue(pooledObj);
            }
            else
                Debug.LogError("Can't Return Object to Pool of " + typeof(T) + ", it has not initialized yet!");
        }

        public virtual T GetFromPool(bool setActive = true)
        {
            if (IsInitialized)
            {
                if (objectPool.Count == 0)
                    GrowPool();

                T pooledObj = objectPool.Dequeue();
                if (setActive)
                    pooledObj.gameObject.SetActive(true);
                return pooledObj;
            }
            else
            {
                Debug.LogError("Can't Get Object from Pool of " + typeof(T) + ", it has not initialized yet!");
                return null;
            }
        }

        public virtual void DeinitializePool()
        {
            int count = objectPool.Count;
            for (int i = 0; i < count; i++)
                Destroy(GetFromPool().gameObject);

            objectPool.Clear();
            IsInitialized = false;
        }
    }
}