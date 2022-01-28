using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBehaviour : MonoBehaviour
{

    [SerializeField]
    public float jumpspeed = 10;
    private GroundDetector _groundDetector;
    private Rigidbody2D _rb;


    internal bool GetGround()
    {
        return _groundDetector.isGrounded;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (GetGround())
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpspeed);
            }
        }
    }
}
