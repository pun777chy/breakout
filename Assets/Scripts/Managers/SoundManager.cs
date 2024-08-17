using Breakout.Managers;
using UnityEngine;

namespace Breakout.Audio
{
    public class SoundManager : MonoBehaviour
    {
        // Serialized fields for the audio source and the scriptable object containing audio clips
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioScriptableObject levelsScriptableObject;

        // Called when the script instance is being loaded
        private void Awake()
        {
            // Ensure the audioSource is assigned, either from the inspector or by getting the attached AudioSource component
            audioSource = audioSource ?? GetComponent<AudioSource>();
        }

        // Called when the object becomes enabled and active
        private void OnEnable()
        {
            // Registering event listeners for various game events to trigger corresponding sound effects
            AudioManager.Instance.OnBallColliding.AddListener(PlayOnBallCollide);
            AudioManager.Instance.OnBrickBreaking.AddListener(PlayOnBrickBreaking);
            AudioManager.Instance.OnBallDroping.AddListener(PlayOnBallDroping);
            AudioManager.Instance.OnLevelFailed.AddListener(PlayOnLevelFailed);
            AudioManager.Instance.OnLevelSuccess.AddListener(PlayOnLevelSuccess);
            AudioManager.Instance.OnBtnClick.AddListener(PlayOnBtnClick);
        }

        // Plays the sound for button click events
        private void PlayOnBtnClick()
        {
            audioSource.PlayOneShot(levelsScriptableObject.btnClickSound);
        }

        // Plays the sound for level success events
        private void PlayOnLevelSuccess()
        {
            audioSource.PlayOneShot(levelsScriptableObject.levelSuccessSound);
        }

        // Plays the sound for level failure events
        private void PlayOnLevelFailed()
        {
            audioSource.PlayOneShot(levelsScriptableObject.levelFailedSound);
        }

        // Plays the sound for ball dropping events
        private void PlayOnBallDroping()
        {
            audioSource.PlayOneShot(levelsScriptableObject.ballDropingSound);
        }

        // Plays the sound for brick breaking events
        private void PlayOnBrickBreaking()
        {
            audioSource.PlayOneShot(levelsScriptableObject.brickBreakingSound);
        }

        // Plays the sound for ball colliding events
        private void PlayOnBallCollide()
        {
            audioSource.PlayOneShot(levelsScriptableObject.ballCollidingSound);
        }

        // Called when the object becomes disabled or inactive
        private void OnDisable()
        {
            // Unregistering event listeners when the object is disabled to prevent memory leaks or unexpected behavior
            AudioManager.Instance.OnBallColliding.RemoveListener(PlayOnBallCollide);
            AudioManager.Instance.OnBrickBreaking.RemoveListener(PlayOnBrickBreaking);
            AudioManager.Instance.OnBallDroping.RemoveListener(PlayOnBallDroping);
            AudioManager.Instance.OnLevelFailed.RemoveListener(PlayOnLevelFailed);
            AudioManager.Instance.OnLevelSuccess.RemoveListener(PlayOnLevelSuccess);
            AudioManager.Instance.OnBtnClick.RemoveListener(PlayOnBtnClick);
        }
    }
}
