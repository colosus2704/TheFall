using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject Obstacle1;

    [SerializeField]
    private Transform[] positions;

    void Start()
    {
        StartCoroutine(GenerateFloor());
    }

    IEnumerator GenerateFloor()
    {     

        GameObject Floor = PoolingManager.Instance.GetPooledObject("Floor");

        if (Floor != null)
        {
            Floor.transform.position = positions[0].position;
            Floor.SetActive(true);
        }

        yield return new WaitForSeconds(0.2f);
        StartCoroutine(GenerateFloor());
    }
}
