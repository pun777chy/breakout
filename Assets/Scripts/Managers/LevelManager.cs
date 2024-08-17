using UnityEngine;
using Breakout.Levels;
using Breakout.Commands;

namespace Breakout.Managers
{
    public class LevelManager : MonoBehaviour
    {
        // Reference to the LevelsScriptableObject which holds all the levels data.
        [SerializeField] private LevelsScriptableObject levelsScriptableObject;

        // Transform that will contain the bricks of the current level.
        [SerializeField] private Transform levelBricksContainerTransform;

        // Static property to keep track of the current level index.
        internal static int currentLevel { get; private set; } = 0;

        // Called when the script instance is being loaded.
        private void Start()
        {
            // Initialize the level with the current level index.
            InitializeLevel(currentLevel);
        }

        // Initializes the level based on the provided level index.
        private void InitializeLevel(int levelIndex)
        {
            // Check if the level index is within bounds.
            if (levelIndex < 0 || levelIndex >= levelsScriptableObject.levels.Length)
            {
                Debug.LogError("Level index out of bounds.");
                return;
            }

            // Retrieve the level data from the scriptable object.
            var level = levelsScriptableObject.levels[levelIndex];

            // Queue commands to set up the level in the game manager.
            BreakoutGameManager.Instance.QueueCommand(new SetLevelValuesCommand(level.lives, level.scoreToWin, levelIndex));
            BreakoutGameManager.Instance.QueueCommand(new StartGameCommand());

            // Instantiate the brick container for the current level.
            Instantiate(level.levelBrickContainer, levelBricksContainerTransform);
        }

        // Loads the next level by incrementing the current level index.
        public void LoadNextLevel()
        {
            currentLevel++;

            // Check if there are more levels to load.
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
