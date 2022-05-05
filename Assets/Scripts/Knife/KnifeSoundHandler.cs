using UnityEngine;

namespace Knife
{
    public class KnifeSoundHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource knifeHit, targetHit;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Knife"))
            {
                knifeHit.Play(0);
            }

            if (other.transform.CompareTag("Target"))
            {
                targetHit.Play(0);
            }
        }
    }
}