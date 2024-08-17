using UnityEngine;

namespace Breakout.Game
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField] private float paddleSpeed = 10f;

        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float horizontalInput = Input.GetAxis(GameConstants.HorizontalAxis);
            Vector2 newPosition = rb.position + Vector2.right * horizontalInput * paddleSpeed * Time.deltaTime;

            newPosition.x = Mathf.Clamp(newPosition.x, 0, Screen.width);
            rb.MovePosition(newPosition);
           
        }
    }
}
