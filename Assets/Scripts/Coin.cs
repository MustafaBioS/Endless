using UnityEngine;
using System.Collections.Generic;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] public AudioSource coinSound;

    void Collect()
    {
        gameObject.SetActive(false);
        coinSound.Play();
        Debug.Log("Coin collected");
        Player.score += 1;
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
}
