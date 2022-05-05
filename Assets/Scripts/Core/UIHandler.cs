using UnityEngine;

namespace Core
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private Canvas mainMenu, skins, inGameMenu, winMenu, gameOverMenu;
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _gameManager.OnGameStartedEvent += OnGameStarted;
            _gameManager.OnWinEvent += OnWin;
            _gameManager.OnGameOverEvent += OnGameOver;
        }

        private void Start()
        {
            mainMenu.gameObject.SetActive(true);
            skins.gameObject.SetActive(false);
            inGameMenu.gameObject.SetActive(false);
            winMenu.gameObject.SetActive(false);
            gameOverMenu.gameObject.SetActive(false);
        }

        private void OnGameStarted()
        {
            mainMenu.gameObject.SetActive(false);
            skins.gameObject.SetActive(false);
            inGameMenu.gameObject.SetActive(true);
            winMenu.gameObject.SetActive(false);
            gameOverMenu.gameObject.SetActive(false);
        }

        private void OnWin()
        {
            mainMenu.gameObject.SetActive(false);
            skins.gameObject.SetActive(false);
            inGameMenu.gameObject.SetActive(false);
            winMenu.gameObject.SetActive(true);
            gameOverMenu.gameObject.SetActive(false);
        }

        private void OnGameOver()
        {
            mainMenu.gameObject.SetActive(false);
            skins.gameObject.SetActive(false);
            inGameMenu.gameObject.SetActive(false);
            winMenu.gameObject.SetActive(false);
            gameOverMenu.gameObject.SetActive(true);
        }

        public void ShowSkinsMenu()
        {
            mainMenu.gameObject.SetActive(false);
            skins.gameObject.SetActive(true);
            inGameMenu.gameObject.SetActive(false);
            winMenu.gameObject.SetActive(false);
            gameOverMenu.gameObject.SetActive(false);
        }

        public void HideSkinsMenu()
        {
            mainMenu.gameObject.SetActive(true);
            skins.gameObject.SetActive(false);
            inGameMenu.gameObject.SetActive(false);
            winMenu.gameObject.SetActive(false);
            gameOverMenu.gameObject.SetActive(false);
        }
    }
}