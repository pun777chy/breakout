using Breakout.Managers;

namespace Breakout.Commands
{
    // Command to start the game.
    public class StartGameCommand : ICommand
    {
        // Executes the command to start the game.
        public void Execute()
        {
            // Calls the StartGame method on the BreakoutGameManager instance.
            BreakoutGameManager.Instance.StartGame();
        }
    }

    // Command to update the score.
    public class UpdateScoreCommand : ICommand
    {
        private int points; // Points to add to the score.

        // Constructor to initialize the command with the points to be added.
        public UpdateScoreCommand(int points)
        {
            this.points = points;
        }

        // Executes the command to update the score.
        public void Execute()
        {
            // Calls the UpdateScore method on the BreakoutGameManager instance with the points.
            BreakoutGameManager.Instance.UpdateScore(points);
        }
    }

    // Command to handle losing a life.
    public class LoseLifeCommand : ICommand
    {
        // Executes the command to handle losing a life.
        public void Execute()
        {
            // Calls the LoseLife method on the BreakoutGameManager instance.
            BreakoutGameManager.Instance.LoseLife();
        }
    }

    // Command to end the game.
    public class EndGameCommand : ICommand
    {
        // Executes the command to end the game.
        public void Execute()
        {
            // Calls the EndGame method on the BreakoutGameManager instance.
            BreakoutGameManager.Instance.EndGame();
        }
    }

    // Command to set level values in the game.
    public class SetLevelValuesCommand : ICommand
    {
        private int lives;          // Number of lives for the level.
        private int scoreToWin;     // Score required to win the level.
        private int level;          // The index of the current level.

        // Constructor to initialize the command with level values.
        public SetLevelValuesCommand(int lives, int scoreToWin, int level)
        {
            this.lives = lives;
            this.scoreToWin = scoreToWin;
            this.level = level;
        }

        // Executes the command to set the level values.
        public void Execute()
        {
            // Calls the SetLevelValues method on the BreakoutGameManager instance with the provided values.
            BreakoutGameManager.Instance.SetLevelValues(lives, scoreToWin, level);
        }
    }
}
