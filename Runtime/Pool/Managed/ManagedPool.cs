using System.Collections.Generic;
using UnityEngine;

namespace L32Utils.Pooling
{
    public class ManagedPool<T> : GamePool<T>, IManagedPool<T> where T : Component
    {
       protected List<T> activeObjects = new List<T>();

        public override void ReturnToPool(T pooledObj)
        {
            if (activeObjects.Contains(pooledObj))
                activeObjects.Remove(pooledObj);
            base.ReturnToPool(pooledObj);
        }

        public virtual T GetAutoReturingFromPool()
        {
            T pooled = GetFromPool(true);
            activeObjects.Add(pooled);
            return pooled;
        }

        private void Update() =>
            CheckActivePooledObjects();

        protected virtual void CheckActivePooledObjects()
        {
            if (activeObjects.Count > 0)
            {
                for (int i = activeObjects.Count - 1; i >= 0; i--)
                {
                    T activeObj = activeObjects[i];
                    if (activeObj != null && !activeObj.gameObject.activeInHierarchy)
                        ReturnToPool(activeObj);
                }
            }
        }

        public virtual void ReturnAllToPool()
        {
            for (int i = activeObjects.Count - 1; i >= 0; i--)
            {
                T obj = activeObjects[i];
                if (obj != null)
                    ReturnToPool(activeObjects[i]);
            }

            activeObjects.Clear();
        }

        public override void DeinitializePool()
        {
            ReturnAllToPool();
            base.DeinitializePool();
        }

    }
}
