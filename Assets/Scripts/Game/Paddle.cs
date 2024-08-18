using UnityEngine;
using Breakout.Managers;

namespace Breakout.Game
{
    // This class handles the paddle's movement and collision detection.
    public class Paddle : MonoBehaviour
    {
        // Speed at which the paddle moves.
        [SerializeField] private float paddleSpeed = 10f;

        // Reference to the Rigidbody2D component attached to the paddle.
        private Rigidbody2D rb;

        // Initialize the Rigidbody2D reference when the game starts.
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Called every frame to handle player input and move the paddle.
        private void FixedUpdate()
        {
            // Get horizontal input (left/right arrow keys or A/D keys).
            float horizontalInput = Input.GetAxis(GameConstants.HorizontalAxis);

            // Calculate the new position based on input, speed, and time.
            Vector2 newPosition = rb.position + Vector2.right * horizontalInput * paddleSpeed * Time.deltaTime;

            // Clamp the paddle's x position to keep it within the screen bounds.
            newPosition.x = Mathf.Clamp(newPosition.x, 0, Screen.width);

            // Move the paddle to the new position.
            rb.MovePosition(newPosition);
        }

        // Called when the paddle collides with another object.
        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Check if the paddle collided with the ball.
            if (collision.gameObject.CompareTag(GameConstants.Ball))
            {
                // Play the ball collision sound.
                AudioManager.Instance.OnBallColliding?.Invoke();
            }
        }
    }
}
