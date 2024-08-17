using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Breakout.Game
{
    public abstract class BrickDecorator : Brick
    {
        protected Brick decoratedBrick;

        public BrickDecorator(Brick brick)
        {
            decoratedBrick = brick;
        }

        public override void OnHit()
        {
            decoratedBrick.OnHit();
            ApplyDecoration();
        }

        protected abstract void ApplyDecoration();
    }

    public class ExplodingBrick : BrickDecorator
    {
        public ExplodingBrick(Brick brick) : base(brick) { }

        protected override void ApplyDecoration()
        {
            // Example: Add explosion effect
            Debug.Log("Explosion Effect Applied!");
            // Additional explosion behavior here
        }
    }
}
