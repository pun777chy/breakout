using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Breakout.Commands;
using Breakout.Game;
using Breakout.Utilities;

namespace Breakout.Managers
{
    // The BreakoutGameManager class is a singleton that manages the game's state, events, and commands.
    public class BreakoutGameManager : GenericSingleton<BreakoutGameManager>
    {
        // UnityEvents to notify other parts of the game about state changes.
        public UnityEvent OnScoreChanged = new UnityEvent();
        public UnityEvent OnLivesChanged = new UnityEvent();
        public UnityEvent OnLevelChanged = new UnityEvent();
        public UnityEvent OnResetLostBall = new UnityEvent();
        public UnityEvent<bool> OnGameOver = new UnityEvent<bool>();
        public UnityEvent<bool> OnBallResleased = new UnityEvent<bool>();

        // Game state variables
        internal static int score { get; private set; } = 0;
        internal static int lives { get; private set; } = 3;
        internal static int level { get; private set; }
        internal static bool won { get; private set; } = false;
        internal static int scoreToWin { get; private set; } = 150;

        // Queue to hold commands that need to be executed
        private Queue<ICommand> commandQueue = new Queue<ICommand>();

        // Update is called once per frame to process the command queue.
        private void Update()
        {
            if (commandQueue.Count > 0)
            {
                var command = commandQueue.Dequeue();
                command.Execute();
            }
        }

        // Method to add a command to the queue.
        public void QueueCommand(ICommand command)
        {
            commandQueue.Enqueue(command);
        }

        // Method to set the level's initial values such as lives and score to win.
        public void SetLevelValues(int levelLives, int levelScoreToWin, int currentLevel)
        {
            lives = levelLives;
            scoreToWin = levelScoreToWin;
            level = currentLevel;
        }

        // Method to start the game, resetting score and invoking relevant events.
        public void StartGame()
        {
            score = 0;
            OnScoreChanged?.Invoke();
            OnLivesChanged?.Invoke();
            OnLevelChanged?.Invoke();
            Debug.Log("Game Started");
        }

        // Method to update the score and check if the player has won.
        public void UpdateScore(int points)
        {
            score += points;
            OnScoreChanged?.Invoke();
            Debug.Log("Score Updated: " + score);
            if (score >= scoreToWin)
            {
                won = true;
                EndGame();
            }
        }

        // Method to handle the player losing a life, and possibly ending the game.
        public void LoseLife()
        {
            lives--;
            OnLivesChanged?.Invoke();

            if (lives <= 0)
            {
                won = false;
                AudioManager.Instance.OnLevelFailed?.Invoke();
                QueueCommand(new EndGameCommand());
                return;
            }

            // Reset the ball after losing a life
            OnResetLostBall?.Invoke();
        }

        // Method to handle the end of the game, invoking the game over event.
        public void EndGame()
        {
            OnGameOver?.Invoke(won);
            AudioManager.Instance.OnLevelSuccess?.Invoke();
            Debug.Log("Game Over");
        }

        // Method to handle when a brick is destroyed, updating the score.
        public void OnBrickDestroyed(Brick brick)
        {
            QueueCommand(new UpdateScoreCommand(brick.pointValue));
        }

        // Method to handle when the ball is lost, queuing a command to lose a life.
        public void OnBallLost()
        {
            QueueCommand(new LoseLifeCommand());
        }


        private void OnDisable()
        {
            OnScoreChanged.RemoveAllListeners();
            OnLivesChanged.RemoveAllListeners();
            OnLevelChanged.RemoveAllListeners();
            OnResetLostBall.RemoveAllListeners();
            OnGameOver.RemoveAllListeners();
            OnBallResleased.RemoveAllListeners();
        }
        // OnDestroy is called when the object is destroyed, removing all event listeners to avoid memory leaks.
        public override void OnDestroy()
        {
            OnScoreChanged.RemoveAllListeners();
            OnLivesChanged.RemoveAllListeners();
            OnLevelChanged.RemoveAllListeners();
            OnResetLostBall.RemoveAllListeners();
            OnGameOver.RemoveAllListeners();
            OnBallResleased.RemoveAllListeners();
            base.OnDestroy();
        }
    }
}
