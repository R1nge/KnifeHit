using Core;
using UnityEngine;

namespace Knife
{
    public class KnifeMovement : MonoBehaviour
    {
        [SerializeField] private float force;
        private readonly Vector2 _direction = new Vector2(0, 1);
        private bool _hasCollided;
        private Rigidbody2D _rigidbody;
        private GameManager _gameManager;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            if (!_gameManager.HasStarted) return;
            if (_hasCollided) return;
            Throw();
        }

        private void Throw() => _rigidbody.AddForce(_direction * force, ForceMode2D.Impulse);

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Target")) return;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0;
            _rigidbody.isKinematic = true;
            transform.parent = other.transform;
            _hasCollided = true;
        }
    }
}