using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerHereByDefault = false;
    public int nbCoinsCollected = 0;
    public static CurrentSceneManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple CurrentSceneManager on the scene");
            return;
        }
        instance = this;
    }
}
