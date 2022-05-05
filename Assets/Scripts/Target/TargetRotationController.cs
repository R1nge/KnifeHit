using UnityEngine;

namespace Target
{
    public class TargetRotationController : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void FixedUpdate() => transform.Rotate(new Vector3(0, 0, 1), speed * Time.fixedDeltaTime);
    }
}