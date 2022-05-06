using Collectables;
using Core;
using UnityEngine;

namespace Knife
{
    public class KnifeBase : MonoBehaviour
    {
        private Spawner _spawner;
        private GameManager _gameManager;

        private void Awake()
        {
            _spawner = FindObjectOfType<Spawner>();
            _gameManager = FindObjectOfType<GameManager>();
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Knife"))
            {
                _gameManager.GameOver();
                return;
            }

            if (other.transform.TryGetComponent(out ICollectable collectable))
            {
                collectable.Collect();
                return;
            }

            if (other.transform.CompareTag("Target")) 
                _spawner.SpawnKnife();
        }
    }
}