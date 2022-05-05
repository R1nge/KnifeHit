using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public event Action OnGameStartedEvent;
        public event Action OnGameOverEvent;
        public bool HasStarted { get; private set; }

        private void Start() => Application.targetFrameRate = 9999; //To maintain stable 60+ fps

        public void StartGame()
        {
            OnGameStartedEvent?.Invoke();
            HasStarted = true;
            SetTimeScale(1);
        }

        public void GameOver()
        {
            OnGameOverEvent?.Invoke();
            HasStarted = false;
            SetTimeScale(0);
        }

        private void SetTimeScale(int amount) => Time.timeScale = amount;

        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}