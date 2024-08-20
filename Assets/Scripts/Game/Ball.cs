using UnityEngine;
using Breakout.Managers;
using System;

namespace Breakout.Game
{
    public class Ball : MonoBehaviour
    {
        // Serialized fields allow for configuration in the Unity editor
        [SerializeField] private Vector2 initialImpulse; // Initial force applied to the ball when launched
        [SerializeField] private Rigidbody2D ballRigidbody; // Reference to the Rigidbody2D component on the ball
        [SerializeField] private Transform paddleTransform; // Reference to the paddle's transform, used to position the ball initially
        [SerializeField] private Transform gameAreaTransform; // Reference to the game area, used to detach the ball from the paddle
        [SerializeField] private Vector3 ballRestingPosition; // The position where the ball rests on the paddle
        [SerializeField] private float referenceWidth = 1920f; // Reference screen width for calculating consistent force across different resolutions

        private bool isAtRest = true; // Indicates whether the ball is at rest on the paddle

        // Called when the object is enabled. Adds a listener to the event for resetting the ball.
        private void OnEnable()
        {
            BreakoutGameManager.Instance.OnResetLostBall.AddListener(ResetBall);
            InitializeBall(); // Initializes the ball's position and state
        }

        // Resets the ball to its resting state on the paddle
        private void ResetBall()
        {
            SetBallToRest();
        }

        // Called once per frame. Checks for player input to launch the ball.
        public virtual void Update()
        {
            if (isAtRest && Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBall(); // Launches the ball when the spacebar is pressed
            }
        }

        // Initializes the ball's Rigidbody2D and sets it to rest on the paddle
        private void InitializeBall()
        {
            // Ensures the Rigidbody2D component is assigned, either from the inspector or by getting it from the GameObject
            ballRigidbody = ballRigidbody ?? GetComponent<Rigidbody2D>();
            SetBallToRest(); // Puts the ball in its resting position on the paddle
        }

        // Sets the ball to rest on the paddle, making it ready to be launched
        private void SetBallToRest()
        {
            transform.SetParent(paddleTransform); // Attaches the ball to the paddle
            transform.localPosition = ballRestingPosition; // Moves the ball to the designated resting position
            ballRigidbody.velocity = Vector3.zero; // Stops any movement by setting velocity to zero
            ballRigidbody.bodyType = RigidbodyType2D.Kinematic; // Makes the ball kinematic (not affected by physics)
            isAtRest = true; // Sets the state to indicate the ball is at rest
            // Invokes an event indicating the ball is now at rest
            BreakoutGameManager.Instance.OnBallResleased.Invoke(isAtRest);
        }

        // Launches the ball into play by applying an initial impulse force
        private void LaunchBall()
        {
            isAtRest = false; // Sets the state to indicate the ball is no longer at rest
            transform.SetParent(gameAreaTransform); // Detaches the ball from the paddle
            ballRigidbody.bodyType = RigidbodyType2D.Dynamic; // Makes the ball dynamic (affected by physics)
            // Applies an impulse force to launch the ball, adjusted for screen resolution
            ballRigidbody.AddForce(initialImpulse * (Screen.width / referenceWidth), ForceMode2D.Impulse);
            // Invokes an event indicating the ball has been released
            BreakoutGameManager.Instance.OnBallResleased.Invoke(isAtRest);
            // Triggers sound effect for ball launch, if subscribed
            AudioManager.Instance.OnBallColliding?.Invoke();
        }

        // Called when the object is disabled. Removes the listener for resetting the ball.
        private void OnDisable()
        {
            BreakoutGameManager.Instance.OnResetLostBall.RemoveListener(ResetBall);
        }
    }
}
