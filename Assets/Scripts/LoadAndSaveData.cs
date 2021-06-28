
using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple LoadAndSaveData on the scene");
            return;
        }
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    public void Load()
    {
        Inventory.instance.nbCoins = PlayerPrefs.GetInt("coins", 0);
        Inventory.instance.UpdateTextUI();
        
        int currentHealth = PlayerPrefs.GetInt("health", 100);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("coins", Inventory.instance.nbCoins);
        PlayerPrefs.SetInt("health", PlayerHealth.instance.currentHealth);
    }
}
