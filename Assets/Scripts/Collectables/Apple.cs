using UnityEngine;

namespace Collectables
{
    public class Apple : MonoBehaviour, ICollectable
    {
        public void Collect()
        {
            print("Collected");
        }
    }
}