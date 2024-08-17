using UnityEngine;
using Breakout.Game;

namespace Breakout
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Brick BrickPrefab;
        [SerializeField] private RectTransform BrickContainer;
    }
}