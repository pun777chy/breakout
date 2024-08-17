using UnityEngine;
using Breakout.Managers;

namespace Breakout
{
    // This class handles the logic for when the ball falls out of the play area.
    public class BottomBoundary : MonoBehaviour
    {
        // This method is triggered when another object enters the boundary's trigger collider.
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Check if the object that entered the boundary is tagged as a "Ball".
            if (collision.gameObject.CompareTag(GameConstants.Ball))
            {
                // If it is the ball, notify the game manager that the ball has been lost.
                BreakoutGameManager.Instance.OnBallLost();

                // Play the sound associated with the ball dropping out of bounds.
                AudioManager.Instance.OnBallDroping?.Invoke();
            }
        }
    }
}
