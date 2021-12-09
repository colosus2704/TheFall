using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject Obstacle1;

    [SerializeField]
    public GameObject Obstacle2;

    [SerializeField]
    public GameObject Obstacle3;

    [SerializeField]
    public GameObject Obstacle4;

    [SerializeField]
    private Transform[] positions;

    void Start()
    {
        StartCoroutine(GenerateObstacle());
    }

    IEnumerator GenerateObstacle()
    {
        var randomPoint = Random.Range(0, 3);

        var randomMeteor = Random.Range(0, 4);

        //-------------------------------------------------------------------------------

        GameObject Spike = PoolingManager.Instance.GetPooledObject("Spikes");
        GameObject Platform = PoolingManager.Instance.GetPooledObject("Platforms");
        GameObject Rock = PoolingManager.Instance.GetPooledObject("Rocks");
        GameObject Enemy = PoolingManager.Instance.GetPooledObject("Enemies");

        if (Spike != null && randomMeteor == 0)
        {
            Spike.transform.position = positions[2].position;
            Spike.SetActive(true);
        }
        else if (Platform != null && randomMeteor == 1)
        {
            Platform.transform.position = positions[1].position;
            Platform.SetActive(true);
        }
        else if (Rock != null && randomMeteor == 2)
        {
            Rock.transform.position = positions[2].position;
            Rock.SetActive(true);
        }
        else if (Enemy != null && randomMeteor == 3)
        {
            Enemy.transform.position = positions[randomPoint].position;
            Enemy.SetActive(true);
        }

        yield return new WaitForSeconds(1.0f);
        StartCoroutine(GenerateObstacle());
    }
}
