using UnityEngine;

namespace Breakout.Levels
{
    // This class represents a scriptable object that holds data related to levels in the game.
    [CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelManagerScriptableObject", order = 1)]
    public class LevelsScriptableObject : ScriptableObject
    {
        // Array of Level objects that defines the different levels in the game.
        public Level[] levels;
    }

    // This class is used to define the properties of a single level in the game.
    [System.Serializable]
    public class Level
    {
        // Prefab or GameObject that contains the bricks for this level.
        public GameObject levelBrickContainer;

        // Number of lives the player has for this level.
        public int lives;

        // Score required to win the level.
        public int scoreToWin;
    }
}
