using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    private GameObject playerAnim;
    [SerializeField] GameObject fadeOut;
    [SerializeField] Transform playerTransform;

    public void setPlayerTransform(Transform transform)
    {
        playerTransform = transform;
    }

    public void SetPlayerAnim(GameObject animObject)
    {
        playerAnim = animObject;
    }

    public void SetFadeOut(GameObject fadeOutObject)
    {
        fadeOut = fadeOutObject;
    }

    void Update()
    {
        if (transform.position.z < playerTransform.position.z - 20f)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            player.enabled = false;
            playerAnim.GetComponent<Animator>().Play("Lose");
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {   
        yield return new WaitForSeconds(1f);
        fadeOut.SetActive(true);
        Player.coins = 0;
        Player.score = 0;
        Player.countDown = 3;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }
}