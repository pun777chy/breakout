using UnityEngine;
using Breakout.Managers;

namespace Breakout
{
    // This class represents the boundaries in the Breakout game, which handle collisions with the ball.
    public class Boundary : MonoBehaviour
    {
        // The BoxCollider2D component attached to the boundary object.
        [SerializeField] private BoxCollider2D boxCollider2D;

        // On start, the size of the BoxCollider2D is set to match the size of the RectTransform (useful for UI-based boundaries).
        private void Start() =>
            boxCollider2D.size = (transform as RectTransform).rect.size;

        // This method is called when another object collides with the boundary.
        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Check if the object that collided with the boundary is the ball.
            if (collision.gameObject.CompareTag(GameConstants.Ball))
            {
                // If it is, play the ball colliding sound through the AudioManager.
                AudioManager.Instance.OnBallColliding?.Invoke();
            }
        }
    }
}
