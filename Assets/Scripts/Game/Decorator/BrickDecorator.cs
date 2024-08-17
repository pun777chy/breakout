using UnityEngine;

namespace Breakout.Game
{
    // Abstract class representing a decorator for a Brick.
    // This class extends the Brick class and allows for additional behavior through decoration.
    public abstract class BrickDecorator : Brick
    {
        protected Brick decoratedBrick; // The Brick instance being decorated.

        // Constructor to initialize the BrickDecorator with a Brick.
        public BrickDecorator(Brick brick)
        {
            decoratedBrick = brick; // Assign the provided Brick to the decoratedBrick field.
        }

        // Override the OnHit method to include decoration behavior.
        public override void OnHit()
        {
            decoratedBrick.OnHit(); // Call the OnHit method of the decorated Brick.
            ApplyDecoration(); // Apply additional decoration behavior.
        }

        // Abstract method to be implemented by concrete decorators to apply specific decoration behavior.
        protected abstract void ApplyDecoration();
    }

    // Concrete decorator that adds an explosion effect to the Brick.
    public class ExplodingBrick : BrickDecorator
    {
        // Constructor that initializes the ExplodingBrick with a Brick.
        public ExplodingBrick(Brick brick) : base(brick) { }

        // Implement the ApplyDecoration method to add explosion behavior.
        protected override void ApplyDecoration()
        {
            // Example: Add explosion effect
            Debug.Log("Explosion Effect Applied!"); // Log an explosion effect message.
            // Additional explosion behavior here, such as particle effects or sound.
        }
    }
}
