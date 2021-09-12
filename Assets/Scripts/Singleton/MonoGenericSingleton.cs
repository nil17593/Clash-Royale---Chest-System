using System.Collections;
using UnityEngine;


public class MonoGenericSingleton<T> : MonoBehaviour where T : MonoGenericSingleton<T>
{
    private static T instance;

    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
