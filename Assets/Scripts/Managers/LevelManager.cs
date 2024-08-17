using UnityEngine;
using Breakout.Levels;
using Breakout.Commands;
namespace Breakout.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelsScriptableObject levelsScriptableObject;
        [SerializeField] private Transform levelBricksContainerTransform;

        internal static int currentLevel { get; private set; } = 0;

        private void Start()
        {
            InitializeLevel(currentLevel);
        }

        private void InitializeLevel(int levelIndex)
        {
            if (levelIndex < 0 || levelIndex >= levelsScriptableObject.levels.Length)
            {
                Debug.LogError("Level index out of bounds.");
                return;
            }

            var level = levelsScriptableObject.levels[levelIndex];

            BreakoutGameManager.Instance.QueueCommand(new SetLevelValuesCommand(level.lives, level.scoreToWin, levelIndex));
            Instantiate(level.levelBrickContainer, levelBricksContainerTransform);
        }

        public void LoadNextLevel()
        {
            currentLevel++;
            if (currentLevel < levelsScriptableObject.levels.Length)
            {
                InitializeLevel(currentLevel);
            }
            else
            {
                Debug.Log("No more levels to load.");
            }
        }
    }
}
