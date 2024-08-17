using UnityEngine;
using Breakout.Managers;
namespace Breakout
{
    public class BottonBoundary : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(GameConstants.Ball))
            {
                BreakoutGameManager.Instance.OnBallLost();
            }
        }
    }
}
