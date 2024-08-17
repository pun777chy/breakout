using UnityEngine;
using UnityEngine.UI;
using Breakout.Managers;
using UnityEngine.SceneManagement;
using System;

namespace Breakout.UI
{
    public class BreakoutUI : MonoBehaviour
    {
        [SerializeField] private Text instructionText;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text livesText;
        [SerializeField] private Text levelText;
        [SerializeField] private GameObject endScreen;
        [SerializeField] private Text endScreenText;
        [SerializeField] private Button restartBtn;

      

        private void OnEnable()
        {
            BreakoutGameManager.Instance.OnScoreChanged.AddListener(UpdateScore);
            BreakoutGameManager.Instance.OnLivesChanged.AddListener(UpdateLives);
            BreakoutGameManager.Instance.OnLevelChanged.AddListener(UpdateLevel);
            BreakoutGameManager.Instance.OnGameOver.AddListener(ShowEndScreen);
            BreakoutGameManager.Instance.OnBallResleased.AddListener(OnBallReleased);
            restartBtn.onClick.AddListener(RestartGame);
        }

        private void OnDisable()
        {
            BreakoutGameManager.Instance.OnScoreChanged.RemoveListener(UpdateScore);
            BreakoutGameManager.Instance.OnLivesChanged.RemoveListener(UpdateLives);
            BreakoutGameManager.Instance.OnLevelChanged.RemoveListener(UpdateLevel);
            BreakoutGameManager.Instance.OnGameOver.RemoveListener(ShowEndScreen);
            BreakoutGameManager.Instance.OnBallResleased.RemoveListener(OnBallReleased);
            restartBtn.onClick.RemoveListener(RestartGame);
        }

        private void OnBallReleased()
        {
            instructionText.gameObject.SetActive(false);
        }

        public void Initialize()
        {
            UpdateScore();
            UpdateLives();
        }
        public void RestartGame() => SceneManager.LoadScene(0);
     
 

        public void UpdateScore()
        {
            scoreText.text = "Score: " + BreakoutGameManager.score;
        }

        public void UpdateLives()
        {
            livesText.text = "Lives: " + BreakoutGameManager.lives;
        }
        public void UpdateLevel()
        {
            levelText.text = "Level: " + (BreakoutGameManager.level+1);
        }
        public void ShowEndScreen(bool victory = false)
        {
            endScreen.SetActive(true);
            endScreenText.text = victory ? "Victory!\nFinal Score: " + BreakoutGameManager.score : "Game Over\nFinal Score: " + BreakoutGameManager.score;
        }

    }
}
