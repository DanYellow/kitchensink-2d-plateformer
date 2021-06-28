using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isGameInPause = false;
    public GameObject pauseUi;
    public static PauseMenu instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple PauseMenu on the scene");
            return;
        }
        instance = this;

        pauseUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGameInPause)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        // Afficher menu pause
        // Arrêter le temps
        pauseUi.SetActive(true);
        isGameInPause = true;
        PlayerMvt.instance.enabled = false;
        // Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseUi.SetActive(false);
        PlayerMvt.instance.enabled = true;
        isGameInPause = false;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        PlayerHealth.instance.TakeDamage(1000000);
        GameOverManager.instance.OnRetry();
    }
}
