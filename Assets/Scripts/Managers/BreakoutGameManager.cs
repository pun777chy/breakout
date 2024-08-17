using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Breakout.Commands;
using Breakout.Game;
using Breakout.Utilities;

namespace Breakout.Managers
{
    public class BreakoutGameManager : GenericSingleton<BreakoutGameManager>
    {
        public UnityEvent OnScoreChanged = new UnityEvent();
        public UnityEvent OnLivesChanged = new UnityEvent();
        public UnityEvent OnLevelChanged = new UnityEvent();
        public UnityEvent<bool> OnGameOver = new UnityEvent<bool>();
        public UnityEvent OnBallResleased = new UnityEvent();

        internal static int score { get; private set; }
        internal static int lives { get; private set; } = 3;
        internal static int level { get; private set; }
        internal static bool won { get; private set; } = false;
        internal static int scoreToWin { get; private set; } = 150;
       

        private Queue<ICommand> commandQueue = new Queue<ICommand>();

        private void Start()
        {
            StartGame();
        }

        private void Update()
        {
            if (commandQueue.Count > 0)
            {
                var command = commandQueue.Dequeue();
                command.Execute();
            }
        }

        public void QueueCommand(ICommand command)
        {
            commandQueue.Enqueue(command);
        }

        public void SetLevelValues(int levelLives, int levelScoreToWin, int currentLevel)
        {
            lives = levelLives;
            scoreToWin = levelScoreToWin;
            level = currentLevel;
        }
        public void StartGame()
        {
            OnScoreChanged.Invoke();
            OnLivesChanged.Invoke();
            OnLevelChanged.Invoke();
            Debug.Log("Game Started");
        }

        public void UpdateScore(int points)
        {
            score += points;
            OnScoreChanged.Invoke();
            Debug.Log("Score Updated: " + score);
            if(score>=scoreToWin)
            {
                won = true;
                EndGame();
            }
        }

        public void LoseLife()
        {
            lives--;
            OnLivesChanged.Invoke();

            if (lives <= 0)
            {
                won = false;
                QueueCommand(new EndGameCommand());
                return;
            }
        }

        public void EndGame()
        {
            OnGameOver.Invoke(won);
            Debug.Log("Game Over");
        }

        public void OnBrickDestroyed(Brick brick)
        {
            QueueCommand(new UpdateScoreCommand(brick.pointValue));
        }

        public void OnBallLost()
        {
            QueueCommand(new LoseLifeCommand());
        }
        private void OnDestroy()
        {
            // Unsubscribe all listeners to avoid memory leaks
            OnScoreChanged.RemoveAllListeners();
            OnLivesChanged.RemoveAllListeners();
            OnLevelChanged.RemoveAllListeners();
            OnGameOver.RemoveAllListeners();
            OnBallResleased.RemoveAllListeners();
        }
    }
}
