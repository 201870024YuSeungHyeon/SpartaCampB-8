using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string key = "bestScore";

    private void Awake()
    {
        if(null == Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
