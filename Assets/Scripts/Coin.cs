using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] public AudioSource coinSound;

    void Collect()
    {
        Debug.Log(coinSound.clip);
        Debug.Log(coinSound.isActiveAndEnabled);
        StartCoroutine(SoundPlay());
        Player.score += 1;
        Debug.Log("Coin collected");
        // gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
 
    IEnumerator SoundPlay()
    {
        coinSound.Play();
        yield return new WaitForSeconds(coinSound.clip.length);
        gameObject.SetActive(false);
    }
}