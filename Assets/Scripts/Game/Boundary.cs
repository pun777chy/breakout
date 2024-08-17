using UnityEngine;

namespace Breakout
{
    public class Boundary : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D BoxCollider2D;

        private void Start() =>
            BoxCollider2D.size = (transform as RectTransform).rect.size;
    }
}
