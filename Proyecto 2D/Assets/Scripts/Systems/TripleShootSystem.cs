using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TripleShootSystem : ShootingSystem
{
    private int Shots = 3;

    Quaternion rotation;

    public override void Shoot()
    {
        GameObject[] shot = new GameObject[Shots];

        if (shot != null)
        {
            for (int i = 0; i < Shots; i++)
            {
                switch (i)
                {
                    case 0:
                         rotation = Quaternion.Euler(shotPoint.rotation.x, shotPoint.rotation.y, shotPoint.rotation.z + 25);
                        break;
                    case 1:  
                        rotation = Quaternion.Euler(shotPoint.rotation.x, shotPoint.rotation.y, shotPoint.rotation.z);
                        break;
                    case 2:
                        rotation = Quaternion.Euler(shotPoint.rotation.x, shotPoint.rotation.y, shotPoint.rotation.z - 25);
                        break;

                }
                shot[i] = PoolingManager.Instance.GetPooledObject("Bullets");
                shot[i].transform.position = shotPoint.position;
                shot[i].transform.rotation = rotation;
                shot[i].SetActive(true);
                shot[i].GetComponent<Rigidbody2D>().AddForce(shot[i].transform.right * shootingdata.fireForce);
                PlaySound();
            }
        }

    }
    public void PlaySound()
    {
        GetComponent<AudioSource>().clip = Sound;
        GetComponent<AudioSource>().Play();
    }
}
