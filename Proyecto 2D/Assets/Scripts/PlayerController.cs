using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform[] shotPoints;
    private ShootingSystem launcher;

    private void Awake()
    {
        InputSystemKeyboard sk;

        if (TryGetComponent<InputSystemKeyboard>(out sk))
        {
            sk.OnFire += Shoot;
        }
    }
    
    private void Start()
    {
        launcher = GetComponent<ShootingSystem>();
    }

    public Transform GetShotPoint(int position)
    {
        return shotPoints[position];
    }
    
    public void SetLauncher(ShootingSystem launcherSet)
    {
        launcher = launcherSet;
    }

    void Shoot()
    {
        launcher.Shoot();
    }
}