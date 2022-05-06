using UnityEngine;

namespace Core
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject target, apple, knife;
        [SerializeField] private SpawnChance appleChance;
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
            var targetInstance = Instantiate(target, _targetSpawnPosition, Quaternion.identity);
            Spawn(knife, targetInstance.transform, 1f, Random.Range(1, 4));
            if (Random.Range(0, 100) <= appleChance.chance)
            {
                Spawn(apple, targetInstance.transform, 1.3f, 1);
            }
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

        private void Spawn(GameObject gameObject, Transform origin, float radius, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var instance = Instantiate(gameObject,
                    RandomCirclePosition(origin.position, radius),
                    Quaternion.identity,
                    origin);

                Vector3 dir = instance.transform.position - origin.transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
                instance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }

        private Vector2 RandomCirclePosition(Vector2 center, float radius)
        {
            float ang = Random.value * 360;
            Vector2 pos;
            pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
            pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
            return pos;
        }
    }
}