using UnityEngine;

namespace Pong
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Vector2 InitialImpulse;
        [SerializeField] private Rigidbody2D Rigidbody2D;

        private void Start() =>
            Rigidbody2D.AddForce(InitialImpulse, ForceMode2D.Impulse);
    }
}