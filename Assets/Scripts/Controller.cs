using UnityEngine;

using System.Linq;
using System.Collections.Generic;

namespace Breakout
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private Brick BrickPrefab;
        [SerializeField] private RectTransform BrickContainer;
    }
}