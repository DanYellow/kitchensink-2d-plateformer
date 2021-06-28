using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;
    public static DontDestroyOnLoadScene instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple DontDestroyOnLoadScene on the scene");
            return;
        }
        instance = this;

        foreach (var elmnt in objects)
        {
            DontDestroyOnLoad(elmnt);
        }
    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var elmnt in objects)
        {
            SceneManager.MoveGameObjectToScene(elmnt, SceneManager.GetActiveScene());
        }
    }
}
