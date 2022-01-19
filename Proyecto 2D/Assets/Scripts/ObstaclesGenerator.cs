using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;

    void Start()
    {
        StartCoroutine(GenerateObstacle());
    }

    IEnumerator GenerateObstacle()
    {

        var randomMeteor = Random.Range(0, 2);

        //-------------------------------------------------------------------------------

        GameObject Obstacle1 = PoolingManager.Instance.GetPooledObject("Obstacle1");
        //GameObject Platform = PoolingManager.Instance.GetPooledObject("Platforms");
        //GameObject Rock = PoolingManager.Instance.GetPooledObject("Rocks");
        GameObject Enemy = PoolingManager.Instance.GetPooledObject("Enemies");

        if (Obstacle1 != null && randomMeteor == 0)
        {
            Obstacle1.transform.position = positions[0].position;
            Obstacle1.SetActive(true);
        }
        else if (Enemy != null && randomMeteor == 1)
        {
            Enemy.transform.position = positions[0].position;
            Enemy.SetActive(true);
        }

        yield return new WaitForSeconds(4.5f);
        StartCoroutine(GenerateObstacle());
    }
    //Hacer un garbage collector en el cambio de escena y mirar cuanta RAM uso.
}
