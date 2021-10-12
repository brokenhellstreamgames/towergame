using UnityEngine;


public class MonoBehaviourSingleton<T> : MonoBehaviour where T : Component
{
    protected static T _instance;

    public static T Instance
    {
        get
        {
            _instance = FindObjectOfType<T>();
            if (_instance == null)
            {
                GameObject singleton = new GameObject(typeof(T).Name);
                _instance = singleton.AddComponent<T>();
            }

            DontDestroyOnLoad(_instance.gameObject);
            return _instance;
        }
    }
}