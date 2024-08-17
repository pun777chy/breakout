using UnityEngine;
using Breakout.Managers;

namespace Breakout.Game
{
    // This class represents a brick in the Breakout game. Bricks have point values, hit points, and can be destroyed when hit by the ball.
    public class Brick : MonoBehaviour
    {
        // The number of points the player earns when this brick is destroyed.
        public int pointValue = 10;

        // The number of hits the brick can take before being destroyed.
        public int hitPoints = 1;

        // A property that checks if the brick is still active (i.e., has more than 0 hit points).
        public bool isActive => hitPoints > 0;

        // This method is triggered when the brick collides with another object (like the ball).
        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Check if the object that hit the brick is the ball.
            if (collision.gameObject.CompareTag(GameConstants.Ball))
            {
                // If it is, call the OnHit method to process the hit.
                OnHit();
            }
        }

        // This method is called when the brick is hit by the ball.
        public virtual void OnHit()
        {
            // Reduce the brick's hit points by 1.
            hitPoints--;

            // If the brick has no more hit points, destroy it.
            if (hitPoints <= 0)
            {
                // Notify the BreakoutGameManager that this brick was destroyed.
                BreakoutGameManager.Instance.OnBrickDestroyed(this);

                // Play the brick breaking sound.
                AudioManager.Instance.OnBrickBreaking?.Invoke();

                // Deactivate the brick (make it disappear).
                Deactivate();
            }
        }

        // Deactivates the brick by setting its GameObject to inactive.
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        // Resets the brick to its initial state with full hit points and makes it active again.
        public void Reset()
        {
            hitPoints = 1;
            gameObject.SetActive(true);
        }
    }
}
