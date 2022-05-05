using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ObjectPool : MonoBehaviour
    {
        public GameObject objectToPool;
        public int amountToPool;
        private List<GameObject> _pooledObjects;

        private void Start()
        {
            _pooledObjects = new List<GameObject>();
            for (int i = 0; i < amountToPool; i++)
            {
                var tmp = Instantiate(objectToPool);
                tmp.SetActive(false);
                _pooledObjects.Add(tmp);
            }
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < amountToPool; i++)
            {
                if (!_pooledObjects[i].activeInHierarchy)
                {
                    return _pooledObjects[i];
                }
            }

            return null;
        }
    }
}