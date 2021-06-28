using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject resumeUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple GameOverManager on the scene");
            return;
        }
        instance = this;
        gameOverUI.SetActive(false);
    }


    public void OnPlayerDeath()
    {
        if (CurrentSceneManager.instance.isPlayerHereByDefault) // 
        {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        }

        gameOverUI.SetActive(true);
    }

    public void OnRetry()
    {
        // Recommencer niveau
        // Recharger la scene
        // Replacer le niveau
        // Remettre la vie
        gameOverUI.SetActive(false);
        // resumeUI.SetActive(false);
        Inventory.instance.AddCoins(-CurrentSceneManager.instance.nbCoinsCollected);
        PlayerHealth.instance.Respawn();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseMenu.instance.Resume();
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void onMainMenu()
    {

    }
}
