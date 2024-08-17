using UnityEngine;

namespace Breakout.Audio
{
    // This class represents a scriptable object that holds various audio clips used in the game.
    [CreateAssetMenu(fileName = "AudioData", menuName = "ScriptableObjects/AudioScriptableObject", order = 1)]
    public class AudioScriptableObject : ScriptableObject
    {
        // AudioClip for the button click sound.
        public AudioClip btnClickSound;

        // AudioClip for the sound when the ball collides with something.
        public AudioClip ballCollidingSound;

        // AudioClip for the sound when a brick breaks.
        public AudioClip brickBreakingSound;

        // AudioClip for the sound when the ball drops below the paddle.
        public AudioClip ballDropingSound;

        // AudioClip for the sound when the player fails a level.
        public AudioClip levelFailedSound;

        // AudioClip for the sound when the player successfully completes a level.
        public AudioClip levelSuccessSound;
    }
}
