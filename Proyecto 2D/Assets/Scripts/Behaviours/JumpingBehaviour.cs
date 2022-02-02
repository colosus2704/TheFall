using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBehaviour : MonoBehaviour
{
    public AudioClip Sound;

    [SerializeField]
    public float jumpspeed = 10;
    private GroundDetector _groundDetector;
    private Rigidbody2D _rb;
    private FSM.Controller _controller;


    internal bool GetGround()
    {
        return _groundDetector.isGrounded;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _rb = GetComponent<Rigidbody2D>();
        _controller = GetComponent<FSM.Controller>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_controller.GetInputW())
        {
            if (GetGround())
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpspeed);
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
