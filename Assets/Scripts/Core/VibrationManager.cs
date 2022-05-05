using UnityEngine;

namespace Core
{
    public class VibrationManager : MonoBehaviour
    {
        private void Awake() => Vibration.Init();

        private void Vibrate() => Vibration.VibratePop();

        private void OnCollisionEnter2D() => Vibrate();
    }
}