using UnityEngine;

using System.Collections;

public class PlayerEffects : MonoBehaviour
{
    public static PlayerEffects instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple PlayerEffects on the scene");
            return;
        }
        instance = this;
    }
    public void AddSpeed(int speedGiven, float speedDuration)
    {
        PlayerMvt.instance.moveSpeed += speedGiven;

        StartCoroutine(RemoveSpeed(speedGiven, speedDuration));
    }

    private IEnumerator RemoveSpeed(int speedGiven, float speedDuration)
    {
        yield return new WaitForSeconds(speedDuration);
        PlayerMvt.instance.moveSpeed -= speedGiven;
    }
}
