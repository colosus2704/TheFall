using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : ShootingSystem 
{
    public override void Shoot()
    {
        GameObject shot = PoolingManager.Instance.GetPooledObject("Bullets");

        shot.GetComponent<HealthSystem>().ResetHealth();
       
        if(shot != null)
        {
            shot.transform.position = shotPoint.position;
            shot.transform.rotation = shotPoint.rotation;
            shot.SetActive(true);
            shot.GetComponent<Rigidbody2D>().AddForce(transform.right * shootingdata.fireForce);
            PlaySound();
        }
    }
    public void PlaySound()
    {
        GetComponent<AudioSource>().clip = Sound;
        GetComponent<AudioSource>().Play();
    }
}