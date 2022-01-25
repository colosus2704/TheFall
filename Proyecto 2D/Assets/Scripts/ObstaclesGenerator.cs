using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;

    private float FastForwardTime = 1;
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
            yield return new WaitForSeconds(2.5f);
        }
        else if (IsDashing == true)
        {
            yield return new WaitForSeconds(2.5f / FastForwardTime);
            DashTime--;
            if (DashTime <= 0)
            {
                IsDashing = false;
            }
        }
        var randomMeteor = Random.Range(0, 2);

        //-------------------------------------------------------------------------------

        GameObject Obstacle1 = PoolingManager.Instance.GetPooledObject("Obstacle1");
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
    //Hacer un garbage collector en el cambio de escena y mirar cuanta RAM uso.
}
