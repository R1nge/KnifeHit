using UnityEngine;

namespace Core
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject target, apple, knife;
        private GameManager _gameManager;
        private ObjectPool _pool;
        private readonly Vector3 _targetSpawnPosition = new Vector3(0, 3, 0);
        private readonly Vector3 _knifeSpawnPosition = new Vector3(0, -3, 0);

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _gameManager.OnGameStartedEvent += OnGameStarted;
            _pool = FindObjectOfType<ObjectPool>();
        }

        private void OnGameStarted()
        {
            Instantiate(target, _targetSpawnPosition, Quaternion.identity);
        }

        public void SpawnKnife()
        {
            var knifeInstance = _pool.GetPooledObject();
            if (knifeInstance != null)
            {
                knifeInstance.transform.position = _knifeSpawnPosition;
                knifeInstance.SetActive(true);
            }
            else
            {
                _gameManager.Win();
            }
        }

        private void SpawnKnifeTarget(Transform origin)
        {
        }

        private void SpawnAppleTarget(Transform origin)
        {
        }
    }
}