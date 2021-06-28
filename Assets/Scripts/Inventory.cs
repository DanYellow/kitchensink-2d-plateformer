
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class Inventory : MonoBehaviour
{
    public int nbCoins = 0;

    public Text nbCoinsText;
    public static Inventory instance;
    public List<Item> content = new List<Item>();
    private int currentContentIdx = 0;
    public Image currentContentImg;
    public Text currentContentTxt;
    public Sprite emptyImage;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple Inventory on the scene");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        UpdateInventoryUI();
    }

    public void ConsumeItem()
    {
        if (!hasItems())
        {
            return;
        }

        Item currentItem = content[currentContentIdx];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        PlayerEffects.instance.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {
        if (!hasItems())
        {
            return;
        }

        currentContentIdx++;
        if (currentContentIdx > content.Count - 1)
        {
            currentContentIdx = 0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if (!hasItems())
        {
            return;
        }

        currentContentIdx--;
        if (currentContentIdx < 0)
        {
            currentContentIdx = content.Count - 1;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if (hasItems())
        {
            currentContentImg.sprite = content[currentContentIdx].image;
            currentContentTxt.text = content[currentContentIdx].name;
        }
        else
        {
            currentContentImg.sprite = emptyImage;
            currentContentTxt.text = "No items";
        }
    }

    private bool hasItems()
    {
        return content.Count > 0;
    }

    public void AddCoins(int count)
    {
        nbCoins += count;
        UpdateTextUI();
    }

    public void UpdateTextUI()
    {
        nbCoinsText.text = nbCoins.ToString();
    }
}
