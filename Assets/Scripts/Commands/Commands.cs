using Breakout.Managers;
namespace Breakout.Commands
{
    public class StartGameCommand : ICommand
    {
        public void Execute()
        {
            BreakoutGameManager.Instance.StartGame();
        }
    }

    public class UpdateScoreCommand : ICommand
    {
        private int points;

        public UpdateScoreCommand(int points)
        {
            this.points = points;
        }

        public void Execute()
        {
            BreakoutGameManager.Instance.UpdateScore(points);
        }
    }

    public class LoseLifeCommand : ICommand
    {
        public void Execute()
        {
            BreakoutGameManager.Instance.LoseLife();
        }
    }

    public class EndGameCommand : ICommand
    {
        public void Execute()
        {
            BreakoutGameManager.Instance.EndGame();
        }
    }
    public class SetLevelValuesCommand : ICommand
    {
        private int lives;
        private int scoreToWin;

        public SetLevelValuesCommand(int lives, int scoreToWin)
        {
            this.lives = lives;
            this.scoreToWin = scoreToWin;
        }

        public void Execute()
        {
            BreakoutGameManager.Instance.SetLevelValues(lives, scoreToWin);
        }
    }
}
