using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementBehavior: MonoBehaviour
{
    private float _speed = 8;

    [SerializeField]
    private Vector3 _direction;

    private Rigidbody2D rb;

    private float FastForwardTime;
    private float DashSpeed = 2;

    private bool IsDashing = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Dashing()
    {
        IsDashing = true;
        FastForwardTime = 80;
    }

    public void Move()
    {
        if(IsDashing == true)
        {
            if(FastForwardTime >= 0)
            {
                rb.MovePosition(transform.position + _direction * (_speed * DashSpeed) * Time.fixedDeltaTime);
            }
            else
            {
                rb.MovePosition(transform.position + _direction * _speed * Time.fixedDeltaTime);
                IsDashing = false;
            }
            FastForwardTime--;
        }
        else
        {
            rb.MovePosition(transform.position + _direction * _speed *  Time.fixedDeltaTime);
        }
        
    }

    public void Move(Vector3 dir)
    {
        rb.MovePosition(transform.position + dir * _speed * Time.fixedDeltaTime);
    }

    public void MovePosition(float x, float y, float z)
    {
        transform.position += new Vector3(x, y, z);
    }

    public void Move(float x, float y)
    {
        Vector3 dir = new Vector3(x, y, 0);
        rb.MovePosition(transform.position + dir * _speed * Time.fixedDeltaTime);
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
