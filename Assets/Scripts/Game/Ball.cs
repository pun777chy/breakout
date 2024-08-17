using UnityEngine;

namespace Breakout
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Vector2 InitialImpulse;
        [SerializeField] private Rigidbody2D Rigidbody2D;
        [SerializeField] private bool isBallAtRest = true;

        //private void Start() =>
        //    Rigidbody2D.AddForce(InitialImpulse, ForceMode2D.Impulse);

        private void Update()
        {
            if(isBallAtRest)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    isBallAtRest = false;
                    Rigidbody2D.AddForce(InitialImpulse, ForceMode2D.Impulse);
                }
            }
        }
    }
}