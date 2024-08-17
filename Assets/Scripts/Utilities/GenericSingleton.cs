using UnityEngine;

namespace Breakout.Utilities
{
    // Generic singleton class that ensures only one instance of a class exists.
    // Inherit from this class to create a singleton pattern.
    public class GenericSingleton<T> : MonoBehaviour where T : Component
    {
        // Holds the single instance of the singleton class.
        private static T instance;

        // Public property to access the singleton instance.
        public static T Instance
        {
            get
            {
                // If the instance is null, try to find it or create a new one.
                if (instance == null)
                {
                    // Search for an existing instance in the scene.
                    instance = FindObjectOfType<T>();

                    // If no instance is found, create a new GameObject and attach the component.
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name; // Name the GameObject after the type of the singleton.
                        instance = obj.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        // Called when the script instance is being loaded.
        public virtual void Awake()
        {
            // If there's no existing instance, set this as the instance and prevent destruction on scene load.
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(this.gameObject); // Preserve this GameObject across scene loads.
            }
            else
            {
                // If an instance already exists, destroy this duplicate GameObject.
                Destroy(gameObject);
            }
        }
        private void OnDestroy()
        {
            // Ensure that instance is cleaned up properly
            if (instance == this)
            {
                instance = null;
            }
        }
    }
}
