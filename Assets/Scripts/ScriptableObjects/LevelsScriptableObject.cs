using UnityEngine;
namespace Breakout.Levels
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelManagerScriptableObject", order = 1)]
    public class LevelsScriptableObject : ScriptableObject
    {
        public Level[] levels;
    }
    [System.Serializable]
    public class Level
    {
        public GameObject levelBrickContainer;
        public  int lives;
        public int scoreToWin;
    }
}
