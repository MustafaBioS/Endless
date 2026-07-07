using UnityEngine;
using System.Collections.Generic;

public class CoinPool : MonoBehaviour
{

    public int poolSize = 25;

    public GameObject coinPrefab;
    private List<GameObject> coins;

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
