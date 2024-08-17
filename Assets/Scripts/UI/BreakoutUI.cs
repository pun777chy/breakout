using UnityEngine;
using UnityEngine.UI;
using Breakout.Managers;
using UnityEngine.SceneManagement;

namespace Breakout.UI
{
    public class BreakoutUI : MonoBehaviour
    {
        [SerializeField] private Text instructionText;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text livesText;
        [SerializeField] private GameObject endScreen;
        [SerializeField] private Text endScreenText;
        [SerializeField] private Button restartBtn;

      

        private void OnEnable()
        {
            BreakoutGameManager.Instance.OnScoreChanged.AddListener(UpdateScore);
            BreakoutGameManager.Instance.OnLivesChanged.AddListener(UpdateLives);
            BreakoutGameManager.Instance.OnGameOver.AddListener(ShowEndScreen);
            restartBtn.onClick.AddListener(RestartGame);
        }

        private void OnDisable()
        {
            BreakoutGameManager.Instance.OnScoreChanged.RemoveListener(UpdateScore);
            BreakoutGameManager.Instance.OnLivesChanged.RemoveListener(UpdateLives);
            BreakoutGameManager.Instance.OnGameOver.RemoveListener(ShowEndScreen);
            restartBtn.onClick.RemoveListener(RestartGame);
        }
 
        public void Initialize()
        {
            UpdateScore();
            UpdateLives();
        }
        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
 

        public void UpdateScore()
        {
            scoreText.text = "Score: " + BreakoutGameManager.score;
        }

        public void UpdateLives()
        {
            livesText.text = "Lives: " + BreakoutGameManager.lives;
        }

        public void ShowEndScreen(bool victory = false)
        {
            endScreen.SetActive(true);
            endScreenText.text = victory ? "Victory!\nFinal Score: " + BreakoutGameManager.score : "Game Over\nFinal Score: " + BreakoutGameManager.score;
        }

    }
}
