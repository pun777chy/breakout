using UnityEngine;
using Breakout.Managers;

namespace Breakout.Game
{
    public class Brick : MonoBehaviour
    {
        public int pointValue = 10;
        public int hitPoints = 1;
        public bool isActive => hitPoints > 0;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(GameConstants.Ball))
            {
                OnHit();
            }
        }

        public virtual void OnHit()
        {
            hitPoints--;

            if (hitPoints <= 0)
            {
                BreakoutGameManager.Instance.OnBrickDestroyed(this);
                Deactivate();
            }
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void Reset()
        {
            hitPoints = 1;
            gameObject.SetActive(true);
        }
    }
}
