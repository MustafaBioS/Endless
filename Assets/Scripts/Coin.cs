using UnityEngine;
using System.Collections.Generic;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    
    public GameObject coinPrefab;
    public int poolSize = 25;

    private List<GameObject> coins;

    void Collect()
    {
        gameObject.SetActive(false);
        Debug.Log("Coin collected");       
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
        coins = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.SetActive(false);
            coins.Add(coin);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    public GameObject GetCoin(Vector3 position)
    {
        Debug.Log("GETCOIN CALLED");
        foreach (GameObject coin in coins)
        {
            if (!coin.activeInHierarchy)
            {
                coin.transform.position = position;
                coin.SetActive(true);
                return coin;
            }
        }

        return null;
    }
}
