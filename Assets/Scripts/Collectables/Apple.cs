using Core;
using UnityEngine;

namespace Collectables
{
    public class Apple : MonoBehaviour, ICollectable
    {
        [SerializeField] private int amount;
        private Wallet _wallet;

        private void Awake() => _wallet = FindObjectOfType<Wallet>();

        private void OnTriggerEnter2D(Collider2D other) => Collect();

        public void Collect()
        {
            _wallet.Earn(amount);
            Destroy(gameObject);
        }
    }
}