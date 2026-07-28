using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Segments : MonoBehaviour
{
    public GameObject[] segments;
    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;

    public CoinPool coinPool;
    public ObstaclePool obstaclePool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (creatingSegment == false)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, segments.Length);

        GameObject newSegment = Instantiate(
            segments[segmentNum],
            new Vector3(0, 0, zPos),
            Quaternion.identity
        );

        zPos += 50;

        float[] lanes = { -3.5f, 0f, 3.5f };

        List<Vector3> coinPositions = new List<Vector3>();

        float z1 = Random.Range(2f, 6f);
        float z2 = Random.Range(2f, 6f);

        int coinCount = Random.Range(3, CoinPool.coinPoolSize + 1);

        for (int i = 0; i < coinCount; i++)
        {
            float x = lanes[Random.Range(0, lanes.Length)];

            Vector3 spawnPos = newSegment.transform.position +
                            new Vector3(x, 1.25f, z1);

            coinPositions.Add(spawnPos);
            coinPool.GetCoin(spawnPos);

            z1 += Random.Range(4f, 7f);
        }

        int obstacleCount = Random.Range(3, ObstaclePool.obstaclePoolSize + 1);

        for (int i = 0; i < obstacleCount; i++)
        {
            float x = lanes[Random.Range(0, lanes.Length)];

            Vector3 spawnPos = newSegment.transform.position +
                            new Vector3(x, 2f, z2);

            bool closeToCoin = false;

            foreach (Vector3 coinPos in coinPositions)
            {
                bool sameLane = 
                    Mathf.Abs(spawnPos.x - coinPos.x) < 0.1f;
            
                bool close = 
                    Mathf.Abs(spawnPos.z - coinPos.z) < 4f;

                if (sameLane && close)
                {
                    closeToCoin = true;
                    break;
                }
            }

            if (!closeToCoin)
            {
                obstaclePool.GetObstacle(spawnPos);
            }

            z2 += Random.Range(4f, 7f);
        }

        yield return new WaitForSeconds(3f);

        creatingSegment = false;
    }
}
