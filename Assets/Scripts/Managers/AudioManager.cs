using Breakout.Utilities;
using UnityEngine.Events;
using UnityEngine;

namespace Breakout.Managers
{
    // AudioManager handles the audio events in the game. It's a Singleton, so there's only one instance at any time.
    public class AudioManager : GenericSingleton<AudioManager>
    {
        // UnityEvents that represent various audio-related events in the game.
        // Other classes can subscribe to these events to trigger corresponding audio actions.
        public UnityEvent OnBallColliding = new UnityEvent();
        public UnityEvent OnBrickBreaking = new UnityEvent();
        public UnityEvent OnBallDroping = new UnityEvent();
        public UnityEvent OnLevelFailed = new UnityEvent();
        public UnityEvent OnLevelSuccess = new UnityEvent();
        public UnityEvent OnBtnClick = new UnityEvent();

        public override void Awake()
        {
            base.Awake();
        }
        // OnDisable is called when the object becomes disabled or inactive.
        // We remove all listeners from the events to prevent memory leaks or unwanted behavior.
        private void OnDisable()
        {
            OnBallColliding.RemoveAllListeners();
            OnBrickBreaking.RemoveAllListeners();
            OnBallDroping.RemoveAllListeners();
            OnLevelFailed.RemoveAllListeners();
            OnLevelSuccess.RemoveAllListeners();
            OnBtnClick.RemoveAllListeners();
        }

        // OnDestroy is called when the object is destroyed.
        // Similar to OnDisable, we remove all listeners to clean up and avoid potential issues.
        public override void OnDestroy()
        {
            
            OnBallColliding.RemoveAllListeners();
            OnBrickBreaking.RemoveAllListeners();
            OnBallDroping.RemoveAllListeners();
            OnLevelFailed.RemoveAllListeners();
            OnLevelSuccess.RemoveAllListeners();
            OnBtnClick.RemoveAllListeners();
            base.OnDestroy();
        }
    }
}
