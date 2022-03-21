using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;

    private float FastForwardTime = 2;
    private float DashTime = 3;

    private bool IsDashing = false;

    void Start()
    {
        StartCoroutine(GenerateObstacle());
    }

    void Dashing()
    {
        IsDashing = true;
        DashTime = 2;
    }

    IEnumerator GenerateObstacle()
    {
        if (IsDashing == false)
        {
            yield return new WaitForSeconds(4f);
        }
        else if (IsDashing == true)
        {
            yield return new WaitForSeconds(4f / FastForwardTime);
            DashTime--;
            if (DashTime <= 0)
            {
                IsDashing = false;
            }
        }
        var randomMeteor = Random.Range(0, 4);

 //-------------------------------------------------------------------------------

        GameObject Obstacle1 = PoolingManager.Instance.GetPooledObject("Obstacle1");
        GameObject Obstacle2 = PoolingManager.Instance.GetPooledObject("Obstacle2");
        GameObject Obstacle4 = PoolingManager.Instance.GetPooledObject("Obstacle4");
        GameObject Obstacle3 = PoolingManager.Instance.GetPooledObject("Obstacle3");

        if (Obstacle1 != null && randomMeteor == 0)
        {
            Obstacle1.transform.position = positions[0].position;
            Obstacle1.SetActive(true);

            for (int i = 0; i < Obstacle1.transform.childCount; i++)
                Obstacle1.transform.GetChild(i).gameObject.SetActive(true);
        }
        else if (Obstacle4 != null && randomMeteor == 1)
        {
            Obstacle4.transform.position = positions[0].position;
            Obstacle4.SetActive(true);

            for (int i = 0; i < Obstacle4.transform.childCount; i++)
                Obstacle4.transform.GetChild(i).gameObject.SetActive(true);
        }
        else if (Obstacle2 != null && randomMeteor == 2)
        {
            Obstacle2.transform.position = positions[0].position;
            Obstacle2.SetActive(true);

            for (int i = 0; i < Obstacle2.transform.childCount; i++)
                Obstacle2.transform.GetChild(i).gameObject.SetActive(true);
        }
        else if (Obstacle3 != null && randomMeteor == 3)
        {
            Obstacle3.transform.position = positions[0].position;
            Obstacle3.SetActive(true);

            for (int i = 0; i < Obstacle3.transform.childCount; i++)
                Obstacle3.transform.GetChild(i).gameObject.SetActive(true);
        }

        StartCoroutine(GenerateObstacle());
    }

   
    void OnEnable()
    {
        DashingBehaviour.Dash += Dashing;   
    }
    void OnDisable()
    {
        DashingBehaviour.Dash -= Dashing;
    }
}
