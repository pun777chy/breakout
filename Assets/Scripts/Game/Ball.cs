using UnityEngine;
using Breakout.Managers;
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
            InitializeBall();
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
            ballRigidbody.bodyType = RigidbodyType2D.Kinematic;
            isAtRest = true;
        }

        private void LaunchBall()
        {
            isAtRest = false;
            transform.SetParent(gameAreaTransform);
            ballRigidbody.bodyType = RigidbodyType2D.Dynamic;
            ballRigidbody.AddForce(initialImpulse, ForceMode2D.Impulse);
            BreakoutGameManager.Instance.OnBallResleased.Invoke();
        }
    }
}