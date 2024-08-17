using UnityEngine;
using UnityEngine.UI;
using Breakout.Managers;
using UnityEngine.SceneManagement;

namespace Breakout.UI
{
    public class BreakoutUI : MonoBehaviour
    {
        // UI Elements
        [SerializeField] private Text instructionText; // Text element to show instructions to the player
        [SerializeField] private Text scoreText;        // Text element to display the current score
        [SerializeField] private Text livesText;        // Text element to display the number of lives remaining
        [SerializeField] private Text levelText;        // Text element to display the current level
        [SerializeField] private GameObject endScreen;  // UI element for the end screen (victory/defeat)
        [SerializeField] private Text endScreenText;    // Text element to show the result message on the end screen
        [SerializeField] private Button restartBtn;     // Button to restart the game

        private void OnEnable()
        {
            // Subscribe to events from the GameManager
            BreakoutGameManager.Instance.OnScoreChanged.AddListener(UpdateScore);
            BreakoutGameManager.Instance.OnLivesChanged.AddListener(UpdateLives);
            BreakoutGameManager.Instance.OnLevelChanged.AddListener(UpdateLevel);
            BreakoutGameManager.Instance.OnGameOver.AddListener(ShowEndScreen);
            BreakoutGameManager.Instance.OnBallResleased.AddListener(OnBallReleased);

            // Subscribe to the restart button click event
            restartBtn.onClick.AddListener(RestartGame);
        }

        private void OnDisable()
        {
            // Unsubscribe from events to avoid memory leaks
            BreakoutGameManager.Instance.OnScoreChanged.RemoveListener(UpdateScore);
            BreakoutGameManager.Instance.OnLivesChanged.RemoveListener(UpdateLives);
            BreakoutGameManager.Instance.OnLevelChanged.RemoveListener(UpdateLevel);
            BreakoutGameManager.Instance.OnGameOver.RemoveListener(ShowEndScreen);
            BreakoutGameManager.Instance.OnBallResleased.RemoveListener(OnBallReleased);

            // Unsubscribe from the restart button click event
            restartBtn.onClick.RemoveListener(RestartGame);
        }

        // Method to handle the ball release event and update UI
        private void OnBallReleased(bool isActive)
        {
            instructionText.gameObject.SetActive(isActive);
        }

        // Method to initialize or refresh the UI elements
        public void Initialize()
        {
            UpdateScore();
            UpdateLives();
            UpdateLevel();
        }

        // Method to restart the game by reloading the current scene
        public void RestartGame()
        {
            AudioManager.Instance.OnBtnClick?.Invoke(); // Play button click sound
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
        }

        // Method to update the score text
        public void UpdateScore()
        {
            scoreText.text = "Score: " + BreakoutGameManager.score;
        }

        // Method to update the lives text
        public void UpdateLives()
        {
            livesText.text = "Lives: " + BreakoutGameManager.lives;
        }

        // Method to update the level text
        public void UpdateLevel()
        {
            levelText.text = "Level: " + (BreakoutGameManager.level + 1);
        }

        // Method to display the end screen with appropriate message based on the game result
        public void ShowEndScreen(bool victory = false)
        {
            endScreen.SetActive(true); // Show the end screen
            endScreenText.text = victory
                ? "Victory!\nFinal Score: " + BreakoutGameManager.score
                : "Game Over\nFinal Score: " + BreakoutGameManager.score;
        }
    }
}
