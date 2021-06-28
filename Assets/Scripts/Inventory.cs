
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
    public int currentContentIdx = 0;
    public Image currentContentImg;
    public Text currentContentTxt;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple Inventory on the scene");
            return;
        }
        instance = this;
        UpdateCurrentItem();
    }

    public void ConsumeItem()
    {
        Item currentItem = content[currentContentIdx];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        PlayerMvt.instance.moveSpeed += currentItem.speedGiven;
        content.Remove(currentItem);
        GetNextItem();
    }

    public void GetNextItem()
    {
        currentContentIdx++;
        currentContentIdx = (currentContentIdx + 1) % content.Count;
        UpdateCurrentItem();
    }

    public void GetPreviousItem()
    {
        currentContentIdx--;
        if (currentContentIdx < 0)
        {
            currentContentIdx = content.Count - 1;
        }
        UpdateCurrentItem();
    }

    public void UpdateCurrentItem()
    {
        currentContentImg.sprite = content[currentContentIdx].image;
        currentContentTxt.text = content[currentContentIdx].name;
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
