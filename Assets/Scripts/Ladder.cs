using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private PlayerMvt playerMvt;
    public BoxCollider2D topCollider;

    public Text interactText;

    // Start is called before the first frame update
    void Awake()
    {
        playerMvt = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMvt>();
        interactText = GameObject.FindGameObjectWithTag("InteractText").GetComponent<Text>();
        interactText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && playerMvt.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            playerMvt.isClimbing = false;
            topCollider.isTrigger = false;

            return;
        }

        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMvt.isClimbing = true;
            topCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactText.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactText.enabled = false;
            playerMvt.isClimbing = false;
            topCollider.isTrigger = false;
        }
    }
}
