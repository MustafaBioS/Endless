using UnityEngine;
using System.Collections.Generic;

public class ObstaclePool : MonoBehaviour
{

    public static int obstaclePoolSize = 10;

    public GameObject obstaclePrefab;
    public GameObject playerAnim;
    [SerializeField] GameObject fadeOut;
    [SerializeField] Transform playerTransform;

    private List<GameObject> obstacles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obstacles = new List<GameObject>();

        for (int i = 0; i < obstaclePoolSize; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefab);

            obstacle.GetComponent<Obstacle>().SetPlayerAnim(playerAnim);
            obstacle.GetComponent<Obstacle>().SetFadeOut(fadeOut);
            obstacle.GetComponent<Obstacle>().setPlayerTransform(playerTransform);

            obstacle.SetActive(false);
            obstacles.Add(obstacle);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetObstacle(Vector3 position)
    {
        foreach (GameObject obstacle in obstacles)
        {
            if (!obstacle.activeInHierarchy)
            {
                obstacle.transform.position = position;
                obstacle.SetActive(true);
                return obstacle;
            }
        }

        return null;
    }
}
