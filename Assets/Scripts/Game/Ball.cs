using UnityEngine;
using Breakout.Managers;
using System;

namespace Breakout.Game
{
    public class Ball : MonoBehaviour
    {

        [SerializeField] private Vector2 initialImpulse;
        [SerializeField] private Rigidbody2D ballRigidbody;
        [SerializeField] private Transform paddleTransform;
        [SerializeField] private Transform gameAreaTransform;
        [SerializeField] private Vector3 ballRestingPosition;

        private bool isAtRest = true;

        private void OnEnable()
        {
            BreakoutGameManager.Instance.OnResetLostBall.AddListener(ResetBall);
            InitializeBall();
        }

        private void ResetBall()
        {
            SetBallToRest();
        }

        public virtual void Update()
        {
            if (isAtRest && Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBall();
            }
        }

        private void InitializeBall()
        {
            ballRigidbody = ballRigidbody ?? GetComponent<Rigidbody2D>();
            SetBallToRest();
        }

        private void SetBallToRest()
        {
            transform.SetParent(paddleTransform);
            transform.localPosition = ballRestingPosition;
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.bodyType = RigidbodyType2D.Kinematic;
            isAtRest = true;
            BreakoutGameManager.Instance.OnBallResleased.Invoke(isAtRest);
        }

        private void LaunchBall()
        {
            isAtRest = false;
            transform.SetParent(gameAreaTransform);
            ballRigidbody.bodyType = RigidbodyType2D.Dynamic;
            ballRigidbody.AddForce(initialImpulse, ForceMode2D.Impulse);
            BreakoutGameManager.Instance.OnBallResleased.Invoke(isAtRest);
            AudioManager.Instance.OnBallColliding?.Invoke();
        }
        private void OnDisable()
        {
            BreakoutGameManager.Instance.OnResetLostBall.RemoveListener(ResetBall);
        }
    }
}