using UnityEngine;

namespace Core
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        private GameManager _gameManager;
        private ObjectPool _pool;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _gameManager.OnGameStartedEvent += OnGameStarted;
            _pool = FindObjectOfType<ObjectPool>();
        }

        private void OnGameStarted() => Instantiate(target, new Vector3(0, 3, 0), Quaternion.identity);

        public void SpawnKnife()
        {
            var knifeInstance = _pool.GetPooledObject();
            if (knifeInstance != null)
            {
                knifeInstance.transform.position = new Vector3(0, -3, 0);
                knifeInstance.SetActive(true);
            }
            else
            {
                print("win");
            }

            //Instantiate(knife, new Vector3(0, -3, 0), knife.transform.rotation);
        }
    }
}