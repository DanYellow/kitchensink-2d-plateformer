using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public Text interactUI;
    private bool isInRange;

    public Item item;
    public AudioClip soundToPlay;
    private Vector3 camPos = Camera.main.transform.position;
    public GameObject player;

    private Vector3 velocity;

    private void Start()
    {
        interactUI.enabled = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            TakeItem();
        }

        //interactUI.transform.position = new Vector3(camPos.x + 0.5f, interactUI.transform.position.y, 0);

        interactUI.transform.position = Vector3.SmoothDamp(interactUI.transform.position, player.transform.position + new Vector3(0, 1.0f, 0), ref velocity, 0.2f);
    }

    void TakeItem()
    {
        Inventory.instance.content.Add(item);
        Inventory.instance.GetNextItem();
        // Inventory.instance.UpdateInventoryUI();
        AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
        interactUI.enabled = false;
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
