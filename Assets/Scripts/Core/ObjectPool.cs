using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ObjectPool : MonoBehaviour
    {
        private List<GameObject> _pooledObjects;
        public GameObject objectToPool;
        public int amountToPool;
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _gameManager.OnGameStartedEvent += OnGameStarted;
        }

        private void OnGameStarted()
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