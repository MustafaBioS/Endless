using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    private GameObject playerAnim;

    public void SetPlayerAnim(GameObject animObject)
    {
        playerAnim = animObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                Debug.Log("Disabling player movement");
                player.enabled = false;
            }

            if (playerAnim != null)
            {
                Debug.Log("Playing lose animation");
                playerAnim.GetComponent<Animator>().Play("Lose");
            }

            Debug.Log("Obstacle hit");
        }
    }
}