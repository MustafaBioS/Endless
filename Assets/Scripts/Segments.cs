using UnityEngine;
using System.Collections;

public class Segments : MonoBehaviour
{
    public GameObject[] segments;
    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;
    public Coin coinPool;

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
        GameObject newSegment = Instantiate(segments[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        int coinCount = Random.Range(3, 8); // 3 to 7 coins

        for (int i = 0; i < coinCount; i++)
        {
            float randomX = Random.Range(-2f, 2f);
            float randomZ = Random.Range(0f, 45f);

            Vector3 spawnPos = newSegment.transform.position + new Vector3(randomX, 1.25f, randomZ);

            coinPool.GetCoin(spawnPos);
        }
        yield return new WaitForSeconds(3f);
        creatingSegment = false;
    }
}
