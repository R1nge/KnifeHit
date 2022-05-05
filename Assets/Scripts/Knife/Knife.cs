using Core;
using UnityEngine;

namespace Knife
{
    public class Knife : MonoBehaviour
    {
        private Spawner _spawner;
        private GameManager _gameManager;

        private void Awake()
        {
            _spawner = FindObjectOfType<Spawner>();
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Target"))
                _spawner.SpawnKnife();

            if (other.transform.CompareTag("Knife"))
                _gameManager.GameOver();
        }
    }
}