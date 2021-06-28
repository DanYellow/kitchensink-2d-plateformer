
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int nbCoins = 0;

    public Text nbCoinsText;
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple Inventory on the scene");
            return;
        }
        instance = this;
    }

    public void AddCoins(int count)
    {
        nbCoins += count;
        UpdateTextUI();
    }

    public void UpdateTextUI() {
        nbCoinsText.text = nbCoins.ToString();
    }
}
