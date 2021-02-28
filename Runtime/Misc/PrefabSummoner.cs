using UnityEngine;

namespace L32Utils
{
    public class PrefabSummoner : MonoBehaviour
    {
        public GameObject prefab;

        public Vector3 posOffset;
        public Vector3 rotOffset;

        [Space(10)]
        public bool summonOnStart = true;

        void Start()
        {
            if (summonOnStart)
                Summon();
        }

        public void Summon()
        {
            if (prefab != null)
            {
                GameObject go = Instantiate(prefab, transform);
                go.transform.localPosition = posOffset;
                go.transform.localRotation = Quaternion.Euler(rotOffset);
                Destroy(this);
            }
        }
    }
}
