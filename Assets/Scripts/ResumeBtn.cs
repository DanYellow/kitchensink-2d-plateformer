using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeBtn : MonoBehaviour
{
    public static ResumeBtn instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple ResumeBtn on the scene");
            return;
        }
        instance = this;
    }

    void onAnimationEndEvent()
    {
        Time.timeScale = 0;
    }
}
